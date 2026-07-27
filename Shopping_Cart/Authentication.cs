using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace Shopping_Cart
{
    public partial class Authentication : Form
    {
        // SQL Server connection string
        private readonly string connectionString =
            "Server=DESKTOP-985956K\\SQLEXPRESS;Database=Shopping_Cart;User ID=sa;Password=130506;TrustServerCertificate=True;";

        public Authentication()
        {
            InitializeComponent();

            // Pre-fill default login credentials for testing
            txtEmail.Text = "admin123@gmail.com";
            txtPassword.Text = "123456";

            // Wire up the submit button to Login or Register based on current mode
            btnSubmit.Click += BtnSubmit_Click;
        }

        // ======================
        // Submit Button Handler
        // ======================
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (isRegisterMode)
                Register();
            else
                Login();
        }

        // ======================
        // LOGIN
        // ======================
        private void Login()
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter email and password.", "Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hardcoded admin login for development/testing
            if (email == "admin123@gmail.com" && password == "123456")
            {
                MessageBox.Show("Welcome, Admin!", "Login Successful",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                Dashboard dashboard = new Dashboard();
                dashboard.Show();
                this.Hide();
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT COUNT(*) FROM Users WHERE UserEmail = @UserEmail AND UserPassword = @UserPassword";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserEmail", email);
                        cmd.Parameters.AddWithValue("@UserPassword", password);

                        int count = (int)cmd.ExecuteScalar();

                        if (count > 0)
                        {
                            string userName = GetUserNameByEmail(email);

                            MessageBox.Show($"Welcome back, {userName}!", "Login Successful",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            OpenProductCatalog(userName);
                        }
                        else
                        {
                            MessageBox.Show("Invalid email or password.", "Login Failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ======================
        // REGISTER
        // ======================
        private void Register()
        {
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all fields.", "Register",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Check if email already exists
                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE UserEmail = @UserEmail";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@UserEmail", email);
                        int exists = (int)checkCmd.ExecuteScalar();

                        if (exists > 0)
                        {
                            MessageBox.Show("This email is already registered.", "Register",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Insert new user
                    string insertQuery = @"
                        INSERT INTO Users (UserName, UserPassword, UserEmail, CreatedAt)
                        VALUES (@UserName, @UserPassword, @UserEmail, GETDATE())";

                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@UserName", name);
                        insertCmd.Parameters.AddWithValue("@UserPassword", password);
                        insertCmd.Parameters.AddWithValue("@UserEmail", email);

                        int rows = insertCmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show($"Welcome to ShopMart, {name}!", "Registration Successful",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            OpenProductCatalog(name);
                        }
                        else
                        {
                            MessageBox.Show("Registration failed.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ======================
        // Helper: Switch back to Login view after successful registration
        // ======================
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

        // ======================
        // Helper: Open Product Catalog as a logged-in user
        // ======================
        private void OpenProductCatalog(string userName)
        {
            ProductCatalog catalog = new ProductCatalog();
            catalog.UserName = userName;
            catalog.Show();
            this.Hide();
        }

        // ======================
        // Helper: Get UserName from database by email
        // ======================
        private string GetUserNameByEmail(string email)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
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
    }
}
