using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Shopping_Cart
{
    public partial class ProductCatalog : Form
    {
        private int cartCount = 0;
        private DataTable productsTable;

        public string UserName { get; set; }

        public ProductCatalog()
        {
            InitializeComponent();
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

            cartCount++;
            lblCartCount.Text = cartCount.ToString();

            MessageBox.Show(
                $"{info.ProductName} has been added to your cart.",
                "Added to Cart",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
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
            MessageBox.Show(
                $"You have {cartCount} item(s) in your cart.",
                "Shopping Cart",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnMyOrders_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "My Orders page will be available soon.",
                "My Orders",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
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
}
