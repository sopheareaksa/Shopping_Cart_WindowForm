namespace Shopping_Cart
{
    partial class Dashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mainTable = new System.Windows.Forms.TableLayoutPanel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.bodyTable = new System.Windows.Forms.TableLayoutPanel();
            this.sidebarPanel = new System.Windows.Forms.Panel();
            this.btnNavSettings = new System.Windows.Forms.Button();
            this.btnNavCustomers = new System.Windows.Forms.Button();
            this.btnNavOrders = new System.Windows.Forms.Button();
            this.btnNavProducts = new System.Windows.Forms.Button();
            this.btnNavDashboard = new System.Windows.Forms.Button();
            this.lblMenu = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.contentTable = new System.Windows.Forms.TableLayoutPanel();
            this.cardsTable = new System.Windows.Forms.TableLayoutPanel();
            this.cardTotalSales = new System.Windows.Forms.Panel();
            this.lblSalesValue = new System.Windows.Forms.Label();
            this.lblSalesTitle = new System.Windows.Forms.Label();
            this.cardTotalOrders = new System.Windows.Forms.Panel();
            this.lblOrdersValue = new System.Windows.Forms.Label();
            this.lblOrdersTitle = new System.Windows.Forms.Label();
            this.cardTotalProducts = new System.Windows.Forms.Panel();
            this.lblProductsValue = new System.Windows.Forms.Label();
            this.lblProductsTitle = new System.Windows.Forms.Label();
            this.cardTotalCustomers = new System.Windows.Forms.Panel();
            this.lblCustomersValue = new System.Windows.Forms.Label();
            this.lblCustomersTitle = new System.Windows.Forms.Label();
            this.crudPanel = new System.Windows.Forms.Panel();
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.inputPanel = new System.Windows.Forms.Panel();
            this.txtCreatedAt = new System.Windows.Forms.TextBox();
            this.lblCreatedAt = new System.Windows.Forms.Label();
            this.txtImage4 = new System.Windows.Forms.TextBox();
            this.btnBrowseImage4 = new System.Windows.Forms.Button();
            this.lblImage4 = new System.Windows.Forms.Label();
            this.txtImage3 = new System.Windows.Forms.TextBox();
            this.btnBrowseImage3 = new System.Windows.Forms.Button();
            this.lblImage3 = new System.Windows.Forms.Label();
            this.txtImage2 = new System.Windows.Forms.TextBox();
            this.btnBrowseImage2 = new System.Windows.Forms.Button();
            this.lblImage2 = new System.Windows.Forms.Label();
            this.txtImage1 = new System.Windows.Forms.TextBox();
            this.btnBrowseImage1 = new System.Windows.Forms.Button();
            this.lblImage1 = new System.Windows.Forms.Label();
            this.txtSpecialOffer = new System.Windows.Forms.TextBox();
            this.lblSpecialOffer = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.lblProductId = new System.Windows.Forms.Label();
            this.crudTopPanel = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblCrudTitle = new System.Windows.Forms.Label();
            this.mainTable.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.bodyTable.SuspendLayout();
            this.sidebarPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.contentTable.SuspendLayout();
            this.cardsTable.SuspendLayout();
            this.cardTotalSales.SuspendLayout();
            this.cardTotalOrders.SuspendLayout();
            this.cardTotalProducts.SuspendLayout();
            this.cardTotalCustomers.SuspendLayout();
            this.crudPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            this.inputPanel.SuspendLayout();
            this.crudTopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTable
            // 
            this.mainTable.ColumnCount = 1;
            this.mainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTable.Controls.Add(this.headerPanel, 0, 0);
            this.mainTable.Controls.Add(this.bodyTable, 0, 1);
            this.mainTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTable.Location = new System.Drawing.Point(0, 0);
            this.mainTable.Margin = new System.Windows.Forms.Padding(0);
            this.mainTable.Name = "mainTable";
            this.mainTable.RowCount = 2;
            this.mainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.mainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTable.Size = new System.Drawing.Size(1300, 900);
            this.mainTable.TabIndex = 0;
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(43)))), ((int)(((byte)(104)))));
            this.headerPanel.Controls.Add(this.btnLogout);
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Margin = new System.Windows.Forms.Padding(0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(25, 0, 25, 0);
            this.headerPanel.Size = new System.Drawing.Size(1300, 70);
            this.headerPanel.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(65)))), ((int)(((byte)(138)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(1160, 15);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(110, 40);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(25, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(223, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Shopping Cart";
            // 
            // bodyTable
            // 
            this.bodyTable.ColumnCount = 2;
            this.bodyTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.bodyTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.bodyTable.Controls.Add(this.sidebarPanel, 0, 0);
            this.bodyTable.Controls.Add(this.contentPanel, 1, 0);
            this.bodyTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bodyTable.Location = new System.Drawing.Point(0, 70);
            this.bodyTable.Margin = new System.Windows.Forms.Padding(0);
            this.bodyTable.Name = "bodyTable";
            this.bodyTable.RowCount = 1;
            this.bodyTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.bodyTable.Size = new System.Drawing.Size(1300, 830);
            this.bodyTable.TabIndex = 1;
            // 
            // sidebarPanel
            // 
            this.sidebarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(68)))), ((int)(((byte)(149)))));
            this.sidebarPanel.Controls.Add(this.btnNavSettings);
            this.sidebarPanel.Controls.Add(this.btnNavCustomers);
            this.sidebarPanel.Controls.Add(this.btnNavOrders);
            this.sidebarPanel.Controls.Add(this.btnNavProducts);
            this.sidebarPanel.Controls.Add(this.btnNavDashboard);
            this.sidebarPanel.Controls.Add(this.lblMenu);
            this.sidebarPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sidebarPanel.Location = new System.Drawing.Point(0, 0);
            this.sidebarPanel.Margin = new System.Windows.Forms.Padding(0);
            this.sidebarPanel.Name = "sidebarPanel";
            this.sidebarPanel.Padding = new System.Windows.Forms.Padding(20);
            this.sidebarPanel.Size = new System.Drawing.Size(250, 830);
            this.sidebarPanel.TabIndex = 0;
            // 
            // btnNavSettings
            // 
            this.btnNavSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNavSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(68)))), ((int)(((byte)(149)))));
            this.btnNavSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavSettings.FlatAppearance.BorderSize = 0;
            this.btnNavSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavSettings.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnNavSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.btnNavSettings.Location = new System.Drawing.Point(20, 305);
            this.btnNavSettings.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.btnNavSettings.Name = "btnNavSettings";
            this.btnNavSettings.Size = new System.Drawing.Size(210, 50);
            this.btnNavSettings.TabIndex = 5;
            this.btnNavSettings.Text = "  Reports";
            this.btnNavSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavSettings.UseVisualStyleBackColor = false;
            // 
            // btnNavCustomers
            // 
            this.btnNavCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNavCustomers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(68)))), ((int)(((byte)(149)))));
            this.btnNavCustomers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavCustomers.FlatAppearance.BorderSize = 0;
            this.btnNavCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavCustomers.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnNavCustomers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.btnNavCustomers.Location = new System.Drawing.Point(20, 245);
            this.btnNavCustomers.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.btnNavCustomers.Name = "btnNavCustomers";
            this.btnNavCustomers.Size = new System.Drawing.Size(210, 50);
            this.btnNavCustomers.TabIndex = 4;
            this.btnNavCustomers.Text = "  Customers";
            this.btnNavCustomers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavCustomers.UseVisualStyleBackColor = false;
            // 
            // btnNavOrders
            // 
            this.btnNavOrders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNavOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(68)))), ((int)(((byte)(149)))));
            this.btnNavOrders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavOrders.FlatAppearance.BorderSize = 0;
            this.btnNavOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavOrders.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnNavOrders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.btnNavOrders.Location = new System.Drawing.Point(20, 185);
            this.btnNavOrders.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.btnNavOrders.Name = "btnNavOrders";
            this.btnNavOrders.Size = new System.Drawing.Size(210, 50);
            this.btnNavOrders.TabIndex = 3;
            this.btnNavOrders.Text = "  Orders";
            this.btnNavOrders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavOrders.UseVisualStyleBackColor = false;
            // 
            // btnNavProducts
            // 
            this.btnNavProducts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNavProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(68)))), ((int)(((byte)(149)))));
            this.btnNavProducts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavProducts.FlatAppearance.BorderSize = 0;
            this.btnNavProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavProducts.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnNavProducts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.btnNavProducts.Location = new System.Drawing.Point(20, 125);
            this.btnNavProducts.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.btnNavProducts.Name = "btnNavProducts";
            this.btnNavProducts.Size = new System.Drawing.Size(210, 50);
            this.btnNavProducts.TabIndex = 2;
            this.btnNavProducts.Text = "  Products";
            this.btnNavProducts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavProducts.UseVisualStyleBackColor = false;
            this.btnNavProducts.Click += new System.EventHandler(this.btnNavProducts_Click);
            // 
            // btnNavDashboard
            // 
            this.btnNavDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNavDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(91)))), ((int)(((byte)(184)))));
            this.btnNavDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavDashboard.FlatAppearance.BorderSize = 0;
            this.btnNavDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavDashboard.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnNavDashboard.ForeColor = System.Drawing.Color.White;
            this.btnNavDashboard.Location = new System.Drawing.Point(20, 65);
            this.btnNavDashboard.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.btnNavDashboard.Name = "btnNavDashboard";
            this.btnNavDashboard.Size = new System.Drawing.Size(210, 50);
            this.btnNavDashboard.TabIndex = 1;
            this.btnNavDashboard.Text = "  Dashboard";
            this.btnNavDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavDashboard.UseVisualStyleBackColor = false;
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(181)))), ((int)(((byte)(230)))));
            this.lblMenu.Location = new System.Drawing.Point(20, 20);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(60, 23);
            this.lblMenu.TabIndex = 0;
            this.lblMenu.Text = "MENU";
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.contentPanel.Controls.Add(this.contentTable);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(250, 0);
            this.contentPanel.Margin = new System.Windows.Forms.Padding(0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(30);
            this.contentPanel.Size = new System.Drawing.Size(1050, 830);
            this.contentPanel.TabIndex = 1;
            // 
            // contentTable
            // 
            this.contentTable.ColumnCount = 1;
            this.contentTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentTable.Controls.Add(this.cardsTable, 0, 0);
            this.contentTable.Controls.Add(this.crudPanel, 0, 1);
            this.contentTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentTable.Location = new System.Drawing.Point(30, 30);
            this.contentTable.Margin = new System.Windows.Forms.Padding(0);
            this.contentTable.Name = "contentTable";
            this.contentTable.RowCount = 2;
            this.contentTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.contentTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentTable.Size = new System.Drawing.Size(990, 770);
            this.contentTable.TabIndex = 0;
            // 
            // cardsTable
            // 
            this.cardsTable.ColumnCount = 4;
            this.cardsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.cardsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.cardsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.cardsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.cardsTable.Controls.Add(this.cardTotalSales, 0, 0);
            this.cardsTable.Controls.Add(this.cardTotalOrders, 1, 0);
            this.cardsTable.Controls.Add(this.cardTotalProducts, 2, 0);
            this.cardsTable.Controls.Add(this.cardTotalCustomers, 3, 0);
            this.cardsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardsTable.Location = new System.Drawing.Point(0, 0);
            this.cardsTable.Margin = new System.Windows.Forms.Padding(0);
            this.cardsTable.Name = "cardsTable";
            this.cardsTable.RowCount = 1;
            this.cardsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.cardsTable.Size = new System.Drawing.Size(990, 140);
            this.cardsTable.TabIndex = 0;
            // 
            // cardTotalSales
            // 
            this.cardTotalSales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.cardTotalSales.Controls.Add(this.lblSalesValue);
            this.cardTotalSales.Controls.Add(this.lblSalesTitle);
            this.cardTotalSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardTotalSales.Location = new System.Drawing.Point(0, 0);
            this.cardTotalSales.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.cardTotalSales.Name = "cardTotalSales";
            this.cardTotalSales.Padding = new System.Windows.Forms.Padding(20);
            this.cardTotalSales.Size = new System.Drawing.Size(232, 140);
            this.cardTotalSales.TabIndex = 0;
            // 
            // lblSalesValue
            // 
            this.lblSalesValue.AutoSize = true;
            this.lblSalesValue.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblSalesValue.ForeColor = System.Drawing.Color.White;
            this.lblSalesValue.Location = new System.Drawing.Point(20, 55);
            this.lblSalesValue.Name = "lblSalesValue";
            this.lblSalesValue.Size = new System.Drawing.Size(172, 54);
            this.lblSalesValue.TabIndex = 2;
            this.lblSalesValue.Text = "$12,450";
            // 
            // lblSalesTitle
            // 
            this.lblSalesTitle.AutoSize = true;
            this.lblSalesTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSalesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(255)))), ((int)(((byte)(240)))));
            this.lblSalesTitle.Location = new System.Drawing.Point(20, 20);
            this.lblSalesTitle.Name = "lblSalesTitle";
            this.lblSalesTitle.Size = new System.Drawing.Size(95, 23);
            this.lblSalesTitle.TabIndex = 1;
            this.lblSalesTitle.Text = "Total Sales";
            // 
            // cardTotalOrders
            // 
            this.cardTotalOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(189)))), ((int)(((byte)(248)))));
            this.cardTotalOrders.Controls.Add(this.lblOrdersValue);
            this.cardTotalOrders.Controls.Add(this.lblOrdersTitle);
            this.cardTotalOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardTotalOrders.Location = new System.Drawing.Point(262, 0);
            this.cardTotalOrders.Margin = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.cardTotalOrders.Name = "cardTotalOrders";
            this.cardTotalOrders.Padding = new System.Windows.Forms.Padding(20);
            this.cardTotalOrders.Size = new System.Drawing.Size(217, 140);
            this.cardTotalOrders.TabIndex = 1;
            // 
            // lblOrdersValue
            // 
            this.lblOrdersValue.AutoSize = true;
            this.lblOrdersValue.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblOrdersValue.ForeColor = System.Drawing.Color.White;
            this.lblOrdersValue.Location = new System.Drawing.Point(20, 55);
            this.lblOrdersValue.Name = "lblOrdersValue";
            this.lblOrdersValue.Size = new System.Drawing.Size(92, 54);
            this.lblOrdersValue.TabIndex = 2;
            this.lblOrdersValue.Text = "348";
            // 
            // lblOrdersTitle
            // 
            this.lblOrdersTitle.AutoSize = true;
            this.lblOrdersTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblOrdersTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.lblOrdersTitle.Location = new System.Drawing.Point(20, 20);
            this.lblOrdersTitle.Name = "lblOrdersTitle";
            this.lblOrdersTitle.Size = new System.Drawing.Size(107, 23);
            this.lblOrdersTitle.TabIndex = 1;
            this.lblOrdersTitle.Text = "Total Orders";
            // 
            // cardTotalProducts
            // 
            this.cardTotalProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(115)))), ((int)(((byte)(22)))));
            this.cardTotalProducts.Controls.Add(this.lblProductsValue);
            this.cardTotalProducts.Controls.Add(this.lblProductsTitle);
            this.cardTotalProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardTotalProducts.Location = new System.Drawing.Point(509, 0);
            this.cardTotalProducts.Margin = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.cardTotalProducts.Name = "cardTotalProducts";
            this.cardTotalProducts.Padding = new System.Windows.Forms.Padding(20);
            this.cardTotalProducts.Size = new System.Drawing.Size(217, 140);
            this.cardTotalProducts.TabIndex = 2;
            // 
            // lblProductsValue
            // 
            this.lblProductsValue.AutoSize = true;
            this.lblProductsValue.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblProductsValue.ForeColor = System.Drawing.Color.White;
            this.lblProductsValue.Location = new System.Drawing.Point(20, 55);
            this.lblProductsValue.Name = "lblProductsValue";
            this.lblProductsValue.Size = new System.Drawing.Size(69, 54);
            this.lblProductsValue.TabIndex = 2;
            this.lblProductsValue.Text = "86";
            // 
            // lblProductsTitle
            // 
            this.lblProductsTitle.AutoSize = true;
            this.lblProductsTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblProductsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(235)))));
            this.lblProductsTitle.Location = new System.Drawing.Point(20, 20);
            this.lblProductsTitle.Name = "lblProductsTitle";
            this.lblProductsTitle.Size = new System.Drawing.Size(80, 23);
            this.lblProductsTitle.TabIndex = 1;
            this.lblProductsTitle.Text = "Products";
            // 
            // cardTotalCustomers
            // 
            this.cardTotalCustomers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.cardTotalCustomers.Controls.Add(this.lblCustomersValue);
            this.cardTotalCustomers.Controls.Add(this.lblCustomersTitle);
            this.cardTotalCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardTotalCustomers.Location = new System.Drawing.Point(756, 0);
            this.cardTotalCustomers.Margin = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.cardTotalCustomers.Name = "cardTotalCustomers";
            this.cardTotalCustomers.Padding = new System.Windows.Forms.Padding(20);
            this.cardTotalCustomers.Size = new System.Drawing.Size(234, 140);
            this.cardTotalCustomers.TabIndex = 3;
            // 
            // lblCustomersValue
            // 
            this.lblCustomersValue.AutoSize = true;
            this.lblCustomersValue.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblCustomersValue.ForeColor = System.Drawing.Color.White;
            this.lblCustomersValue.Location = new System.Drawing.Point(20, 55);
            this.lblCustomersValue.Name = "lblCustomersValue";
            this.lblCustomersValue.Size = new System.Drawing.Size(126, 54);
            this.lblCustomersValue.TabIndex = 2;
            this.lblCustomersValue.Text = "1,240";
            // 
            // lblCustomersTitle
            // 
            this.lblCustomersTitle.AutoSize = true;
            this.lblCustomersTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCustomersTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.lblCustomersTitle.Location = new System.Drawing.Point(20, 20);
            this.lblCustomersTitle.Name = "lblCustomersTitle";
            this.lblCustomersTitle.Size = new System.Drawing.Size(96, 23);
            this.lblCustomersTitle.TabIndex = 1;
            this.lblCustomersTitle.Text = "Customers";
            // 
            // crudPanel
            // 
            this.crudPanel.BackColor = System.Drawing.Color.White;
            this.crudPanel.Controls.Add(this.dataGridViewProducts);
            this.crudPanel.Controls.Add(this.inputPanel);
            this.crudPanel.Controls.Add(this.crudTopPanel);
            this.crudPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crudPanel.Location = new System.Drawing.Point(0, 160);
            this.crudPanel.Margin = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.crudPanel.Name = "crudPanel";
            this.crudPanel.Padding = new System.Windows.Forms.Padding(25);
            this.crudPanel.Size = new System.Drawing.Size(990, 610);
            this.crudPanel.TabIndex = 1;
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.AllowUserToAddRows = false;
            this.dataGridViewProducts.AllowUserToDeleteRows = false;
            this.dataGridViewProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewProducts.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewProducts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(238)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(43)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.dataGridViewProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewProducts.ColumnHeadersHeight = 42;
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewProducts.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(231)))), ((int)(((byte)(245)))));
            this.dataGridViewProducts.Location = new System.Drawing.Point(25, 375);
            this.dataGridViewProducts.Margin = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.dataGridViewProducts.MultiSelect = false;
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.ReadOnly = true;
            this.dataGridViewProducts.RowHeadersVisible = false;
            this.dataGridViewProducts.RowHeadersWidth = 51;
            this.dataGridViewProducts.RowTemplate.Height = 34;
            this.dataGridViewProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProducts.Size = new System.Drawing.Size(940, 210);
            this.dataGridViewProducts.TabIndex = 2;
            this.dataGridViewProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProducts_CellClick);
            // 
            // inputPanel
            // 
            this.inputPanel.Controls.Add(this.txtCreatedAt);
            this.inputPanel.Controls.Add(this.lblCreatedAt);
            this.inputPanel.Controls.Add(this.txtImage4);
            this.inputPanel.Controls.Add(this.btnBrowseImage4);
            this.inputPanel.Controls.Add(this.lblImage4);
            this.inputPanel.Controls.Add(this.txtImage3);
            this.inputPanel.Controls.Add(this.btnBrowseImage3);
            this.inputPanel.Controls.Add(this.lblImage3);
            this.inputPanel.Controls.Add(this.txtImage2);
            this.inputPanel.Controls.Add(this.btnBrowseImage2);
            this.inputPanel.Controls.Add(this.lblImage2);
            this.inputPanel.Controls.Add(this.txtImage1);
            this.inputPanel.Controls.Add(this.btnBrowseImage1);
            this.inputPanel.Controls.Add(this.lblImage1);
            this.inputPanel.Controls.Add(this.txtSpecialOffer);
            this.inputPanel.Controls.Add(this.lblSpecialOffer);
            this.inputPanel.Controls.Add(this.txtDiscount);
            this.inputPanel.Controls.Add(this.lblDiscount);
            this.inputPanel.Controls.Add(this.txtPrice);
            this.inputPanel.Controls.Add(this.lblPrice);
            this.inputPanel.Controls.Add(this.cmbCategory);
            this.inputPanel.Controls.Add(this.lblCategory);
            this.inputPanel.Controls.Add(this.txtProductName);
            this.inputPanel.Controls.Add(this.lblProductName);
            this.inputPanel.Controls.Add(this.txtProductId);
            this.inputPanel.Controls.Add(this.lblProductId);
            this.inputPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.inputPanel.Location = new System.Drawing.Point(25, 80);
            this.inputPanel.Name = "inputPanel";
            this.inputPanel.Size = new System.Drawing.Size(940, 295);
            this.inputPanel.TabIndex = 1;
            // 
            // txtCreatedAt
            // 
            this.txtCreatedAt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.txtCreatedAt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCreatedAt.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCreatedAt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(33)))), ((int)(((byte)(71)))));
            this.txtCreatedAt.Location = new System.Drawing.Point(700, 110);
            this.txtCreatedAt.Name = "txtCreatedAt";
            this.txtCreatedAt.ReadOnly = true;
            this.txtCreatedAt.Size = new System.Drawing.Size(220, 23);
            this.txtCreatedAt.TabIndex = 25;
            // 
            // lblCreatedAt
            // 
            this.lblCreatedAt.AutoSize = true;
            this.lblCreatedAt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCreatedAt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(63)))), ((int)(((byte)(114)))));
            this.lblCreatedAt.Location = new System.Drawing.Point(700, 85);
            this.lblCreatedAt.Name = "lblCreatedAt";
            this.lblCreatedAt.Size = new System.Drawing.Size(84, 20);
            this.lblCreatedAt.TabIndex = 24;
            this.lblCreatedAt.Text = "Created At";
            // 
            // txtImage4
            // 
            this.txtImage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.txtImage4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtImage4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtImage4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(33)))), ((int)(((byte)(71)))));
            this.txtImage4.Location = new System.Drawing.Point(490, 260);
            this.txtImage4.Name = "txtImage4";
            this.txtImage4.ReadOnly = true;
            this.txtImage4.Size = new System.Drawing.Size(250, 23);
            this.txtImage4.TabIndex = 23;
            // 
            // btnBrowseImage4
            // 
            this.btnBrowseImage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(246)))));
            this.btnBrowseImage4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseImage4.FlatAppearance.BorderSize = 0;
            this.btnBrowseImage4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseImage4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBrowseImage4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(68)))), ((int)(((byte)(149)))));
            this.btnBrowseImage4.Location = new System.Drawing.Point(750, 255);
            this.btnBrowseImage4.Name = "btnBrowseImage4";
            this.btnBrowseImage4.Size = new System.Drawing.Size(90, 32);
            this.btnBrowseImage4.TabIndex = 22;
            this.btnBrowseImage4.Text = "Browse";
            this.btnBrowseImage4.UseVisualStyleBackColor = false;
            this.btnBrowseImage4.Click += new System.EventHandler(this.btnBrowseImage_Click);
            // 
            // lblImage4
            // 
            this.lblImage4.AutoSize = true;
            this.lblImage4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblImage4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(63)))), ((int)(((byte)(114)))));
            this.lblImage4.Location = new System.Drawing.Point(490, 235);
            this.lblImage4.Name = "lblImage4";
            this.lblImage4.Size = new System.Drawing.Size(66, 20);
            this.lblImage4.TabIndex = 21;
            this.lblImage4.Text = "Image 4";
            // 
            // txtImage3
            // 
            this.txtImage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.txtImage3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtImage3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtImage3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(33)))), ((int)(((byte)(71)))));
            this.txtImage3.Location = new System.Drawing.Point(120, 260);
            this.txtImage3.Name = "txtImage3";
            this.txtImage3.ReadOnly = true;
            this.txtImage3.Size = new System.Drawing.Size(250, 23);
            this.txtImage3.TabIndex = 20;
            // 
            // btnBrowseImage3
            // 
            this.btnBrowseImage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(246)))));
            this.btnBrowseImage3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseImage3.FlatAppearance.BorderSize = 0;
            this.btnBrowseImage3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseImage3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBrowseImage3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(68)))), ((int)(((byte)(149)))));
            this.btnBrowseImage3.Location = new System.Drawing.Point(380, 255);
            this.btnBrowseImage3.Name = "btnBrowseImage3";
            this.btnBrowseImage3.Size = new System.Drawing.Size(90, 32);
            this.btnBrowseImage3.TabIndex = 19;
            this.btnBrowseImage3.Text = "Browse";
            this.btnBrowseImage3.UseVisualStyleBackColor = false;
            this.btnBrowseImage3.Click += new System.EventHandler(this.btnBrowseImage_Click);
            // 
            // lblImage3
            // 
            this.lblImage3.AutoSize = true;
            this.lblImage3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblImage3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(63)))), ((int)(((byte)(114)))));
            this.lblImage3.Location = new System.Drawing.Point(120, 235);
            this.lblImage3.Name = "lblImage3";
            this.lblImage3.Size = new System.Drawing.Size(66, 20);
            this.lblImage3.TabIndex = 18;
            this.lblImage3.Text = "Image 3";
            // 
            // txtImage2
            // 
            this.txtImage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.txtImage2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtImage2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtImage2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(33)))), ((int)(((byte)(71)))));
            this.txtImage2.Location = new System.Drawing.Point(490, 200);
            this.txtImage2.Name = "txtImage2";
            this.txtImage2.ReadOnly = true;
            this.txtImage2.Size = new System.Drawing.Size(250, 23);
            this.txtImage2.TabIndex = 17;
            // 
            // btnBrowseImage2
            // 
            this.btnBrowseImage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(246)))));
            this.btnBrowseImage2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseImage2.FlatAppearance.BorderSize = 0;
            this.btnBrowseImage2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseImage2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBrowseImage2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(68)))), ((int)(((byte)(149)))));
            this.btnBrowseImage2.Location = new System.Drawing.Point(750, 195);
            this.btnBrowseImage2.Name = "btnBrowseImage2";
            this.btnBrowseImage2.Size = new System.Drawing.Size(90, 32);
            this.btnBrowseImage2.TabIndex = 16;
            this.btnBrowseImage2.Text = "Browse";
            this.btnBrowseImage2.UseVisualStyleBackColor = false;
            this.btnBrowseImage2.Click += new System.EventHandler(this.btnBrowseImage_Click);
            // 
            // lblImage2
            // 
            this.lblImage2.AutoSize = true;
            this.lblImage2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblImage2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(63)))), ((int)(((byte)(114)))));
            this.lblImage2.Location = new System.Drawing.Point(490, 175);
            this.lblImage2.Name = "lblImage2";
            this.lblImage2.Size = new System.Drawing.Size(66, 20);
            this.lblImage2.TabIndex = 15;
            this.lblImage2.Text = "Image 2";
            // 
            // txtImage1
            // 
            this.txtImage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.txtImage1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtImage1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtImage1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(33)))), ((int)(((byte)(71)))));
            this.txtImage1.Location = new System.Drawing.Point(120, 200);
            this.txtImage1.Name = "txtImage1";
            this.txtImage1.ReadOnly = true;
            this.txtImage1.Size = new System.Drawing.Size(250, 23);
            this.txtImage1.TabIndex = 14;
            // 
            // btnBrowseImage1
            // 
            this.btnBrowseImage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(246)))));
            this.btnBrowseImage1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseImage1.FlatAppearance.BorderSize = 0;
            this.btnBrowseImage1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseImage1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBrowseImage1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(68)))), ((int)(((byte)(149)))));
            this.btnBrowseImage1.Location = new System.Drawing.Point(380, 195);
            this.btnBrowseImage1.Name = "btnBrowseImage1";
            this.btnBrowseImage1.Size = new System.Drawing.Size(90, 32);
            this.btnBrowseImage1.TabIndex = 13;
            this.btnBrowseImage1.Text = "Browse";
            this.btnBrowseImage1.UseVisualStyleBackColor = false;
            this.btnBrowseImage1.Click += new System.EventHandler(this.btnBrowseImage_Click);
            // 
            // lblImage1
            // 
            this.lblImage1.AutoSize = true;
            this.lblImage1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblImage1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(63)))), ((int)(((byte)(114)))));
            this.lblImage1.Location = new System.Drawing.Point(120, 175);
            this.lblImage1.Name = "lblImage1";
            this.lblImage1.Size = new System.Drawing.Size(66, 20);
            this.lblImage1.TabIndex = 12;
            this.lblImage1.Text = "Image 1";
            // 
            // txtSpecialOffer
            // 
            this.txtSpecialOffer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.txtSpecialOffer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSpecialOffer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSpecialOffer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(33)))), ((int)(((byte)(71)))));
            this.txtSpecialOffer.Location = new System.Drawing.Point(490, 110);
            this.txtSpecialOffer.Name = "txtSpecialOffer";
            this.txtSpecialOffer.Size = new System.Drawing.Size(170, 23);
            this.txtSpecialOffer.TabIndex = 11;
            // 
            // lblSpecialOffer
            // 
            this.lblSpecialOffer.AutoSize = true;
            this.lblSpecialOffer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSpecialOffer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(63)))), ((int)(((byte)(114)))));
            this.lblSpecialOffer.Location = new System.Drawing.Point(490, 85);
            this.lblSpecialOffer.Name = "lblSpecialOffer";
            this.lblSpecialOffer.Size = new System.Drawing.Size(115, 20);
            this.lblSpecialOffer.TabIndex = 10;
            this.lblSpecialOffer.Text = "Special Offer %";
            // 
            // txtDiscount
            // 
            this.txtDiscount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.txtDiscount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDiscount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDiscount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(33)))), ((int)(((byte)(71)))));
            this.txtDiscount.Location = new System.Drawing.Point(290, 110);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.ReadOnly = true;
            this.txtDiscount.Size = new System.Drawing.Size(170, 23);
            this.txtDiscount.TabIndex = 9;
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDiscount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(63)))), ((int)(((byte)(114)))));
            this.lblDiscount.Location = new System.Drawing.Point(290, 85);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(150, 20);
            this.lblDiscount.TabIndex = 8;
            this.lblDiscount.Text = "Price After Discount";
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(33)))), ((int)(((byte)(71)))));
            this.txtPrice.Location = new System.Drawing.Point(120, 110);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(150, 23);
            this.txtPrice.TabIndex = 7;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(63)))), ((int)(((byte)(114)))));
            this.lblPrice.Location = new System.Drawing.Point(120, 85);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(43, 20);
            this.lblPrice.TabIndex = 6;
            this.lblPrice.Text = "Price";
            // 
            // cmbCategory
            // 
            this.cmbCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(33)))), ((int)(((byte)(71)))));
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Items.AddRange(new object[] {
            "Electronics",
            "Fashion",
            "Home & Living",
            "Sports",
            "Books"});
            this.cmbCategory.Location = new System.Drawing.Point(700, 45);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(220, 31);
            this.cmbCategory.TabIndex = 5;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(63)))), ((int)(((byte)(114)))));
            this.lblCategory.Location = new System.Drawing.Point(700, 20);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(73, 20);
            this.lblCategory.TabIndex = 4;
            this.lblCategory.Text = "Category";
            // 
            // txtProductName
            // 
            this.txtProductName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.txtProductName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProductName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtProductName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(33)))), ((int)(((byte)(71)))));
            this.txtProductName.Location = new System.Drawing.Point(290, 45);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(380, 23);
            this.txtProductName.TabIndex = 3;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblProductName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(63)))), ((int)(((byte)(114)))));
            this.lblProductName.Location = new System.Drawing.Point(290, 20);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(110, 20);
            this.lblProductName.TabIndex = 2;
            this.lblProductName.Text = "Product Name";
            // 
            // txtProductId
            // 
            this.txtProductId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.txtProductId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProductId.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtProductId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(33)))), ((int)(((byte)(71)))));
            this.txtProductId.Location = new System.Drawing.Point(120, 45);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.ReadOnly = true;
            this.txtProductId.Size = new System.Drawing.Size(150, 23);
            this.txtProductId.TabIndex = 1;
            this.txtProductId.Text = "(Auto)";
            // 
            // lblProductId
            // 
            this.lblProductId.AutoSize = true;
            this.lblProductId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblProductId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(63)))), ((int)(((byte)(114)))));
            this.lblProductId.Location = new System.Drawing.Point(120, 20);
            this.lblProductId.Name = "lblProductId";
            this.lblProductId.Size = new System.Drawing.Size(84, 20);
            this.lblProductId.TabIndex = 0;
            this.lblProductId.Text = "Product ID";
            // 
            // crudTopPanel
            // 
            this.crudTopPanel.Controls.Add(this.btnClear);
            this.crudTopPanel.Controls.Add(this.btnDelete);
            this.crudTopPanel.Controls.Add(this.btnUpdate);
            this.crudTopPanel.Controls.Add(this.btnAdd);
            this.crudTopPanel.Controls.Add(this.lblCrudTitle);
            this.crudTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.crudTopPanel.Location = new System.Drawing.Point(25, 25);
            this.crudTopPanel.Name = "crudTopPanel";
            this.crudTopPanel.Size = new System.Drawing.Size(940, 55);
            this.crudTopPanel.TabIndex = 0;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(233)))), ((int)(((byte)(246)))));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(68)))), ((int)(((byte)(149)))));
            this.btnClear.Location = new System.Drawing.Point(850, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 42);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnDelete.Location = new System.Drawing.Point(760, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 42);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(98)))), ((int)(((byte)(196)))));
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(650, 5);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 42);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(68)))), ((int)(((byte)(149)))));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(560, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 42);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblCrudTitle
            // 
            this.lblCrudTitle.AutoSize = true;
            this.lblCrudTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblCrudTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(33)))), ((int)(((byte)(71)))));
            this.lblCrudTitle.Location = new System.Drawing.Point(0, 5);
            this.lblCrudTitle.Name = "lblCrudTitle";
            this.lblCrudTitle.Size = new System.Drawing.Size(242, 37);
            this.lblCrudTitle.TabIndex = 0;
            this.lblCrudTitle.Text = "Manage Products";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1300, 900);
            this.Controls.Add(this.mainTable);
            this.MinimumSize = new System.Drawing.Size(900, 700);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shopping Cart - Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.mainTable.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.bodyTable.ResumeLayout(false);
            this.sidebarPanel.ResumeLayout(false);
            this.sidebarPanel.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            this.contentTable.ResumeLayout(false);
            this.cardsTable.ResumeLayout(false);
            this.cardTotalSales.ResumeLayout(false);
            this.cardTotalSales.PerformLayout();
            this.cardTotalOrders.ResumeLayout(false);
            this.cardTotalOrders.PerformLayout();
            this.cardTotalProducts.ResumeLayout(false);
            this.cardTotalProducts.PerformLayout();
            this.cardTotalCustomers.ResumeLayout(false);
            this.cardTotalCustomers.PerformLayout();
            this.crudPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            this.inputPanel.ResumeLayout(false);
            this.inputPanel.PerformLayout();
            this.crudTopPanel.ResumeLayout(false);
            this.crudTopPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTable;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.TableLayoutPanel bodyTable;
        private System.Windows.Forms.Panel sidebarPanel;
        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.Button btnNavDashboard;
        private System.Windows.Forms.Button btnNavProducts;
        private System.Windows.Forms.Button btnNavOrders;
        private System.Windows.Forms.Button btnNavCustomers;
        private System.Windows.Forms.Button btnNavSettings;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.TableLayoutPanel contentTable;
        private System.Windows.Forms.TableLayoutPanel cardsTable;
        private System.Windows.Forms.Panel cardTotalSales;
        private System.Windows.Forms.Label lblSalesTitle;
        private System.Windows.Forms.Label lblSalesValue;
        private System.Windows.Forms.Panel cardTotalOrders;
        private System.Windows.Forms.Label lblOrdersTitle;
        private System.Windows.Forms.Label lblOrdersValue;
        private System.Windows.Forms.Panel cardTotalProducts;
        private System.Windows.Forms.Label lblProductsTitle;
        private System.Windows.Forms.Label lblProductsValue;
        private System.Windows.Forms.Panel cardTotalCustomers;
        private System.Windows.Forms.Label lblCustomersTitle;
        private System.Windows.Forms.Label lblCustomersValue;
        private System.Windows.Forms.Panel crudPanel;
        private System.Windows.Forms.Panel crudTopPanel;
        private System.Windows.Forms.Label lblCrudTitle;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private System.Windows.Forms.Panel inputPanel;
        private System.Windows.Forms.Label lblProductId;
        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label lblSpecialOffer;
        private System.Windows.Forms.TextBox txtSpecialOffer;
        private System.Windows.Forms.Label lblImage1;
        private System.Windows.Forms.TextBox txtImage1;
        private System.Windows.Forms.Button btnBrowseImage1;
        private System.Windows.Forms.Label lblImage2;
        private System.Windows.Forms.TextBox txtImage2;
        private System.Windows.Forms.Button btnBrowseImage2;
        private System.Windows.Forms.Label lblImage3;
        private System.Windows.Forms.TextBox txtImage3;
        private System.Windows.Forms.Button btnBrowseImage3;
        private System.Windows.Forms.Label lblImage4;
        private System.Windows.Forms.TextBox txtImage4;
        private System.Windows.Forms.Button btnBrowseImage4;
        private System.Windows.Forms.Label lblCreatedAt;
        private System.Windows.Forms.TextBox txtCreatedAt;
    }
}
