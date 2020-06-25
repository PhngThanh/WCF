using System.ComponentModel;
using System.Windows.Forms;
using POS.CustomControl;

namespace POS.Common
{
    partial class MessageDialog
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
            this.btnNegative = new POS.Common.FlexButton();
            this.btnPositive = new POS.Common.FlexButton();
            this.lbMessage = new System.Windows.Forms.Label();
            this.btnNormal = new POS.Common.FlexButton();
            this.SuspendLayout();
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
            this.btnNegative.Location = new System.Drawing.Point(77, 127);
            this.btnNegative.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnNegative.Name = "btnNegative";
            this.btnNegative.NormalColor = System.Drawing.Color.White;
            this.btnNegative.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.btnNegative.Size = new System.Drawing.Size(155, 46);
            this.btnNegative.TabIndex = 0;
            this.btnNegative.Click += new System.EventHandler(this.btnNegative_Click);
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
            this.btnPositive.Location = new System.Drawing.Point(308, 127);
            this.btnPositive.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnPositive.Name = "btnPositive";
            this.btnPositive.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnPositive.PressColor = System.Drawing.Color.White;
            this.btnPositive.Size = new System.Drawing.Size(155, 46);
            this.btnPositive.TabIndex = 1;
            this.btnPositive.Click += new System.EventHandler(this.btnPositive_Click);
            // 
            // lbMessage
            // 
            this.lbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMessage.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMessage.ForeColor = System.Drawing.Color.White;
            this.lbMessage.Location = new System.Drawing.Point(16, 26);
            this.lbMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(507, 68);
            this.lbMessage.TabIndex = 2;
            this.lbMessage.Text = "Bàn đang sử dụng";
            this.lbMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.btnNormal.Location = new System.Drawing.Point(189, 127);
            this.btnNormal.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.NormalColor = System.Drawing.Color.White;
            this.btnNormal.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.btnNormal.Size = new System.Drawing.Size(155, 46);
            this.btnNormal.TabIndex = 3;
            this.btnNormal.Click += new System.EventHandler(this.btnNormal_Click);
            // 
            // MessageDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(560, 258);
            this.Controls.Add(this.btnNormal);
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.btnPositive);
            this.Controls.Add(this.btnNegative);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(560, 258);
            this.MinimumSize = new System.Drawing.Size(560, 258);
            this.Name = "MessageDialog";
            this.ShowInTaskbar = false;
            this.Text = "MessageDialog";
            this.ResumeLayout(false);

        }

        #endregion

        private FlexButton btnNegative;
        private FlexButton btnPositive;
        private Label lbMessage;
        private FlexButton btnNormal;
    }
}