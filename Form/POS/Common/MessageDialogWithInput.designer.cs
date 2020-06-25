using System.ComponentModel;
using System.Windows.Forms;

namespace POS.Common
{
    partial class MessageDialogWithInput
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
            this.txtInput1 = new POS.Common.RoundTextbox();
            this.txtInput = new POS.Common.LoginFlatTextBox();
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
            this.lbMessage.Location = new System.Drawing.Point(12, 29);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(380, 63);
            this.lbMessage.TabIndex = 2;
            this.lbMessage.Text = "Bàn đang sử dụng";
            this.lbMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtInput1
            // 
            this.txtInput1.AutoSize = true;
            this.txtInput1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.txtInput1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.txtInput1.BorderRadius = 2;
            this.txtInput1.BorderThick = 1;
            this.txtInput1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput1.ForeColor = System.Drawing.Color.White;
            this.txtInput1.Location = new System.Drawing.Point(56, 97);
            this.txtInput1.Margin = new System.Windows.Forms.Padding(1);
            this.txtInput1.Name = "txtInput1";
            this.txtInput1.PasswordChar = '\0';
            this.txtInput1.ReadOnly = false;
            this.txtInput1.Size = new System.Drawing.Size(289, 29);
            this.txtInput1.TabIndex = 4;
            this.txtInput1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInput1.TextBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.txtInput1.Visible = false;
            // 
            // txtInput
            // 
            this.txtInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.txtInput.BorderRadius = 2;
            this.txtInput.BorderSize = 1;
            this.txtInput.ImageWidth = 0;
            this.txtInput.ImageZoom = 4;
            this.txtInput.Location = new System.Drawing.Point(56, 109);
            this.txtInput.Logo = null;
            this.txtInput.Name = "txtInput";
            this.txtInput.PasswordChar = '*';
            this.txtInput.Size = new System.Drawing.Size(289, 36);
            this.txtInput.TabIndex = 0;
            this.txtInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyUp);
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
            this.btnNormal.Location = new System.Drawing.Point(152, 184);
            this.btnNormal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnNormal.PressColor = System.Drawing.Color.White;
            this.btnNormal.Size = new System.Drawing.Size(116, 37);
            this.btnNormal.TabIndex = 2;
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
            this.btnPositive.Location = new System.Drawing.Point(276, 184);
            this.btnPositive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPositive.Name = "btnPositive";
            this.btnPositive.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnPositive.PressColor = System.Drawing.Color.White;
            this.btnPositive.Size = new System.Drawing.Size(116, 37);
            this.btnPositive.TabIndex = 1;
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
            this.btnNegative.Location = new System.Drawing.Point(28, 184);
            this.btnNegative.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNegative.Name = "btnNegative";
            this.btnNegative.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnNegative.PressColor = System.Drawing.Color.White;
            this.btnNegative.Size = new System.Drawing.Size(116, 37);
            this.btnNegative.TabIndex = 3;
            this.btnNegative.Click += new System.EventHandler(this.btnNegative_Click);
            // 
            // MessageDialogWithInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(420, 250);
            this.Controls.Add(this.txtInput1);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.btnNormal);
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.btnPositive);
            this.Controls.Add(this.btnNegative);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(420, 250);
            this.MinimumSize = new System.Drawing.Size(420, 250);
            this.Name = "MessageDialogWithInput";
            this.ShowInTaskbar = false;
            this.Text = "MessageDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FlexButton btnNegative;
        private FlexButton btnPositive;
        private Label lbMessage;
        private FlexButton btnNormal;
        private LoginFlatTextBox txtInput;
        private RoundTextbox txtInput1;
    }
}