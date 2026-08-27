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

        public string SelectedModel { get; set; } = "openai/gpt-oss-120b";

        private const string SystemPrompt = @"You are the intelligent Admin AI Assistant for the Shopping Cart E-Commerce Windows Forms Management System.
Your mission is to help the store administrator search data, calculate revenue and amounts, find customer details, analyze orders, and track product inventory.

Database Schema & Relationships:
1. Table 'Users':
   - UserId (INT, Primary Key)
   - UserName (NVARCHAR)
   - UserPassword (NVARCHAR)
   - UserEmail (NVARCHAR)
   - CreatedAt (DATETIME)

2. Table 'Products':
   - ProductId (INT, Primary Key)
   - ProductName (NVARCHAR)
   - Category (NVARCHAR)
   - Price (DECIMAL)
   - Discount (DECIMAL - discounted price)
   - SpecialOffer (INT - discount percentage 0-100)
   - Stock (INT - available inventory stock quantity)
   - Image1, Image2, Image3, Image4 (NVARCHAR)
   - CreatedAt (DATETIME)

3. Table 'Orders':
   - OrderId (INT, Primary Key)
   - TotalCost (DECIMAL)
   - OrderStatus (NVARCHAR - e.g. 'Paid', 'Pending', 'Cancelled')
   - UserId (INT, Foreign Key -> Users.UserId)
   - UserPhone (NVARCHAR)
   - UserCity (NVARCHAR)
   - UserAddress (NVARCHAR)
   - OrderDate (DATETIME)

4. Table 'OrderItems':
   - OrderItemId (INT, Primary Key)
   - OrderId (INT, Foreign Key -> Orders.OrderId)
   - ProductId (INT, Foreign Key -> Products.ProductId)
   - ProductName (NVARCHAR)
   - ProductImage (NVARCHAR)
   - ProductPrice (DECIMAL)
   - Quantity (INT)
   - UserId (INT, Foreign Key -> Users.UserId)
   - OrderDate (DATETIME)

5. Table 'Payments':
   - PaymentId (INT, Primary Key)
   - OrderId (INT, Foreign Key -> Orders.OrderId)
   - UserId (INT, Foreign Key -> Users.UserId)
   - TransactionId (NVARCHAR)
   - PaymentDate (DATETIME)

6. Table 'ProductActivityLog':
   - LogId (INT, Primary Key)
   - ActionType (NVARCHAR - 'Add', 'Update', 'Delete')
   - ProductName (NVARCHAR)
   - ActionDate (DATETIME)

CRITICAL INSTRUCTIONS FOR DATABASE QUERIES:
- If answering the admin's request requires querying, searching, filtering, calculating, or aggregating data from the database, you MUST write a T-SQL query enclosed strictly within a single ```sql ... ``` code block.
- ONLY output READ-ONLY SELECT statements. Never output INSERT, UPDATE, DELETE, DROP, ALTER, TRUNCATE, or EXEC.
- Use valid Microsoft SQL Server syntax (e.g. TOP N, ISNULL(), FORMAT(), COUNT(), SUM(), AVG(), GROUP BY, JOIN).
- Example: If asked 'Who is the highest spending customer?', write:
```sql
SELECT TOP 5 u.UserId, u.UserName, u.UserEmail, COUNT(o.OrderId) AS OrderCount, ISNULL(SUM(o.TotalCost), 0) AS TotalSpent
FROM Users u
LEFT JOIN Orders o ON u.UserId = o.UserId
GROUP BY u.UserId, u.UserName, u.UserEmail
ORDER BY TotalSpent DESC
```
- If the question is a general greeting, explanation, or does not require database data, respond directly in friendly, clear, professional English (or the user's language). Format numbers as currency ($) where appropriate.";

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
                        ? $"[DATABASE ERROR]: Failed to execute query on SQL Server: {dbError}"
                        : ConvertDataTableToTextSummary(dt);

                    // Add assistant's query generation step and tool result
                    _conversationHistory.Add(new ChatMessage("assistant", firstResponse));
                    _conversationHistory.Add(new ChatMessage("user", 
                        $"[DATABASE QUERY RESULT]:\n{dataSummary}\n\nPlease summarize the result clearly for the admin. If there was a database connection error, explain what query was attempted and how to resolve the connection."));

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
                max_tokens = 2048
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
                        // Try fallback model if model_not_found
                        if (responseBody.Contains("model_not_found") && SelectedModel != "qwen/qwen3.8-27b")
                        {
                            SelectedModel = "qwen/qwen3.8-27b";
                            return await CallGroqApiAsync(messages);
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
                return "Query executed successfully, but returned 0 rows.";
            }

            var sb = new StringBuilder();
            sb.AppendLine($"Total Rows Returned: {dt.Rows.Count}");
            
            // Header
            var columnNames = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToList();
            sb.AppendLine(string.Join(" | ", columnNames));
            sb.AppendLine(new string('-', 50));

            // Max 25 rows to prevent token overflow
            int rowLimit = Math.Min(dt.Rows.Count, 25);
            for (int i = 0; i < rowLimit; i++)
            {
                var row = dt.Rows[i];
                var values = columnNames.Select(col =>
                {
                    object val = row[col];
                    if (val == DBNull.Value || val == null) return "NULL";
                    if (val is DateTime dtVal) return dtVal.ToString("yyyy-MM-dd HH:mm");
                    return val.ToString();
                });
                sb.AppendLine(string.Join(" | ", values));
            }

            if (dt.Rows.Count > rowLimit)
            {
                sb.AppendLine($"... [truncated {dt.Rows.Count - rowLimit} additional rows]");
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
