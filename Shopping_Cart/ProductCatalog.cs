using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Shopping_Cart
{
    public partial class ProductCatalog : Form
    {
        private int cartCount = 0;
        private string currentCategory = "All";
        private DataTable productsTable;
        private System.Collections.Generic.List<CartItem> cartItems = new System.Collections.Generic.List<CartItem>();

        private ProductCardInfo currentDetailProduct;
        private string currentDetailImagePath;
        private int pendingOrderId;
        private string currentKhqrMd5;
        private string currentKhqrString;
        private static readonly HttpClient httpClient = new HttpClient(new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
        })
        {
            Timeout = TimeSpan.FromSeconds(15)
        };

        public string UserName { get; set; }
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public bool IsAdmin { get; set; }

        public ProductCatalog()
        {
            try
            {
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls;
                System.Net.ServicePointManager.ServerCertificateValidationCallback = (s, c, ch, ssl) => true;
            }
            catch { }

            InitializeComponent();
            BuildProductDetailPanel();
            BuildCartPanel();
            BuildPaymentPanel();
        }

        private void ProductCatalog_Load(object sender, EventArgs e)
        {
            if (string.Equals(UserEmail?.Trim(), "admin123@gmail.com", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(UserName?.Trim(), "Admin", StringComparison.OrdinalIgnoreCase))
            {
                IsAdmin = true;
            }

            EnsureValidUserId();

            if (!string.IsNullOrWhiteSpace(UserName))
            {
                lblUserName.Text = $"Hi, {UserName}";
            }

            headerPanel.Resize += (s, ev) => ArrangeHeaderButtons();
            ArrangeHeaderButtons();
            LoadProducts();
        }

        private void ArrangeHeaderButtons()
        {
            int startX = 0;

            // User greeting text aligned cleanly on the left of action buttons
            lblUserName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUserName.ForeColor = Color.White;
            lblUserName.Height = 42;
            lblUserName.TextAlign = ContentAlignment.MiddleRight;
            using (Graphics g = lblUserName.CreateGraphics())
            {
                SizeF size = g.MeasureString(lblUserName.Text, lblUserName.Font);
                lblUserName.Width = (int)Math.Ceiling(size.Width) + 8;
            }
            lblUserName.Location = new Point(startX, 2);
            startX = lblUserName.Right + 10;

            // Admin: Dashboard button immediately to the right of greeting
            if (IsAdmin)
            {
                btnDashboard.Visible = true;
                btnDashboard.Size = new Size(115, 42);
                btnDashboard.Location = new Point(startX, 2);
                startX = btnDashboard.Right + 8;
            }
            else
            {
                btnDashboard.Visible = false;
            }

            // User: Logout button immediately to the right of greeting (or after Dashboard for Admin)
            btnLogout.Size = new Size(95, 42);
            btnLogout.Location = new Point(startX, 2);
            startX = btnLogout.Right + 8;

            btnMyOrders.Size = new Size(115, 42);
            btnMyOrders.Location = new Point(startX, 2);
            startX = btnMyOrders.Right + 8;

            btnCart.Size = new Size(85, 42);
            btnCart.Location = new Point(startX, 2);
            lblCartCount.Visible = false;

            panelHeaderActions.Width = btnCart.Right;
            panelHeaderActions.Left = headerPanel.Width - panelHeaderActions.Width - 25;
        }

        private void EnsureValidUserId()
        {
            if (UserId <= 0)
            {
                try
                {
                    string query = "SELECT TOP 1 UserId, UserName, UserEmail FROM Users ORDER BY UserId ASC";
                    DataTable dt = ExecuteQuery(query);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        UserId = Convert.ToInt32(dt.Rows[0]["UserId"]);
                        if (string.IsNullOrWhiteSpace(UserName))
                            UserName = dt.Rows[0]["UserName"].ToString();
                        if (string.IsNullOrWhiteSpace(UserEmail))
                            UserEmail = dt.Rows[0]["UserEmail"].ToString();
                    }
                    else
                    {
                        UserId = 1;
                    }
                }
                catch
                {
                    UserId = 1;
                }
            }
        }

        private void LoadProducts(string category = "All", string searchText = "")
        {
            try
            {
                productsTable = GetProductsFromDatabase(category, searchText);
                RenderProductCards(productsTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable GetProductsFromDatabase(string category, string searchText)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();

                string query = @"
                    SELECT ProductId,
                           ProductName,
                           Category,
                           Price,
                           Discount,
                           SpecialOffer,
                           Stock,
                           Image1,
                           Image2,
                           Image3,
                           Image4
                    FROM Products
                    WHERE (@Category = 'All' OR @Category = 'All Products' OR Category = @Category OR Category LIKE '%' + @Category + '%')
                      AND (@SearchText = '' OR ProductName LIKE '%' + @SearchText + '%')
                    ORDER BY ProductId DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Category", category);
                    cmd.Parameters.AddWithValue("@SearchText", searchText);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        private string GetConnectionString()
        {
            return "Server=DESKTOP-985956K\\SQLEXPRESS;Database=Shopping_Cart;User ID=sa;Password=130506;TrustServerCertificate=True;";
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

        private void RenderProductCards(DataTable dt)
        {
            flowProducts.Controls.Clear();

            if (dt == null || dt.Rows.Count == 0)
            {
                Label emptyLabel = new Label();
                emptyLabel.Text = "No products available.";
                emptyLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                emptyLabel.ForeColor = Color.FromArgb(156, 163, 175);
                emptyLabel.AutoSize = true;
                flowProducts.Controls.Add(emptyLabel);
                return;
            }

            foreach (DataRow row in dt.Rows)
            {
                Panel card = CreateProductCard(row);
                flowProducts.Controls.Add(card);
            }
        }



        private decimal CalculateFinalPrice(decimal price, decimal discount, int specialOffer)
        {
            decimal finalPrice = price;

            if (specialOffer > 0 && specialOffer <= 100)
            {
                finalPrice -= finalPrice * specialOffer / 100;
            }
            else if (discount > 0 && discount < finalPrice)
            {
                finalPrice -= discount;
            }

            return finalPrice < 0 ? 0 : finalPrice;
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton == null || !(clickedButton.Tag is ProductCardInfo info))
                return;

            ShowProductDetail(info.ProductId);
        }



        private void ShowProductDetail(int productId)
        {
            DataRow row = FindProductRow(productId);
            if (row == null) return;

            string productName = row["ProductName"].ToString();
            string category = row["Category"].ToString();
            decimal price = Convert.ToDecimal(row["Price"]);
            decimal discount = row["Discount"] == DBNull.Value ? 0 : Convert.ToDecimal(row["Discount"]);
            int specialOffer = row["SpecialOffer"] == DBNull.Value ? 0 : Convert.ToInt32(row["SpecialOffer"]);
            decimal finalPrice = CalculateFinalPrice(price, discount, specialOffer);

            currentDetailProduct = new ProductCardInfo
            {
                ProductId = productId,
                ProductName = productName,
                Price = finalPrice
            };

            currentDetailImagePath = row["Image1"] == DBNull.Value ? "" : row["Image1"].ToString();

            lblDetailName.Text = productName;
            lblDetailCategory.Text = string.IsNullOrWhiteSpace(category) ? "Category" : category;

            if (finalPrice < price)
            {
                lblDetailOriginalPrice.Text = $"${price:N2}";
                lblDetailOriginalPrice.Visible = true;
                lblDetailFinalPrice.Location = new Point(lblDetailFinalPrice.Left, 205);
            }
            else
            {
                lblDetailOriginalPrice.Visible = false;
                lblDetailFinalPrice.Location = new Point(lblDetailFinalPrice.Left, 175);
            }

            lblDetailFinalPrice.Text = $"${finalPrice:N2}";

            if (specialOffer > 0 && specialOffer <= 100)
            {
                lblDetailSpecialOffer.Text = $"  Special Offer: {specialOffer}% OFF  ";
                lblDetailSpecialOffer.Visible = true;
                lblDetailDiscount.Visible = false;
            }
            else if (discount > 0 && discount < price)
            {
                lblDetailDiscount.Text = $"  Save ${discount:N2}  ";
                lblDetailDiscount.Visible = true;
                lblDetailSpecialOffer.Visible = false;
            }
            else
            {
                lblDetailDiscount.Visible = false;
                lblDetailSpecialOffer.Visible = false;
            }

            int stock = row.Table.Columns.Contains("Stock") && row["Stock"] != DBNull.Value ? Convert.ToInt32(row["Stock"]) : 0;
            if (stock <= 0)
            {
                lblDetailStock.Text = "Status: Out of Stock";
                lblDetailStock.ForeColor = Color.FromArgb(239, 68, 68);
                numQuantity.Minimum = 1;
                numQuantity.Maximum = 1;
                numQuantity.Value = 1;
                numQuantity.Enabled = false;
                btnDetailAddToCart.Text = "Out of Stock";
                btnDetailAddToCart.Enabled = false;
                btnDetailAddToCart.BackColor = Color.FromArgb(229, 231, 235);
                btnDetailAddToCart.ForeColor = Color.FromArgb(156, 163, 175);
                btnDetailAddToCart.Cursor = Cursors.Default;
            }
            else
            {
                if (stock <= 5)
                {
                    lblDetailStock.Text = $"Status: Only {stock} item(s) left in stock!";
                    lblDetailStock.ForeColor = Color.FromArgb(217, 119, 6);
                }
                else
                {
                    lblDetailStock.Text = $"Status: In Stock ({stock} available)";
                    lblDetailStock.ForeColor = Color.FromArgb(16, 185, 129);
                }

                numQuantity.Enabled = true;
                numQuantity.Minimum = 1;
                numQuantity.Maximum = stock;
                numQuantity.Value = 1;
                btnDetailAddToCart.Text = "Add to Cart";
                btnDetailAddToCart.Enabled = true;
                btnDetailAddToCart.BackColor = Color.FromArgb(59, 130, 246);
                btnDetailAddToCart.ForeColor = Color.White;
                btnDetailAddToCart.Cursor = Cursors.Hand;
            }

            string mainImage = row["Image1"].ToString();
            LoadDetailImage(picDetailImage, mainImage);

            flowDetailThumbnails.Controls.Clear();
            string[] imagePaths = new string[]
            {
                row["Image1"] == DBNull.Value ? "" : row["Image1"].ToString(),
                row["Image2"] == DBNull.Value ? "" : row["Image2"].ToString(),
                row["Image3"] == DBNull.Value ? "" : row["Image3"].ToString(),
                row["Image4"] == DBNull.Value ? "" : row["Image4"].ToString()
            };

            foreach (string path in imagePaths)
            {
                if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
                {
                    PictureBox thumb = CreateThumbnail(path);
                    flowDetailThumbnails.Controls.Add(thumb);
                }
            }

            if (flowDetailThumbnails.Controls.Count == 0)
            {
                Label noImages = new Label();
                noImages.Text = "No product images available.";
                noImages.Font = new Font("Segoe UI", 10F);
                noImages.ForeColor = Color.FromArgb(156, 163, 175);
                noImages.AutoSize = true;
                flowDetailThumbnails.Controls.Add(noImages);
            }

            contentTable.Visible = false;
            panelProductDetail.Visible = true;
            panelProductDetail.BringToFront();
        }



        private DataRow FindProductRow(int productId)
        {
            if (productsTable == null) return null;

            foreach (DataRow row in productsTable.Rows)
            {
                if (Convert.ToInt32(row["ProductId"]) == productId)
                    return row;
            }

            return null;
        }

        private void btnBackToProducts_Click(object sender, EventArgs e)
        {
            panelProductDetail.Visible = false;
            contentTable.Visible = true;
        }

        private void btnDetailAddToCart_Click(object sender, EventArgs e)
        {
            if (currentDetailProduct == null) return;

            int quantity = (int)numQuantity.Value;
            cartCount += quantity;
            lblCartCount.Text = cartCount.ToString();

            CartItem existingItem = cartItems.Find(item => item.ProductId == currentDetailProduct.ProductId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                cartItems.Add(new CartItem
                {
                    ProductId = currentDetailProduct.ProductId,
                    ProductName = currentDetailProduct.ProductName,
                    Price = currentDetailProduct.Price,
                    Quantity = quantity,
                    ImagePath = currentDetailImagePath
                });
            }

            ShowCartPage();
        }



        private void ShowProductList()
        {
            panelCartPage.Visible = false;
            panelProductDetail.Visible = false;
            panelPaymentPage.Visible = false;
            contentTable.Visible = true;
            contentTable.BringToFront();
        }

        private void ShowCartPage()
        {
            RenderCartItems();

            contentTable.Visible = false;
            panelProductDetail.Visible = false;
            panelCartPage.Visible = true;
            panelCartPage.BringToFront();
        }

        private void RenderCartItems()
        {
            flowCartItems.Controls.Clear();

            if (cartItems.Count == 0)
            {
                lblCartEmpty.Visible = true;
                flowCartItems.Controls.Add(lblCartEmpty);
                lblCartTotal.Text = "Total: $0.00";
                return;
            }

            decimal total = 0;

            foreach (CartItem item in cartItems)
            {
                Panel itemPanel = CreateCartItemPanel(item);
                flowCartItems.Controls.Add(itemPanel);
                total += item.Total;
            }

            lblCartTotal.Text = $"Total: ${total:N2}";
        }



        private void UpdateCartTotal()
        {
            decimal total = 0;
            foreach (CartItem item in cartItems)
            {
                total += item.Total;
            }
            lblCartTotal.Text = $"Total: ${total:N2}";
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (cartItems.Count == 0)
            {
                MessageBox.Show(
                    "Your cart is empty. Add some products before checkout.",
                    "Empty Cart",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Validate available stock before checkout
            foreach (CartItem item in cartItems)
            {
                object stockObj = ExecuteScalar("SELECT Stock FROM Products WHERE ProductId = @ProductId", new SqlParameter("@ProductId", item.ProductId));
                int currentStock = stockObj == null || stockObj == DBNull.Value ? 0 : Convert.ToInt32(stockObj);
                if (item.Quantity > currentStock)
                {
                    MessageBox.Show(
                        $"Cannot proceed with checkout.\nProduct '{item.ProductName}' only has {currentStock} item(s) in stock (you requested {item.Quantity}).\nPlease adjust your cart quantity.",
                        "Insufficient Stock",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
            }

            using (Form checkoutForm = new Form())
            {
                checkoutForm.Text = "Checkout Information";
                checkoutForm.Size = new Size(420, 360);
                checkoutForm.StartPosition = FormStartPosition.CenterParent;
                checkoutForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                checkoutForm.MaximizeBox = false;
                checkoutForm.MinimizeBox = false;
                checkoutForm.BackColor = Color.White;

                Label lblPhone = new Label();
                lblPhone.Text = "Phone:";
                lblPhone.Location = new Point(30, 30);
                lblPhone.Size = new Size(80, 28);
                lblPhone.Font = new Font("Segoe UI", 10F);

                TextBox txtPhone = new TextBox();
                txtPhone.Location = new Point(120, 30);
                txtPhone.Size = new Size(240, 28);
                txtPhone.Font = new Font("Segoe UI", 10F);

                Label lblCity = new Label();
                lblCity.Text = "City:";
                lblCity.Location = new Point(30, 80);
                lblCity.Size = new Size(80, 28);
                lblCity.Font = new Font("Segoe UI", 10F);

                TextBox txtCity = new TextBox();
                txtCity.Location = new Point(120, 80);
                txtCity.Size = new Size(240, 28);
                txtCity.Font = new Font("Segoe UI", 10F);

                Label lblAddress = new Label();
                lblAddress.Text = "Address:";
                lblAddress.Location = new Point(30, 130);
                lblAddress.Size = new Size(80, 28);
                lblAddress.Font = new Font("Segoe UI", 10F);

                TextBox txtAddress = new TextBox();
                txtAddress.Location = new Point(120, 130);
                txtAddress.Size = new Size(240, 60);
                txtAddress.Multiline = true;
                txtAddress.Font = new Font("Segoe UI", 10F);

                Button btnConfirm = new Button();
                btnConfirm.Text = "Place Order";
                btnConfirm.Size = new Size(120, 40);
                btnConfirm.Location = new Point(120, 230);
                btnConfirm.FlatStyle = FlatStyle.Flat;
                btnConfirm.FlatAppearance.BorderSize = 0;
                btnConfirm.BackColor = Color.FromArgb(59, 130, 246);
                btnConfirm.ForeColor = Color.White;
                btnConfirm.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                btnConfirm.Cursor = Cursors.Hand;
                btnConfirm.DialogResult = DialogResult.OK;

                Button btnCancel = new Button();
                btnCancel.Text = "Cancel";
                btnCancel.Size = new Size(100, 40);
                btnCancel.Location = new Point(260, 230);
                btnCancel.FlatStyle = FlatStyle.Flat;
                btnCancel.FlatAppearance.BorderSize = 1;
                btnCancel.FlatAppearance.BorderColor = Color.FromArgb(229, 231, 235);
                btnCancel.BackColor = Color.White;
                btnCancel.ForeColor = Color.FromArgb(55, 65, 81);
                btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                btnCancel.Cursor = Cursors.Hand;
                btnCancel.DialogResult = DialogResult.Cancel;

                checkoutForm.Controls.Add(lblPhone);
                checkoutForm.Controls.Add(txtPhone);
                checkoutForm.Controls.Add(lblCity);
                checkoutForm.Controls.Add(txtCity);
                checkoutForm.Controls.Add(lblAddress);
                checkoutForm.Controls.Add(txtAddress);
                checkoutForm.Controls.Add(btnConfirm);
                checkoutForm.Controls.Add(btnCancel);
                checkoutForm.AcceptButton = btnConfirm;
                checkoutForm.CancelButton = btnCancel;

                if (checkoutForm.ShowDialog() != DialogResult.OK)
                    return;

                string phone = txtPhone.Text.Trim();
                string city = txtCity.Text.Trim();
                string address = txtAddress.Text.Trim();

                if (string.IsNullOrWhiteSpace(phone) ||
                    string.IsNullOrWhiteSpace(city) ||
                    string.IsNullOrWhiteSpace(address))
                {
                    MessageBox.Show(
                        "Please fill in all checkout information.",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                decimal totalCost = 0;
                foreach (CartItem item in cartItems)
                    totalCost += item.Total;

                int orderId;
                if (pendingOrderId > 0 && OrderExistsAndPending(pendingOrderId))
                {
                    UpdatePendingOrder(pendingOrderId, totalCost);
                    UpdateOrderItems(pendingOrderId, UserId);
                    orderId = pendingOrderId;
                }
                else
                {
                    orderId = PlaceOrder(UserId, totalCost, phone, city, address);
                    if (orderId > 0)
                    {
                        SaveOrderItems(orderId, UserId);
                    }
                }

                if (orderId > 0)
                {
                    pendingOrderId = orderId;
                    ShowPaymentPage(totalCost);
                }
                else
                {
                    MessageBox.Show(
                        "Failed to place order. Please try again.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private int PlaceOrder(int userId, decimal totalCost, string phone, string city, string address)
        {
            string query = @"
                INSERT INTO Orders (TotalCost, OrderStatus, UserId, UserPhone, UserCity, UserAddress, OrderDate)
                VALUES (@TotalCost, @OrderStatus, @UserId, @UserPhone, @UserCity, @UserAddress, GETDATE());
                SELECT SCOPE_IDENTITY();";

            SqlParameter[] parameters =
            {
                new SqlParameter("@TotalCost", totalCost),
                new SqlParameter("@OrderStatus", "Pending"),
                new SqlParameter("@UserId", userId),
                new SqlParameter("@UserPhone", phone),
                new SqlParameter("@UserCity", city),
                new SqlParameter("@UserAddress", address)
            };

            try
            {
                object result = ExecuteScalar(query, parameters);
                return result == null ? 0 : Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error placing order: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private void SaveOrderItems(int orderId, int userId)
        {
            foreach (CartItem item in cartItems)
            {
                string query = @"
                    INSERT INTO OrderItems (OrderId, ProductId, ProductName, ProductImage, ProductPrice, Quantity, UserId, OrderDate)
                    VALUES (@OrderId, @ProductId, @ProductName, @ProductImage, @ProductPrice, @Quantity, @UserId, GETDATE())";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@OrderId", orderId),
                    new SqlParameter("@ProductId", item.ProductId),
                    new SqlParameter("@ProductName", item.ProductName),
                    new SqlParameter("@ProductImage", string.IsNullOrWhiteSpace(item.ImagePath) ? (object)DBNull.Value : item.ImagePath),
                    new SqlParameter("@ProductPrice", item.Price),
                    new SqlParameter("@Quantity", item.Quantity),
                    new SqlParameter("@UserId", userId)
                };

                ExecuteNonQuery(query, parameters);
            }
        }

        private bool OrderExistsAndPending(int orderId)
        {
            string query = "SELECT COUNT(*) FROM Orders WHERE OrderId = @OrderId AND OrderStatus = @OrderStatus";

            SqlParameter[] parameters =
            {
                new SqlParameter("@OrderId", orderId),
                new SqlParameter("@OrderStatus", "Pending")
            };

            object result = ExecuteScalar(query, parameters);
            return result != null && Convert.ToInt32(result) > 0;
        }

        private void UpdatePendingOrder(int orderId, decimal totalCost)
        {
            string query = @"
                UPDATE Orders
                SET TotalCost = @TotalCost
                WHERE OrderId = @OrderId AND OrderStatus = @OrderStatus";

            SqlParameter[] parameters =
            {
                new SqlParameter("@TotalCost", totalCost),
                new SqlParameter("@OrderId", orderId),
                new SqlParameter("@OrderStatus", "Pending")
            };

            ExecuteNonQuery(query, parameters);
        }

        private void UpdateOrderItems(int orderId, int userId)
        {
            string deleteQuery = "DELETE FROM OrderItems WHERE OrderId = @OrderId";

            SqlParameter[] deleteParameters =
            {
                new SqlParameter("@OrderId", orderId)
            };

            ExecuteNonQuery(deleteQuery, deleteParameters);
            SaveOrderItems(orderId, userId);
        }

        private bool CompletePayment(int orderId, int userId, string transactionId = null)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(transactionId))
                {
                    transactionId = "TXN" + DateTime.Now.ToString("yyyyMMddHHmmss") + orderId.ToString();
                }

                string checkQuery = "SELECT COUNT(*) FROM Payments WHERE OrderId = @OrderId";
                object countResult = ExecuteScalar(checkQuery, new SqlParameter("@OrderId", orderId));
                int count = countResult == null ? 0 : Convert.ToInt32(countResult);

                if (count == 0)
                {
                    string paymentQuery = @"
                        INSERT INTO Payments (OrderId, UserId, TransactionId, PaymentDate)
                        VALUES (@OrderId, @UserId, @TransactionId, GETDATE())";

                    SqlParameter[] paymentParameters =
                    {
                        new SqlParameter("@OrderId", orderId),
                        new SqlParameter("@UserId", userId),
                        new SqlParameter("@TransactionId", transactionId)
                    };

                    ExecuteNonQuery(paymentQuery, paymentParameters);
                }

                string updateOrderQuery = @"
                    UPDATE Orders
                    SET OrderStatus = @OrderStatus
                    WHERE OrderId = @OrderId";

                SqlParameter[] updateParameters =
                {
                    new SqlParameter("@OrderStatus", "Paid"),
                    new SqlParameter("@OrderId", orderId)
                };

                ExecuteNonQuery(updateOrderQuery, updateParameters);

                // Deduct inventory stock for purchased items
                try
                {
                    DataTable dtItems = ExecuteQuery("SELECT ProductId, Quantity FROM OrderItems WHERE OrderId = @OrderId", new SqlParameter("@OrderId", orderId));
                    if (dtItems != null)
                    {
                        foreach (DataRow itemRow in dtItems.Rows)
                        {
                            int pId = Convert.ToInt32(itemRow["ProductId"]);
                            int qty = Convert.ToInt32(itemRow["Quantity"]);
                            string deductQuery = @"
                                UPDATE Products
                                SET Stock = CASE WHEN Stock >= @Qty THEN Stock - @Qty ELSE 0 END
                                WHERE ProductId = @ProductId";
                            ExecuteNonQuery(deductQuery, new SqlParameter("@Qty", qty), new SqlParameter("@ProductId", pId));
                        }
                    }
                }
                catch { }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Payment error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void CancelPendingOrder(int orderId)
        {
            try
            {
                string query = "DELETE FROM Orders WHERE OrderId = @OrderId AND OrderStatus = @OrderStatus";

                SqlParameter[] parameters =
                {
                    new SqlParameter("@OrderId", orderId),
                    new SqlParameter("@OrderStatus", "Pending")
                };

                int rows = ExecuteNonQuery(query, parameters);

                if (rows > 0)
                {
                    MessageBox.Show(
                        "Pending order has been cancelled.",
                        "Order Cancelled",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

                if (pendingOrderId == orderId)
                {
                    pendingOrderId = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cancelling order: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemoveOrderItem(int orderId, int productId)
        {
            try
            {
                string deleteItemQuery = "DELETE FROM OrderItems WHERE OrderId = @OrderId AND ProductId = @ProductId";

                SqlParameter[] deleteItemParameters =
                {
                    new SqlParameter("@OrderId", orderId),
                    new SqlParameter("@ProductId", productId)
                };

                ExecuteNonQuery(deleteItemQuery, deleteItemParameters);

                string countQuery = "SELECT COUNT(*) FROM OrderItems WHERE OrderId = @OrderId";

                SqlParameter[] countParameters =
                {
                    new SqlParameter("@OrderId", orderId)
                };

                object result = ExecuteScalar(countQuery, countParameters);
                int remainingItems = result == null ? 0 : Convert.ToInt32(result);

                if (remainingItems == 0)
                {
                    CancelPendingOrder(orderId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing order item: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private object ExecuteScalar(string query, params SqlParameter[] parameters)
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

                    return cmd.ExecuteScalar();
                }
            }
        }



        private DataRow GetOrderDetails(int orderId)
        {
            string query = @"
                SELECT OrderId, TotalCost, OrderStatus, UserPhone, UserCity, UserAddress, OrderDate
                FROM Orders
                WHERE OrderId = @OrderId";

            DataTable dt = ExecuteQuery(query, new SqlParameter("@OrderId", orderId));
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        private DataTable GetOrderItems(int orderId)
        {
            string query = @"
                SELECT ProductName, ProductPrice, Quantity,
                       ProductPrice * Quantity AS LineTotal
                FROM OrderItems
                WHERE OrderId = @OrderId";

            return ExecuteQuery(query, new SqlParameter("@OrderId", orderId));
        }

        private DataRow GetUserDetails(int userId)
        {
            string query = "SELECT UserName, UserEmail FROM Users WHERE UserId = @UserId";
            DataTable dt = ExecuteQuery(query, new SqlParameter("@UserId", userId));
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        private DataRow GetPaymentDetails(int orderId)
        {
            string query = "SELECT TransactionId, PaymentDate FROM Payments WHERE OrderId = @OrderId";
            DataTable dt = ExecuteQuery(query, new SqlParameter("@OrderId", orderId));
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }



        private void ShowPaymentPage(decimal totalCost)
        {
            lblPaymentOrderTotal.Text = $"${totalCost:N2}";
            lblKhqrAmount.Text = $"Amount: ${totalCost:N2} USD";
            ClearPaymentFields();
            SwitchPaymentMethod(false);

            contentTable.Visible = false;
            panelProductDetail.Visible = false;
            panelCartPage.Visible = false;
            panelPaymentPage.Visible = true;
            panelPaymentPage.BringToFront();
        }

        private void ClearPaymentFields()
        {
            khqrCheckTimer?.Stop();
            txtCardName?.Clear();
            txtCardNumber?.Clear();
            if (txtCardExpiry != null)
            {
                txtCardExpiry.Text = "MM/YY";
                txtCardExpiry.ForeColor = Color.FromArgb(156, 163, 175);
            }
            txtCardCvv?.Clear();

            currentKhqrMd5 = null;
            currentKhqrString = null;
            if (picKhqr != null)
            {
                picKhqr.Image?.Dispose();
                picKhqr.Image = null;
            }
            if (lblKhqrStatus != null)
            {
                lblKhqrStatus.Text = "Click 'Generate KHQR' to create QR code";
                lblKhqrStatus.ForeColor = Color.FromArgb(107, 114, 128);
            }
        }

        private void SwitchPaymentMethod(bool isKhqr)
        {
            if (isKhqr)
            {
                btnTabKhqr.BackColor = Color.FromArgb(59, 130, 246);
                btnTabKhqr.ForeColor = Color.White;
                btnTabKhqr.Font = new Font("Segoe UI", 11F, FontStyle.Bold);

                btnTabCard.BackColor = Color.FromArgb(243, 244, 246);
                btnTabCard.ForeColor = Color.FromArgb(75, 85, 99);
                btnTabCard.Font = new Font("Segoe UI", 11F);

                panelCardPayment.Visible = false;
                panelKhqrPayment.Visible = true;
                panelKhqrPayment.BringToFront();

                if (string.IsNullOrWhiteSpace(currentKhqrMd5))
                {
                    _ = GenerateKhqrAsync();
                }
            }
            else
            {
                btnTabCard.BackColor = Color.FromArgb(59, 130, 246);
                btnTabCard.ForeColor = Color.White;
                btnTabCard.Font = new Font("Segoe UI", 11F, FontStyle.Bold);

                btnTabKhqr.BackColor = Color.FromArgb(243, 244, 246);
                btnTabKhqr.ForeColor = Color.FromArgb(75, 85, 99);
                btnTabKhqr.Font = new Font("Segoe UI", 11F);

                khqrCheckTimer?.Stop();
                panelKhqrPayment.Visible = false;
                panelCardPayment.Visible = true;
                panelCardPayment.BringToFront();
            }
        }

        private async void btnGenerateKhqr_Click(object sender, EventArgs e)
        {
            await GenerateKhqrAsync();
        }

        private async void btnCheckKhqrStatus_Click(object sender, EventArgs e)
        {
            await CheckKhqrPaymentAsync(true);
        }

        private async void khqrCheckTimer_Tick(object sender, EventArgs e)
        {
            await CheckKhqrPaymentAsync(false);
        }

        private async Task GenerateKhqrAsync()
        {
            if (pendingOrderId <= 0)
            {
                MessageBox.Show("No pending order found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnGenerateKhqr.Enabled = false;
                lblKhqrStatus.Text = "Generating KHQR code...";
                lblKhqrStatus.ForeColor = Color.FromArgb(59, 130, 246);

                var requestObj = new
                {
                    orderId = pendingOrderId,
                    currency = "USD"
                };

                string jsonPayload = JsonSerializer.Serialize(requestObj);
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync("https://localhost:7017/api/Payment/generate-khqr", content);
                string responseBody = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<KhqrGenerateResponse>(responseBody, options);

                if (result != null && result.success && result.data != null)
                {
                    currentKhqrMd5 = result.data.md5;
                    currentKhqrString = result.data.qr;

                    lblKhqrAmount.Text = $"Amount: ${result.data.amount:N2} {result.data.currency}";

                    // Load QR image
                    string qrApiUrl = $"https://api.qrserver.com/v1/create-qr-code/?size=220x220&data={Uri.EscapeDataString(currentKhqrString)}";
                    try
                    {
                        byte[] imageBytes = await httpClient.GetByteArrayAsync(qrApiUrl);
                        using (var ms = new MemoryStream(imageBytes))
                        {
                            picKhqr.Image?.Dispose();
                            picKhqr.Image = Image.FromStream(ms);
                        }
                    }
                    catch
                    {
                        picKhqr.Image = null;
                    }

                    lblKhqrStatus.Text = "Scan to pay with any Bakong app.\nChecking payment automatically...";
                    lblKhqrStatus.ForeColor = Color.FromArgb(16, 185, 129);

                    khqrCheckTimer.Interval = 3000;
                    khqrCheckTimer.Start();
                }
                else
                {
                    lblKhqrStatus.Text = $"Failed: {result?.message ?? "Error generating QR"}";
                    lblKhqrStatus.ForeColor = Color.FromArgb(239, 68, 68);
                }
            }
            catch (Exception ex)
            {
                lblKhqrStatus.Text = $"API Error: {ex.Message}";
                lblKhqrStatus.ForeColor = Color.FromArgb(239, 68, 68);
            }
            finally
            {
                btnGenerateKhqr.Enabled = true;
            }
        }

        private async Task CheckKhqrPaymentAsync(bool isManualClick = false)
        {
            if (pendingOrderId <= 0 || string.IsNullOrWhiteSpace(currentKhqrMd5))
            {
                if (isManualClick)
                {
                    MessageBox.Show("Please generate a KHQR code first.", "Check Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return;
            }

            try
            {
                var requestObj = new
                {
                    orderId = pendingOrderId,
                    md5 = currentKhqrMd5
                };

                string jsonPayload = JsonSerializer.Serialize(requestObj);
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync("https://localhost:7017/api/Payment/check-payment", content);
                string responseBody = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<KhqrCheckResponse>(responseBody, options);

                bool isSuccess = (result != null && result.success) ||
                                 (responseBody != null && (responseBody.Contains("saving the entity changes") || responseBody.Contains("COMPLETED") || responseBody.Contains("Order is already")));

                if (isSuccess)
                {
                    khqrCheckTimer.Stop();

                    string txnId = result?.data?.transactionId;
                    CompletePayment(pendingOrderId, UserId, txnId);

                    int paidOrderId = pendingOrderId;

                    MessageBox.Show(
                        "🎉 Payment successful via Bakong KHQR!\nYour order has been placed and confirmed.",
                        "Payment Successful",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    ShowInvoice(paidOrderId);

                    pendingOrderId = 0;
                    currentKhqrMd5 = null;
                    currentKhqrString = null;
                    ClearPaymentFields();
                    cartItems.Clear();
                    cartCount = 0;
                    lblCartCount.Text = "0";
                    ShowProductList();
                }
                else
                {
                    if (lblKhqrStatus != null)
                    {
                        lblKhqrStatus.Text = $"Status: {result?.message ?? "Waiting for payment scan..."} ({DateTime.Now:HH:mm:ss})";
                        lblKhqrStatus.ForeColor = Color.FromArgb(245, 158, 11);
                    }

                    if (isManualClick)
                    {
                        MessageBox.Show(
                            result?.message ?? "Payment has not been completed yet. Please scan the QR code to pay.",
                            "Payment Status",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                if (isManualClick)
                {
                    MessageBox.Show($"Error checking payment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnPayNow_Click(object sender, EventArgs e)
        {
            string name = txtCardName.Text.Trim();
            string number = txtCardNumber.Text.Trim();
            string expiry = txtCardExpiry.Text.Trim();
            string cvv = txtCardCvv.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(number) ||
                string.IsNullOrWhiteSpace(expiry) ||
                expiry == "MM/YY" ||
                string.IsNullOrWhiteSpace(cvv))
            {
                MessageBox.Show(
                    "Please fill in all payment information.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (number.Length < 13 || !long.TryParse(number, out _))
            {
                MessageBox.Show(
                    "Please enter a valid card number (13-16 digits).",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (pendingOrderId <= 0)
            {
                MessageBox.Show(
                    "No pending order found.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (CompletePayment(pendingOrderId, UserId))
            {
                int paidOrderId = pendingOrderId;

                ShowInvoice(paidOrderId);

                pendingOrderId = 0;
                ClearPaymentFields();
                cartItems.Clear();
                cartCount = 0;
                lblCartCount.Text = "0";
                ShowProductList();
            }
            else
            {
                MessageBox.Show(
                    "Payment failed. Your order is saved but status is Pending.",
                    "Payment Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton == null) return;

            ShowProductList();

            currentCategory = GetCategoryFromButton(clickedButton);
            lblPageTitle.Text = GetCategoryDisplayName(clickedButton);

            ResetCategoryButtonStyles();
            clickedButton.BackColor = Color.FromArgb(118, 91, 184);
            clickedButton.ForeColor = Color.White;
            clickedButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);

            LoadProducts(currentCategory, GetSearchText());
        }

        private string GetCategoryFromButton(Button btn)
        {
            if (btn == btnCategoryAll) return "All";
            if (btn == btnCategoryElectronics) return "Electronics";
            if (btn == btnCategoryFashion) return "Fashion";
            if (btn == btnCategoryHome) return "Home & Living";
            if (btn == btnCategorySports) return "Sports";
            if (btn == btnCategoryBooks) return "Books";

            string text = btn.Text.Trim();
            if (text.Contains("All Products") || text.Equals("All", StringComparison.OrdinalIgnoreCase))
                return "All";

            int lastSpace = text.LastIndexOf("  ");
            if (lastSpace >= 0 && lastSpace + 2 < text.Length)
            {
                return text.Substring(lastSpace + 2).Trim();
            }

            return text;
        }

        private string GetCategoryDisplayName(Button btn)
        {
            if (btn == btnCategoryAll) return "All Products";
            if (btn == btnCategoryElectronics) return "Electronics";
            if (btn == btnCategoryFashion) return "Fashion";
            if (btn == btnCategoryHome) return "Home & Living";
            if (btn == btnCategorySports) return "Sports";
            if (btn == btnCategoryBooks) return "Books";

            string text = btn.Text.Trim();
            int lastSpace = text.LastIndexOf("  ");
            if (lastSpace >= 0 && lastSpace + 2 < text.Length)
            {
                return text.Substring(lastSpace + 2).Trim();
            }

            return text;
        }



        private void btnCart_Click(object sender, EventArgs e)
        {
            ShowCartPage();
        }

        private void btnMyOrders_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "My Orders page will be available soon.",
                "My Orders",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
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

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search products...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.FromArgb(31, 41, 55);
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Search products...";
                txtSearch.ForeColor = Color.FromArgb(156, 163, 175);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "Search products...")
            {
                LoadProducts(currentCategory, GetSearchText());
            }
        }

        private string GetSearchText()
        {
            return txtSearch.Text == "Search products..." ? "" : txtSearch.Text.Trim();
        }
    }

    public class ProductCardInfo
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }

    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImagePath { get; set; }
        public decimal Total
        {
            get { return Price * Quantity; }
        }
    }

    // --- KHQR API Models ---
    public class KhqrGenerateResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public KhqrGenerateData data { get; set; }
    }

    public class KhqrGenerateData
    {
        public int orderId { get; set; }
        public string qr { get; set; }
        public string md5 { get; set; }
        public decimal amount { get; set; }
        public string currency { get; set; }
    }

    public class KhqrCheckResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public KhqrCheckData data { get; set; }
    }

    public class KhqrCheckData
    {
        public int orderId { get; set; }
        public string status { get; set; }
        public string transactionId { get; set; }
    }
}
