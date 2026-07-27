using System;
using System.Windows.Forms;

namespace Shopping_Cart
{
    public partial class ProductCatalog : Form
    {
        private int cartCount = 0;

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
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            string productName = "Product";

            if (clickedButton != null)
            {
                TableLayoutPanel cardTable = clickedButton.Parent as TableLayoutPanel;
                if (cardTable != null)
                {
                    Label nameLabel = cardTable.GetControlFromPosition(0, 1) as Label;
                    if (nameLabel != null)
                    {
                        productName = nameLabel.Text;
                    }
                }
            }

            cartCount++;
            lblCartCount.Text = cartCount.ToString();

            MessageBox.Show(
                $"{productName} has been added to your cart.",
                "Added to Cart",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                lblPageTitle.Text = clickedButton.Text;
                ResetCategoryButtonStyles();
                clickedButton.BackColor = System.Drawing.Color.FromArgb(59, 130, 246);
                clickedButton.ForeColor = System.Drawing.Color.White;
                clickedButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            }
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
                btn.BackColor = System.Drawing.Color.White;
                btn.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
                btn.Font = new System.Drawing.Font("Segoe UI", 11F);
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
                txtSearch.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Search products...";
                txtSearch.ForeColor = System.Drawing.Color.FromArgb(156, 163, 175);
            }
        }
    }
}
