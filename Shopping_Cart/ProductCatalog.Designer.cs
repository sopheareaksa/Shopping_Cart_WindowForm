using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace Shopping_Cart
{
    partial class ProductCatalog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainTable = new System.Windows.Forms.TableLayoutPanel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.panelHeaderActions = new System.Windows.Forms.Panel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnMyOrders = new System.Windows.Forms.Button();
            this.btnCart = new System.Windows.Forms.Button();
            this.lblCartCount = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.bodyTable = new System.Windows.Forms.TableLayoutPanel();
            this.sidebarPanel = new System.Windows.Forms.Panel();
            this.btnCategoryBooks = new System.Windows.Forms.Button();
            this.btnCategorySports = new System.Windows.Forms.Button();
            this.btnCategoryHome = new System.Windows.Forms.Button();
            this.btnCategoryFashion = new System.Windows.Forms.Button();
            this.btnCategoryElectronics = new System.Windows.Forms.Button();
            this.btnCategoryAll = new System.Windows.Forms.Button();
            this.lblCategories = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.contentTable = new System.Windows.Forms.TableLayoutPanel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.flowProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.productCard1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanelCard1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelImage1 = new System.Windows.Forms.Panel();
            this.lblImagePlaceholder1 = new System.Windows.Forms.Label();
            this.lblProductName1 = new System.Windows.Forms.Label();
            this.lblProductPrice1 = new System.Windows.Forms.Label();
            this.btnAddToCart1 = new System.Windows.Forms.Button();
            this.productCard2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanelCard2 = new System.Windows.Forms.TableLayoutPanel();
            this.panelImage2 = new System.Windows.Forms.Panel();
            this.lblImagePlaceholder2 = new System.Windows.Forms.Label();
            this.lblProductName2 = new System.Windows.Forms.Label();
            this.lblProductPrice2 = new System.Windows.Forms.Label();
            this.btnAddToCart2 = new System.Windows.Forms.Button();
            this.productCard3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanelCard3 = new System.Windows.Forms.TableLayoutPanel();
            this.panelImage3 = new System.Windows.Forms.Panel();
            this.lblImagePlaceholder3 = new System.Windows.Forms.Label();
            this.lblProductName3 = new System.Windows.Forms.Label();
            this.lblProductPrice3 = new System.Windows.Forms.Label();
            this.btnAddToCart3 = new System.Windows.Forms.Button();
            this.productCard4 = new System.Windows.Forms.Panel();
            this.tableLayoutPanelCard4 = new System.Windows.Forms.TableLayoutPanel();
            this.panelImage4 = new System.Windows.Forms.Panel();
            this.lblImagePlaceholder4 = new System.Windows.Forms.Label();
            this.lblProductName4 = new System.Windows.Forms.Label();
            this.lblProductPrice4 = new System.Windows.Forms.Label();
            this.btnAddToCart4 = new System.Windows.Forms.Button();
            this.mainTable.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.panelHeaderActions.SuspendLayout();
            this.bodyTable.SuspendLayout();
            this.sidebarPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.contentTable.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.flowProducts.SuspendLayout();
            this.productCard1.SuspendLayout();
            this.tableLayoutPanelCard1.SuspendLayout();
            this.panelImage1.SuspendLayout();
            this.productCard2.SuspendLayout();
            this.tableLayoutPanelCard2.SuspendLayout();
            this.panelImage2.SuspendLayout();
            this.productCard3.SuspendLayout();
            this.tableLayoutPanelCard3.SuspendLayout();
            this.panelImage3.SuspendLayout();
            this.productCard4.SuspendLayout();
            this.tableLayoutPanelCard4.SuspendLayout();
            this.panelImage4.SuspendLayout();
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
            this.mainTable.Size = new System.Drawing.Size(1200, 750);
            this.mainTable.TabIndex = 0;
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(43)))), ((int)(((byte)(104)))));
            this.headerPanel.Controls.Add(this.panelHeaderActions);
            this.headerPanel.Controls.Add(this.lblBrand);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Margin = new System.Windows.Forms.Padding(0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(25, 0, 25, 0);
            this.headerPanel.Size = new System.Drawing.Size(1200, 70);
            this.headerPanel.TabIndex = 0;
            // 
            // panelHeaderActions
            // 
            this.panelHeaderActions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelHeaderActions.Controls.Add(this.lblUserName);
            this.panelHeaderActions.Controls.Add(this.btnDashboard);
            this.panelHeaderActions.Controls.Add(this.btnLogout);
            this.panelHeaderActions.Controls.Add(this.btnMyOrders);
            this.panelHeaderActions.Controls.Add(this.btnCart);
            this.panelHeaderActions.Controls.Add(this.lblCartCount);
            this.panelHeaderActions.Location = new System.Drawing.Point(625, 12);
            this.panelHeaderActions.Name = "panelHeaderActions";
            this.panelHeaderActions.Size = new System.Drawing.Size(550, 46);
            this.panelHeaderActions.TabIndex = 1;
            // 
            // lblUserName
            // 
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUserName.ForeColor = System.Drawing.Color.White;
            this.lblUserName.Location = new System.Drawing.Point(0, 2);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(90, 42);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "Hi, Guest";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(65)))), ((int)(((byte)(138)))));
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Location = new System.Drawing.Point(100, 2);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(115, 42);
            this.btnDashboard.TabIndex = 5;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(65)))), ((int)(((byte)(138)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(223, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(95, 42);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnMyOrders
            // 
            this.btnMyOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(65)))), ((int)(((byte)(138)))));
            this.btnMyOrders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMyOrders.FlatAppearance.BorderSize = 0;
            this.btnMyOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyOrders.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMyOrders.ForeColor = System.Drawing.Color.White;
            this.btnMyOrders.Location = new System.Drawing.Point(326, 2);
            this.btnMyOrders.Name = "btnMyOrders";
            this.btnMyOrders.Size = new System.Drawing.Size(115, 42);
            this.btnMyOrders.TabIndex = 0;
            this.btnMyOrders.Text = "My Orders";
            this.btnMyOrders.UseVisualStyleBackColor = false;
            this.btnMyOrders.Click += new System.EventHandler(this.btnMyOrders_Click);
            // 
            // btnCart
            // 
            this.btnCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(91)))), ((int)(((byte)(184)))));
            this.btnCart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCart.FlatAppearance.BorderSize = 0;
            this.btnCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCart.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCart.ForeColor = System.Drawing.Color.White;
            this.btnCart.Location = new System.Drawing.Point(449, 2);
            this.btnCart.Name = "btnCart";
            this.btnCart.Size = new System.Drawing.Size(85, 42);
            this.btnCart.TabIndex = 1;
            this.btnCart.Text = "Cart";
            this.btnCart.UseVisualStyleBackColor = false;
            this.btnCart.Click += new System.EventHandler(this.btnCart_Click);
            // 
            // lblCartCount
            // 
            this.lblCartCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblCartCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCartCount.ForeColor = System.Drawing.Color.White;
            this.lblCartCount.Location = new System.Drawing.Point(520, 2);
            this.lblCartCount.Name = "lblCartCount";
            this.lblCartCount.Size = new System.Drawing.Size(24, 24);
            this.lblCartCount.TabIndex = 2;
            this.lblCartCount.Text = "0";
            this.lblCartCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCartCount.Visible = false;
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblBrand.ForeColor = System.Drawing.Color.White;
            this.lblBrand.Location = new System.Drawing.Point(25, 16);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(160, 41);
            this.lblBrand.TabIndex = 0;
            this.lblBrand.Text = "ShopMart";
            // 
            // bodyTable
            // 
            this.bodyTable.ColumnCount = 2;
            this.bodyTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.bodyTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.bodyTable.Controls.Add(this.sidebarPanel, 0, 0);
            this.bodyTable.Controls.Add(this.contentPanel, 1, 0);
            this.bodyTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bodyTable.Location = new System.Drawing.Point(0, 70);
            this.bodyTable.Margin = new System.Windows.Forms.Padding(0);
            this.bodyTable.Name = "bodyTable";
            this.bodyTable.RowCount = 1;
            this.bodyTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.bodyTable.Size = new System.Drawing.Size(1200, 680);
            this.bodyTable.TabIndex = 1;
            // 
            // sidebarPanel
            // 
            this.sidebarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(68)))), ((int)(((byte)(149)))));
            this.sidebarPanel.Controls.Add(this.btnCategoryBooks);
            this.sidebarPanel.Controls.Add(this.btnCategorySports);
            this.sidebarPanel.Controls.Add(this.btnCategoryHome);
            this.sidebarPanel.Controls.Add(this.btnCategoryFashion);
            this.sidebarPanel.Controls.Add(this.btnCategoryElectronics);
            this.sidebarPanel.Controls.Add(this.btnCategoryAll);
            this.sidebarPanel.Controls.Add(this.lblCategories);
            this.sidebarPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sidebarPanel.Location = new System.Drawing.Point(0, 0);
            this.sidebarPanel.Margin = new System.Windows.Forms.Padding(0);
            this.sidebarPanel.Name = "sidebarPanel";
            this.sidebarPanel.Padding = new System.Windows.Forms.Padding(15);
            this.sidebarPanel.Size = new System.Drawing.Size(200, 680);
            this.sidebarPanel.TabIndex = 0;
            // 
            // btnCategoryBooks
            // 
            this.btnCategoryBooks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCategoryBooks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(68)))), ((int)(((byte)(149)))));
            this.btnCategoryBooks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCategoryBooks.FlatAppearance.BorderSize = 0;
            this.btnCategoryBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategoryBooks.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnCategoryBooks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.btnCategoryBooks.Location = new System.Drawing.Point(15, 340);
            this.btnCategoryBooks.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.btnCategoryBooks.Name = "btnCategoryBooks";
            this.btnCategoryBooks.Size = new System.Drawing.Size(170, 45);
            this.btnCategoryBooks.TabIndex = 6;
            this.btnCategoryBooks.Text = "📚  Books";
            this.btnCategoryBooks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategoryBooks.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.btnCategoryBooks.UseVisualStyleBackColor = false;
            this.btnCategoryBooks.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnCategorySports
            // 
            this.btnCategorySports.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCategorySports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(68)))), ((int)(((byte)(149)))));
            this.btnCategorySports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCategorySports.FlatAppearance.BorderSize = 0;
            this.btnCategorySports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategorySports.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnCategorySports.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.btnCategorySports.Location = new System.Drawing.Point(15, 285);
            this.btnCategorySports.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.btnCategorySports.Name = "btnCategorySports";
            this.btnCategorySports.Size = new System.Drawing.Size(170, 45);
            this.btnCategorySports.TabIndex = 5;
            this.btnCategorySports.Text = "🏀  Sports";
            this.btnCategorySports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategorySports.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.btnCategorySports.UseVisualStyleBackColor = false;
            this.btnCategorySports.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnCategoryHome
            // 
            this.btnCategoryHome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCategoryHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(68)))), ((int)(((byte)(149)))));
            this.btnCategoryHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCategoryHome.FlatAppearance.BorderSize = 0;
            this.btnCategoryHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategoryHome.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnCategoryHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.btnCategoryHome.Location = new System.Drawing.Point(15, 230);
            this.btnCategoryHome.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.btnCategoryHome.Name = "btnCategoryHome";
            this.btnCategoryHome.Size = new System.Drawing.Size(170, 45);
            this.btnCategoryHome.TabIndex = 4;
            this.btnCategoryHome.Text = "🏠  Home & Living";
            this.btnCategoryHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategoryHome.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.btnCategoryHome.UseVisualStyleBackColor = false;
            this.btnCategoryHome.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnCategoryFashion
            // 
            this.btnCategoryFashion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCategoryFashion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(68)))), ((int)(((byte)(149)))));
            this.btnCategoryFashion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCategoryFashion.FlatAppearance.BorderSize = 0;
            this.btnCategoryFashion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategoryFashion.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnCategoryFashion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.btnCategoryFashion.Location = new System.Drawing.Point(15, 175);
            this.btnCategoryFashion.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.btnCategoryFashion.Name = "btnCategoryFashion";
            this.btnCategoryFashion.Size = new System.Drawing.Size(170, 45);
            this.btnCategoryFashion.TabIndex = 3;
            this.btnCategoryFashion.Text = "👗  Fashion";
            this.btnCategoryFashion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategoryFashion.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.btnCategoryFashion.UseVisualStyleBackColor = false;
            this.btnCategoryFashion.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnCategoryElectronics
            // 
            this.btnCategoryElectronics.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCategoryElectronics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(68)))), ((int)(((byte)(149)))));
            this.btnCategoryElectronics.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCategoryElectronics.FlatAppearance.BorderSize = 0;
            this.btnCategoryElectronics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategoryElectronics.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnCategoryElectronics.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.btnCategoryElectronics.Location = new System.Drawing.Point(15, 120);
            this.btnCategoryElectronics.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.btnCategoryElectronics.Name = "btnCategoryElectronics";
            this.btnCategoryElectronics.Size = new System.Drawing.Size(170, 45);
            this.btnCategoryElectronics.TabIndex = 2;
            this.btnCategoryElectronics.Text = "🔌  Electronics";
            this.btnCategoryElectronics.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategoryElectronics.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.btnCategoryElectronics.UseVisualStyleBackColor = false;
            this.btnCategoryElectronics.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnCategoryAll
            // 
            this.btnCategoryAll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCategoryAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(91)))), ((int)(((byte)(184)))));
            this.btnCategoryAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCategoryAll.FlatAppearance.BorderSize = 0;
            this.btnCategoryAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategoryAll.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnCategoryAll.ForeColor = System.Drawing.Color.White;
            this.btnCategoryAll.Location = new System.Drawing.Point(15, 65);
            this.btnCategoryAll.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.btnCategoryAll.Name = "btnCategoryAll";
            this.btnCategoryAll.Size = new System.Drawing.Size(170, 45);
            this.btnCategoryAll.TabIndex = 1;
            this.btnCategoryAll.Text = "🛒  All Products";
            this.btnCategoryAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategoryAll.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.btnCategoryAll.UseVisualStyleBackColor = false;
            this.btnCategoryAll.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // lblCategories
            // 
            this.lblCategories.AutoSize = true;
            this.lblCategories.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCategories.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(181)))), ((int)(((byte)(230)))));
            this.lblCategories.Location = new System.Drawing.Point(15, 20);
            this.lblCategories.Name = "lblCategories";
            this.lblCategories.Size = new System.Drawing.Size(112, 28);
            this.lblCategories.TabIndex = 0;
            this.lblCategories.Text = "Categories";
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.contentPanel.Controls.Add(this.contentTable);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(200, 0);
            this.contentPanel.Margin = new System.Windows.Forms.Padding(0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(15, 20, 15, 20);
            this.contentPanel.Size = new System.Drawing.Size(1000, 680);
            this.contentPanel.TabIndex = 1;
            // 
            // contentTable
            // 
            this.contentTable.ColumnCount = 1;
            this.contentTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentTable.Controls.Add(this.topPanel, 0, 0);
            this.contentTable.Controls.Add(this.flowProducts, 0, 1);
            this.contentTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentTable.Location = new System.Drawing.Point(30, 30);
            this.contentTable.Margin = new System.Windows.Forms.Padding(0);
            this.contentTable.Name = "contentTable";
            this.contentTable.RowCount = 2;
            this.contentTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.contentTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentTable.Size = new System.Drawing.Size(900, 620);
            this.contentTable.TabIndex = 0;
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.topPanel.Controls.Add(this.txtSearch);
            this.topPanel.Controls.Add(this.lblPageTitle);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(900, 55);
            this.topPanel.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(33)))), ((int)(((byte)(71)))));
            this.txtSearch.Location = new System.Drawing.Point(630, 20);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(270, 32);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.Text = "Search products...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(33)))), ((int)(((byte)(71)))));
            this.lblPageTitle.Location = new System.Drawing.Point(0, 10);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(215, 46);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "All Products";
            // 
            // flowProducts
            // 
            this.flowProducts.AutoScroll = true;
            this.flowProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.flowProducts.Controls.Add(this.productCard1);
            this.flowProducts.Controls.Add(this.productCard2);
            this.flowProducts.Controls.Add(this.productCard3);
            this.flowProducts.Controls.Add(this.productCard4);
            this.flowProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowProducts.Location = new System.Drawing.Point(0, 75);
            this.flowProducts.Margin = new System.Windows.Forms.Padding(0);
            this.flowProducts.Name = "flowProducts";
            this.flowProducts.Size = new System.Drawing.Size(900, 545);
            this.flowProducts.TabIndex = 1;
            // 
            // productCard1
            // 
            this.productCard1.BackColor = System.Drawing.Color.White;
            this.productCard1.Controls.Add(this.tableLayoutPanelCard1);
            this.productCard1.Location = new System.Drawing.Point(0, 0);
            this.productCard1.Margin = new System.Windows.Forms.Padding(0, 0, 15, 20);
            this.productCard1.Name = "productCard1";
            this.productCard1.Size = new System.Drawing.Size(210, 290);
            this.productCard1.TabIndex = 0;
            // 
            // tableLayoutPanelCard1
            // 
            this.tableLayoutPanelCard1.ColumnCount = 1;
            this.tableLayoutPanelCard1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCard1.Controls.Add(this.panelImage1, 0, 0);
            this.tableLayoutPanelCard1.Controls.Add(this.lblProductName1, 0, 1);
            this.tableLayoutPanelCard1.Controls.Add(this.lblProductPrice1, 0, 2);
            this.tableLayoutPanelCard1.Controls.Add(this.btnAddToCart1, 0, 3);
            this.tableLayoutPanelCard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCard1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelCard1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelCard1.Name = "tableLayoutPanelCard1";
            this.tableLayoutPanelCard1.RowCount = 4;
            this.tableLayoutPanelCard1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanelCard1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanelCard1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanelCard1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelCard1.Size = new System.Drawing.Size(210, 290);
            this.tableLayoutPanelCard1.TabIndex = 0;
            // 
            // panelImage1
            // 
            this.panelImage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.panelImage1.Controls.Add(this.lblImagePlaceholder1);
            this.panelImage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelImage1.Location = new System.Drawing.Point(10, 10);
            this.panelImage1.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.panelImage1.Name = "panelImage1";
            this.panelImage1.Size = new System.Drawing.Size(190, 150);
            this.panelImage1.TabIndex = 0;
            // 
            // lblImagePlaceholder1
            // 
            this.lblImagePlaceholder1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblImagePlaceholder1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblImagePlaceholder1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblImagePlaceholder1.Location = new System.Drawing.Point(0, 0);
            this.lblImagePlaceholder1.Name = "lblImagePlaceholder1";
            this.lblImagePlaceholder1.Size = new System.Drawing.Size(190, 150);
            this.lblImagePlaceholder1.TabIndex = 0;
            this.lblImagePlaceholder1.Text = "Product Image";
            this.lblImagePlaceholder1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProductName1
            // 
            this.lblProductName1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProductName1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblProductName1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblProductName1.Location = new System.Drawing.Point(12, 160);
            this.lblProductName1.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.lblProductName1.Name = "lblProductName1";
            this.lblProductName1.Size = new System.Drawing.Size(186, 45);
            this.lblProductName1.TabIndex = 1;
            this.lblProductName1.Text = "Wireless Headphones";
            this.lblProductName1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProductPrice1
            // 
            this.lblProductPrice1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProductPrice1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblProductPrice1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblProductPrice1.Location = new System.Drawing.Point(12, 205);
            this.lblProductPrice1.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.lblProductPrice1.Name = "lblProductPrice1";
            this.lblProductPrice1.Size = new System.Drawing.Size(186, 35);
            this.lblProductPrice1.TabIndex = 2;
            this.lblProductPrice1.Text = "$49.99";
            this.lblProductPrice1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAddToCart1
            // 
            this.btnAddToCart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnAddToCart1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddToCart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddToCart1.FlatAppearance.BorderSize = 0;
            this.btnAddToCart1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddToCart1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddToCart1.ForeColor = System.Drawing.Color.White;
            this.btnAddToCart1.Location = new System.Drawing.Point(12, 245);
            this.btnAddToCart1.Margin = new System.Windows.Forms.Padding(12, 5, 12, 10);
            this.btnAddToCart1.Name = "btnAddToCart1";
            this.btnAddToCart1.Size = new System.Drawing.Size(186, 35);
            this.btnAddToCart1.TabIndex = 3;
            this.btnAddToCart1.Text = "Add to Cart";
            this.btnAddToCart1.UseVisualStyleBackColor = false;
            this.btnAddToCart1.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // productCard2
            // 
            this.productCard2.BackColor = System.Drawing.Color.White;
            this.productCard2.Controls.Add(this.tableLayoutPanelCard2);
            this.productCard2.Location = new System.Drawing.Point(225, 0);
            this.productCard2.Margin = new System.Windows.Forms.Padding(0, 0, 15, 20);
            this.productCard2.Name = "productCard2";
            this.productCard2.Size = new System.Drawing.Size(210, 290);
            this.productCard2.TabIndex = 1;
            // 
            // tableLayoutPanelCard2
            // 
            this.tableLayoutPanelCard2.ColumnCount = 1;
            this.tableLayoutPanelCard2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCard2.Controls.Add(this.panelImage2, 0, 0);
            this.tableLayoutPanelCard2.Controls.Add(this.lblProductName2, 0, 1);
            this.tableLayoutPanelCard2.Controls.Add(this.lblProductPrice2, 0, 2);
            this.tableLayoutPanelCard2.Controls.Add(this.btnAddToCart2, 0, 3);
            this.tableLayoutPanelCard2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCard2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelCard2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelCard2.Name = "tableLayoutPanelCard2";
            this.tableLayoutPanelCard2.RowCount = 4;
            this.tableLayoutPanelCard2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanelCard2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanelCard2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanelCard2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelCard2.Size = new System.Drawing.Size(210, 290);
            this.tableLayoutPanelCard2.TabIndex = 0;
            // 
            // panelImage2
            // 
            this.panelImage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(243)))), ((int)(((byte)(199)))));
            this.panelImage2.Controls.Add(this.lblImagePlaceholder2);
            this.panelImage2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelImage2.Location = new System.Drawing.Point(10, 10);
            this.panelImage2.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.panelImage2.Name = "panelImage2";
            this.panelImage2.Size = new System.Drawing.Size(190, 150);
            this.panelImage2.TabIndex = 0;
            // 
            // lblImagePlaceholder2
            // 
            this.lblImagePlaceholder2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblImagePlaceholder2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblImagePlaceholder2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblImagePlaceholder2.Location = new System.Drawing.Point(0, 0);
            this.lblImagePlaceholder2.Name = "lblImagePlaceholder2";
            this.lblImagePlaceholder2.Size = new System.Drawing.Size(190, 150);
            this.lblImagePlaceholder2.TabIndex = 0;
            this.lblImagePlaceholder2.Text = "Product Image";
            this.lblImagePlaceholder2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProductName2
            // 
            this.lblProductName2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProductName2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblProductName2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblProductName2.Location = new System.Drawing.Point(12, 160);
            this.lblProductName2.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.lblProductName2.Name = "lblProductName2";
            this.lblProductName2.Size = new System.Drawing.Size(186, 45);
            this.lblProductName2.TabIndex = 1;
            this.lblProductName2.Text = "Smart Watch";
            this.lblProductName2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProductPrice2
            // 
            this.lblProductPrice2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProductPrice2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblProductPrice2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblProductPrice2.Location = new System.Drawing.Point(12, 205);
            this.lblProductPrice2.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.lblProductPrice2.Name = "lblProductPrice2";
            this.lblProductPrice2.Size = new System.Drawing.Size(186, 35);
            this.lblProductPrice2.TabIndex = 2;
            this.lblProductPrice2.Text = "$129.99";
            this.lblProductPrice2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAddToCart2
            // 
            this.btnAddToCart2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnAddToCart2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddToCart2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddToCart2.FlatAppearance.BorderSize = 0;
            this.btnAddToCart2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddToCart2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddToCart2.ForeColor = System.Drawing.Color.White;
            this.btnAddToCart2.Location = new System.Drawing.Point(12, 245);
            this.btnAddToCart2.Margin = new System.Windows.Forms.Padding(12, 5, 12, 10);
            this.btnAddToCart2.Name = "btnAddToCart2";
            this.btnAddToCart2.Size = new System.Drawing.Size(186, 35);
            this.btnAddToCart2.TabIndex = 3;
            this.btnAddToCart2.Text = "Add to Cart";
            this.btnAddToCart2.UseVisualStyleBackColor = false;
            this.btnAddToCart2.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // productCard3
            // 
            this.productCard3.BackColor = System.Drawing.Color.White;
            this.productCard3.Controls.Add(this.tableLayoutPanelCard3);
            this.productCard3.Location = new System.Drawing.Point(450, 0);
            this.productCard3.Margin = new System.Windows.Forms.Padding(0, 0, 15, 20);
            this.productCard3.Name = "productCard3";
            this.productCard3.Size = new System.Drawing.Size(210, 290);
            this.productCard3.TabIndex = 2;
            // 
            // tableLayoutPanelCard3
            // 
            this.tableLayoutPanelCard3.ColumnCount = 1;
            this.tableLayoutPanelCard3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCard3.Controls.Add(this.panelImage3, 0, 0);
            this.tableLayoutPanelCard3.Controls.Add(this.lblProductName3, 0, 1);
            this.tableLayoutPanelCard3.Controls.Add(this.lblProductPrice3, 0, 2);
            this.tableLayoutPanelCard3.Controls.Add(this.btnAddToCart3, 0, 3);
            this.tableLayoutPanelCard3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCard3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelCard3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelCard3.Name = "tableLayoutPanelCard3";
            this.tableLayoutPanelCard3.RowCount = 4;
            this.tableLayoutPanelCard3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanelCard3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanelCard3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanelCard3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelCard3.Size = new System.Drawing.Size(210, 290);
            this.tableLayoutPanelCard3.TabIndex = 0;
            // 
            // panelImage3
            // 
            this.panelImage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(252)))), ((int)(((byte)(231)))));
            this.panelImage3.Controls.Add(this.lblImagePlaceholder3);
            this.panelImage3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelImage3.Location = new System.Drawing.Point(10, 10);
            this.panelImage3.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.panelImage3.Name = "panelImage3";
            this.panelImage3.Size = new System.Drawing.Size(190, 150);
            this.panelImage3.TabIndex = 0;
            // 
            // lblImagePlaceholder3
            // 
            this.lblImagePlaceholder3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblImagePlaceholder3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblImagePlaceholder3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblImagePlaceholder3.Location = new System.Drawing.Point(0, 0);
            this.lblImagePlaceholder3.Name = "lblImagePlaceholder3";
            this.lblImagePlaceholder3.Size = new System.Drawing.Size(190, 150);
            this.lblImagePlaceholder3.TabIndex = 0;
            this.lblImagePlaceholder3.Text = "Product Image";
            this.lblImagePlaceholder3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProductName3
            // 
            this.lblProductName3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProductName3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblProductName3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblProductName3.Location = new System.Drawing.Point(12, 160);
            this.lblProductName3.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.lblProductName3.Name = "lblProductName3";
            this.lblProductName3.Size = new System.Drawing.Size(186, 45);
            this.lblProductName3.TabIndex = 1;
            this.lblProductName3.Text = "Portable Speaker";
            this.lblProductName3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProductPrice3
            // 
            this.lblProductPrice3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProductPrice3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblProductPrice3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblProductPrice3.Location = new System.Drawing.Point(12, 205);
            this.lblProductPrice3.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.lblProductPrice3.Name = "lblProductPrice3";
            this.lblProductPrice3.Size = new System.Drawing.Size(186, 35);
            this.lblProductPrice3.TabIndex = 2;
            this.lblProductPrice3.Text = "$79.99";
            this.lblProductPrice3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAddToCart3
            // 
            this.btnAddToCart3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnAddToCart3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddToCart3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddToCart3.FlatAppearance.BorderSize = 0;
            this.btnAddToCart3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddToCart3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddToCart3.ForeColor = System.Drawing.Color.White;
            this.btnAddToCart3.Location = new System.Drawing.Point(12, 245);
            this.btnAddToCart3.Margin = new System.Windows.Forms.Padding(12, 5, 12, 10);
            this.btnAddToCart3.Name = "btnAddToCart3";
            this.btnAddToCart3.Size = new System.Drawing.Size(186, 35);
            this.btnAddToCart3.TabIndex = 3;
            this.btnAddToCart3.Text = "Add to Cart";
            this.btnAddToCart3.UseVisualStyleBackColor = false;
            this.btnAddToCart3.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // productCard4
            // 
            this.productCard4.BackColor = System.Drawing.Color.White;
            this.productCard4.Controls.Add(this.tableLayoutPanelCard4);
            this.productCard4.Location = new System.Drawing.Point(675, 0);
            this.productCard4.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.productCard4.Name = "productCard4";
            this.productCard4.Size = new System.Drawing.Size(210, 290);
            this.productCard4.TabIndex = 3;
            // 
            // tableLayoutPanelCard4
            // 
            this.tableLayoutPanelCard4.ColumnCount = 1;
            this.tableLayoutPanelCard4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCard4.Controls.Add(this.panelImage4, 0, 0);
            this.tableLayoutPanelCard4.Controls.Add(this.lblProductName4, 0, 1);
            this.tableLayoutPanelCard4.Controls.Add(this.lblProductPrice4, 0, 2);
            this.tableLayoutPanelCard4.Controls.Add(this.btnAddToCart4, 0, 3);
            this.tableLayoutPanelCard4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCard4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelCard4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelCard4.Name = "tableLayoutPanelCard4";
            this.tableLayoutPanelCard4.RowCount = 4;
            this.tableLayoutPanelCard4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanelCard4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanelCard4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanelCard4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelCard4.Size = new System.Drawing.Size(210, 290);
            this.tableLayoutPanelCard4.TabIndex = 0;
            // 
            // panelImage4
            // 
            this.panelImage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.panelImage4.Controls.Add(this.lblImagePlaceholder4);
            this.panelImage4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelImage4.Location = new System.Drawing.Point(10, 10);
            this.panelImage4.Margin = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.panelImage4.Name = "panelImage4";
            this.panelImage4.Size = new System.Drawing.Size(190, 150);
            this.panelImage4.TabIndex = 0;
            // 
            // lblImagePlaceholder4
            // 
            this.lblImagePlaceholder4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblImagePlaceholder4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblImagePlaceholder4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblImagePlaceholder4.Location = new System.Drawing.Point(0, 0);
            this.lblImagePlaceholder4.Name = "lblImagePlaceholder4";
            this.lblImagePlaceholder4.Size = new System.Drawing.Size(190, 150);
            this.lblImagePlaceholder4.TabIndex = 0;
            this.lblImagePlaceholder4.Text = "Product Image";
            this.lblImagePlaceholder4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProductName4
            // 
            this.lblProductName4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProductName4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblProductName4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.lblProductName4.Location = new System.Drawing.Point(12, 160);
            this.lblProductName4.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.lblProductName4.Name = "lblProductName4";
            this.lblProductName4.Size = new System.Drawing.Size(186, 45);
            this.lblProductName4.TabIndex = 1;
            this.lblProductName4.Text = "USB-C Cable";
            this.lblProductName4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProductPrice4
            // 
            this.lblProductPrice4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProductPrice4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblProductPrice4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.lblProductPrice4.Location = new System.Drawing.Point(12, 205);
            this.lblProductPrice4.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.lblProductPrice4.Name = "lblProductPrice4";
            this.lblProductPrice4.Size = new System.Drawing.Size(186, 35);
            this.lblProductPrice4.TabIndex = 2;
            this.lblProductPrice4.Text = "$14.99";
            this.lblProductPrice4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAddToCart4
            // 
            this.btnAddToCart4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnAddToCart4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddToCart4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddToCart4.FlatAppearance.BorderSize = 0;
            this.btnAddToCart4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddToCart4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddToCart4.ForeColor = System.Drawing.Color.White;
            this.btnAddToCart4.Location = new System.Drawing.Point(12, 245);
            this.btnAddToCart4.Margin = new System.Windows.Forms.Padding(12, 5, 12, 10);
            this.btnAddToCart4.Name = "btnAddToCart4";
            this.btnAddToCart4.Size = new System.Drawing.Size(186, 35);
            this.btnAddToCart4.TabIndex = 3;
            this.btnAddToCart4.Text = "Add to Cart";
            this.btnAddToCart4.UseVisualStyleBackColor = false;
            this.btnAddToCart4.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // ProductCatalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.mainTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "ProductCatalog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShopMart - Product Catalog";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ProductCatalog_Load);
            this.mainTable.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.panelHeaderActions.ResumeLayout(false);
            this.bodyTable.ResumeLayout(false);
            this.sidebarPanel.ResumeLayout(false);
            this.sidebarPanel.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            this.contentTable.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.flowProducts.ResumeLayout(false);
            this.productCard1.ResumeLayout(false);
            this.tableLayoutPanelCard1.ResumeLayout(false);
            this.panelImage1.ResumeLayout(false);
            this.productCard2.ResumeLayout(false);
            this.tableLayoutPanelCard2.ResumeLayout(false);
            this.panelImage2.ResumeLayout(false);
            this.productCard3.ResumeLayout(false);
            this.tableLayoutPanelCard3.ResumeLayout(false);
            this.panelImage3.ResumeLayout(false);
            this.productCard4.ResumeLayout(false);
            this.tableLayoutPanelCard4.ResumeLayout(false);
            this.panelImage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainTable;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Panel panelHeaderActions;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnMyOrders;
        private System.Windows.Forms.Button btnCart;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblCartCount;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TableLayoutPanel bodyTable;
        private System.Windows.Forms.Panel sidebarPanel;
        private System.Windows.Forms.Label lblCategories;
        private System.Windows.Forms.Button btnCategoryAll;
        private System.Windows.Forms.Button btnCategoryElectronics;
        private System.Windows.Forms.Button btnCategoryFashion;
        private System.Windows.Forms.Button btnCategoryHome;
        private System.Windows.Forms.Button btnCategorySports;
        private System.Windows.Forms.Button btnCategoryBooks;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.TableLayoutPanel contentTable;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.FlowLayoutPanel flowProducts;
        private System.Windows.Forms.Panel productCard1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCard1;
        private System.Windows.Forms.Panel panelImage1;
        private System.Windows.Forms.Label lblImagePlaceholder1;
        private System.Windows.Forms.Label lblProductName1;
        private System.Windows.Forms.Label lblProductPrice1;
        private System.Windows.Forms.Button btnAddToCart1;
        private System.Windows.Forms.Panel productCard2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCard2;
        private System.Windows.Forms.Panel panelImage2;
        private System.Windows.Forms.Label lblImagePlaceholder2;
        private System.Windows.Forms.Label lblProductName2;
        private System.Windows.Forms.Label lblProductPrice2;
        private System.Windows.Forms.Button btnAddToCart2;
        private System.Windows.Forms.Panel productCard3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCard3;
        private System.Windows.Forms.Panel panelImage3;
        private System.Windows.Forms.Label lblImagePlaceholder3;
        private System.Windows.Forms.Label lblProductName3;
        private System.Windows.Forms.Label lblProductPrice3;
        private System.Windows.Forms.Button btnAddToCart3;
        private System.Windows.Forms.Panel productCard4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCard4;
        private System.Windows.Forms.Panel panelImage4;
        private System.Windows.Forms.Label lblImagePlaceholder4;
        private System.Windows.Forms.Label lblProductName4;
        private System.Windows.Forms.Label lblProductPrice4;
        private System.Windows.Forms.Button btnAddToCart4;

        // Product Detail Panel controls
        private System.Windows.Forms.Panel panelProductDetail;
        private System.Windows.Forms.PictureBox picDetailImage;
        private System.Windows.Forms.Label lblDetailName;
        private System.Windows.Forms.Label lblDetailCategory;
        private System.Windows.Forms.Label lblDetailOriginalPrice;
        private System.Windows.Forms.Label lblDetailFinalPrice;
        private System.Windows.Forms.Label lblDetailDiscount;
        private System.Windows.Forms.Label lblDetailSpecialOffer;
        private System.Windows.Forms.Label lblDetailStock;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Button btnBackToProducts;
        private System.Windows.Forms.Button btnDetailAddToCart;
        private System.Windows.Forms.FlowLayoutPanel flowDetailThumbnails;

        // Cart Page controls
        private System.Windows.Forms.Panel panelCartPage;
        private System.Windows.Forms.FlowLayoutPanel flowCartItems;
        private System.Windows.Forms.Label lblCartTotal;
        private System.Windows.Forms.Label lblCartEmpty;
        private System.Windows.Forms.Button btnContinueShopping;
        private System.Windows.Forms.Button btnCheckout;

        // Payment Page controls
        private System.Windows.Forms.Panel panelPaymentPage;
        private System.Windows.Forms.Label lblPaymentOrderTotal;
        private System.Windows.Forms.Button btnTabCard;
        private System.Windows.Forms.Button btnTabKhqr;
        private System.Windows.Forms.Panel panelCardPayment;
        private System.Windows.Forms.TextBox txtCardName;
        private System.Windows.Forms.TextBox txtCardNumber;
        private System.Windows.Forms.TextBox txtCardExpiry;
        private System.Windows.Forms.TextBox txtCardCvv;
        private System.Windows.Forms.Button btnPayNow;
        private System.Windows.Forms.Button btnCardContinue;

        private System.Windows.Forms.Panel panelKhqrPayment;
        private System.Windows.Forms.PictureBox picKhqr;
        private System.Windows.Forms.Label lblKhqrStatus;
        private System.Windows.Forms.Label lblKhqrAmount;
        private System.Windows.Forms.Button btnGenerateKhqr;
        private System.Windows.Forms.Button btnCheckKhqrStatus;
        private System.Windows.Forms.Button btnKhqrContinue;
        private System.Windows.Forms.Timer khqrCheckTimer;

        private void BuildProductDetailPanel()
        {
            panelProductDetail = new System.Windows.Forms.Panel();
            panelProductDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            panelProductDetail.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            panelProductDetail.Padding = new System.Windows.Forms.Padding(30);
            panelProductDetail.Visible = false;
            panelProductDetail.AutoScroll = true;
            contentPanel.Controls.Add(panelProductDetail);
            panelProductDetail.BringToFront();

            System.Windows.Forms.TableLayoutPanel detailTable = new System.Windows.Forms.TableLayoutPanel();
            detailTable.Dock = System.Windows.Forms.DockStyle.Fill;
            detailTable.ColumnCount = 2;
            detailTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            detailTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            detailTable.RowCount = 1;
            detailTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            System.Windows.Forms.Panel imagePanel = new System.Windows.Forms.Panel();
            imagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            imagePanel.BackColor = System.Drawing.Color.White;
            imagePanel.Padding = new System.Windows.Forms.Padding(20);

            picDetailImage = new System.Windows.Forms.PictureBox();
            picDetailImage.Dock = System.Windows.Forms.DockStyle.Fill;
            picDetailImage.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            picDetailImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            picDetailImage.Margin = new System.Windows.Forms.Padding(0);
            imagePanel.Controls.Add(picDetailImage);

            flowDetailThumbnails = new System.Windows.Forms.FlowLayoutPanel();
            flowDetailThumbnails.Dock = System.Windows.Forms.DockStyle.Bottom;
            flowDetailThumbnails.Height = 80;
            flowDetailThumbnails.BackColor = System.Drawing.Color.White;
            flowDetailThumbnails.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            flowDetailThumbnails.AutoScroll = true;
            flowDetailThumbnails.WrapContents = false;
            imagePanel.Controls.Add(flowDetailThumbnails);
            flowDetailThumbnails.BringToFront();

            System.Windows.Forms.Panel infoPanel = new System.Windows.Forms.Panel();
            infoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            infoPanel.BackColor = System.Drawing.Color.White;
            infoPanel.Padding = new System.Windows.Forms.Padding(30);

            btnBackToProducts = new System.Windows.Forms.Button();
            btnBackToProducts.Text = "← Back to Products";
            btnBackToProducts.AutoSize = true;
            btnBackToProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBackToProducts.FlatAppearance.BorderSize = 0;
            btnBackToProducts.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnBackToProducts.ForeColor = System.Drawing.Color.FromArgb(59, 130, 246);
            btnBackToProducts.BackColor = System.Drawing.Color.White;
            btnBackToProducts.Cursor = System.Windows.Forms.Cursors.Hand;
            btnBackToProducts.Location = new System.Drawing.Point(30, 30);
            btnBackToProducts.Click += new System.EventHandler(this.btnBackToProducts_Click);
            infoPanel.Controls.Add(btnBackToProducts);

            lblDetailName = new System.Windows.Forms.Label();
            lblDetailName.AutoSize = true;
            lblDetailName.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            lblDetailName.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            lblDetailName.Location = new System.Drawing.Point(30, 75);
            lblDetailName.MaximumSize = new System.Drawing.Size(420, 0);
            infoPanel.Controls.Add(lblDetailName);

            lblDetailCategory = new System.Windows.Forms.Label();
            lblDetailCategory.AutoSize = true;
            lblDetailCategory.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblDetailCategory.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            lblDetailCategory.Location = new System.Drawing.Point(30, 120);
            infoPanel.Controls.Add(lblDetailCategory);

            lblDetailOriginalPrice = new System.Windows.Forms.Label();
            lblDetailOriginalPrice.AutoSize = true;
            lblDetailOriginalPrice.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Strikeout);
            lblDetailOriginalPrice.ForeColor = System.Drawing.Color.FromArgb(156, 163, 175);
            lblDetailOriginalPrice.Location = new System.Drawing.Point(30, 175);
            infoPanel.Controls.Add(lblDetailOriginalPrice);

            lblDetailFinalPrice = new System.Windows.Forms.Label();
            lblDetailFinalPrice.AutoSize = true;
            lblDetailFinalPrice.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            lblDetailFinalPrice.ForeColor = System.Drawing.Color.FromArgb(59, 130, 246);
            lblDetailFinalPrice.Location = new System.Drawing.Point(30, 205);
            infoPanel.Controls.Add(lblDetailFinalPrice);

            lblDetailDiscount = new System.Windows.Forms.Label();
            lblDetailDiscount.AutoSize = true;
            lblDetailDiscount.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblDetailDiscount.ForeColor = System.Drawing.Color.FromArgb(239, 68, 68);
            lblDetailDiscount.BackColor = System.Drawing.Color.FromArgb(254, 226, 226);
            lblDetailDiscount.Padding = new System.Windows.Forms.Padding(8, 4, 8, 4);
            lblDetailDiscount.Location = new System.Drawing.Point(30, 270);
            lblDetailDiscount.Visible = false;
            infoPanel.Controls.Add(lblDetailDiscount);

            lblDetailSpecialOffer = new System.Windows.Forms.Label();
            lblDetailSpecialOffer.AutoSize = true;
            lblDetailSpecialOffer.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblDetailSpecialOffer.ForeColor = System.Drawing.Color.White;
            lblDetailSpecialOffer.BackColor = System.Drawing.Color.FromArgb(245, 158, 11);
            lblDetailSpecialOffer.Padding = new System.Windows.Forms.Padding(8, 4, 8, 4);
            lblDetailSpecialOffer.Location = new System.Drawing.Point(30, 270);
            lblDetailSpecialOffer.Visible = false;
            infoPanel.Controls.Add(lblDetailSpecialOffer);

            lblDetailStock = new System.Windows.Forms.Label();
            lblDetailStock.AutoSize = true;
            lblDetailStock.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblDetailStock.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129);
            lblDetailStock.Location = new System.Drawing.Point(30, 310);
            infoPanel.Controls.Add(lblDetailStock);

            System.Windows.Forms.Label lblQuantity = new System.Windows.Forms.Label();
            lblQuantity.Text = "Quantity:";
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblQuantity.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            lblQuantity.Location = new System.Drawing.Point(30, 350);
            infoPanel.Controls.Add(lblQuantity);

            numQuantity = new System.Windows.Forms.NumericUpDown();
            numQuantity.Font = new System.Drawing.Font("Segoe UI", 12F);
            numQuantity.Minimum = 1;
            numQuantity.Maximum = 99;
            numQuantity.Value = 1;
            numQuantity.Width = 80;
            numQuantity.Location = new System.Drawing.Point(130, 345);
            infoPanel.Controls.Add(numQuantity);

            btnDetailAddToCart = new System.Windows.Forms.Button();
            btnDetailAddToCart.Text = "Add to Cart";
            btnDetailAddToCart.Size = new System.Drawing.Size(220, 55);
            btnDetailAddToCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDetailAddToCart.FlatAppearance.BorderSize = 0;
            btnDetailAddToCart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            btnDetailAddToCart.ForeColor = System.Drawing.Color.White;
            btnDetailAddToCart.BackColor = System.Drawing.Color.FromArgb(59, 130, 246);
            btnDetailAddToCart.Cursor = System.Windows.Forms.Cursors.Hand;
            btnDetailAddToCart.Location = new System.Drawing.Point(30, 415);
            btnDetailAddToCart.Click += new System.EventHandler(this.btnDetailAddToCart_Click);
            infoPanel.Controls.Add(btnDetailAddToCart);

            detailTable.Controls.Add(imagePanel, 0, 0);
            detailTable.Controls.Add(infoPanel, 1, 0);
            panelProductDetail.Controls.Add(detailTable);
        }

        private void BuildCartPanel()
        {
            panelCartPage = new System.Windows.Forms.Panel();
            panelCartPage.Dock = System.Windows.Forms.DockStyle.Fill;
            panelCartPage.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            panelCartPage.Padding = new System.Windows.Forms.Padding(30);
            panelCartPage.Visible = false;
            panelCartPage.AutoScroll = true;
            contentPanel.Controls.Add(panelCartPage);
            panelCartPage.BringToFront();

            System.Windows.Forms.TableLayoutPanel cartTable = new System.Windows.Forms.TableLayoutPanel();
            cartTable.Dock = System.Windows.Forms.DockStyle.Fill;
            cartTable.ColumnCount = 1;
            cartTable.RowCount = 3;
            cartTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            cartTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            cartTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));

            System.Windows.Forms.Panel cartHeader = new System.Windows.Forms.Panel();
            cartHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            cartHeader.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);

            System.Windows.Forms.Button btnBack = new System.Windows.Forms.Button();
            btnBack.Text = "← Back to Products";
            btnBack.AutoSize = true;
            btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnBack.ForeColor = System.Drawing.Color.FromArgb(59, 130, 246);
            btnBack.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            btnBack.Location = new System.Drawing.Point(0, 10);
            btnBack.Click += (s, ev) => ShowProductList();
            cartHeader.Controls.Add(btnBack);

            System.Windows.Forms.Label lblTitle = new System.Windows.Forms.Label();
            lblTitle.Text = "Shopping Cart";
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            lblTitle.AutoSize = true;
            lblTitle.Location = new System.Drawing.Point(0, 45);
            cartHeader.Controls.Add(lblTitle);

            System.Windows.Forms.Panel cartItemsPanel = new System.Windows.Forms.Panel();
            cartItemsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            cartItemsPanel.BackColor = System.Drawing.Color.White;
            cartItemsPanel.Padding = new System.Windows.Forms.Padding(20);
            cartItemsPanel.AutoScroll = true;

            flowCartItems = new System.Windows.Forms.FlowLayoutPanel();
            flowCartItems.Dock = System.Windows.Forms.DockStyle.Fill;
            flowCartItems.BackColor = System.Drawing.Color.White;
            flowCartItems.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowCartItems.WrapContents = false;
            flowCartItems.AutoScroll = true;
            cartItemsPanel.Controls.Add(flowCartItems);

            lblCartEmpty = new System.Windows.Forms.Label();
            lblCartEmpty.Text = "Your cart is empty.";
            lblCartEmpty.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblCartEmpty.ForeColor = System.Drawing.Color.FromArgb(156, 163, 175);
            lblCartEmpty.AutoSize = true;
            lblCartEmpty.Visible = false;
            flowCartItems.Controls.Add(lblCartEmpty);

            System.Windows.Forms.Panel cartFooter = new System.Windows.Forms.Panel();
            cartFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            cartFooter.BackColor = System.Drawing.Color.White;
            cartFooter.Padding = new System.Windows.Forms.Padding(20);

            lblCartTotal = new System.Windows.Forms.Label();
            lblCartTotal.Text = "Total: $0.00";
            lblCartTotal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            lblCartTotal.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            lblCartTotal.AutoSize = true;
            lblCartTotal.Location = new System.Drawing.Point(20, 25);
            cartFooter.Controls.Add(lblCartTotal);

            btnContinueShopping = new System.Windows.Forms.Button();
            btnContinueShopping.Text = "Continue Shopping";
            btnContinueShopping.Size = new System.Drawing.Size(180, 50);
            btnContinueShopping.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnContinueShopping.FlatAppearance.BorderSize = 1;
            btnContinueShopping.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(229, 231, 235);
            btnContinueShopping.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnContinueShopping.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            btnContinueShopping.BackColor = System.Drawing.Color.White;
            btnContinueShopping.Cursor = System.Windows.Forms.Cursors.Hand;
            btnContinueShopping.Location = new System.Drawing.Point(400, 20);
            btnContinueShopping.Click += (s, ev) => ShowProductList();
            cartFooter.Controls.Add(btnContinueShopping);

            btnCheckout = new System.Windows.Forms.Button();
            btnCheckout.Text = "Checkout";
            btnCheckout.Size = new System.Drawing.Size(180, 50);
            btnCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCheckout.FlatAppearance.BorderSize = 0;
            btnCheckout.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnCheckout.ForeColor = System.Drawing.Color.White;
            btnCheckout.BackColor = System.Drawing.Color.FromArgb(59, 130, 246);
            btnCheckout.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCheckout.Location = new System.Drawing.Point(600, 20);
            btnCheckout.Click += (s, ev) => btnCheckout_Click(s, ev);
            cartFooter.Controls.Add(btnCheckout);

            cartTable.Controls.Add(cartHeader, 0, 0);
            cartTable.Controls.Add(cartItemsPanel, 0, 1);
            cartTable.Controls.Add(cartFooter, 0, 2);
            panelCartPage.Controls.Add(cartTable);
        }

        private void BuildPaymentPanel()
        {
            panelPaymentPage = new System.Windows.Forms.Panel();
            panelPaymentPage.Dock = System.Windows.Forms.DockStyle.Fill;
            panelPaymentPage.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            panelPaymentPage.Padding = new System.Windows.Forms.Padding(20);
            panelPaymentPage.Visible = false;
            panelPaymentPage.AutoScroll = true;
            contentPanel.Controls.Add(panelPaymentPage);
            panelPaymentPage.BringToFront();

            khqrCheckTimer = new System.Windows.Forms.Timer();
            khqrCheckTimer.Interval = 3000;
            khqrCheckTimer.Tick += new System.EventHandler(this.khqrCheckTimer_Tick);

            System.Windows.Forms.Panel centerPanel = new System.Windows.Forms.Panel();
            centerPanel.Size = new System.Drawing.Size(540, 650);
            centerPanel.BackColor = System.Drawing.Color.White;
            centerPanel.Padding = new System.Windows.Forms.Padding(0);
            centerPanel.Location = new System.Drawing.Point(
                (panelPaymentPage.Width - centerPanel.Width) / 2,
                10);
            centerPanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            panelPaymentPage.Controls.Add(centerPanel);
            panelPaymentPage.Resize += (s, ev) =>
            {
                centerPanel.Left = (panelPaymentPage.Width - centerPanel.Width) / 2;
            };

            System.Windows.Forms.Label lblTitle = new System.Windows.Forms.Label();
            lblTitle.Text = "Payment";
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            lblTitle.AutoSize = true;
            lblTitle.Location = new System.Drawing.Point(35, 18);
            centerPanel.Controls.Add(lblTitle);

            System.Windows.Forms.Label lblSubtitle = new System.Windows.Forms.Label();
            lblSubtitle.Text = "Select your payment method to complete your purchase";
            lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            lblSubtitle.AutoSize = true;
            lblSubtitle.Location = new System.Drawing.Point(35, 58);
            centerPanel.Controls.Add(lblSubtitle);

            // Total banner
            System.Windows.Forms.Panel totalPanel = new System.Windows.Forms.Panel();
            totalPanel.Size = new System.Drawing.Size(470, 60);
            totalPanel.BackColor = System.Drawing.Color.FromArgb(239, 246, 255);
            totalPanel.Location = new System.Drawing.Point(35, 90);
            totalPanel.Padding = new System.Windows.Forms.Padding(0);
            centerPanel.Controls.Add(totalPanel);

            System.Windows.Forms.Label lblTotalText = new System.Windows.Forms.Label();
            lblTotalText.Text = "Order Total";
            lblTotalText.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblTotalText.ForeColor = System.Drawing.Color.FromArgb(59, 130, 246);
            lblTotalText.Location = new System.Drawing.Point(15, 8);
            lblTotalText.Size = new System.Drawing.Size(120, 20);
            totalPanel.Controls.Add(lblTotalText);

            lblPaymentOrderTotal = new System.Windows.Forms.Label();
            lblPaymentOrderTotal.Text = "$0.00";
            lblPaymentOrderTotal.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            lblPaymentOrderTotal.ForeColor = System.Drawing.Color.FromArgb(59, 130, 246);
            lblPaymentOrderTotal.AutoSize = true;
            lblPaymentOrderTotal.Location = new System.Drawing.Point(15, 26);
            totalPanel.Controls.Add(lblPaymentOrderTotal);

            // Tabs panel
            System.Windows.Forms.Panel tabsPanel = new System.Windows.Forms.Panel();
            tabsPanel.Size = new System.Drawing.Size(470, 44);
            tabsPanel.Location = new System.Drawing.Point(35, 160);
            centerPanel.Controls.Add(tabsPanel);

            btnTabCard = new System.Windows.Forms.Button();
            btnTabCard.Text = "💳 Credit / Debit Card";
            btnTabCard.Size = new System.Drawing.Size(230, 44);
            btnTabCard.Location = new System.Drawing.Point(0, 0);
            btnTabCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnTabCard.FlatAppearance.BorderSize = 0;
            btnTabCard.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnTabCard.BackColor = System.Drawing.Color.FromArgb(59, 130, 246);
            btnTabCard.ForeColor = System.Drawing.Color.White;
            btnTabCard.Cursor = System.Windows.Forms.Cursors.Hand;
            btnTabCard.Click += (s, ev) => SwitchPaymentMethod(false);
            tabsPanel.Controls.Add(btnTabCard);

            btnTabKhqr = new System.Windows.Forms.Button();
            btnTabKhqr.Text = "📱 Bakong KHQR";
            btnTabKhqr.Size = new System.Drawing.Size(230, 44);
            btnTabKhqr.Location = new System.Drawing.Point(240, 0);
            btnTabKhqr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnTabKhqr.FlatAppearance.BorderSize = 0;
            btnTabKhqr.Font = new System.Drawing.Font("Segoe UI", 11F);
            btnTabKhqr.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            btnTabKhqr.ForeColor = System.Drawing.Color.FromArgb(75, 85, 99);
            btnTabKhqr.Cursor = System.Windows.Forms.Cursors.Hand;
            btnTabKhqr.Click += (s, ev) => SwitchPaymentMethod(true);
            tabsPanel.Controls.Add(btnTabKhqr);

            // 1. Credit Card Panel
            panelCardPayment = new System.Windows.Forms.Panel();
            panelCardPayment.Size = new System.Drawing.Size(470, 420);
            panelCardPayment.Location = new System.Drawing.Point(35, 215);
            panelCardPayment.BackColor = System.Drawing.Color.White;
            centerPanel.Controls.Add(panelCardPayment);

            System.Windows.Forms.Label lblName = CreateFieldLabel("Cardholder Name");
            lblName.Location = new System.Drawing.Point(0, 5);
            panelCardPayment.Controls.Add(lblName);

            txtCardName = CreateModernTextBox(470, 36);
            txtCardName.Location = new System.Drawing.Point(0, 30);
            panelCardPayment.Controls.Add(txtCardName);

            System.Windows.Forms.Label lblNumber = CreateFieldLabel("Card Number");
            lblNumber.Location = new System.Drawing.Point(0, 75);
            panelCardPayment.Controls.Add(lblNumber);

            txtCardNumber = CreateModernTextBox(470, 36);
            txtCardNumber.Location = new System.Drawing.Point(0, 100);
            txtCardNumber.MaxLength = 16;
            panelCardPayment.Controls.Add(txtCardNumber);

            System.Windows.Forms.Label lblExpiry = CreateFieldLabel("Expiry Date");
            lblExpiry.Location = new System.Drawing.Point(0, 145);
            panelCardPayment.Controls.Add(lblExpiry);

            txtCardExpiry = CreateModernTextBox(220, 36);
            txtCardExpiry.Location = new System.Drawing.Point(0, 170);
            txtCardExpiry.MaxLength = 5;
            txtCardExpiry.Text = "MM/YY";
            txtCardExpiry.ForeColor = System.Drawing.Color.FromArgb(156, 163, 175);
            txtCardExpiry.Enter += (s, ev) =>
            {
                if (txtCardExpiry.Text == "MM/YY")
                {
                    txtCardExpiry.Text = "";
                    txtCardExpiry.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
                }
            };
            txtCardExpiry.Leave += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtCardExpiry.Text))
                {
                    txtCardExpiry.Text = "MM/YY";
                    txtCardExpiry.ForeColor = System.Drawing.Color.FromArgb(156, 163, 175);
                }
            };
            panelCardPayment.Controls.Add(txtCardExpiry);

            System.Windows.Forms.Label lblCvv = CreateFieldLabel("CVV");
            lblCvv.Location = new System.Drawing.Point(250, 145);
            panelCardPayment.Controls.Add(lblCvv);

            txtCardCvv = CreateModernTextBox(220, 36);
            txtCardCvv.Location = new System.Drawing.Point(250, 170);
            txtCardCvv.MaxLength = 4;
            txtCardCvv.PasswordChar = '*';
            panelCardPayment.Controls.Add(txtCardCvv);

            btnCardContinue = new System.Windows.Forms.Button();
            btnCardContinue.Text = "Continue Shopping";
            btnCardContinue.Size = new System.Drawing.Size(220, 50);
            btnCardContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCardContinue.FlatAppearance.BorderSize = 1;
            btnCardContinue.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(229, 231, 235);
            btnCardContinue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnCardContinue.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            btnCardContinue.BackColor = System.Drawing.Color.White;
            btnCardContinue.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCardContinue.Location = new System.Drawing.Point(0, 230);
            btnCardContinue.Click += (s, ev) =>
            {
                ClearPaymentFields();
                ShowProductList();
            };
            panelCardPayment.Controls.Add(btnCardContinue);

            btnPayNow = new System.Windows.Forms.Button();
            btnPayNow.Text = "Pay Now";
            btnPayNow.Size = new System.Drawing.Size(230, 50);
            btnPayNow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnPayNow.FlatAppearance.BorderSize = 0;
            btnPayNow.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnPayNow.ForeColor = System.Drawing.Color.White;
            btnPayNow.BackColor = System.Drawing.Color.FromArgb(59, 130, 246);
            btnPayNow.Cursor = System.Windows.Forms.Cursors.Hand;
            btnPayNow.Location = new System.Drawing.Point(240, 230);
            btnPayNow.Click += new System.EventHandler(this.btnPayNow_Click);
            panelCardPayment.Controls.Add(btnPayNow);

            System.Windows.Forms.Label lblSecure = new System.Windows.Forms.Label();
            lblSecure.Text = "🔒 Secure 256-bit SSL Encrypted Payment";
            lblSecure.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblSecure.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            lblSecure.AutoSize = true;
            lblSecure.Location = new System.Drawing.Point(120, 300);
            panelCardPayment.Controls.Add(lblSecure);

            // 2. KHQR Bakong Panel
            panelKhqrPayment = new System.Windows.Forms.Panel();
            panelKhqrPayment.Size = new System.Drawing.Size(470, 420);
            panelKhqrPayment.Location = new System.Drawing.Point(35, 215);
            panelKhqrPayment.BackColor = System.Drawing.Color.White;
            panelKhqrPayment.Visible = false;
            centerPanel.Controls.Add(panelKhqrPayment);

            System.Windows.Forms.Label lblKhqrDesc = new System.Windows.Forms.Label();
            lblKhqrDesc.Text = "Scan with ABA, ACLEDA, Bakong or any KHQR banking app";
            lblKhqrDesc.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            lblKhqrDesc.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            lblKhqrDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblKhqrDesc.Dock = System.Windows.Forms.DockStyle.Top;
            lblKhqrDesc.Height = 22;
            panelKhqrPayment.Controls.Add(lblKhqrDesc);

            // QR Box Frame
            System.Windows.Forms.Panel qrFrame = new System.Windows.Forms.Panel();
            qrFrame.Size = new System.Drawing.Size(200, 200);
            qrFrame.Location = new System.Drawing.Point(135, 28);
            qrFrame.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            qrFrame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelKhqrPayment.Controls.Add(qrFrame);

            picKhqr = new System.Windows.Forms.PictureBox();
            picKhqr.Dock = System.Windows.Forms.DockStyle.Fill;
            picKhqr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            picKhqr.BackColor = System.Drawing.Color.White;
            qrFrame.Controls.Add(picKhqr);

            lblKhqrAmount = new System.Windows.Forms.Label();
            lblKhqrAmount.Text = "Amount: $0.00";
            lblKhqrAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblKhqrAmount.ForeColor = System.Drawing.Color.FromArgb(59, 130, 246);
            lblKhqrAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblKhqrAmount.Location = new System.Drawing.Point(0, 232);
            lblKhqrAmount.Size = new System.Drawing.Size(470, 24);
            panelKhqrPayment.Controls.Add(lblKhqrAmount);

            lblKhqrStatus = new System.Windows.Forms.Label();
            lblKhqrStatus.Text = "Click 'Generate KHQR' to create QR code";
            lblKhqrStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            lblKhqrStatus.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            lblKhqrStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblKhqrStatus.Location = new System.Drawing.Point(0, 258);
            lblKhqrStatus.Size = new System.Drawing.Size(470, 38);
            panelKhqrPayment.Controls.Add(lblKhqrStatus);

            btnGenerateKhqr = new System.Windows.Forms.Button();
            btnGenerateKhqr.Text = "⚡ Generate KHQR";
            btnGenerateKhqr.Size = new System.Drawing.Size(220, 44);
            btnGenerateKhqr.Location = new System.Drawing.Point(0, 305);
            btnGenerateKhqr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnGenerateKhqr.FlatAppearance.BorderSize = 0;
            btnGenerateKhqr.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            btnGenerateKhqr.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            btnGenerateKhqr.ForeColor = System.Drawing.Color.White;
            btnGenerateKhqr.Cursor = System.Windows.Forms.Cursors.Hand;
            btnGenerateKhqr.Click += new System.EventHandler(this.btnGenerateKhqr_Click);
            panelKhqrPayment.Controls.Add(btnGenerateKhqr);

            btnCheckKhqrStatus = new System.Windows.Forms.Button();
            btnCheckKhqrStatus.Text = "🔄 Check Status";
            btnCheckKhqrStatus.Size = new System.Drawing.Size(230, 44);
            btnCheckKhqrStatus.Location = new System.Drawing.Point(240, 305);
            btnCheckKhqrStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCheckKhqrStatus.FlatAppearance.BorderSize = 0;
            btnCheckKhqrStatus.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            btnCheckKhqrStatus.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            btnCheckKhqrStatus.ForeColor = System.Drawing.Color.White;
            btnCheckKhqrStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCheckKhqrStatus.Click += new System.EventHandler(this.btnCheckKhqrStatus_Click);
            panelKhqrPayment.Controls.Add(btnCheckKhqrStatus);

            btnKhqrContinue = new System.Windows.Forms.Button();
            btnKhqrContinue.Text = "← Back to Shopping";
            btnKhqrContinue.Size = new System.Drawing.Size(180, 36);
            btnKhqrContinue.Location = new System.Drawing.Point(145, 360);
            btnKhqrContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnKhqrContinue.FlatAppearance.BorderSize = 0;
            btnKhqrContinue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            btnKhqrContinue.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            btnKhqrContinue.BackColor = System.Drawing.Color.White;
            btnKhqrContinue.Cursor = System.Windows.Forms.Cursors.Hand;
            btnKhqrContinue.Click += (s, ev) =>
            {
                khqrCheckTimer.Stop();
                ClearPaymentFields();
                ShowProductList();
            };
            panelKhqrPayment.Controls.Add(btnKhqrContinue);
        }

        private System.Windows.Forms.TextBox CreateModernTextBox(int width, int height)
        {
            System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox();
            textBox.Size = new System.Drawing.Size(width, height);
            textBox.Font = new System.Drawing.Font("Segoe UI", 11F);
            textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox.BackColor = System.Drawing.Color.White;
            textBox.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            textBox.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            return textBox;
        }

        private System.Windows.Forms.Label CreateFieldLabel(string text)
        {
            System.Windows.Forms.Label label = new System.Windows.Forms.Label();
            label.Text = text;
            label.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            label.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            label.AutoSize = true;
            return label;
        }

        private Panel CreateProductCard(DataRow row)
        {
            int productId = Convert.ToInt32(row["ProductId"]);
            string productName = row["ProductName"].ToString();
            decimal price = Convert.ToDecimal(row["Price"]);
            decimal discount = row["Discount"] == DBNull.Value ? 0 : Convert.ToDecimal(row["Discount"]);
            int specialOffer = row["SpecialOffer"] == DBNull.Value ? 0 : Convert.ToInt32(row["SpecialOffer"]);
            int stock = row.Table.Columns.Contains("Stock") && row["Stock"] != DBNull.Value ? Convert.ToInt32(row["Stock"]) : 0;
            string imagePath = row["Image1"].ToString();

            decimal finalPrice = CalculateFinalPrice(price, discount, specialOffer);

            Panel card = new Panel();
            card.Size = new Size(185, 275);
            card.BackColor = Color.White;
            card.Margin = new Padding(0, 0, 12, 16);

            TableLayoutPanel table = new TableLayoutPanel();
            table.Dock = DockStyle.Fill;
            table.ColumnCount = 1;
            table.RowCount = 4;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 140F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));

            PictureBox pictureBox = new PictureBox();
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.BackColor = Color.FromArgb(241, 245, 249);
            pictureBox.Margin = new Padding(8, 8, 8, 0);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

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
            nameLabel.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            nameLabel.ForeColor = Color.FromArgb(15, 23, 42);
            nameLabel.Margin = new Padding(10, 0, 10, 0);
            nameLabel.TextAlign = ContentAlignment.MiddleLeft;

            Label priceLabel = new Label();
            if (stock <= 0)
            {
                priceLabel.Text = $"${finalPrice:N2} (Out of Stock)";
                priceLabel.ForeColor = Color.FromArgb(239, 68, 68);
            }
            else if (stock <= 5)
            {
                priceLabel.Text = $"${finalPrice:N2} (Only {stock} left!)";
                priceLabel.ForeColor = Color.FromArgb(217, 119, 6);
            }
            else
            {
                priceLabel.Text = $"${finalPrice:N2} (Stock: {stock})";
                priceLabel.ForeColor = Color.FromArgb(91, 68, 149);
            }
            priceLabel.Dock = DockStyle.Fill;
            priceLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            priceLabel.Margin = new Padding(10, 0, 10, 0);
            priceLabel.TextAlign = ContentAlignment.MiddleLeft;

            Button addButton = new Button();
            addButton.Dock = DockStyle.Fill;
            addButton.FlatStyle = FlatStyle.Flat;
            addButton.FlatAppearance.BorderSize = 0;
            addButton.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            addButton.Margin = new Padding(10, 4, 10, 8);

            if (stock <= 0)
            {
                addButton.Text = "Out of Stock";
                addButton.BackColor = Color.FromArgb(229, 231, 235);
                addButton.ForeColor = Color.FromArgb(156, 163, 175);
                addButton.Cursor = Cursors.Default;
                addButton.Enabled = false;
            }
            else
            {
                addButton.Text = "Add to Cart";
                addButton.BackColor = Color.FromArgb(91, 68, 149);
                addButton.ForeColor = Color.White;
                addButton.Cursor = Cursors.Hand;
                addButton.Enabled = true;
            }

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

            Button btnSavePdf = new Button();
            btnSavePdf.Text = "💾 Save as PDF";
            btnSavePdf.Size = new Size(170, 45);
            btnSavePdf.FlatStyle = FlatStyle.Flat;
            btnSavePdf.FlatAppearance.BorderSize = 0;
            btnSavePdf.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSavePdf.ForeColor = Color.White;
            btnSavePdf.BackColor = Color.FromArgb(239, 68, 68);
            btnSavePdf.Cursor = Cursors.Hand;
            btnSavePdf.Location = new Point(20, 12);
            btnSavePdf.Click += (s, ev) => SaveInvoiceAsPdf(orderId);
            footerPanel.Controls.Add(btnSavePdf);

            Button btnPrint = new Button();
            btnPrint.Text = "🖨️ Print Invoice";
            btnPrint.Size = new Size(170, 45);
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPrint.ForeColor = Color.White;
            btnPrint.BackColor = Color.FromArgb(16, 185, 129);
            btnPrint.Cursor = Cursors.Hand;
            btnPrint.Location = new Point(200, 12);
            btnPrint.Click += (s, ev) => PrintInvoice();
            footerPanel.Controls.Add(btnPrint);

            Button btnContinue = new Button();
            btnContinue.Text = "Continue Shopping";
            btnContinue.Size = new Size(190, 45);
            btnContinue.FlatStyle = FlatStyle.Flat;
            btnContinue.FlatAppearance.BorderSize = 0;
            btnContinue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnContinue.ForeColor = Color.White;
            btnContinue.BackColor = Color.FromArgb(59, 130, 246);
            btnContinue.Cursor = Cursors.Hand;
            btnContinue.Location = new Point(380, 12);
            btnContinue.DialogResult = DialogResult.OK;
            footerPanel.Controls.Add(btnContinue);

            invoiceForm.AcceptButton = btnContinue;
            invoiceForm.ShowDialog(this);
        }

        private void SaveInvoiceAsPdf(int orderId)
        {
            if (invoicePrintPanel == null) return;

            bool hasPdfPrinter = false;
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                if (printer.Equals("Microsoft Print to PDF", StringComparison.OrdinalIgnoreCase))
                {
                    hasPdfPrinter = true;
                    break;
                }
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Save Invoice to File Explorer";
                sfd.Filter = hasPdfPrinter
                    ? "PDF Document (*.pdf)|*.pdf|PNG Image (*.png)|*.png|All Files (*.*)|*.*"
                    : "PNG Image (*.png)|*.png|Bitmap Image (*.bmp)|*.bmp|All Files (*.*)|*.*";
                sfd.FileName = $"Invoice_INV-{orderId}.pdf";
                sfd.DefaultExt = hasPdfPrinter ? "pdf" : "png";
                sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string filePath = sfd.FileName;
                        string extension = Path.GetExtension(filePath).ToLower();

                        if (extension == ".pdf" && hasPdfPrinter)
                        {
                            SaveAsPdfFile(filePath);
                        }
                        else
                        {
                            SaveAsImageFile(filePath);
                        }

                        DialogResult res = MessageBox.Show(
                            $"Invoice saved successfully to:\n\n{filePath}\n\nWould you like to open its location in File Explorer?",
                            "Invoice Saved",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information);

                        if (res == DialogResult.Yes)
                        {
                            try
                            {
                                System.Diagnostics.Process.Start("explorer.exe", $"/select,\"{filePath}\"");
                            }
                            catch
                            {
                                System.Diagnostics.Process.Start(Path.GetDirectoryName(filePath));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving invoice: {ex.Message}", "Save Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void SaveAsPdfFile(string filePath)
        {
            if (invoicePrintPanel == null) return;

            PrintDocument pd = new PrintDocument();
            pd.PrinterSettings.PrinterName = "Microsoft Print to PDF";
            pd.PrinterSettings.PrintToFile = true;
            pd.PrinterSettings.PrintFileName = filePath;
            pd.DefaultPageSettings.Margins = new Margins(30, 30, 30, 30);

            pd.PrintPage += (s, ev) =>
            {
                Rectangle printableArea = ev.MarginBounds;
                using (Bitmap bitmap = new Bitmap(invoicePrintPanel.Width, invoicePrintPanel.Height))
                {
                    invoicePrintPanel.DrawToBitmap(bitmap, new Rectangle(0, 0, invoicePrintPanel.Width, invoicePrintPanel.Height));
                    float scale = Math.Min((float)printableArea.Width / invoicePrintPanel.Width, (float)printableArea.Height / invoicePrintPanel.Height);
                    int destWidth = (int)(invoicePrintPanel.Width * scale);
                    int destHeight = (int)(invoicePrintPanel.Height * scale);
                    int destX = printableArea.X + (printableArea.Width - destWidth) / 2;
                    int destY = printableArea.Y;

                    ev.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    ev.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    ev.Graphics.DrawImage(bitmap, destX, destY, destWidth, destHeight);
                }
                ev.HasMorePages = false;
            };

            pd.Print();
        }

        private void SaveAsImageFile(string filePath)
        {
            if (invoicePrintPanel == null) return;

            using (Bitmap bitmap = new Bitmap(invoicePrintPanel.Width, invoicePrintPanel.Height))
            {
                invoicePrintPanel.DrawToBitmap(bitmap, new Rectangle(0, 0, invoicePrintPanel.Width, invoicePrintPanel.Height));
                string ext = Path.GetExtension(filePath).ToLower();
                System.Drawing.Imaging.ImageFormat format = System.Drawing.Imaging.ImageFormat.Png;
                if (ext == ".jpg" || ext == ".jpeg") format = System.Drawing.Imaging.ImageFormat.Jpeg;
                else if (ext == ".bmp") format = System.Drawing.Imaging.ImageFormat.Bmp;

                bitmap.Save(filePath, format);
            }
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
                if (btn != null)
                {
                    btn.BackColor = Color.FromArgb(91, 68, 149);
                    btn.ForeColor = Color.FromArgb(235, 230, 250);
                    btn.Font = new Font("Segoe UI", 11F);
                }
            }
        }
    }
}
