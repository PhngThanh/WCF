
using POS.Common;
using POS.Properties;
using POS.Repository.ExchangeDataModel;

namespace POS.LoginScreen
{
    partial class LoginScreen1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginScreen1));
            this.btnCancel = new POS.Common.FlexButton();
            this.btnLogin = new POS.Common.FlexButton();
            this.txtPassword = new POS.Common.LoginFlatTextBox();
            this.txtUsername = new POS.Common.LoginFlatTextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.BorderColor = System.Drawing.Color.White;
            this.btnCancel.BorderRadius = 4;
            this.btnCancel.BorderThick = 4;
            this.btnCancel.Caption = "CANCEL";
            this.btnCancel.CenterImageDisable = null;
            this.btnCancel.CenterImageNormal = null;
            this.btnCancel.CenterImagePress = null;
            this.btnCancel.DisableColor = System.Drawing.Color.Empty;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnCancel.IsActivated = false;
            this.btnCancel.LeftImageDisable = null;
            this.btnCancel.LeftImageGap = 0;
            this.btnCancel.LeftImageNornal = null;
            this.btnCancel.LeftImagePress = null;
            this.btnCancel.Location = new System.Drawing.Point(346, 249);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 27, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnCancel.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.btnCancel.Size = new System.Drawing.Size(118, 45);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogin.BorderColor = System.Drawing.Color.White;
            this.btnLogin.BorderRadius = 4;
            this.btnLogin.BorderThick = 4;
            this.btnLogin.Caption = "LOGIN";
            this.btnLogin.CenterImageDisable = null;
            this.btnLogin.CenterImageNormal = null;
            this.btnLogin.CenterImagePress = null;
            this.btnLogin.DisableColor = System.Drawing.Color.Empty;
            this.btnLogin.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLogin.IsActivated = false;
            this.btnLogin.LeftImageDisable = null;
            this.btnLogin.LeftImageGap = 0;
            this.btnLogin.LeftImageNornal = null;
            this.btnLogin.LeftImagePress = null;
            this.btnLogin.Location = new System.Drawing.Point(196, 249);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 30, 4, 4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnLogin.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.btnLogin.Size = new System.Drawing.Size(118, 45);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtPassword.BorderRadius = 3;
            this.txtPassword.BorderSize = 1;
            this.txtPassword.ImageWidth = 30;
            this.txtPassword.ImageZoom = 10;
            this.txtPassword.Location = new System.Drawing.Point(169, 178);
            this.txtPassword.Logo = ((System.Drawing.Image)(resources.GetObject("txtPassword.Logo")));
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 30, 3, 0);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(323, 44);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyUp);
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUsername.BackColor = System.Drawing.Color.Transparent;
            this.txtUsername.BorderRadius = 3;
            this.txtUsername.BorderSize = 1;
            this.txtUsername.ImageWidth = 30;
            this.txtUsername.ImageZoom = 10;
            this.txtUsername.Location = new System.Drawing.Point(169, 104);
            this.txtUsername.Logo = ((System.Drawing.Image)(resources.GetObject("txtUsername.Logo")));
            this.txtUsername.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PasswordChar = '\0';
            this.txtUsername.Size = new System.Drawing.Size(323, 44);
            this.txtUsername.TabIndex = 0;
            // 
            // LoginScreen1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(66)))), ((int)(((byte)(67)))));
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Name = "LoginScreen1";
            this.Size = new System.Drawing.Size(660, 413);
            this.ResumeLayout(false);

        }

        #endregion

        private LoginFlatTextBox txtUsername;
        private LoginFlatTextBox txtPassword;
        private FlexButton btnLogin;
        private FlexButton btnCancel;
    }
}
