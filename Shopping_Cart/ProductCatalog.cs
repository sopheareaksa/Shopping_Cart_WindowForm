using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Shopping_Cart
{
    public partial class ProductCatalog : Form
    {
        private int cartCount = 0;
        private DataTable productsTable;
        private System.Collections.Generic.List<CartItem> cartItems = new System.Collections.Generic.List<CartItem>();

        private Panel panelProductDetail;
        private PictureBox picDetailImage;
        private Label lblDetailName;
        private Label lblDetailCategory;
        private Label lblDetailOriginalPrice;
        private Label lblDetailFinalPrice;
        private Label lblDetailDiscount;
        private Label lblDetailSpecialOffer;
        private NumericUpDown numQuantity;
        private Button btnBackToProducts;
        private Button btnDetailAddToCart;
        private FlowLayoutPanel flowDetailThumbnails;
        private ProductCardInfo currentDetailProduct;
        private string currentDetailImagePath;

        private Panel panelCartPage;
        private FlowLayoutPanel flowCartItems;
        private Label lblCartTotal;
        private Label lblCartEmpty;
        private Button btnContinueShopping;
        private Button btnCheckout;

        private Panel panelPaymentPage;
        private TextBox txtCardName;
        private TextBox txtCardNumber;
        private TextBox txtCardExpiry;
        private TextBox txtCardCvv;
        private Label lblPaymentOrderTotal;
        private int pendingOrderId;

        public string UserName { get; set; }
        public int UserId { get; set; }
        public string UserEmail { get; set; }

        public ProductCatalog()
        {
            InitializeComponent();
            BuildProductDetailPanel();
            BuildCartPanel();
            BuildPaymentPanel();
        }

        private void ProductCatalog_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                lblUserName.Text = $"Hi, {UserName}";
            }

            LoadProducts();
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
                           Image1,
                           Image2,
                           Image3,
                           Image4
                    FROM Products
                    WHERE (@Category = 'All' OR Category = @Category)
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

        private Panel CreateProductCard(DataRow row)
        {
            int productId = Convert.ToInt32(row["ProductId"]);
            string productName = row["ProductName"].ToString();
            decimal price = Convert.ToDecimal(row["Price"]);
            decimal discount = row["Discount"] == DBNull.Value ? 0 : Convert.ToDecimal(row["Discount"]);
            int specialOffer = row["SpecialOffer"] == DBNull.Value ? 0 : Convert.ToInt32(row["SpecialOffer"]);
            string imagePath = row["Image1"].ToString();

            decimal finalPrice = CalculateFinalPrice(price, discount, specialOffer);

            Panel card = new Panel();
            card.Size = new Size(210, 290);
            card.BackColor = Color.White;
            card.Margin = new Padding(0, 0, 15, 20);

            TableLayoutPanel table = new TableLayoutPanel();
            table.Dock = DockStyle.Fill;
            table.ColumnCount = 1;
            table.RowCount = 4;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 160F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));

            PictureBox pictureBox = new PictureBox();
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.BackColor = Color.FromArgb(219, 234, 254);
            pictureBox.Margin = new Padding(10, 10, 10, 0);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            if (!string.IsNullOrWhiteSpace(imagePath) && File.Exists(imagePath))
            {
                try
                {
                    pictureBox.Image = Image.FromFile(imagePath);
                }
                catch
                {
                    pictureBox.Controls.Add(CreateImagePlaceholder());
                }
            }
            else
            {
                pictureBox.Controls.Add(CreateImagePlaceholder());
            }

            Label nameLabel = new Label();
            nameLabel.Text = productName;
            nameLabel.Dock = DockStyle.Fill;
            nameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            nameLabel.ForeColor = Color.FromArgb(31, 41, 55);
            nameLabel.Margin = new Padding(12, 0, 12, 0);
            nameLabel.TextAlign = ContentAlignment.MiddleLeft;

            Label priceLabel = new Label();
            priceLabel.Text = $"${finalPrice:N2}";
            priceLabel.Dock = DockStyle.Fill;
            priceLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            priceLabel.ForeColor = Color.FromArgb(59, 130, 246);
            priceLabel.Margin = new Padding(12, 0, 12, 0);
            priceLabel.TextAlign = ContentAlignment.MiddleLeft;

            Button addButton = new Button();
            addButton.Text = "Add to Cart";
            addButton.Dock = DockStyle.Fill;
            addButton.BackColor = Color.FromArgb(59, 130, 246);
            addButton.ForeColor = Color.White;
            addButton.FlatStyle = FlatStyle.Flat;
            addButton.FlatAppearance.BorderSize = 0;
            addButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            addButton.Margin = new Padding(12, 5, 12, 10);
            addButton.Cursor = Cursors.Hand;
            addButton.Tag = new ProductCardInfo
            {
                ProductId = productId,
                ProductName = productName,
                Price = finalPrice
            };
            addButton.Click += btnAddToCart_Click;

            table.Controls.Add(pictureBox, 0, 0);
            table.Controls.Add(nameLabel, 0, 1);
            table.Controls.Add(priceLabel, 0, 2);
            table.Controls.Add(addButton, 0, 3);

            card.Controls.Add(table);
            return card;
        }

        private Label CreateImagePlaceholder()
        {
            Label placeholder = new Label();
            placeholder.Text = "Product Image";
            placeholder.Dock = DockStyle.Fill;
            placeholder.Font = new Font("Segoe UI", 10F);
            placeholder.ForeColor = Color.FromArgb(107, 114, 128);
            placeholder.TextAlign = ContentAlignment.MiddleCenter;
            return placeholder;
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

        private void BuildProductDetailPanel()
        {
            panelProductDetail = new Panel();
            panelProductDetail.Dock = DockStyle.Fill;
            panelProductDetail.BackColor = Color.FromArgb(249, 250, 251);
            panelProductDetail.Padding = new Padding(30);
            panelProductDetail.Visible = false;
            panelProductDetail.AutoScroll = true;
            contentPanel.Controls.Add(panelProductDetail);
            panelProductDetail.BringToFront();

            TableLayoutPanel detailTable = new TableLayoutPanel();
            detailTable.Dock = DockStyle.Fill;
            detailTable.ColumnCount = 2;
            detailTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            detailTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
            detailTable.RowCount = 1;
            detailTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            Panel imagePanel = new Panel();
            imagePanel.Dock = DockStyle.Fill;
            imagePanel.BackColor = Color.White;
            imagePanel.Padding = new Padding(20);

            picDetailImage = new PictureBox();
            picDetailImage.Dock = DockStyle.Fill;
            picDetailImage.BackColor = Color.FromArgb(243, 244, 246);
            picDetailImage.SizeMode = PictureBoxSizeMode.Zoom;
            picDetailImage.Margin = new Padding(0);
            imagePanel.Controls.Add(picDetailImage);

            flowDetailThumbnails = new FlowLayoutPanel();
            flowDetailThumbnails.Dock = DockStyle.Bottom;
            flowDetailThumbnails.Height = 80;
            flowDetailThumbnails.BackColor = Color.White;
            flowDetailThumbnails.Padding = new Padding(0, 15, 0, 0);
            flowDetailThumbnails.AutoScroll = true;
            flowDetailThumbnails.WrapContents = false;
            imagePanel.Controls.Add(flowDetailThumbnails);
            flowDetailThumbnails.BringToFront();

            Panel infoPanel = new Panel();
            infoPanel.Dock = DockStyle.Fill;
            infoPanel.BackColor = Color.White;
            infoPanel.Padding = new Padding(30);

            btnBackToProducts = new Button();
            btnBackToProducts.Text = "← Back to Products";
            btnBackToProducts.AutoSize = true;
            btnBackToProducts.FlatStyle = FlatStyle.Flat;
            btnBackToProducts.FlatAppearance.BorderSize = 0;
            btnBackToProducts.Font = new Font("Segoe UI", 10F);
            btnBackToProducts.ForeColor = Color.FromArgb(59, 130, 246);
            btnBackToProducts.BackColor = Color.White;
            btnBackToProducts.Cursor = Cursors.Hand;
            btnBackToProducts.Location = new Point(30, 30);
            btnBackToProducts.Click += btnBackToProducts_Click;
            infoPanel.Controls.Add(btnBackToProducts);

            lblDetailName = new Label();
            lblDetailName.AutoSize = true;
            lblDetailName.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblDetailName.ForeColor = Color.FromArgb(31, 41, 55);
            lblDetailName.Location = new Point(30, 75);
            lblDetailName.MaximumSize = new Size(420, 0);
            infoPanel.Controls.Add(lblDetailName);

            lblDetailCategory = new Label();
            lblDetailCategory.AutoSize = true;
            lblDetailCategory.Font = new Font("Segoe UI", 11F);
            lblDetailCategory.ForeColor = Color.FromArgb(107, 114, 128);
            lblDetailCategory.Location = new Point(30, 120);
            infoPanel.Controls.Add(lblDetailCategory);

            lblDetailOriginalPrice = new Label();
            lblDetailOriginalPrice.AutoSize = true;
            lblDetailOriginalPrice.Font = new Font("Segoe UI", 14F, FontStyle.Strikeout);
            lblDetailOriginalPrice.ForeColor = Color.FromArgb(156, 163, 175);
            lblDetailOriginalPrice.Location = new Point(30, 175);
            infoPanel.Controls.Add(lblDetailOriginalPrice);

            lblDetailFinalPrice = new Label();
            lblDetailFinalPrice.AutoSize = true;
            lblDetailFinalPrice.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblDetailFinalPrice.ForeColor = Color.FromArgb(59, 130, 246);
            lblDetailFinalPrice.Location = new Point(30, 205);
            infoPanel.Controls.Add(lblDetailFinalPrice);

            lblDetailDiscount = new Label();
            lblDetailDiscount.AutoSize = true;
            lblDetailDiscount.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDetailDiscount.ForeColor = Color.FromArgb(239, 68, 68);
            lblDetailDiscount.BackColor = Color.FromArgb(254, 226, 226);
            lblDetailDiscount.Padding = new Padding(8, 4, 8, 4);
            lblDetailDiscount.Location = new Point(30, 270);
            lblDetailDiscount.Visible = false;
            infoPanel.Controls.Add(lblDetailDiscount);

            lblDetailSpecialOffer = new Label();
            lblDetailSpecialOffer.AutoSize = true;
            lblDetailSpecialOffer.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDetailSpecialOffer.ForeColor = Color.White;
            lblDetailSpecialOffer.BackColor = Color.FromArgb(245, 158, 11);
            lblDetailSpecialOffer.Padding = new Padding(8, 4, 8, 4);
            lblDetailSpecialOffer.Location = new Point(30, 270);
            lblDetailSpecialOffer.Visible = false;
            infoPanel.Controls.Add(lblDetailSpecialOffer);

            Label lblQuantity = new Label();
            lblQuantity.Text = "Quantity:";
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblQuantity.ForeColor = Color.FromArgb(31, 41, 55);
            lblQuantity.Location = new Point(30, 330);
            infoPanel.Controls.Add(lblQuantity);

            numQuantity = new NumericUpDown();
            numQuantity.Font = new Font("Segoe UI", 12F);
            numQuantity.Minimum = 1;
            numQuantity.Maximum = 99;
            numQuantity.Value = 1;
            numQuantity.Width = 80;
            numQuantity.Location = new Point(130, 325);
            infoPanel.Controls.Add(numQuantity);

            btnDetailAddToCart = new Button();
            btnDetailAddToCart.Text = "Add to Cart";
            btnDetailAddToCart.Size = new Size(220, 55);
            btnDetailAddToCart.FlatStyle = FlatStyle.Flat;
            btnDetailAddToCart.FlatAppearance.BorderSize = 0;
            btnDetailAddToCart.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDetailAddToCart.ForeColor = Color.White;
            btnDetailAddToCart.BackColor = Color.FromArgb(59, 130, 246);
            btnDetailAddToCart.Cursor = Cursors.Hand;
            btnDetailAddToCart.Location = new Point(30, 395);
            btnDetailAddToCart.Click += btnDetailAddToCart_Click;
            infoPanel.Controls.Add(btnDetailAddToCart);

            detailTable.Controls.Add(imagePanel, 0, 0);
            detailTable.Controls.Add(infoPanel, 1, 0);
            panelProductDetail.Controls.Add(detailTable);
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

            numQuantity.Value = 1;

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

        private PictureBox CreateThumbnail(string imagePath)
        {
            PictureBox thumb = new PictureBox();
            thumb.Size = new Size(60, 60);
            thumb.SizeMode = PictureBoxSizeMode.Zoom;
            thumb.BackColor = Color.FromArgb(243, 244, 246);
            thumb.Margin = new Padding(0, 0, 10, 0);
            thumb.Cursor = Cursors.Hand;
            thumb.BorderStyle = BorderStyle.FixedSingle;

            try
            {
                thumb.Image = Image.FromFile(imagePath);
            }
            catch
            {
                thumb.BackColor = Color.FromArgb(229, 231, 235);
            }

            thumb.Click += (s, e) =>
            {
                picDetailImage.Image?.Dispose();
                try
                {
                    picDetailImage.Image = Image.FromFile(imagePath);
                }
                catch
                {
                    picDetailImage.Image = null;
                }
            };

            return thumb;
        }

        private void LoadDetailImage(PictureBox pictureBox, string imagePath)
        {
            pictureBox.Image?.Dispose();
            pictureBox.Image = null;

            if (!string.IsNullOrWhiteSpace(imagePath) && File.Exists(imagePath))
            {
                try
                {
                    pictureBox.Image = Image.FromFile(imagePath);
                }
                catch
                {
                    pictureBox.BackColor = Color.FromArgb(229, 231, 235);
                }
            }
            else
            {
                pictureBox.BackColor = Color.FromArgb(229, 231, 235);
            }
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

        private void BuildCartPanel()
        {
            panelCartPage = new Panel();
            panelCartPage.Dock = DockStyle.Fill;
            panelCartPage.BackColor = Color.FromArgb(249, 250, 251);
            panelCartPage.Padding = new Padding(30);
            panelCartPage.Visible = false;
            panelCartPage.AutoScroll = true;
            contentPanel.Controls.Add(panelCartPage);
            panelCartPage.BringToFront();

            TableLayoutPanel cartTable = new TableLayoutPanel();
            cartTable.Dock = DockStyle.Fill;
            cartTable.ColumnCount = 1;
            cartTable.RowCount = 3;
            cartTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            cartTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            cartTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));

            Panel cartHeader = new Panel();
            cartHeader.Dock = DockStyle.Fill;
            cartHeader.BackColor = Color.FromArgb(249, 250, 251);

            Button btnBack = new Button();
            btnBack.Text = "← Back to Products";
            btnBack.AutoSize = true;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Font = new Font("Segoe UI", 10F);
            btnBack.ForeColor = Color.FromArgb(59, 130, 246);
            btnBack.BackColor = Color.FromArgb(249, 250, 251);
            btnBack.Cursor = Cursors.Hand;
            btnBack.Location = new Point(0, 10);
            btnBack.Click += (s, ev) => ShowProductList();
            cartHeader.Controls.Add(btnBack);

            Label lblTitle = new Label();
            lblTitle.Text = "Shopping Cart";
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(31, 41, 55);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(0, 45);
            cartHeader.Controls.Add(lblTitle);

            Panel cartItemsPanel = new Panel();
            cartItemsPanel.Dock = DockStyle.Fill;
            cartItemsPanel.BackColor = Color.White;
            cartItemsPanel.Padding = new Padding(20);
            cartItemsPanel.AutoScroll = true;

            flowCartItems = new FlowLayoutPanel();
            flowCartItems.Dock = DockStyle.Fill;
            flowCartItems.BackColor = Color.White;
            flowCartItems.FlowDirection = FlowDirection.TopDown;
            flowCartItems.WrapContents = false;
            flowCartItems.AutoScroll = true;
            cartItemsPanel.Controls.Add(flowCartItems);

            lblCartEmpty = new Label();
            lblCartEmpty.Text = "Your cart is empty.";
            lblCartEmpty.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCartEmpty.ForeColor = Color.FromArgb(156, 163, 175);
            lblCartEmpty.AutoSize = true;
            lblCartEmpty.Visible = false;
            flowCartItems.Controls.Add(lblCartEmpty);

            Panel cartFooter = new Panel();
            cartFooter.Dock = DockStyle.Fill;
            cartFooter.BackColor = Color.White;
            cartFooter.Padding = new Padding(20);

            lblCartTotal = new Label();
            lblCartTotal.Text = "Total: $0.00";
            lblCartTotal.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblCartTotal.ForeColor = Color.FromArgb(31, 41, 55);
            lblCartTotal.AutoSize = true;
            lblCartTotal.Location = new Point(20, 25);
            cartFooter.Controls.Add(lblCartTotal);

            btnContinueShopping = new Button();
            btnContinueShopping.Text = "Continue Shopping";
            btnContinueShopping.Size = new Size(180, 50);
            btnContinueShopping.FlatStyle = FlatStyle.Flat;
            btnContinueShopping.FlatAppearance.BorderSize = 1;
            btnContinueShopping.FlatAppearance.BorderColor = Color.FromArgb(229, 231, 235);
            btnContinueShopping.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnContinueShopping.ForeColor = Color.FromArgb(55, 65, 81);
            btnContinueShopping.BackColor = Color.White;
            btnContinueShopping.Cursor = Cursors.Hand;
            btnContinueShopping.Location = new Point(400, 20);
            btnContinueShopping.Click += (s, ev) => ShowProductList();
            cartFooter.Controls.Add(btnContinueShopping);

            btnCheckout = new Button();
            btnCheckout.Text = "Checkout";
            btnCheckout.Size = new Size(180, 50);
            btnCheckout.FlatStyle = FlatStyle.Flat;
            btnCheckout.FlatAppearance.BorderSize = 0;
            btnCheckout.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCheckout.ForeColor = Color.White;
            btnCheckout.BackColor = Color.FromArgb(59, 130, 246);
            btnCheckout.Cursor = Cursors.Hand;
            btnCheckout.Location = new Point(600, 20);
            btnCheckout.Click += (s, ev) => btnCheckout_Click(s, ev);
            cartFooter.Controls.Add(btnCheckout);

            cartTable.Controls.Add(cartHeader, 0, 0);
            cartTable.Controls.Add(cartItemsPanel, 0, 1);
            cartTable.Controls.Add(cartFooter, 0, 2);
            panelCartPage.Controls.Add(cartTable);
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

        private Panel CreateCartItemPanel(CartItem item)
        {
            Panel panel = new Panel();
            panel.Size = new Size(820, 110);
            panel.BackColor = Color.White;
            panel.Margin = new Padding(0, 0, 0, 15);
            panel.BorderStyle = BorderStyle.FixedSingle;

            PictureBox pic = new PictureBox();
            pic.Size = new Size(90, 90);
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.BackColor = Color.FromArgb(243, 244, 246);
            pic.Location = new Point(10, 10);

            if (!string.IsNullOrWhiteSpace(item.ImagePath) && File.Exists(item.ImagePath))
            {
                try
                {
                    pic.Image = Image.FromFile(item.ImagePath);
                }
                catch { }
            }

            Label lblName = new Label();
            lblName.Text = item.ProductName;
            lblName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblName.ForeColor = Color.FromArgb(31, 41, 55);
            lblName.Location = new Point(115, 15);
            lblName.Size = new Size(300, 28);

            Label lblPrice = new Label();
            lblPrice.Text = $"${item.Price:N2} each";
            lblPrice.Font = new Font("Segoe UI", 10F);
            lblPrice.ForeColor = Color.FromArgb(107, 114, 128);
            lblPrice.Location = new Point(115, 48);
            lblPrice.Size = new Size(150, 24);

            Label lblTotal = new Label();

            NumericUpDown numQty = new NumericUpDown();
            numQty.Font = new Font("Segoe UI", 11F);
            numQty.Minimum = 1;
            numQty.Maximum = 99;
            numQty.Value = item.Quantity;
            numQty.Width = 70;
            numQty.Location = new Point(430, 38);
            numQty.ValueChanged += (s, ev) =>
            {
                int oldQuantity = item.Quantity;
                item.Quantity = (int)numQty.Value;
                cartCount += item.Quantity - oldQuantity;
                lblCartCount.Text = cartCount.ToString();
                lblTotal.Text = $"Total: ${item.Total:N2}";
                UpdateCartTotal();
            };
            lblTotal.Text = $"Total: ${item.Total:N2}";
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(59, 130, 246);
            lblTotal.Location = new Point(530, 40);
            lblTotal.Size = new Size(150, 28);
            lblTotal.Tag = item;

            Button btnRemove = new Button();
            btnRemove.Text = "Remove";
            btnRemove.Size = new Size(100, 36);
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.FlatAppearance.BorderSize = 0;
            btnRemove.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRemove.ForeColor = Color.White;
            btnRemove.BackColor = Color.FromArgb(239, 68, 68);
            btnRemove.Cursor = Cursors.Hand;
            btnRemove.Location = new Point(700, 37);
            btnRemove.Click += (s, ev) =>
            {
                cartCount -= item.Quantity;
                lblCartCount.Text = cartCount.ToString();
                cartItems.Remove(item);

                if (pendingOrderId > 0)
                {
                    RemoveOrderItem(pendingOrderId, item.ProductId);
                }

                RenderCartItems();
            };

            panel.Controls.Add(pic);
            panel.Controls.Add(lblName);
            panel.Controls.Add(lblPrice);
            panel.Controls.Add(numQty);
            panel.Controls.Add(lblTotal);
            panel.Controls.Add(btnRemove);

            return panel;
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

        private bool CompletePayment(int orderId, int userId)
        {
            try
            {
                string transactionId = "TXN" + DateTime.Now.ToString("yyyyMMddHHmmss") + orderId.ToString();

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

        private TextBox CreateModernTextBox(int width, int height)
        {
            TextBox textBox = new TextBox();
            textBox.Size = new Size(width, height);
            textBox.Font = new Font("Segoe UI", 11F);
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.BackColor = Color.White;
            textBox.ForeColor = Color.FromArgb(31, 41, 55);
            textBox.Padding = new Padding(10, 8, 10, 8);
            return textBox;
        }

        private Label CreateFieldLabel(string text)
        {
            Label label = new Label();
            label.Text = text;
            label.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label.ForeColor = Color.FromArgb(55, 65, 81);
            label.AutoSize = true;
            return label;
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

        private void BuildPaymentPanel()
        {
            panelPaymentPage = new Panel();
            panelPaymentPage.Dock = DockStyle.Fill;
            panelPaymentPage.BackColor = Color.FromArgb(249, 250, 251);
            panelPaymentPage.Padding = new Padding(20);
            panelPaymentPage.Visible = false;
            panelPaymentPage.AutoScroll = true;
            contentPanel.Controls.Add(panelPaymentPage);
            panelPaymentPage.BringToFront();

            Panel centerPanel = new Panel();
            centerPanel.Size = new Size(520, 540);
            centerPanel.BackColor = Color.White;
            centerPanel.Padding = new Padding(0);
            centerPanel.Location = new Point(
                (panelPaymentPage.Width - centerPanel.Width) / 2,
                10);
            centerPanel.Anchor = AnchorStyles.Top;
            panelPaymentPage.Controls.Add(centerPanel);
            panelPaymentPage.Resize += (s, ev) =>
            {
                centerPanel.Left = (panelPaymentPage.Width - centerPanel.Width) / 2;
            };

            Label lblTitle = new Label();
            lblTitle.Text = "Secure Payment";
            lblTitle.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(31, 41, 55);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(35, 25);
            centerPanel.Controls.Add(lblTitle);

            Label lblSubtitle = new Label();
            lblSubtitle.Text = "Complete your purchase with confidence";
            lblSubtitle.Font = new Font("Segoe UI", 11F);
            lblSubtitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblSubtitle.AutoSize = true;
            lblSubtitle.Location = new Point(35, 65);
            centerPanel.Controls.Add(lblSubtitle);

            Panel totalPanel = new Panel();
            totalPanel.Size = new Size(450, 70);
            totalPanel.BackColor = Color.FromArgb(239, 246, 255);
            totalPanel.Location = new Point(35, 105);
            totalPanel.Padding = new Padding(0);
            centerPanel.Controls.Add(totalPanel);

            Label lblTotalText = new Label();
            lblTotalText.Text = "Order Total";
            lblTotalText.Font = new Font("Segoe UI", 11F);
            lblTotalText.ForeColor = Color.FromArgb(59, 130, 246);
            lblTotalText.Location = new Point(15, 10);
            lblTotalText.Size = new Size(120, 24);
            totalPanel.Controls.Add(lblTotalText);

            lblPaymentOrderTotal = new Label();
            lblPaymentOrderTotal.Text = "$0.00";
            lblPaymentOrderTotal.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblPaymentOrderTotal.ForeColor = Color.FromArgb(59, 130, 246);
            lblPaymentOrderTotal.AutoSize = true;
            lblPaymentOrderTotal.Location = new Point(15, 32);
            totalPanel.Controls.Add(lblPaymentOrderTotal);

            Panel formPanel = new Panel();
            formPanel.Size = new Size(450, 220);
            formPanel.BackColor = Color.White;
            formPanel.Location = new Point(35, 185);
            centerPanel.Controls.Add(formPanel);

            Label lblName = CreateFieldLabel("Cardholder Name");
            lblName.Location = new Point(0, 0);
            formPanel.Controls.Add(lblName);

            txtCardName = CreateModernTextBox(450, 36);
            txtCardName.Location = new Point(0, 25);
            formPanel.Controls.Add(txtCardName);

            Label lblNumber = CreateFieldLabel("Card Number");
            lblNumber.Location = new Point(0, 75);
            formPanel.Controls.Add(lblNumber);

            txtCardNumber = CreateModernTextBox(450, 36);
            txtCardNumber.Location = new Point(0, 100);
            txtCardNumber.MaxLength = 16;
            formPanel.Controls.Add(txtCardNumber);

            Label lblExpiry = CreateFieldLabel("Expiry Date");
            lblExpiry.Location = new Point(0, 155);
            formPanel.Controls.Add(lblExpiry);

            txtCardExpiry = CreateModernTextBox(210, 36);
            txtCardExpiry.Location = new Point(0, 180);
            txtCardExpiry.MaxLength = 5;
            txtCardExpiry.Text = "MM/YY";
            txtCardExpiry.ForeColor = Color.FromArgb(156, 163, 175);
            txtCardExpiry.Enter += (s, ev) =>
            {
                if (txtCardExpiry.Text == "MM/YY")
                {
                    txtCardExpiry.Text = "";
                    txtCardExpiry.ForeColor = Color.FromArgb(31, 41, 55);
                }
            };
            txtCardExpiry.Leave += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtCardExpiry.Text))
                {
                    txtCardExpiry.Text = "MM/YY";
                    txtCardExpiry.ForeColor = Color.FromArgb(156, 163, 175);
                }
            };
            formPanel.Controls.Add(txtCardExpiry);

            Label lblCvv = CreateFieldLabel("CVV");
            lblCvv.Location = new Point(240, 155);
            formPanel.Controls.Add(lblCvv);

            txtCardCvv = CreateModernTextBox(210, 36);
            txtCardCvv.Location = new Point(240, 180);
            txtCardCvv.MaxLength = 4;
            txtCardCvv.PasswordChar = '*';
            formPanel.Controls.Add(txtCardCvv);

            Button btnContinue = new Button();
            btnContinue.Text = "Continue Shopping";
            btnContinue.Size = new Size(210, 54);
            btnContinue.FlatStyle = FlatStyle.Flat;
            btnContinue.FlatAppearance.BorderSize = 1;
            btnContinue.FlatAppearance.BorderColor = Color.FromArgb(229, 231, 235);
            btnContinue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnContinue.ForeColor = Color.FromArgb(55, 65, 81);
            btnContinue.BackColor = Color.White;
            btnContinue.Cursor = Cursors.Hand;
            btnContinue.Location = new Point(35, 420);
            btnContinue.Click += (s, ev) =>
            {
                ClearPaymentFields();
                ShowProductList();
            };
            centerPanel.Controls.Add(btnContinue);

            Button btnPay = new Button();
            btnPay.Text = "Pay Now";
            btnPay.Size = new Size(210, 54);
            btnPay.FlatStyle = FlatStyle.Flat;
            btnPay.FlatAppearance.BorderSize = 0;
            btnPay.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnPay.ForeColor = Color.White;
            btnPay.BackColor = Color.FromArgb(59, 130, 246);
            btnPay.Cursor = Cursors.Hand;
            btnPay.Location = new Point(275, 420);
            btnPay.Click += btnPayNow_Click;
            centerPanel.Controls.Add(btnPay);

            Label lblSecure = new Label();
            lblSecure.Text = "🔒 Secure 256-bit SSL Encrypted";
            lblSecure.Font = new Font("Segoe UI", 9F);
            lblSecure.ForeColor = Color.FromArgb(107, 114, 128);
            lblSecure.AutoSize = true;
            lblSecure.Location = new Point(160, 490);
            centerPanel.Controls.Add(lblSecure);
        }

        private void ShowPaymentPage(decimal totalCost)
        {
            lblPaymentOrderTotal.Text = $"${totalCost:N2}";
            ClearPaymentFields();

            contentTable.Visible = false;
            panelProductDetail.Visible = false;
            panelCartPage.Visible = false;
            panelPaymentPage.Visible = true;
            panelPaymentPage.BringToFront();
        }

        private void ClearPaymentFields()
        {
            txtCardName.Clear();
            txtCardNumber.Clear();
            txtCardExpiry.Text = "MM/YY";
            txtCardExpiry.ForeColor = Color.FromArgb(156, 163, 175);
            txtCardCvv.Clear();
        }

private Panel invoicePrintPanel;

        private void ShowInvoice(int orderId)
        {
            DataRow order = GetOrderDetails(orderId);
            DataTable items = GetOrderItems(orderId);
            DataRow user = GetUserDetails(UserId);
            DataRow payment = GetPaymentDetails(orderId);

            if (order == null) return;

            string customerName = user?["UserName"]?.ToString() ?? UserName ?? "Customer";
            string customerEmail = user?["UserEmail"]?.ToString() ?? UserEmail ?? "";
            string transactionId = payment?["TransactionId"]?.ToString() ?? "N/A";
            DateTime orderDate = order["OrderDate"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(order["OrderDate"]);
            DateTime paymentDate = payment?["PaymentDate"] == null || payment["PaymentDate"] == DBNull.Value
                ? DateTime.Now
                : Convert.ToDateTime(payment["PaymentDate"]);
            decimal totalCost = order["TotalCost"] == DBNull.Value ? 0 : Convert.ToDecimal(order["TotalCost"]);

            Form invoiceForm = new Form();
            invoiceForm.Text = "Invoice / Receipt";
            invoiceForm.Size = new Size(620, 820);
            invoiceForm.StartPosition = FormStartPosition.CenterParent;
            invoiceForm.FormBorderStyle = FormBorderStyle.Sizable;
            invoiceForm.MaximizeBox = true;
            invoiceForm.MinimizeBox = true;
            invoiceForm.BackColor = Color.FromArgb(249, 250, 251);

            Panel scrollPanel = new Panel();
            scrollPanel.Dock = DockStyle.Fill;
            scrollPanel.BackColor = Color.FromArgb(249, 250, 251);
            scrollPanel.AutoScroll = true;
            scrollPanel.Padding = new Padding(20);
            invoiceForm.Controls.Add(scrollPanel);

            invoicePrintPanel = new Panel();
            invoicePrintPanel.BackColor = Color.White;
            invoicePrintPanel.Width = 560;
            invoicePrintPanel.Location = new Point(20, 20);
            invoicePrintPanel.Padding = new Padding(40);
            scrollPanel.Controls.Add(invoicePrintPanel);

            int y = 0;
            int width = invoicePrintPanel.Width - 80;

            // Store header
            Label lblStoreName = new Label();
            lblStoreName.Text = "ShopMart";
            lblStoreName.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblStoreName.ForeColor = Color.FromArgb(31, 41, 55);
            lblStoreName.AutoSize = true;
            lblStoreName.Location = new Point(0, y);
            invoicePrintPanel.Controls.Add(lblStoreName);

            Label lblStoreTagline = new Label();
            lblStoreTagline.Text = "Your favorite online shopping destination";
            lblStoreTagline.Font = new Font("Segoe UI", 9F);
            lblStoreTagline.ForeColor = Color.FromArgb(107, 114, 128);
            lblStoreTagline.AutoSize = true;
            lblStoreTagline.Location = new Point(0, y + 42);
            invoicePrintPanel.Controls.Add(lblStoreTagline);

            Label lblInvoiceTitle = new Label();
            lblInvoiceTitle.Text = "INVOICE";
            lblInvoiceTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblInvoiceTitle.ForeColor = Color.FromArgb(59, 130, 246);
            lblInvoiceTitle.AutoSize = true;
            lblInvoiceTitle.Location = new Point(width - lblInvoiceTitle.PreferredWidth, y);
            invoicePrintPanel.Controls.Add(lblInvoiceTitle);

            y += 90;

            // Top info bar
            Panel topInfoPanel = new Panel();
            topInfoPanel.Width = width;
            topInfoPanel.Height = 70;
            topInfoPanel.Location = new Point(0, y);
            topInfoPanel.BackColor = Color.FromArgb(248, 250, 252);
            topInfoPanel.BorderStyle = BorderStyle.FixedSingle;
            invoicePrintPanel.Controls.Add(topInfoPanel);

            AddInvoiceInfoBlock(topInfoPanel, "Invoice #:", $"INV-{orderId}", 15, 10);
            AddInvoiceInfoBlock(topInfoPanel, "Invoice Date:", paymentDate.ToString("MMM dd, yyyy"), 200, 10);
            AddInvoiceInfoBlock(topInfoPanel, "Order Date:", orderDate.ToString("MMM dd, yyyy"), 385, 10);

            y += 90;

            // Bill to section
            Panel billToPanel = new Panel();
            billToPanel.Width = width / 2 - 10;
            billToPanel.Height = 120;
            billToPanel.Location = new Point(0, y);
            billToPanel.BackColor = Color.White;
            billToPanel.BorderStyle = BorderStyle.FixedSingle;
            invoicePrintPanel.Controls.Add(billToPanel);

            Label lblBillToTitle = new Label();
            lblBillToTitle.Text = "BILL TO";
            lblBillToTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblBillToTitle.ForeColor = Color.FromArgb(59, 130, 246);
            lblBillToTitle.AutoSize = true;
            lblBillToTitle.Location = new Point(12, 10);
            billToPanel.Controls.Add(lblBillToTitle);

            AddInvoiceDetailLine(billToPanel, customerName, 12, 35, FontStyle.Bold);
            AddInvoiceDetailLine(billToPanel, customerEmail, 12, 58);
            AddInvoiceDetailLine(billToPanel, order["UserPhone"]?.ToString() ?? "", 12, 81);

            // Ship to section
            Panel shipToPanel = new Panel();
            shipToPanel.Width = width / 2 - 10;
            shipToPanel.Height = 120;
            shipToPanel.Location = new Point(width / 2 + 10, y);
            shipToPanel.BackColor = Color.White;
            shipToPanel.BorderStyle = BorderStyle.FixedSingle;
            invoicePrintPanel.Controls.Add(shipToPanel);

            Label lblShipToTitle = new Label();
            lblShipToTitle.Text = "SHIP TO";
            lblShipToTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblShipToTitle.ForeColor = Color.FromArgb(59, 130, 246);
            lblShipToTitle.AutoSize = true;
            lblShipToTitle.Location = new Point(12, 10);
            shipToPanel.Controls.Add(lblShipToTitle);

            AddInvoiceDetailLine(shipToPanel, order["UserAddress"]?.ToString() ?? "", 12, 35);
            AddInvoiceDetailLine(shipToPanel, order["UserCity"]?.ToString() ?? "", 12, 58);

            y += 140;

            // Items table header
            Panel tableHeader = CreateInvoiceTableHeader(width);
            tableHeader.Location = new Point(0, y);
            invoicePrintPanel.Controls.Add(tableHeader);
            y += tableHeader.Height;

            decimal subtotal = 0;
            foreach (DataRow row in items.Rows)
            {
                string productName = row["ProductName"].ToString();
                decimal price = row["ProductPrice"] == DBNull.Value ? 0 : Convert.ToDecimal(row["ProductPrice"]);
                int qty = row["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(row["Quantity"]);
                decimal lineTotal = row["LineTotal"] == DBNull.Value ? 0 : Convert.ToDecimal(row["LineTotal"]);
                subtotal += lineTotal;

                Panel itemRow = CreateInvoiceTableRow(productName, price, qty, lineTotal, width);
                itemRow.Location = new Point(0, y);
                invoicePrintPanel.Controls.Add(itemRow);
                y += itemRow.Height;
            }

            // Totals section
            y += 20;
            Panel totalsBox = new Panel();
            totalsBox.Width = 240;
            totalsBox.Height = 100;
            totalsBox.Location = new Point(width - 240, y);
            totalsBox.BackColor = Color.White;
            totalsBox.BorderStyle = BorderStyle.FixedSingle;
            invoicePrintPanel.Controls.Add(totalsBox);

            AddInvoiceTotalLine(totalsBox, "Subtotal", subtotal, 10, false);
            AddInvoiceTotalLine(totalsBox, "Tax", 0m, 32, false);
            AddInvoiceTotalLine(totalsBox, "Discount", 0m, 54, false);
            AddInvoiceTotalLine(totalsBox, "Total", totalCost, 76, true);

            y += 120;

            // Payment info
            Panel paymentInfoPanel = new Panel();
            paymentInfoPanel.Width = width - 260;
            paymentInfoPanel.Height = 90;
            paymentInfoPanel.Location = new Point(0, y);
            paymentInfoPanel.BackColor = Color.FromArgb(239, 246, 255);
            paymentInfoPanel.Padding = new Padding(12);
            invoicePrintPanel.Controls.Add(paymentInfoPanel);

            Label lblPaymentTitle = new Label();
            lblPaymentTitle.Text = "Payment Information";
            lblPaymentTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPaymentTitle.ForeColor = Color.FromArgb(59, 130, 246);
            lblPaymentTitle.AutoSize = true;
            lblPaymentTitle.Location = new Point(12, 12);
            paymentInfoPanel.Controls.Add(lblPaymentTitle);

            AddInvoiceDetailLine(paymentInfoPanel, $"Transaction ID: {transactionId}", 12, 38);
            AddInvoiceDetailLine(paymentInfoPanel, "Payment Method: Credit Card", 12, 61);

            y += 110;

            // Footer notes
            Label lblNotesTitle = new Label();
            lblNotesTitle.Text = "Notes";
            lblNotesTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNotesTitle.ForeColor = Color.FromArgb(31, 41, 55);
            lblNotesTitle.AutoSize = true;
            lblNotesTitle.Location = new Point(0, y);
            invoicePrintPanel.Controls.Add(lblNotesTitle);
            y += 25;

            Label lblNotes = new Label();
            lblNotes.Text = "Thank you for shopping with us. If you have any questions about this invoice, please contact our support team.";
            lblNotes.Font = new Font("Segoe UI", 9F);
            lblNotes.ForeColor = Color.FromArgb(107, 114, 128);
            lblNotes.AutoSize = true;
            lblNotes.Location = new Point(0, y);
            lblNotes.MaximumSize = new Size(width, 0);
            invoicePrintPanel.Controls.Add(lblNotes);

            y += lblNotes.PreferredHeight + 30;
            invoicePrintPanel.Height = y + 60;

            // Footer buttons
            Panel footerPanel = new Panel();
            footerPanel.Dock = DockStyle.Bottom;
            footerPanel.Height = 70;
            footerPanel.BackColor = Color.White;
            footerPanel.BorderStyle = BorderStyle.FixedSingle;
            invoiceForm.Controls.Add(footerPanel);

            Button btnPrint = new Button();
            btnPrint.Text = "🖨️ Print Invoice";
            btnPrint.Size = new Size(180, 45);
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnPrint.ForeColor = Color.White;
            btnPrint.BackColor = Color.FromArgb(16, 185, 129);
            btnPrint.Cursor = Cursors.Hand;
            btnPrint.Location = new Point(30, 12);
            btnPrint.Click += (s, ev) => PrintInvoice();
            footerPanel.Controls.Add(btnPrint);

            Button btnContinue = new Button();
            btnContinue.Text = "Continue Shopping";
            btnContinue.Size = new Size(330, 45);
            btnContinue.FlatStyle = FlatStyle.Flat;
            btnContinue.FlatAppearance.BorderSize = 0;
            btnContinue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnContinue.ForeColor = Color.White;
            btnContinue.BackColor = Color.FromArgb(59, 130, 246);
            btnContinue.Cursor = Cursors.Hand;
            btnContinue.Location = new Point(230, 12);
            btnContinue.DialogResult = DialogResult.OK;
            footerPanel.Controls.Add(btnContinue);

            invoiceForm.AcceptButton = btnContinue;
            invoiceForm.ShowDialog(this);
        }

        private void AddInvoiceInfoBlock(Panel parent, string label, string value, int x, int y)
        {
            Label lblLabel = new Label();
            lblLabel.Text = label;
            lblLabel.Font = new Font("Segoe UI", 8F);
            lblLabel.ForeColor = Color.FromArgb(107, 114, 128);
            lblLabel.AutoSize = true;
            lblLabel.Location = new Point(x, y);
            parent.Controls.Add(lblLabel);

            Label lblValue = new Label();
            lblValue.Text = value;
            lblValue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblValue.ForeColor = Color.FromArgb(31, 41, 55);
            lblValue.AutoSize = true;
            lblValue.Location = new Point(x, y + 18);
            parent.Controls.Add(lblValue);
        }

        private void AddInvoiceDetailLine(Panel parent, string text, int x, int y, FontStyle style = FontStyle.Regular)
        {
            Label label = new Label();
            label.Text = text;
            label.Font = new Font("Segoe UI", 9F, style);
            label.ForeColor = Color.FromArgb(55, 65, 81);
            label.AutoSize = true;
            label.Location = new Point(x, y);
            label.MaximumSize = new Size(parent.Width - 24, 0);
            parent.Controls.Add(label);
        }

        private Panel CreateInvoiceTableHeader(int width)
        {
            Panel panel = new Panel();
            panel.Height = 36;
            panel.Width = width;
            panel.BackColor = Color.FromArgb(59, 130, 246);

            Label lblItem = new Label();
            lblItem.Text = "Item Description";
            lblItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblItem.ForeColor = Color.White;
            lblItem.AutoSize = true;
            lblItem.Location = new Point(12, 8);
            panel.Controls.Add(lblItem);

            Label lblPrice = new Label();
            lblPrice.Text = "Price";
            lblPrice.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPrice.ForeColor = Color.White;
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(width - 260, 8);
            panel.Controls.Add(lblPrice);

            Label lblQty = new Label();
            lblQty.Text = "Qty";
            lblQty.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblQty.ForeColor = Color.White;
            lblQty.AutoSize = true;
            lblQty.Location = new Point(width - 170, 8);
            panel.Controls.Add(lblQty);

            Label lblTotal = new Label();
            lblTotal.Text = "Amount";
            lblTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotal.ForeColor = Color.White;
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(width - 90, 8);
            panel.Controls.Add(lblTotal);

            return panel;
        }

        private Panel CreateInvoiceTableRow(string productName, decimal price, int qty, decimal lineTotal, int width)
        {
            Panel panel = new Panel();
            panel.Height = 36;
            panel.Width = width;
            panel.BackColor = Color.White;
            panel.BorderStyle = BorderStyle.FixedSingle;

            Label lblName = new Label();
            lblName.Text = productName;
            lblName.Font = new Font("Segoe UI", 9F);
            lblName.ForeColor = Color.FromArgb(31, 41, 55);
            lblName.AutoSize = true;
            lblName.Location = new Point(12, 8);
            lblName.MaximumSize = new Size(width - 300, 0);
            panel.Controls.Add(lblName);

            Label lblPrice = new Label();
            lblPrice.Text = $"${price:N2}";
            lblPrice.Font = new Font("Segoe UI", 9F);
            lblPrice.ForeColor = Color.FromArgb(75, 85, 99);
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(width - 260, 8);
            panel.Controls.Add(lblPrice);

            Label lblQty = new Label();
            lblQty.Text = qty.ToString();
            lblQty.Font = new Font("Segoe UI", 9F);
            lblQty.ForeColor = Color.FromArgb(75, 85, 99);
            lblQty.AutoSize = true;
            lblQty.Location = new Point(width - 160, 8);
            panel.Controls.Add(lblQty);

            Label lblTotal = new Label();
            lblTotal.Text = $"${lineTotal:N2}";
            lblTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(31, 41, 55);
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(width - 90, 8);
            panel.Controls.Add(lblTotal);

            return panel;
        }

        private void AddInvoiceTotalLine(Panel parent, string label, decimal value, int y, bool isBold)
        {
            Label lblLabel = new Label();
            lblLabel.Text = label;
            lblLabel.Font = new Font("Segoe UI", isBold ? 11F : 9F, isBold ? FontStyle.Bold : FontStyle.Regular);
            lblLabel.ForeColor = isBold ? Color.FromArgb(31, 41, 55) : Color.FromArgb(107, 114, 128);
            lblLabel.AutoSize = true;
            lblLabel.Location = new Point(12, y);
            parent.Controls.Add(lblLabel);

            Label lblValue = new Label();
            lblValue.Text = $"${value:N2}";
            lblValue.Font = new Font("Segoe UI", isBold ? 11F : 9F, isBold ? FontStyle.Bold : FontStyle.Regular);
            lblValue.ForeColor = isBold ? Color.FromArgb(59, 130, 246) : Color.FromArgb(31, 41, 55);
            lblValue.AutoSize = true;
            lblValue.Location = new Point(170, y);
            lblValue.TextAlign = ContentAlignment.MiddleRight;
            parent.Controls.Add(lblValue);
        }

        private void PrintInvoice()
        {
            if (invoicePrintPanel == null) return;

            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += (s, ev) =>
            {
                ev.Graphics.PageUnit = GraphicsUnit.Pixel;
                ev.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Margins
                int marginX = ev.MarginBounds.Left;
                int marginY = ev.MarginBounds.Top;
                int pageWidth = ev.MarginBounds.Width;

                // Scale to fit page width while preserving aspect ratio
                float scale = Math.Min(1f, (float)pageWidth / invoicePrintPanel.Width);
                int panelHeight = (int)(invoicePrintPanel.Height * scale);

                using (Bitmap bitmap = new Bitmap(invoicePrintPanel.Width, invoicePrintPanel.Height))
                {
                    invoicePrintPanel.DrawToBitmap(bitmap, new Rectangle(0, 0, invoicePrintPanel.Width, invoicePrintPanel.Height));
                    ev.Graphics.DrawImage(bitmap, marginX, marginY, (int)(invoicePrintPanel.Width * scale), panelHeight);
                }

                ev.HasMorePages = false;
            };

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
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

            lblPageTitle.Text = clickedButton.Text;
            ResetCategoryButtonStyles();
            clickedButton.BackColor = Color.FromArgb(59, 130, 246);
            clickedButton.ForeColor = Color.White;
            clickedButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);

            LoadProducts(clickedButton.Text, GetSearchText());
        }

        private void ResetCategoryButtonStyles()
        {
            Button[] buttons = new Button[]
            {
                btnCategoryAll,
                btnCategoryElectronics,
                btnCategoryFashion,
                btnCategoryHome,
                btnCategorySports,
                btnCategoryBooks
            };

            foreach (Button btn in buttons)
            {
                btn.BackColor = Color.White;
                btn.ForeColor = Color.FromArgb(55, 65, 81);
                btn.Font = new Font("Segoe UI", 11F);
            }
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
}
