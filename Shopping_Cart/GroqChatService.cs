using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Shopping_Cart
{
    public class ChatMessage
    {
        public string Role { get; set; }
        public string Content { get; set; }

        public ChatMessage(string role, string content)
        {
            Role = role;
            Content = content;
        }
    }

    public class ChatResponseResult
    {
        public string Answer { get; set; }
        public string ExecutedSql { get; set; }
        public bool HasSqlExecution { get; set; }
        public DataTable QueryData { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class GroqChatService
    {
        private readonly string _apiKey;
        private readonly string _apiUrl;
        private readonly string _connectionString;
        private readonly HttpClient _httpClient;
        private readonly List<ChatMessage> _conversationHistory;

        public string SelectedModel { get; set; } = "llama-3.3-70b-versatile";

        private const string SystemPrompt = @"You are the Admin AI Assistant for a Shopping Cart Store Management application.
Database Schema:
- Users (UserId INT PK, UserName NVARCHAR, UserEmail NVARCHAR, Password NVARCHAR, CreatedAt DATETIME)
- Products (ProductId INT PK, ProductName NVARCHAR, Category NVARCHAR, Price DECIMAL, Discount DECIMAL, SpecialOffer INT, Stock INT, Image1-4 NVARCHAR, CreatedAt DATETIME)
- Orders (OrderId INT PK, UserId INT FK, OrderDate DATETIME, TotalCost DECIMAL, OrderStatus NVARCHAR, UserPhone NVARCHAR, UserCity NVARCHAR, UserAddress NVARCHAR)
- OrderItems (OrderItemId INT PK, OrderId INT FK, ProductId INT FK, ProductName NVARCHAR, ProductPrice DECIMAL, Quantity INT, UserId INT, OrderDate DATETIME)
- Payments (PaymentId INT PK, OrderId INT FK, UserId INT FK, TransactionId NVARCHAR, PaymentDate DATETIME)
- ProductActivityLog (LogId INT PK, ActionType NVARCHAR, ProductName NVARCHAR, ActionDate DATETIME)

RULES:
1. If data from the database is needed, output ONLY ONE executable T-SQL query in ```sql ... ```.
2. Only write read-only SELECT queries (use TOP, COUNT, SUM, AVG, ISNULL, JOIN, GROUP BY, ORDER BY).
3. If no database query is required, respond directly with concise, helpful text. Format currency with $.";

        public GroqChatService(string connectionString, string apiKey = "", string apiUrl = "https://api.groq.com/openai/v1/chat/completions")
        {
            try
            {
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls;
            }
            catch { }

            _connectionString = connectionString;
            _apiKey = !string.IsNullOrWhiteSpace(apiKey)
                ? apiKey
                : (Environment.GetEnvironmentVariable("GROQ_API_KEY") ?? "YOUR_GROQ_API_KEY_HERE");
            _apiUrl = apiUrl;
            _httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(60) };
            _conversationHistory = new List<ChatMessage>();
            ResetConversation();
        }

        public void ResetConversation()
        {
            _conversationHistory.Clear();
            _conversationHistory.Add(new ChatMessage("system", SystemPrompt));
        }

        private void PruneHistory()
        {
            // Keep system prompt + last 4 messages to prevent token buildup and 429 rate limit
            if (_conversationHistory.Count > 5)
            {
                var systemMsg = _conversationHistory[0];
                var recent = _conversationHistory.Skip(_conversationHistory.Count - 4).ToList();
                _conversationHistory.Clear();
                _conversationHistory.Add(systemMsg);
                _conversationHistory.AddRange(recent);
            }
        }

        public async Task<ChatResponseResult> SendMessageAsync(string userMessage)
        {
            var result = new ChatResponseResult { IsSuccess = true };

            try
            {
                if (string.IsNullOrWhiteSpace(_apiKey) || _apiKey == "YOUR_GROQ_API_KEY_HERE")
                {
                    result.Answer = "⚠️ Groq API key is not configured. Please set the GROQ_API_KEY environment variable or pass your API key to GroqChatService.";
                    result.IsSuccess = false;
                    return result;
                }

                if (string.IsNullOrWhiteSpace(userMessage))
                {
                    result.Answer = "Please enter a question or command.";
                    return result;
                }

                PruneHistory();
                _conversationHistory.Add(new ChatMessage("user", userMessage));

                // Call Groq API first time
                string firstResponse = await CallGroqApiAsync(_conversationHistory);
                
                // Check if response contains a SQL query
                string sqlQuery = ExtractSqlQuery(firstResponse);

                if (!string.IsNullOrEmpty(sqlQuery))
                {
                    // Validate safety
                    if (!IsSafeSelectQuery(sqlQuery))
                    {
                        result.Answer = "⚠️ For safety reasons, only read-only SELECT queries are allowed.";
                        result.IsSuccess = false;
                        return result;
                    }

                    result.HasSqlExecution = true;
                    result.ExecutedSql = sqlQuery;

                    // Execute SQL Query safely
                    DataTable dt = null;
                    string dbError = null;

                    try
                    {
                        dt = ExecuteSafeQuery(sqlQuery);
                        result.QueryData = dt;
                    }
                    catch (Exception dbEx)
                    {
                        dbError = dbEx.Message;
                    }

                    string dataSummary = dbError != null
                        ? $"[DATABASE ERROR]: {dbError}"
                        : ConvertDataTableToTextSummary(dt);

                    // Add assistant's query generation step and tool result
                    _conversationHistory.Add(new ChatMessage("assistant", firstResponse));
                    _conversationHistory.Add(new ChatMessage("user", 
                        $"[DATA]:\n{dataSummary}\n\nSummarize the answer clearly and concisely for the admin."));

                    // Call Groq API second time for synthesis
                    string finalAnswer = await CallGroqApiAsync(_conversationHistory);
                    result.Answer = CleanResponse(finalAnswer);

                    // Keep conversation clean
                    _conversationHistory.Add(new ChatMessage("assistant", finalAnswer));
                }
                else
                {
                    result.Answer = CleanResponse(firstResponse);
                    _conversationHistory.Add(new ChatMessage("assistant", firstResponse));
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
                result.Answer = $"❌ Error communicating with AI: {ex.Message}";
            }

            return result;
        }

        private async Task<string> CallGroqApiAsync(List<ChatMessage> messages)
        {
            var requestBody = new
            {
                model = SelectedModel,
                messages = messages.Select(m => new { role = m.Role, content = m.Content }).ToArray(),
                temperature = 0.2,
                max_tokens = 1024
            };

            string jsonPayload = JsonSerializer.Serialize(requestBody);

            using (var request = new HttpRequestMessage(HttpMethod.Post, _apiUrl))
            {
                request.Headers.Add("Authorization", $"Bearer {_apiKey}");
                request.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                using (var response = await _httpClient.SendAsync(request))
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        // Auto-fallback on rate limit (429) to llama-3.1-8b-instant
                        if ((int)response.StatusCode == 429 && SelectedModel != "llama-3.1-8b-instant")
                        {
                            SelectedModel = "llama-3.1-8b-instant";
                            return await CallGroqApiAsync(messages);
                        }

                        // Try fallback model if model_not_found
                        if (responseBody.Contains("model_not_found") && SelectedModel != "llama-3.1-8b-instant")
                        {
                            SelectedModel = "llama-3.1-8b-instant";
                            return await CallGroqApiAsync(messages);
                        }

                        if ((int)response.StatusCode == 429)
                        {
                            throw new Exception("Groq free tier rate limit reached (Tokens/Minute). Please wait 10-15 seconds and try again.");
                        }

                        throw new Exception($"Groq API Error ({response.StatusCode}): {responseBody}");
                    }

                    using (var jsonDoc = JsonDocument.Parse(responseBody))
                    {
                        var root = jsonDoc.RootElement;
                        var choices = root.GetProperty("choices");
                        if (choices.GetArrayLength() > 0)
                        {
                            var firstChoice = choices[0];
                            var message = firstChoice.GetProperty("message");
                            return message.GetProperty("content").GetString() ?? "";
                        }
                    }

                    return "No response content received.";
                }
            }
        }

        private string ExtractSqlQuery(string response)
        {
            if (string.IsNullOrWhiteSpace(response)) return null;

            // Look for ```sql ... ```
            var match = Regex.Match(response, @"```sql\s*(SELECT[\s\S]*?)```", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                return match.Groups[1].Value.Trim();
            }

            // Look for generic ``` ... ``` containing SELECT
            match = Regex.Match(response, @"```\s*(SELECT[\s\S]*?)```", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                return match.Groups[1].Value.Trim();
            }

            // Check if response starts with SELECT
            string trimmed = response.Trim();
            if (trimmed.StartsWith("SELECT", StringComparison.OrdinalIgnoreCase))
            {
                return trimmed;
            }

            return null;
        }

        private bool IsSafeSelectQuery(string sql)
        {
            if (string.IsNullOrWhiteSpace(sql)) return false;

            string normalized = sql.Trim().ToUpperInvariant();
            if (!normalized.StartsWith("SELECT") && !normalized.StartsWith("WITH"))
                return false;

            string[] forbiddenWords = { "INSERT ", "UPDATE ", "DELETE ", "DROP ", "ALTER ", "TRUNCATE ", "EXEC ", "EXECUTE ", "INTO ", "CREATE ", "MERGE " };
            foreach (var forbidden in forbiddenWords)
            {
                if (normalized.Contains(forbidden))
                    return false;
            }

            return true;
        }

        private DataTable ExecuteSafeQuery(string query)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandTimeout = 30;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        private string ConvertDataTableToTextSummary(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                return "0 rows returned.";
            }

            var sb = new StringBuilder();
            sb.AppendLine($"Rows: {dt.Rows.Count}");
            
            var columnNames = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToList();
            sb.AppendLine(string.Join(" | ", columnNames));

            int rowLimit = Math.Min(dt.Rows.Count, 8);
            for (int i = 0; i < rowLimit; i++)
            {
                var row = dt.Rows[i];
                var values = columnNames.Select(col =>
                {
                    object val = row[col];
                    if (val == DBNull.Value || val == null) return "NULL";
                    if (val is DateTime dtVal) return dtVal.ToString("yyyy-MM-dd");
                    return val.ToString();
                });
                sb.AppendLine(string.Join(" | ", values));
            }

            if (dt.Rows.Count > rowLimit)
            {
                sb.AppendLine($"... ({dt.Rows.Count - rowLimit} more rows)");
            }

            return sb.ToString();
        }

        private string CleanResponse(string response)
        {
            if (string.IsNullOrEmpty(response)) return "";
            return response.Trim();
        }
    }
}
