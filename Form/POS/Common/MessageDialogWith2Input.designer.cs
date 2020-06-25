using System.ComponentModel;
using System.Windows.Forms;
using POS.CustomControl;

namespace POS.Common
{
    partial class MessageDialogWith2Input
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.lbMessage = new System.Windows.Forms.Label();
            this.lblTitleFirstTextbox = new System.Windows.Forms.Label();
            this.lblTitleSecondTextbox = new System.Windows.Forms.Label();
            this.txtFirstInput = new POS.Common.LoginFlatTextBox();
            this.txtSecondInput = new POS.Common.LoginFlatTextBox();
            this.btnNormal = new POS.Common.FlexButton();
            this.btnPositive = new POS.Common.FlexButton();
            this.btnNegative = new POS.Common.FlexButton();
            this.SuspendLayout();
            // 
            // lbMessage
            // 
            this.lbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMessage.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbMessage.ForeColor = System.Drawing.Color.White;
            this.lbMessage.Location = new System.Drawing.Point(16, 9);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(380, 63);
            this.lbMessage.TabIndex = 2;
            this.lbMessage.Text = "This is title of dialog";
            this.lbMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitleFirstTextbox
            // 
            this.lblTitleFirstTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitleFirstTextbox.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblTitleFirstTextbox.ForeColor = System.Drawing.Color.White;
            this.lblTitleFirstTextbox.Location = new System.Drawing.Point(52, 81);
            this.lblTitleFirstTextbox.Name = "lblTitleFirstTextbox";
            this.lblTitleFirstTextbox.Size = new System.Drawing.Size(326, 25);
            this.lblTitleFirstTextbox.TabIndex = 2;
            this.lblTitleFirstTextbox.Text = "This is title of first textbox";
            this.lblTitleFirstTextbox.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblTitleSecondTextbox
            // 
            this.lblTitleSecondTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitleSecondTextbox.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblTitleSecondTextbox.ForeColor = System.Drawing.Color.White;
            this.lblTitleSecondTextbox.Location = new System.Drawing.Point(55, 160);
            this.lblTitleSecondTextbox.Name = "lblTitleSecondTextbox";
            this.lblTitleSecondTextbox.Size = new System.Drawing.Size(326, 27);
            this.lblTitleSecondTextbox.TabIndex = 2;
            this.lblTitleSecondTextbox.Text = "This is title of second textbox";
            this.lblTitleSecondTextbox.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtFirstInput
            // 
            this.txtFirstInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.txtFirstInput.BorderRadius = 2;
            this.txtFirstInput.BorderSize = 1;
            this.txtFirstInput.ImageWidth = 0;
            this.txtFirstInput.ImageZoom = 4;
            this.txtFirstInput.Location = new System.Drawing.Point(56, 109);
            this.txtFirstInput.Logo = null;
            this.txtFirstInput.Name = "txtFirstInput";
            this.txtFirstInput.PasswordChar = '\0';
            this.txtFirstInput.Size = new System.Drawing.Size(289, 36);
            this.txtFirstInput.TabIndex = 0;
            // 
            // txtSecondInput
            // 
            this.txtSecondInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.txtSecondInput.BorderRadius = 2;
            this.txtSecondInput.BorderSize = 1;
            this.txtSecondInput.ImageWidth = 0;
            this.txtSecondInput.ImageZoom = 4;
            this.txtSecondInput.Location = new System.Drawing.Point(56, 193);
            this.txtSecondInput.Logo = null;
            this.txtSecondInput.Name = "txtSecondInput";
            this.txtSecondInput.PasswordChar = '\0';
            this.txtSecondInput.Size = new System.Drawing.Size(289, 36);
            this.txtSecondInput.TabIndex = 1;
            this.txtSecondInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyUp);
            // 
            // btnNormal
            // 
            this.btnNormal.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnNormal.BorderColor = System.Drawing.Color.White;
            this.btnNormal.BorderRadius = 3;
            this.btnNormal.BorderThick = 1;
            this.btnNormal.Caption = null;
            this.btnNormal.CenterImageDisable = null;
            this.btnNormal.CenterImageNormal = null;
            this.btnNormal.CenterImagePress = null;
            this.btnNormal.DisableColor = System.Drawing.Color.Empty;
            this.btnNormal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNormal.IsActivated = false;
            this.btnNormal.LeftImageDisable = null;
            this.btnNormal.LeftImageGap = 0;
            this.btnNormal.LeftImageNornal = null;
            this.btnNormal.LeftImagePress = null;
            this.btnNormal.Location = new System.Drawing.Point(140, 252);
            this.btnNormal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.NormalColor = System.Drawing.Color.White;
            this.btnNormal.PressColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
            this.btnNormal.Size = new System.Drawing.Size(116, 37);
            this.btnNormal.TabIndex = 3;
            this.btnNormal.Click += new System.EventHandler(this.btnNormal_Click);
            // 
            // btnPositive
            // 
            this.btnPositive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPositive.BorderColor = System.Drawing.Color.White;
            this.btnPositive.BorderRadius = 3;
            this.btnPositive.BorderThick = 1;
            this.btnPositive.Caption = null;
            this.btnPositive.CenterImageDisable = null;
            this.btnPositive.CenterImageNormal = null;
            this.btnPositive.CenterImagePress = null;
            this.btnPositive.DisableColor = System.Drawing.Color.Empty;
            this.btnPositive.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPositive.IsActivated = false;
            this.btnPositive.LeftImageDisable = null;
            this.btnPositive.LeftImageGap = 0;
            this.btnPositive.LeftImageNornal = null;
            this.btnPositive.LeftImagePress = null;
            this.btnPositive.Location = new System.Drawing.Point(229, 252);
            this.btnPositive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPositive.Name = "btnPositive";
            this.btnPositive.NormalColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
            this.btnPositive.PressColor = System.Drawing.Color.White;
            this.btnPositive.Size = new System.Drawing.Size(116, 37);
            this.btnPositive.TabIndex = 2;
            this.btnPositive.Click += new System.EventHandler(this.btnPositive_Click);
            // 
            // btnNegative
            // 
            this.btnNegative.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNegative.BorderColor = System.Drawing.Color.White;
            this.btnNegative.BorderRadius = 3;
            this.btnNegative.BorderThick = 1;
            this.btnNegative.Caption = null;
            this.btnNegative.CenterImageDisable = null;
            this.btnNegative.CenterImageNormal = null;
            this.btnNegative.CenterImagePress = null;
            this.btnNegative.DisableColor = System.Drawing.Color.Empty;
            this.btnNegative.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNegative.IsActivated = false;
            this.btnNegative.LeftImageDisable = null;
            this.btnNegative.LeftImageGap = 0;
            this.btnNegative.LeftImageNornal = null;
            this.btnNegative.LeftImagePress = null;
            this.btnNegative.Location = new System.Drawing.Point(56, 252);
            this.btnNegative.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNegative.Name = "btnNegative";
            this.btnNegative.NormalColor = System.Drawing.Color.White;
            this.btnNegative.PressColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
            this.btnNegative.Size = new System.Drawing.Size(116, 37);
            this.btnNegative.TabIndex = 4;
            this.btnNegative.Click += new System.EventHandler(this.btnNegative_Click);
            // 
            // MessageDialogWith2Input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
            this.ClientSize = new System.Drawing.Size(420, 350);
            this.Controls.Add(this.txtFirstInput);
            this.Controls.Add(this.txtSecondInput);
            this.Controls.Add(this.btnNormal);
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.lblTitleFirstTextbox);
            this.Controls.Add(this.lblTitleSecondTextbox);
            this.Controls.Add(this.btnPositive);
            this.Controls.Add(this.btnNegative);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(420, 350);
            this.MinimumSize = new System.Drawing.Size(420, 350);
            this.Name = "MessageDialogWith2Input";
            this.ShowInTaskbar = false;
            this.Text = "MessageDialog";
            this.ResumeLayout(false);

        }

        #endregion

        private FlexButton btnNegative;
        private FlexButton btnPositive;
        private Label lbMessage;
        private Label lblTitleFirstTextbox;
        private Label lblTitleSecondTextbox;
        private FlexButton btnNormal;
        private LoginFlatTextBox txtFirstInput;
        private LoginFlatTextBox txtSecondInput;
    }
}