using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace Shopping_Cart
{
    public partial class Dashboard : Form
    {
        // flag to indicate whether the grid is showing orders
        private bool isOrdersView = false;
        // flag to indicate whether the grid is showing customers
        private bool isCustomersView = false;

        // order details panel and controls (created on demand)
        private Panel orderDetailsPanel;
        private DataGridView dataGridViewOrderItems;
        private Label lblOrderMeta;
        private Button btnCloseOrderDetails;

        // reports panel and controls (created on demand)
        private bool isReportsView = false;
        private Panel reportsPanel;
        private DataGridView dataGridViewReport;
        private Label lblReportSummary;
        private Button btnReportSales;
        private Button btnReportStatus;
        private Button btnReportProducts;
        private Button btnReportCustomers;
        private Button btnReportActivity;
        private Chart reportChart;

        // AI Chatbot fields and services
        private bool isChatBotView = false;
        private Panel typingIndicatorPanel;
        private Label lblTypingText;
        private GroqChatService chatService;

        private string GetConnectionString()
        {
            return "Server=DESKTOP-985956K\\SQLEXPRESS;Database=Shopping_Cart;User ID=sa;Password=130506;TrustServerCertificate=True;";
        }

        private DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        private int ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public Dashboard()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            EnsureActivityLogTable();
            LoadProducts();

            // Initialize Groq AI Chat Service
            chatService = new GroqChatService(GetConnectionString());

            // Wire up auto-calculation events
            txtPrice.TextChanged += (s, ev) => CalculateFinalPrice();
            txtSpecialOffer.TextChanged += (s, ev) => CalculateFinalPrice();
            // Wire orders, customers, reports, and AI assistant navigation
            btnNavOrders.Click += (s, ev) => BtnNavOrders_Click(s, ev);
            btnNavCustomers.Click += (s, ev) => BtnNavCustomers_Click(s, ev);
            btnNavDashboard.Click += (s, ev) => BtnNavDashboard_Click(s, ev);
            btnNavSettings.Click += (s, ev) => BtnNavReports_Click(s, ev);
            btnNavChatBot.Click += (s, ev) => BtnNavChatBot_Click(s, ev);

            // Wire AI ChatBot controls events
            if (cmbAiModel.Items.Count > 0 && cmbAiModel.SelectedIndex < 0)
            {
                cmbAiModel.SelectedIndex = 0;
            }

            cmbAiModel.SelectedIndexChanged += (s, ev) =>
            {
                if (chatService != null && cmbAiModel.SelectedItem != null)
                {
                    chatService.SelectedModel = cmbAiModel.SelectedItem.ToString();
                }
            };

            btnAiClear.Click += (s, ev) =>
            {
                if (chatService != null)
                {
                    chatService.ResetConversation();
                }
                chatMessagesContainer.Controls.Clear();
                AddWelcomeMessage();
            };

            btnAiSend.Click += (s, ev) => _ = SendAiMessageAsync();

            txtAiInput.KeyDown += (s, ev) =>
            {
                if (ev.KeyCode == Keys.Enter && !ev.Shift)
                {
                    ev.SuppressKeyPress = true;
                    _ = SendAiMessageAsync();
                }
            };

            // Wire quick chip buttons
            btnChipSales.Click += (s, ev) => RunQuickChipPrompt("Calculate total sales amount, grouped by Paid, Pending, and Cancelled orders.");
            btnChipCustomers.Click += (s, ev) => RunQuickChipPrompt("Find the top 5 customers with the highest spending, showing their names, emails, and order counts.");
            btnChipFindUser.Click += (s, ev) => RunQuickChipPrompt("Show me customer user accounts and their total order spending.");
            btnChipDiscounts.Click += (s, ev) => RunQuickChipPrompt("List all products currently having a discount or special offer.");
            btnChipRevenue.Click += (s, ev) => RunQuickChipPrompt("Calculate our monthly revenue summary for Paid orders.");
            btnChipLogs.Click += (s, ev) => RunQuickChipPrompt("Show the latest 10 product activity log actions.");

            // Add resize listener for responsive chat messages container
            aiPanel.Resize += (s, ev) =>
            {
                if (chatMessagesContainer != null && chatScrollPanel != null)
                {
                    chatMessagesContainer.Width = chatScrollPanel.ClientSize.Width - 25;
                }
            };

            // Initial welcome message
            AddWelcomeMessage();

            // default active nav
            SetActiveNavButton(btnNavDashboard);

            dataGridViewProducts.DataBindingComplete += (s, ev) =>
            {
                if (!isOrdersView && !isCustomersView && !isReportsView && !isChatBotView)
                {
                    HideProductImageColumns();
                }
            };
        }

        // ======================
        // Load all products into DataGridView
        // ======================
        private void LoadProducts()
        {
            try
            {
                string query = @"
                    SELECT ProductId, ProductName, Category, Price, Discount,
                           SpecialOffer, Stock, Image1, Image2, Image3, Image4, CreatedAt
                    FROM Products
                    ORDER BY ProductId DESC";

                DataTable dt = ExecuteQuery(query);
                dataGridViewProducts.DataSource = dt;
                HideProductImageColumns();
                // update summary cards whenever products are (re)loaded
                LoadSummary();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HideProductImageColumns()
        {
            string[] imageCols = { "Image1", "Image2", "Image3", "Image4" };
            foreach (string col in imageCols)
            {
                if (dataGridViewProducts.Columns.Contains(col))
                {
                    dataGridViewProducts.Columns[col].Visible = false;
                }
            }
        }

        // ======================
        // Load summary cards: Total Sales, Total Orders, Products, Customers
        // ======================
        private void LoadSummary()
        {
            try
            {
                // Total Sales (sum of TotalCost in Orders)
                DataTable dtSales = ExecuteQuery("SELECT ISNULL(SUM(TotalCost), 0) AS TotalSales FROM Orders WHERE OrderStatus IN ('Paid', 'Pending')");
                decimal totalSales = 0;
                if (dtSales != null && dtSales.Rows.Count > 0 && dtSales.Rows[0]["TotalSales"] != DBNull.Value)
                    totalSales = Convert.ToDecimal(dtSales.Rows[0]["TotalSales"]);

                // Total Orders
                DataTable dtOrders = ExecuteQuery("SELECT COUNT(*) AS TotalOrders FROM Orders");
                int totalOrders = 0;
                if (dtOrders != null && dtOrders.Rows.Count > 0)
                    totalOrders = Convert.ToInt32(dtOrders.Rows[0][0]);

                // Total Products
                DataTable dtProducts = ExecuteQuery("SELECT COUNT(*) AS TotalProducts FROM Products");
                int totalProducts = 0;
                if (dtProducts != null && dtProducts.Rows.Count > 0)
                    totalProducts = Convert.ToInt32(dtProducts.Rows[0][0]);

                // Total Customers (Users table)
                DataTable dtCustomers = ExecuteQuery("SELECT COUNT(*) AS TotalCustomers FROM Users");
                int totalCustomers = 0;
                if (dtCustomers != null && dtCustomers.Rows.Count > 0)
                    totalCustomers = Convert.ToInt32(dtCustomers.Rows[0][0]);

                // Set label texts (format numbers)
                lblSalesValue.Text = totalSales.ToString("C0");
                lblOrdersValue.Text = totalOrders.ToString("N0");
                lblProductsValue.Text = totalProducts.ToString("N0");
                lblCustomersValue.Text = totalCustomers.ToString("N0");
            }
            catch (Exception ex)
            {
                // don't crash the UI if summary fails
                Console.WriteLine("Failed to load summary: " + ex.Message);
            }
        }
        private void CalculateFinalPrice()
        {
            if (decimal.TryParse(txtPrice.Text.Trim(), out decimal price))
            {
                int specialOfferPercent = 0;
                if (!string.IsNullOrWhiteSpace(txtSpecialOffer.Text))
                {
                    int.TryParse(txtSpecialOffer.Text.Trim(), out specialOfferPercent);
                }

                if (specialOfferPercent < 0) specialOfferPercent = 0;
                if (specialOfferPercent > 100) specialOfferPercent = 100;

                decimal discountAmount = price * specialOfferPercent / 100;
                decimal finalPrice = price - discountAmount;

                txtDiscount.Text = finalPrice.ToString("0.00");
            }
            else
            {
                txtDiscount.Clear();
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                string query = @"
                    INSERT INTO Products (ProductName, Category, Price, Discount, SpecialOffer, Stock,
                                          Image1, Image2, Image3, Image4, CreatedAt)
                    VALUES (@ProductName, @Category, @Price, @Discount, @SpecialOffer, @Stock,
                            @Image1, @Image2, @Image3, @Image4, GETDATE())";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@ProductName", txtProductName.Text.Trim()),
                    new SqlParameter("@Category", cmbCategory.SelectedItem?.ToString() ?? ""),
                    new SqlParameter("@Price", decimal.Parse(txtPrice.Text.Trim())),
                    new SqlParameter("@Discount", string.IsNullOrWhiteSpace(txtDiscount.Text) ? 0 : decimal.Parse(txtDiscount.Text.Trim())),
                    new SqlParameter("@SpecialOffer", string.IsNullOrWhiteSpace(txtSpecialOffer.Text) ? 0 : int.Parse(txtSpecialOffer.Text.Trim())),
                    new SqlParameter("@Stock", string.IsNullOrWhiteSpace(txtStock.Text) ? 0 : int.Parse(txtStock.Text.Trim())),
                    new SqlParameter("@Image1", txtImage1.Text.Trim()),
                    new SqlParameter("@Image2", txtImage2.Text.Trim()),
                    new SqlParameter("@Image3", txtImage3.Text.Trim()),
                    new SqlParameter("@Image4", txtImage4.Text.Trim())
                };

                ExecuteNonQuery(query, parameters);

                LogProductActivity("Add", txtProductName.Text.Trim());

                MessageBox.Show("Product added successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearInputs();
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding product: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            if (string.IsNullOrWhiteSpace(txtProductId.Text) || txtProductId.Text == "(Auto)")
            {
                MessageBox.Show("Please select a product from the grid to update.", "Update",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = @"
                    UPDATE Products
                    SET ProductName = @ProductName,
                        Category = @Category,
                        Price = @Price,
                        Discount = @Discount,
                        SpecialOffer = @SpecialOffer,
                        Stock = @Stock,
                        Image1 = @Image1,
                        Image2 = @Image2,
                        Image3 = @Image3,
                        Image4 = @Image4
                    WHERE ProductId = @ProductId";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@ProductId", int.Parse(txtProductId.Text.Trim())),
                    new SqlParameter("@ProductName", txtProductName.Text.Trim()),
                    new SqlParameter("@Category", cmbCategory.SelectedItem?.ToString() ?? ""),
                    new SqlParameter("@Price", decimal.Parse(txtPrice.Text.Trim())),
                    new SqlParameter("@Discount", string.IsNullOrWhiteSpace(txtDiscount.Text) ? 0 : decimal.Parse(txtDiscount.Text.Trim())),
                    new SqlParameter("@SpecialOffer", string.IsNullOrWhiteSpace(txtSpecialOffer.Text) ? 0 : int.Parse(txtSpecialOffer.Text.Trim())),
                    new SqlParameter("@Stock", string.IsNullOrWhiteSpace(txtStock.Text) ? 0 : int.Parse(txtStock.Text.Trim())),
                    new SqlParameter("@Image1", txtImage1.Text.Trim()),
                    new SqlParameter("@Image2", txtImage2.Text.Trim()),
                    new SqlParameter("@Image3", txtImage3.Text.Trim()),
                    new SqlParameter("@Image4", txtImage4.Text.Trim())
                };

                int rows = ExecuteNonQuery(query, parameters);

                if (rows > 0)
                {
                    LogProductActivity("Update", txtProductName.Text.Trim());

                    MessageBox.Show("Product updated successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearInputs();
                    LoadProducts();
                }
                else
                {
                    MessageBox.Show("Product not found.", "Update",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating product: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductId.Text) || txtProductId.Text == "(Auto)")
            {
                MessageBox.Show("Please select a product from the grid to delete.", "Delete",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this product?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            try
            {
                string query = "DELETE FROM Products WHERE ProductId = @ProductId";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@ProductId", int.Parse(txtProductId.Text.Trim()))
                };

                int rows = ExecuteNonQuery(query, parameters);

                if (rows > 0)
                {
                    LogProductActivity("Delete", txtProductName.Text.Trim());

                    MessageBox.Show("Product deleted successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearInputs();
                    LoadProducts();
                }
                else
                {
                    MessageBox.Show("Product not found.", "Delete",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting product: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void ClearInputs()
        {
            txtProductId.Text = "(Auto)";
            txtProductName.Clear();
            cmbCategory.SelectedIndex = -1;
            txtPrice.Clear();
            txtSpecialOffer.Clear();
            txtDiscount.Clear();
            txtStock.Clear();
            txtImage1.Clear();
            txtImage2.Clear();
            txtImage3.Clear();
            txtImage4.Clear();
            txtCreatedAt.Clear();
        }
        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton == null) return;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*";
                openFileDialog.Title = "Select Product Image";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFile = openFileDialog.FileName;

                    if (clickedButton == btnBrowseImage1) txtImage1.Text = selectedFile;
                    else if (clickedButton == btnBrowseImage2) txtImage2.Text = selectedFile;
                    else if (clickedButton == btnBrowseImage3) txtImage3.Text = selectedFile;
                    else if (clickedButton == btnBrowseImage4) txtImage4.Text = selectedFile;
                }
            }
        }
        private void dataGridViewProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridViewProducts.Rows[e.RowIndex];

            if (isOrdersView)
            {
                // show order details when orders view is active
                if (row.Cells["OrderId"]?.Value != null && int.TryParse(row.Cells["OrderId"].Value.ToString(), out int orderId))
                {
                    ShowOrderDetails(orderId);
                }

                return;
            }

            if (isCustomersView)
            {
                if (row.Cells["UserId"]?.Value != null && int.TryParse(row.Cells["UserId"].Value.ToString(), out int userId))
                {
                    ShowCustomerOrders(userId);
                }

                return;
            }

            txtProductId.Text = row.Cells["ProductId"].Value?.ToString();
            txtProductName.Text = row.Cells["ProductName"].Value?.ToString();
            cmbCategory.SelectedItem = row.Cells["Category"].Value?.ToString();
            txtPrice.Text = row.Cells["Price"].Value?.ToString();
            txtSpecialOffer.Text = row.Cells["SpecialOffer"].Value?.ToString();
            txtDiscount.Text = row.Cells["Discount"].Value?.ToString();
            txtStock.Text = row.Cells["Stock"].Value != null ? row.Cells["Stock"].Value.ToString() : "0";
            txtImage1.Text = row.Cells["Image1"].Value?.ToString();
            txtImage2.Text = row.Cells["Image2"].Value?.ToString();
            txtImage3.Text = row.Cells["Image3"].Value?.ToString();
            txtImage4.Text = row.Cells["Image4"].Value?.ToString();
            txtCreatedAt.Text = row.Cells["CreatedAt"].Value?.ToString();
        }
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Please enter a product name.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductName.Focus();
                return false;
            }

            if (cmbCategory.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a category.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategory.Focus();
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text.Trim(), out _))
            {
                MessageBox.Show("Please enter a valid price.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtSpecialOffer.Text) && !int.TryParse(txtSpecialOffer.Text.Trim(), out int offer) && (offer < 0 || offer > 100))
            {
                MessageBox.Show("Please enter a valid special offer percentage (0-100).", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSpecialOffer.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtStock.Text) && (!int.TryParse(txtStock.Text.Trim(), out int stock) || stock < 0))
            {
                MessageBox.Show("Please enter a valid stock quantity (0 or greater).", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStock.Focus();
                return false;
            }

            return true;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Authentication authForm = new Authentication();
                authForm.Show();
                this.Hide();
            }
        }

        private void btnNavProducts_Click(object sender, EventArgs e)
        {
            SetActiveNavButton(btnNavProducts);
            ProductCatalog catalogForm = new ProductCatalog();
            catalogForm.IsAdmin = true;
            catalogForm.UserName = "Admin";
            catalogForm.UserEmail = "admin123@gmail.com";
            catalogForm.Show();
            this.Hide();
        }

        private void SetActiveNavButton(Button active)
        {
            // default styles for purple/violet sidebar theme
            Color activeBack = Color.FromArgb(118, 91, 184);
            Color activeFore = Color.White;
            Color defaultBack = Color.FromArgb(91, 68, 149);
            Color defaultFore = Color.FromArgb(235, 230, 250);

            Button[] navs = { btnNavDashboard, btnNavProducts, btnNavOrders, btnNavCustomers, btnNavSettings, btnNavChatBot };
            foreach (var b in navs)
            {
                if (b == null) continue;
                if (b == active)
                {
                    b.BackColor = activeBack;
                    b.ForeColor = activeFore;
                    b.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                }
                else
                {
                    b.BackColor = defaultBack;
                    b.ForeColor = defaultFore;
                    b.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
                }
            }
        }
        private void BtnNavOrders_Click(object sender, EventArgs e)
        {
            SetActiveNavButton(btnNavOrders);
            isOrdersView = true;
            isCustomersView = false;
            isReportsView = false;
            isChatBotView = false;
            HideReportsPanel();
            HideAiPanel();
            contentTable.Visible = true;
            ShowOrdersList();
        }

        private void BtnNavCustomers_Click(object sender, EventArgs e)
        {
            SetActiveNavButton(btnNavCustomers);
            isCustomersView = true;
            isOrdersView = false;
            isReportsView = false;
            isChatBotView = false;
            HideReportsPanel();
            HideAiPanel();
            contentTable.Visible = true;
            ShowCustomersList();
        }

        private void BtnNavDashboard_Click(object sender, EventArgs e)
        {
            SetActiveNavButton(btnNavDashboard);
            isOrdersView = false;
            isCustomersView = false;
            isReportsView = false;
            isChatBotView = false;
            HideReportsPanel();
            HideAiPanel();
            contentTable.Visible = true;
            // restore product management view
            inputPanel.Visible = true;
            lblCrudTitle.Text = "Manage Products";
            LoadProducts();
        }

        private void ShowCustomersList()
        {
            try
            {
                string query = @"
                    SELECT u.UserId, u.UserName, u.UserEmail,
                           COUNT(o.OrderId) AS OrderCount,
                           ISNULL(SUM(o.TotalCost), 0) AS TotalSpent
                    FROM Users u
                    LEFT JOIN Orders o ON u.UserId = o.UserId
                    GROUP BY u.UserId, u.UserName, u.UserEmail
                    ORDER BY TotalSpent DESC";

                DataTable dt = ExecuteQuery(query);

                dataGridViewProducts.DataSource = dt;
                isCustomersView = true;
                isOrdersView = false;

                lblCrudTitle.Text = "Customers";
                inputPanel.Visible = false;

                EnsureOrderDetailsPanel();
                orderDetailsPanel.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowCustomerOrders(int userId)
        {
            try
            {
                DataTable dtUser = ExecuteQuery("SELECT UserId, UserName, UserEmail FROM Users WHERE UserId = @UserId", new SqlParameter("@UserId", userId));
                if (dtUser == null || dtUser.Rows.Count == 0) return;

                DataRow u = dtUser.Rows[0];

                DataTable dtOrders = ExecuteQuery(@"
                    SELECT OrderId, OrderDate, TotalCost, OrderStatus, UserPhone, UserCity, UserAddress
                    FROM Orders
                    WHERE UserId = @UserId
                    ORDER BY OrderDate DESC", new SqlParameter("@UserId", userId));

                EnsureOrderDetailsPanel();
                lblOrderMeta.Text = $"Customer: {u["UserName"]} ({u["UserEmail"]})\nOrders: {dtOrders.Rows.Count}";
                dataGridViewOrderItems.DataSource = dtOrders;
                orderDetailsPanel.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customer orders: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowOrdersList()
        {
            try
            {
                string query = @"
                    SELECT o.OrderId, o.OrderDate, o.TotalCost, o.OrderStatus,
                           o.UserPhone, o.UserCity, o.UserAddress,
                           u.UserId, u.UserName, u.UserEmail
                    FROM Orders o
                    LEFT JOIN Users u ON o.UserId = u.UserId
                    ORDER BY o.OrderDate DESC";

                DataTable dt = ExecuteQuery(query);

                // show in existing grid
                dataGridViewProducts.DataSource = dt;
                isOrdersView = true;

                // update title
                lblCrudTitle.Text = "Orders";

                // hide product input panel while viewing orders
                inputPanel.Visible = false;

                // ensure details panel exists
                EnsureOrderDetailsPanel();
                orderDetailsPanel.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading orders: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnsureOrderDetailsPanel()
        {
            if (orderDetailsPanel != null) return;

            orderDetailsPanel = new Panel();
            orderDetailsPanel.Width = 420;
            orderDetailsPanel.Dock = DockStyle.Right;
            orderDetailsPanel.Padding = new Padding(15);
            orderDetailsPanel.BackColor = Color.White;

            btnCloseOrderDetails = new Button();
            btnCloseOrderDetails.Text = "Close";
            btnCloseOrderDetails.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCloseOrderDetails.Size = new Size(70, 30);
            btnCloseOrderDetails.Location = new Point(orderDetailsPanel.Width - 85, 10);
            btnCloseOrderDetails.Click += (s, e) => orderDetailsPanel.Visible = false;
            orderDetailsPanel.Controls.Add(btnCloseOrderDetails);

            lblOrderMeta = new Label();
            lblOrderMeta.AutoSize = true;
            lblOrderMeta.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblOrderMeta.ForeColor = Color.FromArgb(45, 33, 71);
            lblOrderMeta.Location = new Point(15, 15);
            lblOrderMeta.MaximumSize = new Size(orderDetailsPanel.Width - 30, 0);
            orderDetailsPanel.Controls.Add(lblOrderMeta);

            dataGridViewOrderItems = new DataGridView();
            dataGridViewOrderItems.Dock = DockStyle.Bottom;
            dataGridViewOrderItems.Height = 300;
            dataGridViewOrderItems.ReadOnly = true;
            dataGridViewOrderItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            orderDetailsPanel.Controls.Add(dataGridViewOrderItems);

            crudPanel.Controls.Add(orderDetailsPanel);
            orderDetailsPanel.BringToFront();
        }

        private void ShowOrderDetails(int orderId)
        {
            try
            {
                // order meta
                string orderQuery = @"
                    SELECT o.OrderId, o.TotalCost, o.OrderStatus, o.UserPhone, o.UserCity, o.UserAddress, o.OrderDate,
                           u.UserName, u.UserEmail
                    FROM Orders o
                    LEFT JOIN Users u ON o.UserId = u.UserId
                    WHERE o.OrderId = @OrderId";

                DataTable dtOrder = ExecuteQuery(orderQuery, new SqlParameter("@OrderId", orderId));
                if (dtOrder == null || dtOrder.Rows.Count == 0) return;

                DataRow r = dtOrder.Rows[0];
                string meta = $"Order #{r["OrderId"]}  •  {Convert.ToDateTime(r["OrderDate"]):g}\n" +
                              $"Customer: {r["UserName"]} ({r["UserEmail"]})\n" +
                              $"Phone: {r["UserPhone"]}  •  {r["UserCity"]}\n" +
                              $"Address: {r["UserAddress"]}\n" +
                              $"Status: {r["OrderStatus"]}  •  Total: {Convert.ToDecimal(r["TotalCost"]):C2}";

                lblOrderMeta.Text = meta;

                // items
                DataTable dtItems = ExecuteQuery(@"
                    SELECT ProductName, ProductPrice, Quantity,
                           ProductPrice * Quantity AS LineTotal
                    FROM OrderItems
                    WHERE OrderId = @OrderId", new SqlParameter("@OrderId", orderId));

                dataGridViewOrderItems.DataSource = dtItems;

                EnsureOrderDetailsPanel();
                orderDetailsPanel.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading order details: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ======================
        // Reports Panel
        // ======================

        private void BtnNavReports_Click(object sender, EventArgs e)
        {
            SetActiveNavButton(btnNavSettings);
            isOrdersView = false;
            isCustomersView = false;
            isReportsView = true;
            isChatBotView = false;
            HideAiPanel();

            // hide the default content (cards + crud)
            contentTable.Visible = false;

            // build and show reports panel
            EnsureReportsPanel();
            reportsPanel.Visible = true;

            // default to Sales Report
            LoadSalesReport();
        }

        private void HideReportsPanel()
        {
            if (reportsPanel != null)
                reportsPanel.Visible = false;
        }

        private void EnsureReportsPanel()
        {
            if (reportsPanel != null) return;

            reportsPanel = new Panel();
            reportsPanel.Dock = DockStyle.Fill;
            reportsPanel.BackColor = Color.FromArgb(248, 250, 252);
            reportsPanel.Padding = new Padding(0);

            // ── Top bar with title and report tab buttons ──
            Panel topBar = new Panel();
            topBar.Dock = DockStyle.Top;
            topBar.Height = 60;
            topBar.BackColor = Color.White;
            topBar.Padding = new Padding(15, 0, 15, 0);

            Label lblReportsTitle = new Label();
            lblReportsTitle.Text = "Reports";
            lblReportsTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblReportsTitle.ForeColor = Color.FromArgb(31, 41, 55);
            lblReportsTitle.AutoSize = true;
            lblReportsTitle.Location = new Point(15, 14);
            topBar.Controls.Add(lblReportsTitle);

            // Tab buttons
            int btnX = 200;
            int btnWidth = 130;
            int btnHeight = 36;
            int gap = 10;
            int btnY = 12;

            btnReportSales = CreateReportTabButton("Sales Report", btnX, btnY, btnWidth, btnHeight);
            btnReportSales.Click += (s, ev) => LoadSalesReport();
            topBar.Controls.Add(btnReportSales);

            btnReportStatus = CreateReportTabButton("Order Status", btnX + btnWidth + gap, btnY, btnWidth, btnHeight);
            btnReportStatus.Click += (s, ev) => LoadOrderStatusReport();
            topBar.Controls.Add(btnReportStatus);

            btnReportProducts = CreateReportTabButton("Top Products", btnX + (btnWidth + gap) * 2, btnY, btnWidth, btnHeight);
            btnReportProducts.Click += (s, ev) => LoadTopProductsReport();
            topBar.Controls.Add(btnReportProducts);

            btnReportCustomers = CreateReportTabButton("Top Customers", btnX + (btnWidth + gap) * 3, btnY, btnWidth + 10, btnHeight);
            btnReportCustomers.Click += (s, ev) => LoadTopCustomersReport();
            topBar.Controls.Add(btnReportCustomers);

            btnReportActivity = CreateReportTabButton("Activity Log", btnX + (btnWidth + gap) * 4 + 10, btnY, btnWidth, btnHeight);
            btnReportActivity.Click += (s, ev) => LoadActivityLogReport();
            topBar.Controls.Add(btnReportActivity);

            reportsPanel.Controls.Add(topBar);

            // ── Summary label ──
            lblReportSummary = new Label();
            lblReportSummary.Dock = DockStyle.Top;
            lblReportSummary.Height = 50;
            lblReportSummary.BackColor = Color.FromArgb(248, 250, 252);
            lblReportSummary.Font = new Font("Segoe UI", 11F);
            lblReportSummary.ForeColor = Color.FromArgb(55, 65, 81);
            lblReportSummary.Padding = new Padding(15, 12, 15, 0);
            lblReportSummary.Text = "";
            reportsPanel.Controls.Add(lblReportSummary);

            // ── Chart ──
            reportChart = new Chart();
            reportChart.Dock = DockStyle.Top;
            reportChart.Height = 280;
            reportChart.BackColor = Color.White;
            reportChart.BorderlineColor = Color.FromArgb(229, 231, 235);
            reportChart.BorderlineDashStyle = ChartDashStyle.Solid;
            reportChart.BorderlineWidth = 1;
            reportChart.Padding = new Padding(10);

            ChartArea chartArea = new ChartArea("MainArea");
            chartArea.BackColor = Color.White;
            chartArea.AxisX.MajorGrid.LineColor = Color.FromArgb(240, 240, 240);
            chartArea.AxisY.MajorGrid.LineColor = Color.FromArgb(240, 240, 240);
            chartArea.AxisX.LabelStyle.Font = new Font("Segoe UI", 8.5F);
            chartArea.AxisY.LabelStyle.Font = new Font("Segoe UI", 8.5F);
            chartArea.AxisX.LabelStyle.ForeColor = Color.FromArgb(75, 85, 99);
            chartArea.AxisY.LabelStyle.ForeColor = Color.FromArgb(75, 85, 99);
            chartArea.AxisX.LineColor = Color.FromArgb(209, 213, 219);
            chartArea.AxisY.LineColor = Color.FromArgb(209, 213, 219);
            chartArea.AxisX.MajorTickMark.LineColor = Color.FromArgb(209, 213, 219);
            chartArea.AxisY.MajorTickMark.LineColor = Color.FromArgb(209, 213, 219);
            reportChart.ChartAreas.Add(chartArea);

            Legend legend = new Legend();
            legend.Font = new Font("Segoe UI", 9F);
            legend.ForeColor = Color.FromArgb(55, 65, 81);
            legend.Docking = Docking.Top;
            legend.Alignment = StringAlignment.Center;
            reportChart.Legends.Add(legend);

            reportsPanel.Controls.Add(reportChart);

            // ── DataGridView for report data ──
            dataGridViewReport = new DataGridView();
            dataGridViewReport.Dock = DockStyle.Fill;
            dataGridViewReport.ReadOnly = true;
            dataGridViewReport.AllowUserToAddRows = false;
            dataGridViewReport.AllowUserToDeleteRows = false;
            dataGridViewReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewReport.BackgroundColor = Color.White;
            dataGridViewReport.BorderStyle = BorderStyle.None;
            dataGridViewReport.RowHeadersVisible = false;
            dataGridViewReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewReport.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewReport.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            dataGridViewReport.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(55, 65, 81);
            dataGridViewReport.ColumnHeadersDefaultCellStyle.Padding = new Padding(8);
            dataGridViewReport.ColumnHeadersHeight = 45;
            dataGridViewReport.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dataGridViewReport.DefaultCellStyle.Padding = new Padding(8);
            dataGridViewReport.RowTemplate.Height = 40;
            dataGridViewReport.EnableHeadersVisualStyles = false;
            dataGridViewReport.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            dataGridViewReport.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewReport.GridColor = Color.FromArgb(229, 231, 235);
            reportsPanel.Controls.Add(dataGridViewReport);

            // Dock stacking order: Fill at bottom, then Top items stack above
            reportsPanel.Controls.SetChildIndex(dataGridViewReport, 0);
            reportsPanel.Controls.SetChildIndex(reportChart, 0);
            reportsPanel.Controls.SetChildIndex(lblReportSummary, 0);
            reportsPanel.Controls.SetChildIndex(topBar, 0);

            // Add to contentPanel
            contentPanel.Controls.Add(reportsPanel);
        }

        private Button CreateReportTabButton(string text, int x, int y, int width, int height)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.Location = new Point(x, y);
            btn.Size = new Size(width, height);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.FromArgb(237, 233, 246);
            btn.ForeColor = Color.FromArgb(91, 68, 149);
            btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            return btn;
        }

        private void SetActiveReportTab(Button active)
        {
            Color activeBg = Color.FromArgb(91, 68, 149);
            Color activeFg = Color.White;
            Color defaultBg = Color.FromArgb(237, 233, 246);
            Color defaultFg = Color.FromArgb(91, 68, 149);

            Button[] tabs = { btnReportSales, btnReportStatus, btnReportProducts, btnReportCustomers, btnReportActivity };
            foreach (var b in tabs)
            {
                if (b == null) continue;
                if (b == active)
                {
                    b.BackColor = activeBg;
                    b.ForeColor = activeFg;
                }
                else
                {
                    b.BackColor = defaultBg;
                    b.ForeColor = defaultFg;
                }
            }
        }

        // ── Report 1: Sales Report (monthly, Paid vs Pending) ──
        private void LoadSalesReport()
        {
            SetActiveReportTab(btnReportSales);
            try
            {
                string query = @"
                    SELECT 
                        FORMAT(OrderDate, 'yyyy-MM') AS [Month],
                        SUM(CASE WHEN OrderStatus = 'Paid' THEN TotalCost ELSE 0 END) AS [Paid Amount],
                        SUM(CASE WHEN OrderStatus = 'Pending' THEN TotalCost ELSE 0 END) AS [Pending Amount],
                        SUM(CASE WHEN OrderStatus IN ('Paid', 'Pending') THEN TotalCost ELSE 0 END) AS [Total]
                    FROM Orders
                    WHERE OrderStatus IN ('Paid', 'Pending')
                    GROUP BY FORMAT(OrderDate, 'yyyy-MM')
                    ORDER BY [Month] ASC";

                DataTable dt = ExecuteQuery(query);
                dataGridViewReport.DataSource = dt;

                // Calculate summary
                decimal totalPaid = 0, totalPending = 0;
                foreach (DataRow row in dt.Rows)
                {
                    totalPaid += Convert.ToDecimal(row["Paid Amount"]);
                    totalPending += Convert.ToDecimal(row["Pending Amount"]);
                }
                lblReportSummary.Text = $"Total Paid: {totalPaid:C0}   |   Total Pending: {totalPending:C0}   |   Grand Total: {(totalPaid + totalPending):C0}";

                // Chart: Stacked bar chart for Paid vs Pending by month
                reportChart.Series.Clear();
                reportChart.ChartAreas[0].AxisX.Title = "Month";
                reportChart.ChartAreas[0].AxisY.Title = "Amount ($)";
                reportChart.ChartAreas[0].AxisX.TitleFont = new Font("Segoe UI", 9F, FontStyle.Bold);
                reportChart.ChartAreas[0].AxisY.TitleFont = new Font("Segoe UI", 9F, FontStyle.Bold);

                Series seriesPaid = new Series("Paid");
                seriesPaid.ChartType = SeriesChartType.Column;
                seriesPaid.Color = Color.FromArgb(34, 197, 94);
                seriesPaid.BorderWidth = 0;

                Series seriesPending = new Series("Pending");
                seriesPending.ChartType = SeriesChartType.Column;
                seriesPending.Color = Color.FromArgb(251, 191, 36);
                seriesPending.BorderWidth = 0;

                foreach (DataRow row in dt.Rows)
                {
                    string month = row["Month"].ToString();
                    seriesPaid.Points.AddXY(month, Convert.ToDouble(row["Paid Amount"]));
                    seriesPending.Points.AddXY(month, Convert.ToDouble(row["Pending Amount"]));
                }

                reportChart.Series.Add(seriesPaid);
                reportChart.Series.Add(seriesPending);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading sales report: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Report 2: Order Status Report ──
        private void LoadOrderStatusReport()
        {
            SetActiveReportTab(btnReportStatus);
            try
            {
                string query = @"
                    SELECT 
                        OrderStatus AS [Status],
                        COUNT(*) AS [Order Count],
                        SUM(TotalCost) AS [Total Amount]
                    FROM Orders
                    GROUP BY OrderStatus
                    ORDER BY [Total Amount] DESC";

                DataTable dt = ExecuteQuery(query);
                dataGridViewReport.DataSource = dt;

                int totalOrders = 0;
                decimal totalAmount = 0;
                foreach (DataRow row in dt.Rows)
                {
                    totalOrders += Convert.ToInt32(row["Order Count"]);
                    totalAmount += Convert.ToDecimal(row["Total Amount"]);
                }
                lblReportSummary.Text = $"Total Orders: {totalOrders}   |   Total Amount: {totalAmount:C0}";

                // Chart: Pie chart for order status distribution
                reportChart.Series.Clear();
                reportChart.ChartAreas[0].AxisX.Title = "";
                reportChart.ChartAreas[0].AxisY.Title = "";

                Series seriesStatus = new Series("Orders");
                seriesStatus.ChartType = SeriesChartType.Pie;
                seriesStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

                Color[] pieColors = {
                    Color.FromArgb(34, 197, 94),   // green (Paid)
                    Color.FromArgb(251, 191, 36),  // amber (Pending)
                    Color.FromArgb(239, 68, 68),   // red (Cancelled)
                    Color.FromArgb(99, 102, 241),  // indigo
                    Color.FromArgb(168, 162, 158)   // gray
                };

                int colorIdx = 0;
                foreach (DataRow row in dt.Rows)
                {
                    int idx = seriesStatus.Points.AddXY(row["Status"].ToString(), Convert.ToDouble(row["Order Count"]));
                    seriesStatus.Points[idx].Color = pieColors[colorIdx % pieColors.Length];
                    seriesStatus.Points[idx].Label = $"{row["Status"]} ({row["Order Count"]})";
                    colorIdx++;
                }

                seriesStatus["PieLabelStyle"] = "Outside";
                reportChart.Series.Add(seriesStatus);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading order status report: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Report 3: Top Selling Products ──
        private void LoadTopProductsReport()
        {
            SetActiveReportTab(btnReportProducts);
            try
            {
                string query = @"
                    SELECT 
                        oi.ProductName AS [Product Name],
                        p.Category AS [Category],
                        SUM(oi.Quantity) AS [Qty Sold],
                        SUM(oi.ProductPrice * oi.Quantity) AS [Revenue]
                    FROM OrderItems oi
                    LEFT JOIN Products p ON oi.ProductName = p.ProductName
                    INNER JOIN Orders o ON oi.OrderId = o.OrderId
                    WHERE o.OrderStatus IN ('Paid', 'Pending')
                    GROUP BY oi.ProductName, p.Category
                    ORDER BY [Qty Sold] DESC";

                DataTable dt = ExecuteQuery(query);
                dataGridViewReport.DataSource = dt;

                int totalQty = 0;
                decimal totalRevenue = 0;
                foreach (DataRow row in dt.Rows)
                {
                    totalQty += Convert.ToInt32(row["Qty Sold"]);
                    totalRevenue += Convert.ToDecimal(row["Revenue"]);
                }
                lblReportSummary.Text = $"Total Items Sold: {totalQty}   |   Total Revenue: {totalRevenue:C0}";

                // Chart: Horizontal bar chart for top products by quantity
                reportChart.Series.Clear();
                reportChart.ChartAreas[0].AxisX.Title = "Product";
                reportChart.ChartAreas[0].AxisY.Title = "Qty Sold";
                reportChart.ChartAreas[0].AxisX.TitleFont = new Font("Segoe UI", 9F, FontStyle.Bold);
                reportChart.ChartAreas[0].AxisY.TitleFont = new Font("Segoe UI", 9F, FontStyle.Bold);

                Series seriesQty = new Series("Qty Sold");
                seriesQty.ChartType = SeriesChartType.Bar;
                seriesQty.Color = Color.FromArgb(99, 102, 241);
                seriesQty.BorderWidth = 0;

                // Show top 10 products
                int count = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (count >= 10) break;
                    string name = row["Product Name"].ToString();
                    if (name.Length > 20) name = name.Substring(0, 17) + "...";
                    seriesQty.Points.AddXY(name, Convert.ToDouble(row["Qty Sold"]));
                    count++;
                }

                reportChart.Series.Add(seriesQty);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading top products report: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Report 4: Top Customers ──
        private void LoadTopCustomersReport()
        {
            SetActiveReportTab(btnReportCustomers);
            try
            {
                string query = @"
                    SELECT 
                        u.UserName AS [Customer Name],
                        u.UserEmail AS [Email],
                        COUNT(o.OrderId) AS [Orders],
                        SUM(o.TotalCost) AS [Total Spent]
                    FROM Users u
                    INNER JOIN Orders o ON u.UserId = o.UserId
                    WHERE o.OrderStatus IN ('Paid', 'Pending')
                    GROUP BY u.UserName, u.UserEmail
                    ORDER BY [Total Spent] DESC";

                DataTable dt = ExecuteQuery(query);
                dataGridViewReport.DataSource = dt;

                int totalCustomers = dt.Rows.Count;
                decimal totalSpent = 0;
                foreach (DataRow row in dt.Rows)
                {
                    totalSpent += Convert.ToDecimal(row["Total Spent"]);
                }
                lblReportSummary.Text = $"Active Customers: {totalCustomers}   |   Combined Spending: {totalSpent:C0}";

                // Chart: Column chart for top customers by spending
                reportChart.Series.Clear();
                reportChart.ChartAreas[0].AxisX.Title = "Customer";
                reportChart.ChartAreas[0].AxisY.Title = "Total Spent ($)";
                reportChart.ChartAreas[0].AxisX.TitleFont = new Font("Segoe UI", 9F, FontStyle.Bold);
                reportChart.ChartAreas[0].AxisY.TitleFont = new Font("Segoe UI", 9F, FontStyle.Bold);

                Series seriesSpent = new Series("Total Spent");
                seriesSpent.ChartType = SeriesChartType.Column;
                seriesSpent.Color = Color.FromArgb(14, 165, 233);
                seriesSpent.BorderWidth = 0;

                // Show top 10 customers
                int count = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (count >= 10) break;
                    string name = row["Customer Name"].ToString();
                    if (name.Length > 15) name = name.Substring(0, 12) + "...";
                    seriesSpent.Points.AddXY(name, Convert.ToDouble(row["Total Spent"]));
                    count++;
                }

                reportChart.Series.Add(seriesSpent);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading top customers report: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ======================
        // Product Activity Log
        // ======================

        private void EnsureActivityLogTable()
        {
            try
            {
                string createTableQuery = @"
                    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ProductActivityLog')
                    BEGIN
                        CREATE TABLE ProductActivityLog (
                            LogId INT IDENTITY(1,1) PRIMARY KEY,
                            ActionType NVARCHAR(20) NOT NULL,
                            ProductName NVARCHAR(200) NOT NULL,
                            ActionDate DATETIME NOT NULL DEFAULT GETDATE()
                        )
                    END";
                ExecuteNonQuery(createTableQuery);
            }
            catch
            {
                // silently ignore – table may already exist
            }
        }

        private void LogProductActivity(string actionType, string productName)
        {
            try
            {
                string query = @"
                    INSERT INTO ProductActivityLog (ActionType, ProductName, ActionDate)
                    VALUES (@ActionType, @ProductName, GETDATE())";

                ExecuteNonQuery(query,
                    new SqlParameter("@ActionType", actionType),
                    new SqlParameter("@ProductName", productName));
            }
            catch
            {
                // silently ignore logging errors
            }
        }

        // ── Report 5: Activity Log ──
        private void LoadActivityLogReport()
        {
            SetActiveReportTab(btnReportActivity);
            try
            {
                string query = @"
                    SELECT 
                        LogId AS [#],
                        ActionType AS [Action],
                        ProductName AS [Product Name],
                        FORMAT(ActionDate, 'yyyy-MM-dd HH:mm') AS [Date/Time]
                    FROM ProductActivityLog
                    ORDER BY LogId DESC";

                DataTable dt = ExecuteQuery(query);
                dataGridViewReport.DataSource = dt;

                // Count actions
                int addCount = 0, updateCount = 0, deleteCount = 0;
                foreach (DataRow row in dt.Rows)
                {
                    string action = row["Action"].ToString();
                    if (action == "Add") addCount++;
                    else if (action == "Update") updateCount++;
                    else if (action == "Delete") deleteCount++;
                }
                lblReportSummary.Text = $"Total Activities: {dt.Rows.Count}   |   Added: {addCount}   |   Updated: {updateCount}   |   Deleted: {deleteCount}";

                // Chart: Column chart of daily activity counts
                reportChart.Series.Clear();
                reportChart.ChartAreas[0].AxisX.Title = "Date";
                reportChart.ChartAreas[0].AxisY.Title = "Actions";
                reportChart.ChartAreas[0].AxisX.TitleFont = new Font("Segoe UI", 9F, FontStyle.Bold);
                reportChart.ChartAreas[0].AxisY.TitleFont = new Font("Segoe UI", 9F, FontStyle.Bold);

                // Query daily activity counts
                string chartQuery = @"
                    SELECT 
                        FORMAT(ActionDate, 'MM-dd') AS [Day],
                        SUM(CASE WHEN ActionType = 'Add' THEN 1 ELSE 0 END) AS [Added],
                        SUM(CASE WHEN ActionType = 'Update' THEN 1 ELSE 0 END) AS [Updated],
                        SUM(CASE WHEN ActionType = 'Delete' THEN 1 ELSE 0 END) AS [Deleted]
                    FROM ProductActivityLog
                    GROUP BY FORMAT(ActionDate, 'yyyy-MM-dd'), FORMAT(ActionDate, 'MM-dd')
                    ORDER BY FORMAT(ActionDate, 'yyyy-MM-dd') ASC";

                DataTable dtChart = ExecuteQuery(chartQuery);

                Series seriesAdd = new Series("Added");
                seriesAdd.ChartType = SeriesChartType.Column;
                seriesAdd.Color = Color.FromArgb(34, 197, 94);
                seriesAdd.BorderWidth = 0;

                Series seriesUpdate = new Series("Updated");
                seriesUpdate.ChartType = SeriesChartType.Column;
                seriesUpdate.Color = Color.FromArgb(251, 191, 36);
                seriesUpdate.BorderWidth = 0;

                Series seriesDelete = new Series("Deleted");
                seriesDelete.ChartType = SeriesChartType.Column;
                seriesDelete.Color = Color.FromArgb(239, 68, 68);
                seriesDelete.BorderWidth = 0;

                foreach (DataRow row in dtChart.Rows)
                {
                    string day = row["Day"].ToString();
                    seriesAdd.Points.AddXY(day, Convert.ToInt32(row["Added"]));
                    seriesUpdate.Points.AddXY(day, Convert.ToInt32(row["Updated"]));
                    seriesDelete.Points.AddXY(day, Convert.ToInt32(row["Deleted"]));
                }

                reportChart.Series.Add(seriesAdd);
                reportChart.Series.Add(seriesUpdate);
                reportChart.Series.Add(seriesDelete);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading activity log: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================================
        // AI ChatBot Assistant (Groq LLaMA / GPT-OSS Database Analytics)
        // =========================================================================

        private void BtnNavChatBot_Click(object sender, EventArgs e)
        {
            SetActiveNavButton(btnNavChatBot);
            isOrdersView = false;
            isCustomersView = false;
            isReportsView = false;
            isChatBotView = true;

            // Hide cards + CRUD and reports
            contentTable.Visible = false;
            HideReportsPanel();

            // Show AI ChatBot panel
            aiPanel.Visible = true;

            if (txtAiInput != null && txtAiInput.CanFocus)
            {
                txtAiInput.Focus();
            }
        }

        private void HideAiPanel()
        {
            if (aiPanel != null)
                aiPanel.Visible = false;
        }

        private void RunQuickChipPrompt(string prompt)
        {
            txtAiInput.Text = prompt;
            _ = SendAiMessageAsync();
        }

        private void AddWelcomeMessage()
        {
            string welcomeText = "👋 **Hello Admin!** I am your Shopping Cart **AI Assistant** powered by Groq LLaMA/GPT.\n\n" +
                                 "I can analyze your live SQL database to:\n" +
                                 "• 💰 Calculate total revenue, pending amounts, and sales metrics\n" +
                                 "• 👑 Identify top-spending customers & order histories\n" +
                                 "• 🔍 Search users, contact information, and addresses\n" +
                                 "• 📦 Filter products by price, category, and discounts\n" +
                                 "• 📊 Answer any general business question or calculation\n\n" +
                                 "Click any of the quick prompt chips above or type your question below!";

            AddAiBubble(welcomeText);
        }

        private void AddUserBubble(string text)
        {
            int containerWidth = Math.Max(chatScrollPanel.ClientSize.Width - 40, 500);

            Panel row = new Panel();
            row.Width = containerWidth;
            row.AutoSize = true;
            row.Margin = new Padding(0, 5, 0, 10);
            row.BackColor = Color.Transparent;

            Panel bubble = new Panel();
            bubble.BackColor = Color.FromArgb(91, 68, 149);
            bubble.Padding = new Padding(14, 10, 14, 12);
            bubble.AutoSize = true;
            bubble.MaximumSize = new Size((int)(containerWidth * 0.78), 0);

            Label lblSender = new Label();
            lblSender.Text = $"👤 Admin  •  {DateTime.Now:t}";
            lblSender.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblSender.ForeColor = Color.FromArgb(235, 230, 250);
            lblSender.AutoSize = true;
            lblSender.Location = new Point(14, 8);
            bubble.Controls.Add(lblSender);

            Label lblBody = new Label();
            lblBody.Text = text;
            lblBody.Font = new Font("Segoe UI", 10F);
            lblBody.ForeColor = Color.White;
            lblBody.AutoSize = true;
            lblBody.Location = new Point(14, 28);
            lblBody.MaximumSize = new Size((int)(containerWidth * 0.74), 0);
            bubble.Controls.Add(lblBody);

            row.Controls.Add(bubble);

            // Right-align bubble
            bubble.Location = new Point(row.Width - bubble.PreferredSize.Width - 10, 0);

            chatMessagesContainer.Controls.Add(row);
            chatScrollPanel.ScrollControlIntoView(row);
        }

        private void AddAiBubble(string answer, bool isError = false)
        {
            int containerWidth = Math.Max(chatScrollPanel.ClientSize.Width - 40, 500);

            Panel row = new Panel();
            row.Width = containerWidth;
            row.AutoSize = true;
            row.Margin = new Padding(0, 5, 0, 15);
            row.BackColor = Color.Transparent;

            Panel bubble = new Panel();
            bubble.BackColor = Color.White;
            bubble.Padding = new Padding(14, 12, 14, 14);
            bubble.AutoSize = true;
            bubble.MaximumSize = new Size((int)(containerWidth * 0.88), 0);

            // Top meta bar inside bubble
            Label lblSender = new Label();
            lblSender.Text = isError ? $"⚠️ AI Alert  •  {DateTime.Now:t}" : $"🤖 AI Assistant  •  {DateTime.Now:t}";
            lblSender.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSender.ForeColor = isError ? Color.FromArgb(220, 38, 38) : Color.FromArgb(91, 68, 149);
            lblSender.AutoSize = true;
            lblSender.Location = new Point(14, 10);
            bubble.Controls.Add(lblSender);

            // Copy button
            Button btnCopy = new Button();
            btnCopy.Text = "📋 Copy";
            btnCopy.Font = new Font("Segoe UI", 8F);
            btnCopy.BackColor = Color.FromArgb(241, 245, 249);
            btnCopy.ForeColor = Color.FromArgb(100, 116, 139);
            btnCopy.FlatStyle = FlatStyle.Flat;
            btnCopy.FlatAppearance.BorderSize = 0;
            btnCopy.Cursor = Cursors.Hand;
            btnCopy.Size = new Size(58, 24);
            btnCopy.Location = new Point(bubble.MaximumSize.Width - 75, 8);
            btnCopy.Click += (s, e) =>
            {
                try
                {
                    Clipboard.SetText(answer);
                    btnCopy.Text = "✓ Copied";
                }
                catch { }
            };
            bubble.Controls.Add(btnCopy);

            int currentY = 36;

            // Body text
            Label lblBody = new Label();
            lblBody.Text = answer;
            lblBody.Font = new Font("Segoe UI", 10F);
            lblBody.ForeColor = isError ? Color.FromArgb(185, 28, 28) : Color.FromArgb(30, 41, 59);
            lblBody.AutoSize = true;
            lblBody.Location = new Point(14, currentY);
            lblBody.MaximumSize = new Size((int)(containerWidth * 0.84), 0);
            bubble.Controls.Add(lblBody);

            row.Controls.Add(bubble);
            bubble.Location = new Point(10, 0);

            chatMessagesContainer.Controls.Add(row);
            chatScrollPanel.ScrollControlIntoView(row);
        }

        private void ShowTypingIndicator(string text = "⚡ AI is analyzing database & calculating...")
        {
            HideTypingIndicator();

            int containerWidth = Math.Max(chatScrollPanel.ClientSize.Width - 40, 500);

            typingIndicatorPanel = new Panel();
            typingIndicatorPanel.Width = containerWidth;
            typingIndicatorPanel.Height = 45;
            typingIndicatorPanel.Margin = new Padding(0, 5, 0, 10);
            typingIndicatorPanel.BackColor = Color.Transparent;

            Panel bubble = new Panel();
            bubble.BackColor = Color.FromArgb(243, 232, 255);
            bubble.Padding = new Padding(12, 8, 12, 8);
            bubble.AutoSize = true;
            bubble.Location = new Point(10, 0);

            lblTypingText = new Label();
            lblTypingText.Text = $"🤖 {text}";
            lblTypingText.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
            lblTypingText.ForeColor = Color.FromArgb(126, 34, 206);
            lblTypingText.AutoSize = true;
            lblTypingText.Location = new Point(10, 8);
            bubble.Controls.Add(lblTypingText);

            typingIndicatorPanel.Controls.Add(bubble);
            chatMessagesContainer.Controls.Add(typingIndicatorPanel);
            chatScrollPanel.ScrollControlIntoView(typingIndicatorPanel);
        }

        private void HideTypingIndicator()
        {
            if (typingIndicatorPanel != null)
            {
                chatMessagesContainer.Controls.Remove(typingIndicatorPanel);
                typingIndicatorPanel.Dispose();
                typingIndicatorPanel = null;
            }
        }

        private async Task SendAiMessageAsync()
        {
            string userMessage = txtAiInput.Text.Trim();
            if (string.IsNullOrWhiteSpace(userMessage)) return;

            txtAiInput.Clear();
            AddUserBubble(userMessage);

            btnAiSend.Enabled = false;
            lblAiStatus.Text = "⚡ Analyzing...";
            lblAiStatus.ForeColor = Color.FromArgb(202, 138, 4);

            ShowTypingIndicator("Groq AI is processing your query and reading database data...");

            try
            {
                var result = await chatService.SendMessageAsync(userMessage);

                HideTypingIndicator();

                if (result.IsSuccess)
                {
                    AddAiBubble(result.Answer);
                    lblAiStatus.Text = "🟢 Ready";
                    lblAiStatus.ForeColor = Color.FromArgb(22, 163, 74);
                }
                else
                {
                    AddAiBubble(result.Answer, isError: true);
                    lblAiStatus.Text = "⚠️ Error";
                    lblAiStatus.ForeColor = Color.FromArgb(220, 38, 38);
                }
            }
            catch (Exception ex)
            {
                HideTypingIndicator();
                AddAiBubble($"❌ Error: {ex.Message}", isError: true);
                lblAiStatus.Text = "⚠️ Error";
                lblAiStatus.ForeColor = Color.FromArgb(220, 38, 38);
            }
            finally
            {
                btnAiSend.Enabled = true;
                if (txtAiInput.CanFocus)
                {
                    txtAiInput.Focus();
                }
            }
        }
    }
}

