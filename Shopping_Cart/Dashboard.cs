using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

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
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            LoadProducts();

            // Wire up auto-calculation events
            txtPrice.TextChanged += (s, ev) => CalculateFinalPrice();
            txtSpecialOffer.TextChanged += (s, ev) => CalculateFinalPrice();
            // Wire orders and customers navigation
            btnNavOrders.Click += (s, ev) => BtnNavOrders_Click(s, ev);
            btnNavCustomers.Click += (s, ev) => BtnNavCustomers_Click(s, ev);
            btnNavDashboard.Click += (s, ev) => BtnNavDashboard_Click(s, ev);

            // default active nav
            SetActiveNavButton(btnNavDashboard);
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
                           SpecialOffer, Image1, Image2, Image3, Image4, CreatedAt
                    FROM Products
                    ORDER BY ProductId DESC";

                DataTable dt = ExecuteQuery(query);
                dataGridViewProducts.DataSource = dt;
                // update summary cards whenever products are (re)loaded
                LoadSummary();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                DataTable dtSales = ExecuteQuery("SELECT ISNULL(SUM(TotalCost), 0) AS TotalSales FROM Orders");
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
                    INSERT INTO Products (ProductName, Category, Price, Discount, SpecialOffer,
                                          Image1, Image2, Image3, Image4, CreatedAt)
                    VALUES (@ProductName, @Category, @Price, @Discount, @SpecialOffer,
                            @Image1, @Image2, @Image3, @Image4, GETDATE())";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@ProductName", txtProductName.Text.Trim()),
                    new SqlParameter("@Category", cmbCategory.SelectedItem?.ToString() ?? ""),
                    new SqlParameter("@Price", decimal.Parse(txtPrice.Text.Trim())),
                    new SqlParameter("@Discount", string.IsNullOrWhiteSpace(txtDiscount.Text) ? 0 : decimal.Parse(txtDiscount.Text.Trim())),
                    new SqlParameter("@SpecialOffer", string.IsNullOrWhiteSpace(txtSpecialOffer.Text) ? 0 : int.Parse(txtSpecialOffer.Text.Trim())),
                    new SqlParameter("@Image1", txtImage1.Text.Trim()),
                    new SqlParameter("@Image2", txtImage2.Text.Trim()),
                    new SqlParameter("@Image3", txtImage3.Text.Trim()),
                    new SqlParameter("@Image4", txtImage4.Text.Trim())
                };

                ExecuteNonQuery(query, parameters);

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
                    new SqlParameter("@Image1", txtImage1.Text.Trim()),
                    new SqlParameter("@Image2", txtImage2.Text.Trim()),
                    new SqlParameter("@Image3", txtImage3.Text.Trim()),
                    new SqlParameter("@Image4", txtImage4.Text.Trim())
                };

                int rows = ExecuteNonQuery(query, parameters);

                if (rows > 0)
                {
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
            catalogForm.Show();
            this.Hide();
        }

        private void SetActiveNavButton(Button active)
        {
            // default styles
            Color activeBack = Color.FromArgb(239, 246, 255);
            Color activeFore = Color.FromArgb(59, 130, 246);
            Color defaultBack = Color.White;
            Color defaultFore = Color.FromArgb(75, 85, 99);

            Button[] navs = { btnNavDashboard, btnNavProducts, btnNavOrders, btnNavCustomers, btnNavSettings };
            foreach (var b in navs)
            {
                if (b == null) continue;
                if (b == active)
                {
                    b.BackColor = activeBack;
                    b.ForeColor = activeFore;
                }
                else
                {
                    b.BackColor = defaultBack;
                    b.ForeColor = defaultFore;
                }
            }
        }
        private void BtnNavOrders_Click(object sender, EventArgs e)
        {
            SetActiveNavButton(btnNavOrders);
            isOrdersView = true;
            isCustomersView = false;
            ShowOrdersList();
        }

        private void BtnNavCustomers_Click(object sender, EventArgs e)
        {
            SetActiveNavButton(btnNavCustomers);
            isCustomersView = true;
            isOrdersView = false;
            ShowCustomersList();
        }

        private void BtnNavDashboard_Click(object sender, EventArgs e)
        {
            SetActiveNavButton(btnNavDashboard);
            isOrdersView = false;
            isCustomersView = false;
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
            lblOrderMeta.ForeColor = Color.FromArgb(31, 41, 55);
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
    }
}
