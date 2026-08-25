using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Shopping_Cart
{
    public partial class Authentication : Form
    {
        private readonly string connectionString =
            "Server=DESKTOP-985956K\\SQLEXPRESS;Database=Shopping_Cart;User ID=sa;Password=130506;TrustServerCertificate=True;";

        public Authentication()
        {
            InitializeComponent();
            WireUpEvents();
        }

        private void WireUpEvents()
        {
            btnSubmit.Click += BtnSubmit_Click;

            btnSubmit.MouseEnter += (s, e) => btnSubmit.BackColor = Color.FromArgb(29, 78, 216);
            btnSubmit.MouseLeave += (s, e) => btnSubmit.BackColor = Color.FromArgb(37, 99, 235);
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (isRegisterMode)
                Register();
            else
                Login();
        }

        private void Login()
        {
            string email = GetEmail();
            string password = GetPassword();

            if (!ValidateLoginInputs(email, password))
                return;

            if (IsAdminLogin(email, password))
            {
                ShowAdminDashboard();
                return;
            }

            AuthenticateUser(email, password);
        }

        private bool ValidateLoginInputs(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                ShowWarning("Please enter email and password.", "Login");
                return false;
            }

            return true;
        }

        private bool IsAdminLogin(string email, string password)
        {
            return string.Equals(email?.Trim(), "admin123@gmail.com", StringComparison.OrdinalIgnoreCase) &&
                   (password == "admin123" || password == "123456");
        }

        private void ShowAdminDashboard()
        {
            ShowInfo("Welcome, Admin!", "Login Successful");
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void AuthenticateUser(string email, string password)
        {
            try
            {
                int count = GetUserCountByCredentials(email, password);

                if (count > 0)
                {
                    UserInfo user = GetUserInfoByCredentials(email, password);
                    ShowInfo($"Welcome back, {user.UserName}!", "Login Successful");
                    OpenProductCatalog(user);
                }
                else
                {
                    ShowError("Invalid email or password.", "Login Failed");
                }
            }
            catch (Exception ex)
            {
                ShowError($"Database error: {ex.Message}", "Error");
            }
        }

        private int GetUserCountByCredentials(string email, string password)
        {
            using (SqlConnection conn = OpenConnection())
            {
                string query = "SELECT COUNT(*) FROM Users WHERE UserEmail = @UserEmail AND UserPassword = @UserPassword";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserEmail", email);
                    cmd.Parameters.AddWithValue("@UserPassword", password);
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        private UserInfo GetUserInfoByCredentials(string email, string password)
        {
            using (SqlConnection conn = OpenConnection())
            {
                string query = "SELECT UserId, UserName, UserEmail FROM Users WHERE UserEmail = @UserEmail AND UserPassword = @UserPassword";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserEmail", email);
                    cmd.Parameters.AddWithValue("@UserPassword", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new UserInfo
                            {
                                UserId = Convert.ToInt32(reader["UserId"]),
                                UserName = reader["UserName"].ToString(),
                                UserEmail = reader["UserEmail"].ToString()
                            };
                        }
                    }
                }
            }

            return null;
        }

        private void Register()
        {
            string name = GetName();
            string email = GetEmail();
            string password = GetPassword();

            if (!ValidateRegisterInputs(name, email, password))
                return;

            if (EmailExists(email))
            {
                ShowWarning("This email is already registered.", "Register");
                return;
            }

            if (InsertUser(name, email, password))
            {
                UserInfo newUser = GetUserInfoByCredentials(email, password);
                ShowInfo($"Welcome to ShopMart, {name}!", "Registration Successful");
                OpenProductCatalog(newUser);
            }
            else
            {
                ShowError("Registration failed.", "Error");
            }
        }

        private bool ValidateRegisterInputs(string name, string email, string password)
        {
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                ShowWarning("Please fill in all fields.", "Register");
                return false;
            }

            if (!IsValidName(name))
            {
                ShowWarning("Name must contain only letters and spaces.", "Register");
                return false;
            }

            if (!IsValidEmail(email))
            {
                ShowWarning("Email must end with @gmail.com.", "Register");
                return false;
            }

            return true;
        }

        private bool IsValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            foreach (char c in name)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                    return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            return email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase);
        }

        private bool EmailExists(string email)
        {
            using (SqlConnection conn = OpenConnection())
            {
                string query = "SELECT COUNT(*) FROM Users WHERE UserEmail = @UserEmail";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserEmail", email);
                    int exists = (int)cmd.ExecuteScalar();
                    return exists > 0;
                }
            }
        }

        private bool InsertUser(string name, string email, string password)
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                {
                    string query = @"
                        INSERT INTO Users (UserName, UserPassword, UserEmail, CreatedAt)
                        VALUES (@UserName, @UserPassword, @UserEmail, GETDATE())";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserName", name);
                        cmd.Parameters.AddWithValue("@UserPassword", password);
                        cmd.Parameters.AddWithValue("@UserEmail", email);

                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError($"Database error: {ex.Message}", "Error");
                return false;
            }
        }

        private string GetName()
        {
            return txtName.Text.Trim();
        }

        private string GetEmail()
        {
            return txtEmail.Text.Trim();
        }

        private string GetPassword()
        {
            return txtPassword.Text;
        }

        private SqlConnection OpenConnection()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            return conn;
        }

        private string GetUserNameByEmail(string email)
        {
            try
            {
                using (SqlConnection conn = OpenConnection())
                {
                    string query = "SELECT UserName FROM Users WHERE UserEmail = @UserEmail";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserEmail", email);
                        object result = cmd.ExecuteScalar();
                        return result != null ? result.ToString() : email;
                    }
                }
            }
            catch
            {
                return email;
            }
        }

        private void OpenProductCatalog(UserInfo user)
        {
            if (user == null) return;

            ProductCatalog catalog = new ProductCatalog();
            catalog.UserName = user.UserName;
            catalog.UserId = user.UserId;
            catalog.UserEmail = user.UserEmail;
            catalog.IsAdmin = false;
            catalog.Show();
            this.Hide();
        }

        private void SwitchToLoginMode()
        {
            isRegisterMode = false;
            ApplyLayoutMode();
            txtName.Clear();
            txtPassword.Clear();
        }

        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var forgotForm = new ForgotPasswordForm(txtEmail.Text.Trim(), connectionString))
            {
                if (forgotForm.ShowDialog(this) == DialogResult.OK)
                {
                    txtEmail.Text = forgotForm.VerifiedEmail;
                    txtPassword.Text = forgotForm.NewPassword;
                    txtPassword.Focus();
                }
            }
        }

        private void ShowInfo(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public class UserInfo
        {
            public int UserId { get; set; }
            public string UserName { get; set; }
            public string UserEmail { get; set; }
        }

        private void ShowWarning(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ShowError(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Form logic for Email OTP verification and setting a new password.
    /// </summary>
    public partial class ForgotPasswordForm : Form
    {
        public string VerifiedEmail { get; private set; } = "";
        public string NewPassword { get; private set; } = "";

        private readonly string _connectionString;
        private string _activeEmail = "";
        private string _activeOtp = "";

        public ForgotPasswordForm(string initialEmail = "", string connectionString = "")
        {
            _connectionString = connectionString;
            InitializeComponent();
            WireUpEvents();

            if (!string.IsNullOrWhiteSpace(initialEmail))
            {
                txtEmailField.Text = initialEmail.Trim();
            }
        }

        private void WireUpEvents()
        {
            btnSendOtp.Click += BtnSendOtp_Click;
            btnVerifyOtp.Click += BtnVerifyOtp_Click;
            lnkResendOtp.LinkClicked += (s, e) => BtnSendOtp_Click(s, e);
            btnSetNewPassword.Click += BtnSetNewPassword_Click;
            btnClose.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            chkShowPassword.CheckedChanged += (s, e) =>
            {
                char ch = chkShowPassword.Checked ? '\0' : '•';
                txtNewPassField.PasswordChar = ch;
                txtConfirmPassField.PasswordChar = ch;
            };
        }

        private async void BtnSendOtp_Click(object sender, EventArgs e)
        {
            string email = txtEmailField.Text.Trim();
            if (string.IsNullOrWhiteSpace(email))
            {
                SetEmailStatus("Please enter your email address.", isError: true);
                txtEmailField.Focus();
                return;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                SetEmailStatus("Please enter a valid email format.", isError: true);
                txtEmailField.Focus();
                return;
            }

            btnSendOtp.Enabled = false;
            btnSendOtp.Text = "Sending...";
            SetEmailStatus("Sending OTP code to " + email + "...", isError: false);

            var (success, message) = await OtpApiClient.SendOtpAsync(email);

            btnSendOtp.Enabled = true;
            btnSendOtp.Text = "Resend OTP";

            if (success)
            {
                _activeEmail = email;
                SetEmailStatus("✓ OTP code sent! Please check your inbox.", isError: false);
                grpStep2.Enabled = true;
                txtOtpField.Focus();
            }
            else
            {
                SetEmailStatus("✗ " + message, isError: true);
            }
        }

        private async void BtnVerifyOtp_Click(object sender, EventArgs e)
        {
            string otp = txtOtpField.Text.Trim();
            if (string.IsNullOrWhiteSpace(otp))
            {
                SetOtpStatus("Please enter the OTP code.", isError: true);
                txtOtpField.Focus();
                return;
            }

            btnVerifyOtp.Enabled = false;
            btnVerifyOtp.Text = "Verifying...";
            SetOtpStatus("Verifying OTP...", isError: false);

            var (success, message) = await OtpApiClient.VerifyOtpAsync(_activeEmail, otp);

            btnVerifyOtp.Enabled = true;
            btnVerifyOtp.Text = "Verify OTP";

            if (success)
            {
                _activeOtp = otp;
                SetOtpStatus("✓ OTP verified successfully!", isError: false);
                txtOtpField.ReadOnly = true;
                btnVerifyOtp.Enabled = false;
                lnkResendOtp.Enabled = false;
                txtEmailField.ReadOnly = true;
                btnSendOtp.Enabled = false;
                grpStep3.Enabled = true;
                txtNewPassField.Focus();
            }
            else
            {
                SetOtpStatus("✗ " + message, isError: true);
            }
        }

        private async void BtnSetNewPassword_Click(object sender, EventArgs e)
        {
            string newPassword = txtNewPassField.Text;
            string confirmPassword = txtConfirmPassField.Text;

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("Please enter a new password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassField.Focus();
                return;
            }

            if (newPassword.Length < 4)
            {
                MessageBox.Show("Password must be at least 4 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassField.Focus();
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match. Please re-enter.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassField.Focus();
                return;
            }

            btnSetNewPassword.Enabled = false;
            btnSetNewPassword.Text = "Updating Password...";

            var (success, message) = await OtpApiClient.SetNewPasswordAsync(_activeEmail, newPassword, _activeOtp);

            // Also update in local SQL Express DB if configured
            UpdateLocalDatabasePassword(_activeEmail, newPassword);

            btnSetNewPassword.Enabled = true;
            btnSetNewPassword.Text = "Set New Password & Finish";

            if (success)
            {
                VerifiedEmail = _activeEmail;
                NewPassword = newPassword;
                MessageBox.Show("Your password has been reset successfully!\nYou can now login with your new credentials.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show($"Failed to reset password:\n{message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetEmailStatus(string msg, bool isError)
        {
            lblEmailMsg.ForeColor = isError ? Color.Crimson : Color.ForestGreen;
            lblEmailMsg.Text = msg;
        }

        private void SetOtpStatus(string msg, bool isError)
        {
            lblOtpMsg.ForeColor = isError ? Color.Crimson : Color.ForestGreen;
            lblOtpMsg.Text = msg;
        }

        private bool UpdateLocalDatabasePassword(string email, string newPassword)
        {
            if (string.IsNullOrWhiteSpace(_connectionString)) return false;
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Users SET UserPassword = @UserPassword WHERE UserEmail = @UserEmail";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserPassword", newPassword);
                        cmd.Parameters.AddWithValue("@UserEmail", email);
                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }

    /// <summary>
    /// API Client for sending OTP, verifying OTP, and setting new password.
    /// </summary>
    public static class OtpApiClient
    {
        private static readonly HttpClient httpClient;

        static OtpApiClient()
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };
            httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://localhost:7017/"),
                Timeout = TimeSpan.FromSeconds(15)
            };
        }

        public static async Task<(bool Success, string Message)> SendOtpAsync(string email)
        {
            try
            {
                var payload = new Dictionary<string, string>
                {
                    { "email", email }
                };
                string json = JsonSerializer.Serialize(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                string url = $"api/OTP/send-otp?email={Uri.EscapeDataString(email)}";
                var response = await httpClient.PostAsync(url, content);
                string responseText = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    string msg = ExtractMessage(responseText);
                    return (true, string.IsNullOrWhiteSpace(msg) ? "OTP sent successfully to your email." : msg);
                }
                else
                {
                    string errMsg = ExtractMessage(responseText);
                    return (false, string.IsNullOrWhiteSpace(errMsg) ? $"Failed to send OTP (Status: {response.StatusCode})." : errMsg);
                }
            }
            catch (Exception ex)
            {
                return (false, $"API connection failed: {ex.Message}");
            }
        }

        public static async Task<(bool Success, string Message)> VerifyOtpAsync(string email, string otp)
        {
            try
            {
                var payload = new Dictionary<string, string>
                {
                    { "email", email },
                    { "otp", otp },
                    { "otpCode", otp },
                    { "code", otp }
                };
                string json = JsonSerializer.Serialize(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                string url = $"api/OTP/verify-otp?email={Uri.EscapeDataString(email)}&otp={Uri.EscapeDataString(otp)}&code={Uri.EscapeDataString(otp)}";
                var response = await httpClient.PostAsync(url, content);
                string responseText = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    string msg = ExtractMessage(responseText);
                    return (true, string.IsNullOrWhiteSpace(msg) ? "OTP verified successfully." : msg);
                }
                else
                {
                    string errMsg = ExtractMessage(responseText);
                    return (false, string.IsNullOrWhiteSpace(errMsg) ? $"OTP verification failed (Status: {response.StatusCode})." : errMsg);
                }
            }
            catch (Exception ex)
            {
                return (false, $"API connection failed: {ex.Message}");
            }
        }

        public static async Task<(bool Success, string Message)> SetNewPasswordAsync(string email, string newPassword, string otp)
        {
            try
            {
                var payload = new Dictionary<string, string>
                {
                    { "email", email },
                    { "newPassword", newPassword },
                    { "password", newPassword },
                    { "otp", otp },
                    { "code", otp }
                };
                string json = JsonSerializer.Serialize(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                string url = $"api/OTP/set-new-password?email={Uri.EscapeDataString(email)}&newPassword={Uri.EscapeDataString(newPassword)}&password={Uri.EscapeDataString(newPassword)}&otp={Uri.EscapeDataString(otp)}";
                var response = await httpClient.PostAsync(url, content);
                string responseText = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    string msg = ExtractMessage(responseText);
                    return (true, string.IsNullOrWhiteSpace(msg) ? "Password updated successfully." : msg);
                }
                else
                {
                    string errMsg = ExtractMessage(responseText);
                    return (false, string.IsNullOrWhiteSpace(errMsg) ? $"Failed to set new password (Status: {response.StatusCode})." : errMsg);
                }
            }
            catch (Exception ex)
            {
                return (false, $"API connection failed: {ex.Message}");
            }
        }

        private static string ExtractMessage(string responseText)
        {
            if (string.IsNullOrWhiteSpace(responseText)) return string.Empty;
            try
            {
                using (var doc = JsonDocument.Parse(responseText))
                {
                    if (doc.RootElement.ValueKind == JsonValueKind.Object)
                    {
                        if (doc.RootElement.TryGetProperty("message", out var msg)) return msg.GetString();
                        if (doc.RootElement.TryGetProperty("Message", out var msg2)) return msg2.GetString();
                        if (doc.RootElement.TryGetProperty("title", out var title)) return title.GetString();
                        if (doc.RootElement.TryGetProperty("error", out var err)) return err.GetString();
                    }
                    else if (doc.RootElement.ValueKind == JsonValueKind.String)
                    {
                        return doc.RootElement.GetString();
                    }
                }
            }
            catch
            {
                if (responseText.Length < 200) return responseText;
            }
            return responseText;
        }
    }
}
