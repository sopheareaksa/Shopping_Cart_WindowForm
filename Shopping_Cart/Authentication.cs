using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace Shopping_Cart
{
    public partial class Authentication : Form
    {
        private readonly string connectionString =
            "Server=DESKTOP-985956K\\SQLEXPRESS;Database=Shopping_Cart;User ID=sa;Password=130506;TrustServerCertificate=True;";

        public Authentication()
        {
            InitializeComponent();
            PrefillDefaultCredentials();
            WireUpEvents();
        }

        private void PrefillDefaultCredentials()
        {
            txtEmail.Text = "admin123@gmail.com";
            txtPassword.Text = "123456";
        }

        private void WireUpEvents()
        {
            btnSubmit.Click += BtnSubmit_Click;
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
            return email == "admin123@gmail.com" && password == "123456";
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
            catalog.Show();
            this.Hide();
        }

        private void SwitchToLoginMode()
        {
            isRegisterMode = false;
            lblTitle.Text = "Login To Your Account";
            btnSubmit.Text = "Login";
            lnkToggleMode.Text = "Don't have an account? Register";
            lblName.Visible = false;
            txtName.Visible = false;
            txtName.Clear();
            txtPassword.Clear();
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
}
