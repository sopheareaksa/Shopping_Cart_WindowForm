using System;
using System.Drawing;
using System.Windows.Forms;

namespace Shopping_Cart
{
    partial class Authentication
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
            this.pnlCenterWrapper = new System.Windows.Forms.Panel();
            this.pnlFormCard = new System.Windows.Forms.Panel();
            this.lblBrandName = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlName = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.pnlEmail = new System.Windows.Forms.Panel();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.pnlPassword = new System.Windows.Forms.Panel();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.chkShowPassword = new System.Windows.Forms.CheckBox();
            this.lnkForgotPassword = new System.Windows.Forms.LinkLabel();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lnkToggleMode = new System.Windows.Forms.LinkLabel();
            this.lnkBackToLogin = new System.Windows.Forms.LinkLabel();
            this.pnlCenterWrapper.SuspendLayout();
            this.pnlFormCard.SuspendLayout();
            this.pnlName.SuspendLayout();
            this.pnlEmail.SuspendLayout();
            this.pnlPassword.SuspendLayout();
            this.pnlOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCenterWrapper
            // 
            this.pnlCenterWrapper.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlCenterWrapper.Controls.Add(this.pnlFormCard);
            this.pnlCenterWrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenterWrapper.Location = new System.Drawing.Point(0, 0);
            this.pnlCenterWrapper.Name = "pnlCenterWrapper";
            this.pnlCenterWrapper.Padding = new System.Windows.Forms.Padding(35, 25, 35, 25);
            this.pnlCenterWrapper.Size = new System.Drawing.Size(540, 600);
            this.pnlCenterWrapper.TabIndex = 0;
            // 
            // pnlFormCard
            // 
            this.pnlFormCard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlFormCard.BackColor = System.Drawing.Color.White;
            this.pnlFormCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFormCard.Controls.Add(this.lnkBackToLogin);
            this.pnlFormCard.Controls.Add(this.lnkToggleMode);
            this.pnlFormCard.Controls.Add(this.btnSubmit);
            this.pnlFormCard.Controls.Add(this.pnlOptions);
            this.pnlFormCard.Controls.Add(this.pnlPassword);
            this.pnlFormCard.Controls.Add(this.pnlEmail);
            this.pnlFormCard.Controls.Add(this.pnlName);
            this.pnlFormCard.Controls.Add(this.lblSubtitle);
            this.pnlFormCard.Controls.Add(this.lblTitle);
            this.pnlFormCard.Controls.Add(this.lblBrandName);
            this.pnlFormCard.Location = new System.Drawing.Point(35, 25);
            this.pnlFormCard.Name = "pnlFormCard";
            this.pnlFormCard.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.pnlFormCard.Size = new System.Drawing.Size(470, 520);
            this.pnlFormCard.TabIndex = 0;
            // 
            // lblBrandName
            // 
            this.lblBrandName.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblBrandName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblBrandName.Location = new System.Drawing.Point(0, 15);
            this.lblBrandName.Name = "lblBrandName";
            this.lblBrandName.Size = new System.Drawing.Size(470, 42);
            this.lblBrandName.TabIndex = 0;
            this.lblBrandName.Text = "ShopMart";
            this.lblBrandName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 58);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(470, 32);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Welcome Back";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSubtitle.Location = new System.Drawing.Point(0, 90);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(470, 22);
            this.lblSubtitle.TabIndex = 2;
            this.lblSubtitle.Text = "Sign in to access your shopping cart and orders";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlName
            // 
            this.pnlName.Controls.Add(this.txtName);
            this.pnlName.Controls.Add(this.lblName);
            this.pnlName.Location = new System.Drawing.Point(30, 120);
            this.pnlName.Name = "pnlName";
            this.pnlName.Size = new System.Drawing.Size(410, 56);
            this.pnlName.TabIndex = 3;
            this.pnlName.Visible = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblName.Location = new System.Drawing.Point(0, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(89, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "FULL NAME";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtName.Location = new System.Drawing.Point(0, 22);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(410, 32);
            this.txtName.TabIndex = 1;
            // 
            // pnlEmail
            // 
            this.pnlEmail.Controls.Add(this.txtEmail);
            this.pnlEmail.Controls.Add(this.lblEmail);
            this.pnlEmail.Location = new System.Drawing.Point(30, 120);
            this.pnlEmail.Name = "pnlEmail";
            this.pnlEmail.Size = new System.Drawing.Size(410, 56);
            this.pnlEmail.TabIndex = 4;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblEmail.Location = new System.Drawing.Point(0, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(121, 20);
            this.lblEmail.TabIndex = 0;
            this.lblEmail.Text = "EMAIL ADDRESS";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtEmail.Location = new System.Drawing.Point(0, 22);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(410, 32);
            this.txtEmail.TabIndex = 1;
            // 
            // pnlPassword
            // 
            this.pnlPassword.Controls.Add(this.txtPassword);
            this.pnlPassword.Controls.Add(this.lblPassword);
            this.pnlPassword.Location = new System.Drawing.Point(30, 185);
            this.pnlPassword.Name = "pnlPassword";
            this.pnlPassword.Size = new System.Drawing.Size(410, 56);
            this.pnlPassword.TabIndex = 5;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblPassword.Location = new System.Drawing.Point(0, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(91, 20);
            this.lblPassword.TabIndex = 0;
            this.lblPassword.Text = "PASSWORD";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtPassword.Location = new System.Drawing.Point(0, 22);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.Size = new System.Drawing.Size(410, 32);
            this.txtPassword.TabIndex = 1;
            // 
            // pnlOptions
            // 
            this.pnlOptions.Controls.Add(this.chkShowPassword);
            this.pnlOptions.Controls.Add(this.lnkForgotPassword);
            this.pnlOptions.Location = new System.Drawing.Point(30, 250);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(410, 26);
            this.pnlOptions.TabIndex = 6;
            // 
            // chkShowPassword
            // 
            this.chkShowPassword.AutoSize = true;
            this.chkShowPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkShowPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkShowPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.chkShowPassword.Location = new System.Drawing.Point(0, 2);
            this.chkShowPassword.Name = "chkShowPassword";
            this.chkShowPassword.Size = new System.Drawing.Size(135, 24);
            this.chkShowPassword.TabIndex = 0;
            this.chkShowPassword.Text = "Show password";
            this.chkShowPassword.UseVisualStyleBackColor = true;
            this.chkShowPassword.CheckedChanged += new System.EventHandler(this.chkShowPassword_CheckedChanged);
            // 
            // lnkForgotPassword
            // 
            this.lnkForgotPassword.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(78)))), ((int)(((byte)(216)))));
            this.lnkForgotPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkForgotPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lnkForgotPassword.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkForgotPassword.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lnkForgotPassword.Location = new System.Drawing.Point(210, 2);
            this.lnkForgotPassword.Name = "lnkForgotPassword";
            this.lnkForgotPassword.Size = new System.Drawing.Size(200, 22);
            this.lnkForgotPassword.TabIndex = 1;
            this.lnkForgotPassword.TabStop = true;
            this.lnkForgotPassword.Text = "Forgot Password?";
            this.lnkForgotPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnkForgotPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkForgotPassword_LinkClicked);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(30, 285);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(410, 46);
            this.btnSubmit.TabIndex = 7;
            this.btnSubmit.Text = "Sign In";
            this.btnSubmit.UseVisualStyleBackColor = false;
            // 
            // lnkToggleMode
            // 
            this.lnkToggleMode.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(78)))), ((int)(((byte)(216)))));
            this.lnkToggleMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkToggleMode.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lnkToggleMode.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkToggleMode.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lnkToggleMode.Location = new System.Drawing.Point(30, 340);
            this.lnkToggleMode.Name = "lnkToggleMode";
            this.lnkToggleMode.Size = new System.Drawing.Size(410, 30);
            this.lnkToggleMode.TabIndex = 8;
            this.lnkToggleMode.TabStop = true;
            this.lnkToggleMode.Text = "Don\'t have an account? Sign up";
            this.lnkToggleMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkToggleMode.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkToggleMode_LinkClicked);
            // 
            // lnkBackToLogin
            // 
            this.lnkBackToLogin.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(78)))), ((int)(((byte)(216)))));
            this.lnkBackToLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkBackToLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lnkBackToLogin.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkBackToLogin.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lnkBackToLogin.Location = new System.Drawing.Point(30, 400);
            this.lnkBackToLogin.Name = "lnkBackToLogin";
            this.lnkBackToLogin.Size = new System.Drawing.Size(410, 32);
            this.lnkBackToLogin.TabIndex = 9;
            this.lnkBackToLogin.TabStop = true;
            this.lnkBackToLogin.Text = "← Back to Login";
            this.lnkBackToLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkBackToLogin.Visible = false;
            this.lnkBackToLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkBackToLogin_LinkClicked);
            // 
            // Authentication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(540, 600);
            this.Controls.Add(this.pnlCenterWrapper);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimumSize = new System.Drawing.Size(540, 600);
            this.Name = "Authentication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShopMart - Authentication";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlCenterWrapper.ResumeLayout(false);
            this.pnlFormCard.ResumeLayout(false);
            this.pnlFormCard.PerformLayout();
            this.pnlName.ResumeLayout(false);
            this.pnlName.PerformLayout();
            this.pnlEmail.ResumeLayout(false);
            this.pnlEmail.PerformLayout();
            this.pnlPassword.ResumeLayout(false);
            this.pnlPassword.PerformLayout();
            this.pnlOptions.ResumeLayout(false);
            this.pnlOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        // Track current mode state
        private bool isRegisterMode = false;

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '•';
        }

        private void lnkToggleMode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            isRegisterMode = !isRegisterMode;
            ApplyLayoutMode();
        }

        private void lnkBackToLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            isRegisterMode = false;
            ApplyLayoutMode();
        }

        private void ApplyLayoutMode()
        {
            if (isRegisterMode)
            {
                // Switch to Register View
                lblTitle.Text = "Create Account";
                lblSubtitle.Text = "Fill in your details to get started with ShopMart";
                btnSubmit.Text = "Create Account";

                // Dynamic layout
                pnlName.Visible = true;
                pnlName.Location = new System.Drawing.Point(30, 120);
                pnlEmail.Location = new System.Drawing.Point(30, 182);
                pnlPassword.Location = new System.Drawing.Point(30, 244);
                pnlOptions.Location = new System.Drawing.Point(30, 306);
                lnkForgotPassword.Visible = false;
                btnSubmit.Location = new System.Drawing.Point(30, 340);

                lnkToggleMode.Visible = false;
                lnkBackToLogin.Visible = true;
                lnkBackToLogin.Location = new System.Drawing.Point(30, 396);
                lnkBackToLogin.BringToFront();
            }
            else
            {
                // Switch back to Login View
                lblTitle.Text = "Welcome Back";
                lblSubtitle.Text = "Sign in to access your shopping cart and orders";
                btnSubmit.Text = "Sign In";

                // Dynamic layout
                pnlName.Visible = false;
                pnlEmail.Location = new System.Drawing.Point(30, 120);
                pnlPassword.Location = new System.Drawing.Point(30, 185);
                pnlOptions.Location = new System.Drawing.Point(30, 250);
                lnkForgotPassword.Visible = true;
                btnSubmit.Location = new System.Drawing.Point(30, 285);

                lnkToggleMode.Visible = true;
                lnkToggleMode.Text = "Don't have an account? Sign up";
                lnkToggleMode.Location = new System.Drawing.Point(30, 340);
                lnkToggleMode.BringToFront();
                lnkBackToLogin.Visible = false;
            }
        }

        private System.Windows.Forms.Panel pnlCenterWrapper;
        private System.Windows.Forms.Panel pnlFormCard;
        private System.Windows.Forms.Label lblBrandName;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Panel pnlEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Panel pnlPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.CheckBox chkShowPassword;
        private System.Windows.Forms.LinkLabel lnkForgotPassword;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.LinkLabel lnkToggleMode;
        private System.Windows.Forms.LinkLabel lnkBackToLogin;
    }

    partial class ForgotPasswordForm
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.lblHeaderSubtitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.grpStep1 = new System.Windows.Forms.GroupBox();
            this.lblEmailPrompt = new System.Windows.Forms.Label();
            this.txtEmailField = new System.Windows.Forms.TextBox();
            this.btnSendOtp = new System.Windows.Forms.Button();
            this.lblEmailMsg = new System.Windows.Forms.Label();
            this.grpStep2 = new System.Windows.Forms.GroupBox();
            this.lblOtpPrompt = new System.Windows.Forms.Label();
            this.txtOtpField = new System.Windows.Forms.TextBox();
            this.btnVerifyOtp = new System.Windows.Forms.Button();
            this.lnkResendOtp = new System.Windows.Forms.LinkLabel();
            this.lblOtpMsg = new System.Windows.Forms.Label();
            this.grpStep3 = new System.Windows.Forms.GroupBox();
            this.lblNewPassPrompt = new System.Windows.Forms.Label();
            this.txtNewPassField = new System.Windows.Forms.TextBox();
            this.lblConfirmPassPrompt = new System.Windows.Forms.Label();
            this.txtConfirmPassField = new System.Windows.Forms.TextBox();
            this.chkShowPassword = new System.Windows.Forms.CheckBox();
            this.btnSetNewPassword = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.grpStep1.SuspendLayout();
            this.grpStep2.SuspendLayout();
            this.grpStep3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.lblHeaderTitle);
            this.panelHeader.Controls.Add(this.lblHeaderSubtitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Padding = new System.Windows.Forms.Padding(20, 12, 20, 10);
            this.panelHeader.Size = new System.Drawing.Size(484, 75);
            this.panelHeader.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lblHeaderTitle.Location = new System.Drawing.Point(20, 12);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(205, 35);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "Forgot Password";
            // 
            // lblHeaderSubtitle
            // 
            this.lblHeaderSubtitle.AutoSize = true;
            this.lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblHeaderSubtitle.Location = new System.Drawing.Point(22, 42);
            this.lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            this.lblHeaderSubtitle.Size = new System.Drawing.Size(338, 20);
            this.lblHeaderSubtitle.TabIndex = 1;
            this.lblHeaderSubtitle.Text = "Verify your email with OTP and set a new password.";
            // 
            // pnlContent
            // 
            this.pnlContent.AutoScroll = true;
            this.pnlContent.Controls.Add(this.grpStep1);
            this.pnlContent.Controls.Add(this.grpStep2);
            this.pnlContent.Controls.Add(this.grpStep3);
            this.pnlContent.Controls.Add(this.btnClose);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 75);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.pnlContent.Size = new System.Drawing.Size(484, 566);
            this.pnlContent.TabIndex = 1;
            // 
            // grpStep1
            // 
            this.grpStep1.Controls.Add(this.lblEmailPrompt);
            this.grpStep1.Controls.Add(this.txtEmailField);
            this.grpStep1.Controls.Add(this.btnSendOtp);
            this.grpStep1.Controls.Add(this.lblEmailMsg);
            this.grpStep1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpStep1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.grpStep1.Location = new System.Drawing.Point(20, 10);
            this.grpStep1.Name = "grpStep1";
            this.grpStep1.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.grpStep1.Size = new System.Drawing.Size(440, 130);
            this.grpStep1.TabIndex = 0;
            this.grpStep1.TabStop = false;
            this.grpStep1.Text = "Step 1: Request OTP";
            // 
            // lblEmailPrompt
            // 
            this.lblEmailPrompt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEmailPrompt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblEmailPrompt.Location = new System.Drawing.Point(15, 25);
            this.lblEmailPrompt.Name = "lblEmailPrompt";
            this.lblEmailPrompt.Size = new System.Drawing.Size(200, 20);
            this.lblEmailPrompt.TabIndex = 0;
            this.lblEmailPrompt.Text = "Registered Email Address:";
            // 
            // txtEmailField
            // 
            this.txtEmailField.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtEmailField.Location = new System.Drawing.Point(15, 48);
            this.txtEmailField.Name = "txtEmailField";
            this.txtEmailField.Size = new System.Drawing.Size(270, 31);
            this.txtEmailField.TabIndex = 1;
            // 
            // btnSendOtp
            // 
            this.btnSendOtp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnSendOtp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendOtp.FlatAppearance.BorderSize = 0;
            this.btnSendOtp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendOtp.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSendOtp.ForeColor = System.Drawing.Color.White;
            this.btnSendOtp.Location = new System.Drawing.Point(295, 46);
            this.btnSendOtp.Name = "btnSendOtp";
            this.btnSendOtp.Size = new System.Drawing.Size(130, 32);
            this.btnSendOtp.TabIndex = 2;
            this.btnSendOtp.Text = "Send OTP";
            this.btnSendOtp.UseVisualStyleBackColor = false;
            // 
            // lblEmailMsg
            // 
            this.lblEmailMsg.AutoEllipsis = true;
            this.lblEmailMsg.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblEmailMsg.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblEmailMsg.Location = new System.Drawing.Point(15, 82);
            this.lblEmailMsg.Name = "lblEmailMsg";
            this.lblEmailMsg.Size = new System.Drawing.Size(410, 38);
            this.lblEmailMsg.TabIndex = 3;
            // 
            // grpStep2
            // 
            this.grpStep2.Controls.Add(this.lblOtpPrompt);
            this.grpStep2.Controls.Add(this.txtOtpField);
            this.grpStep2.Controls.Add(this.btnVerifyOtp);
            this.grpStep2.Controls.Add(this.lnkResendOtp);
            this.grpStep2.Controls.Add(this.lblOtpMsg);
            this.grpStep2.Enabled = false;
            this.grpStep2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpStep2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.grpStep2.Location = new System.Drawing.Point(20, 150);
            this.grpStep2.Name = "grpStep2";
            this.grpStep2.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.grpStep2.Size = new System.Drawing.Size(440, 130);
            this.grpStep2.TabIndex = 1;
            this.grpStep2.TabStop = false;
            this.grpStep2.Text = "Step 2: Enter & Verify OTP";
            // 
            // lblOtpPrompt
            // 
            this.lblOtpPrompt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblOtpPrompt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblOtpPrompt.Location = new System.Drawing.Point(15, 25);
            this.lblOtpPrompt.Name = "lblOtpPrompt";
            this.lblOtpPrompt.Size = new System.Drawing.Size(200, 20);
            this.lblOtpPrompt.TabIndex = 0;
            this.lblOtpPrompt.Text = "6-Digit OTP Code:";
            // 
            // txtOtpField
            // 
            this.txtOtpField.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtOtpField.Location = new System.Drawing.Point(15, 48);
            this.txtOtpField.MaxLength = 8;
            this.txtOtpField.Name = "txtOtpField";
            this.txtOtpField.Size = new System.Drawing.Size(160, 34);
            this.txtOtpField.TabIndex = 1;
            this.txtOtpField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnVerifyOtp
            // 
            this.btnVerifyOtp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(135)))), ((int)(((byte)(84)))));
            this.btnVerifyOtp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerifyOtp.FlatAppearance.BorderSize = 0;
            this.btnVerifyOtp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerifyOtp.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnVerifyOtp.ForeColor = System.Drawing.Color.White;
            this.btnVerifyOtp.Location = new System.Drawing.Point(185, 46);
            this.btnVerifyOtp.Name = "btnVerifyOtp";
            this.btnVerifyOtp.Size = new System.Drawing.Size(120, 32);
            this.btnVerifyOtp.TabIndex = 2;
            this.btnVerifyOtp.Text = "Verify OTP";
            this.btnVerifyOtp.UseVisualStyleBackColor = false;
            // 
            // lnkResendOtp
            // 
            this.lnkResendOtp.AutoSize = true;
            this.lnkResendOtp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkResendOtp.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lnkResendOtp.Location = new System.Drawing.Point(315, 52);
            this.lnkResendOtp.Name = "lnkResendOtp";
            this.lnkResendOtp.Size = new System.Drawing.Size(84, 20);
            this.lnkResendOtp.TabIndex = 3;
            this.lnkResendOtp.TabStop = true;
            this.lnkResendOtp.Text = "Resend OTP";
            // 
            // lblOtpMsg
            // 
            this.lblOtpMsg.AutoEllipsis = true;
            this.lblOtpMsg.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblOtpMsg.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblOtpMsg.Location = new System.Drawing.Point(15, 85);
            this.lblOtpMsg.Name = "lblOtpMsg";
            this.lblOtpMsg.Size = new System.Drawing.Size(410, 35);
            this.lblOtpMsg.TabIndex = 4;
            // 
            // grpStep3
            // 
            this.grpStep3.Controls.Add(this.lblNewPassPrompt);
            this.grpStep3.Controls.Add(this.txtNewPassField);
            this.grpStep3.Controls.Add(this.lblConfirmPassPrompt);
            this.grpStep3.Controls.Add(this.txtConfirmPassField);
            this.grpStep3.Controls.Add(this.chkShowPassword);
            this.grpStep3.Controls.Add(this.btnSetNewPassword);
            this.grpStep3.Enabled = false;
            this.grpStep3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpStep3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.grpStep3.Location = new System.Drawing.Point(20, 290);
            this.grpStep3.Name = "grpStep3";
            this.grpStep3.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.grpStep3.Size = new System.Drawing.Size(440, 205);
            this.grpStep3.TabIndex = 2;
            this.grpStep3.TabStop = false;
            this.grpStep3.Text = "Step 3: Set New Password";
            // 
            // lblNewPassPrompt
            // 
            this.lblNewPassPrompt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNewPassPrompt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblNewPassPrompt.Location = new System.Drawing.Point(15, 25);
            this.lblNewPassPrompt.Name = "lblNewPassPrompt";
            this.lblNewPassPrompt.Size = new System.Drawing.Size(180, 18);
            this.lblNewPassPrompt.TabIndex = 0;
            this.lblNewPassPrompt.Text = "New Password:";
            // 
            // txtNewPassField
            // 
            this.txtNewPassField.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtNewPassField.Location = new System.Drawing.Point(15, 45);
            this.txtNewPassField.Name = "txtNewPassField";
            this.txtNewPassField.PasswordChar = '•';
            this.txtNewPassField.Size = new System.Drawing.Size(410, 31);
            this.txtNewPassField.TabIndex = 1;
            // 
            // lblConfirmPassPrompt
            // 
            this.lblConfirmPassPrompt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblConfirmPassPrompt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblConfirmPassPrompt.Location = new System.Drawing.Point(15, 78);
            this.lblConfirmPassPrompt.Name = "lblConfirmPassPrompt";
            this.lblConfirmPassPrompt.Size = new System.Drawing.Size(180, 18);
            this.lblConfirmPassPrompt.TabIndex = 2;
            this.lblConfirmPassPrompt.Text = "Confirm New Password:";
            // 
            // txtConfirmPassField
            // 
            this.txtConfirmPassField.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtConfirmPassField.Location = new System.Drawing.Point(15, 98);
            this.txtConfirmPassField.Name = "txtConfirmPassField";
            this.txtConfirmPassField.PasswordChar = '•';
            this.txtConfirmPassField.Size = new System.Drawing.Size(410, 31);
            this.txtConfirmPassField.TabIndex = 3;
            // 
            // chkShowPassword
            // 
            this.chkShowPassword.AutoSize = true;
            this.chkShowPassword.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chkShowPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.chkShowPassword.Location = new System.Drawing.Point(15, 132);
            this.chkShowPassword.Name = "chkShowPassword";
            this.chkShowPassword.Size = new System.Drawing.Size(135, 23);
            this.chkShowPassword.TabIndex = 4;
            this.chkShowPassword.Text = "Show Passwords";
            this.chkShowPassword.UseVisualStyleBackColor = true;
            // 
            // btnSetNewPassword
            // 
            this.btnSetNewPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnSetNewPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetNewPassword.FlatAppearance.BorderSize = 0;
            this.btnSetNewPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetNewPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSetNewPassword.ForeColor = System.Drawing.Color.White;
            this.btnSetNewPassword.Location = new System.Drawing.Point(15, 160);
            this.btnSetNewPassword.Name = "btnSetNewPassword";
            this.btnSetNewPassword.Size = new System.Drawing.Size(410, 36);
            this.btnSetNewPassword.TabIndex = 5;
            this.btnSetNewPassword.Text = "Set New Password & Finish";
            this.btnSetNewPassword.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.btnClose.Location = new System.Drawing.Point(20, 505);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(440, 35);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Back to Login";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // ForgotPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(484, 641);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 680);
            this.Name = "ForgotPasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ShopMart - Reset Password";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.grpStep1.ResumeLayout(false);
            this.grpStep1.PerformLayout();
            this.grpStep2.ResumeLayout(false);
            this.grpStep2.PerformLayout();
            this.grpStep3.ResumeLayout(false);
            this.grpStep3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderSubtitle;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.GroupBox grpStep1;
        private System.Windows.Forms.Label lblEmailPrompt;
        private System.Windows.Forms.TextBox txtEmailField;
        private System.Windows.Forms.Button btnSendOtp;
        private System.Windows.Forms.Label lblEmailMsg;
        private System.Windows.Forms.GroupBox grpStep2;
        private System.Windows.Forms.Label lblOtpPrompt;
        private System.Windows.Forms.TextBox txtOtpField;
        private System.Windows.Forms.Button btnVerifyOtp;
        private System.Windows.Forms.LinkLabel lnkResendOtp;
        private System.Windows.Forms.Label lblOtpMsg;
        private System.Windows.Forms.GroupBox grpStep3;
        private System.Windows.Forms.Label lblNewPassPrompt;
        private System.Windows.Forms.TextBox txtNewPassField;
        private System.Windows.Forms.Label lblConfirmPassPrompt;
        private System.Windows.Forms.TextBox txtConfirmPassField;
        private System.Windows.Forms.CheckBox chkShowPassword;
        private System.Windows.Forms.Button btnSetNewPassword;
        private System.Windows.Forms.Button btnClose;
    }
}