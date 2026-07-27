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
        private readonly string connectionString =
            "Server=DESKTOP-985956K\\SQLEXPRESS;Database=Shopping_Cart;User ID=sa;Password=130506;TrustServerCertificate=True;";

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
        }

        // ======================
        // Load all products into DataGridView
        // ======================
        private void LoadProducts()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT ProductId, ProductName, Category, Price, Discount,
                               SpecialOffer, Image1, Image2, Image3, Image4, CreatedAt
                        FROM Products
                        ORDER BY ProductId DESC";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridViewProducts.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ======================
        // Auto-calculate final price from special offer percentage
        // ======================
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

        // ======================
        // Add new product
        // ======================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        INSERT INTO Products (ProductName, Category, Price, Discount, SpecialOffer,
                                              Image1, Image2, Image3, Image4, CreatedAt)
                        VALUES (@ProductName, @Category, @Price, @Discount, @SpecialOffer,
                                @Image1, @Image2, @Image3, @Image4, GETDATE())";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Category", cmbCategory.SelectedItem?.ToString() ?? "");
                        cmd.Parameters.AddWithValue("@Price", decimal.Parse(txtPrice.Text.Trim()));
                        cmd.Parameters.AddWithValue("@Discount", string.IsNullOrWhiteSpace(txtDiscount.Text) ? 0 : decimal.Parse(txtDiscount.Text.Trim()));
                        cmd.Parameters.AddWithValue("@SpecialOffer", string.IsNullOrWhiteSpace(txtSpecialOffer.Text) ? 0 : int.Parse(txtSpecialOffer.Text.Trim()));
                        cmd.Parameters.AddWithValue("@Image1", txtImage1.Text.Trim());
                        cmd.Parameters.AddWithValue("@Image2", txtImage2.Text.Trim());
                        cmd.Parameters.AddWithValue("@Image3", txtImage3.Text.Trim());
                        cmd.Parameters.AddWithValue("@Image4", txtImage4.Text.Trim());

                        cmd.ExecuteNonQuery();
                    }
                }

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

        // ======================
        // Update existing product
        // ======================
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
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
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

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductId", int.Parse(txtProductId.Text.Trim()));
                        cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Category", cmbCategory.SelectedItem?.ToString() ?? "");
                        cmd.Parameters.AddWithValue("@Price", decimal.Parse(txtPrice.Text.Trim()));
                        cmd.Parameters.AddWithValue("@Discount", string.IsNullOrWhiteSpace(txtDiscount.Text) ? 0 : decimal.Parse(txtDiscount.Text.Trim()));
                        cmd.Parameters.AddWithValue("@SpecialOffer", string.IsNullOrWhiteSpace(txtSpecialOffer.Text) ? 0 : int.Parse(txtSpecialOffer.Text.Trim()));
                        cmd.Parameters.AddWithValue("@Image1", txtImage1.Text.Trim());
                        cmd.Parameters.AddWithValue("@Image2", txtImage2.Text.Trim());
                        cmd.Parameters.AddWithValue("@Image3", txtImage3.Text.Trim());
                        cmd.Parameters.AddWithValue("@Image4", txtImage4.Text.Trim());

                        int rows = cmd.ExecuteNonQuery();

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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating product: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ======================
        // Delete product
        // ======================
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
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM Products WHERE ProductId = @ProductId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductId", int.Parse(txtProductId.Text.Trim()));
                        int rows = cmd.ExecuteNonQuery();

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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting product: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ======================
        // Clear inputs
        // ======================
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

        // ======================
        // Browse image from folder
        // ======================
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

        // ======================
        // Fill inputs when grid row is clicked
        // ======================
        private void dataGridViewProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridViewProducts.Rows[e.RowIndex];

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

        // ======================
        // Validation
        // ======================
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
            ProductCatalog catalogForm = new ProductCatalog();
            catalogForm.Show();
            this.Hide();
        }
    }
}
