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
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelCard = new System.Windows.Forms.Panel();
            this.tableLayoutPanelForm = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lnkToggleMode = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanelMain.SuspendLayout();
            this.panelCard.SuspendLayout();
            this.tableLayoutPanelForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 3;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 480F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Controls.Add(this.panelCard, 1, 1);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 3;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 440F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(800, 500);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // panelCard
            // 
            this.panelCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCard.Controls.Add(this.tableLayoutPanelForm);
            this.panelCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCard.Location = new System.Drawing.Point(163, 33);
            this.panelCard.Name = "panelCard";
            this.panelCard.Padding = new System.Windows.Forms.Padding(20);
            this.panelCard.Size = new System.Drawing.Size(474, 434);
            this.panelCard.TabIndex = 0;
            // 
            // tableLayoutPanelForm
            // 
            this.tableLayoutPanelForm.ColumnCount = 1;
            this.tableLayoutPanelForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelForm.Controls.Add(this.lblTitle, 0, 0);
            this.tableLayoutPanelForm.Controls.Add(this.lblName, 0, 1);
            this.tableLayoutPanelForm.Controls.Add(this.txtName, 0, 2);
            this.tableLayoutPanelForm.Controls.Add(this.lblEmail, 0, 3);
            this.tableLayoutPanelForm.Controls.Add(this.txtEmail, 0, 4);
            this.tableLayoutPanelForm.Controls.Add(this.lblPassword, 0, 5);
            this.tableLayoutPanelForm.Controls.Add(this.txtPassword, 0, 6);
            this.tableLayoutPanelForm.Controls.Add(this.btnSubmit, 0, 7);
            this.tableLayoutPanelForm.Controls.Add(this.lnkToggleMode, 0, 8);
            this.tableLayoutPanelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelForm.Location = new System.Drawing.Point(20, 20);
            this.tableLayoutPanelForm.Name = "tableLayoutPanelForm";
            this.tableLayoutPanelForm.RowCount = 9;
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelForm.Size = new System.Drawing.Size(432, 392);
            this.tableLayoutPanelForm.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(426, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Login To Your Account";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblName.Location = new System.Drawing.Point(3, 50);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(426, 25);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Full Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblName.Visible = false;
            // 
            // txtName
            // 
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtName.Location = new System.Drawing.Point(3, 78);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(426, 32);
            this.txtName.TabIndex = 2;
            this.txtName.Visible = false;
            // 
            // lblEmail
            // 
            this.lblEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEmail.Location = new System.Drawing.Point(3, 115);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(426, 25);
            this.lblEmail.TabIndex = 3;
            this.lblEmail.Text = "Email";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtEmail
            // 
            this.txtEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtEmail.Location = new System.Drawing.Point(3, 143);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(426, 32);
            this.txtEmail.TabIndex = 4;
            // 
            // lblPassword
            // 
            this.lblPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPassword.Location = new System.Drawing.Point(3, 180);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(426, 25);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Password";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtPassword
            // 
            this.txtPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPassword.Location = new System.Drawing.Point(3, 208);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.Size = new System.Drawing.Size(426, 32);
            this.txtPassword.TabIndex = 6;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.Location = new System.Drawing.Point(3, 248);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(426, 44);
            this.btnSubmit.TabIndex = 7;
            this.btnSubmit.Text = "Login";
            this.btnSubmit.UseVisualStyleBackColor = true;
            // 
            // lnkToggleMode
            // 
            this.lnkToggleMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lnkToggleMode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lnkToggleMode.Location = new System.Drawing.Point(3, 295);
            this.lnkToggleMode.Name = "lnkToggleMode";
            this.lnkToggleMode.Size = new System.Drawing.Size(426, 97);
            this.lnkToggleMode.TabIndex = 8;
            this.lnkToggleMode.TabStop = true;
            this.lnkToggleMode.Text = "Don\'t have an account? Register";
            this.lnkToggleMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkToggleMode.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkToggleMode_LinkClicked);
            // 
            // Authentication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.MinimumSize = new System.Drawing.Size(550, 480);
            this.Name = "Authentication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shopping Cart - Authentication";
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.panelCard.ResumeLayout(false);
            this.tableLayoutPanelForm.ResumeLayout(false);
            this.tableLayoutPanelForm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        // Track current mode state
        private bool isRegisterMode = false;

        private void lnkToggleMode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            isRegisterMode = !isRegisterMode;

            if (isRegisterMode)
            {
                // Switch to Register View
                lblTitle.Text = "Create New Account";
                btnSubmit.Text = "Register";
                lnkToggleMode.Text = "Already have an account? Login";

                // Show Name input fields
                lblName.Visible = true;
                txtName.Visible = true;
            }
            else
            {
                // Switch back to Login View
                lblTitle.Text = "Login To Your Account";
                btnSubmit.Text = "Login";
                lnkToggleMode.Text = "Don't have an account? Register";

                // Hide Name input fields
                lblName.Visible = false;
                txtName.Visible = false;
            }
        }

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelForm;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.LinkLabel lnkToggleMode;
    }
}