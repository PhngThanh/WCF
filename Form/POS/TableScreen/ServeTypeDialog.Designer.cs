using POS.CustomControl;
using POS.Common;

namespace POS.TableScreen
{
    partial class ServeTypeDialog
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
            this.flexButton3 = new POS.Common.FlexButton();
            this.flexButton2 = new POS.Common.FlexButton();
            this.flexButton1 = new POS.Common.FlexButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flexButton3
            // 
            this.flexButton3.BorderColor = System.Drawing.Color.White;
            this.flexButton3.BorderRadius = 4;
            this.flexButton3.BorderThick = 1;
            this.flexButton3.Caption = null;
            this.flexButton3.CenterImageDisable = null;
            this.flexButton3.CenterImageNormal = global::POS.Properties.Resources.delivery_white;
            this.flexButton3.CenterImagePress = global::POS.Properties.Resources.delivery_white;
            this.flexButton3.DisableColor = System.Drawing.Color.Empty;
            this.flexButton3.IsActivated = false;
            this.flexButton3.LeftImageDisable = null;
            this.flexButton3.LeftImageGap = 0;
            this.flexButton3.LeftImageNornal = null;
            this.flexButton3.LeftImagePress = null;
            this.flexButton3.Location = new System.Drawing.Point(65, 66);
            this.flexButton3.Name = "flexButton3";
            this.flexButton3.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.flexButton3.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.flexButton3.Size = new System.Drawing.Size(138, 138);
            this.flexButton3.TabIndex = 1;
            this.flexButton3.Click += new System.EventHandler(this.flexButton3_Click);
            // 
            // flexButton2
            // 
            this.flexButton2.BorderColor = System.Drawing.Color.White;
            this.flexButton2.BorderRadius = 4;
            this.flexButton2.BorderThick = 1;
            this.flexButton2.Caption = null;
            this.flexButton2.CenterImageDisable = null;
            this.flexButton2.CenterImageNormal = global::POS.Properties.Resources.cup4s_2;
            this.flexButton2.CenterImagePress = global::POS.Properties.Resources.cup4s_2;
            this.flexButton2.DisableColor = System.Drawing.Color.Empty;
            this.flexButton2.IsActivated = false;
            this.flexButton2.LeftImageDisable = null;
            this.flexButton2.LeftImageGap = 0;
            this.flexButton2.LeftImageNornal = null;
            this.flexButton2.LeftImagePress = null;
            this.flexButton2.Location = new System.Drawing.Point(239, 66);
            this.flexButton2.Name = "flexButton2";
            this.flexButton2.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.flexButton2.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.flexButton2.Size = new System.Drawing.Size(138, 138);
            this.flexButton2.TabIndex = 1;
            this.flexButton2.Load += new System.EventHandler(this.flexButton2_Load);
            this.flexButton2.Click += new System.EventHandler(this.flexButton2_Click);
            // 
            // flexButton1
            // 
            this.flexButton1.BorderColor = System.Drawing.Color.White;
            this.flexButton1.BorderRadius = 4;
            this.flexButton1.BorderThick = 1;
            this.flexButton1.Caption = null;
            this.flexButton1.CenterImageDisable = null;
            this.flexButton1.CenterImageNormal = global::POS.Properties.Resources.shop_s;
            this.flexButton1.CenterImagePress = global::POS.Properties.Resources.shop_s;
            this.flexButton1.DisableColor = System.Drawing.Color.Empty;
            this.flexButton1.IsActivated = false;
            this.flexButton1.LeftImageDisable = null;
            this.flexButton1.LeftImageGap = 0;
            this.flexButton1.LeftImageNornal = null;
            this.flexButton1.LeftImagePress = null;
            this.flexButton1.Location = new System.Drawing.Point(413, 66);
            this.flexButton1.Name = "flexButton1";
            this.flexButton1.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.flexButton1.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.flexButton1.Size = new System.Drawing.Size(138, 138);
            this.flexButton1.TabIndex = 1;
            this.flexButton1.Click += new System.EventHandler(this.flexButton1_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(413, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 43);
            this.label1.TabIndex = 2;
            this.label1.Text = "At store";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(239, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 43);
            this.label2.TabIndex = 2;
            this.label2.Text = "Take away";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(65, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 43);
            this.label3.TabIndex = 2;
            this.label3.Text = "Delivery";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ServeTypeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(637, 301);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flexButton3);
            this.Controls.Add(this.flexButton2);
            this.Controls.Add(this.flexButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ServeTypeDialog";
            this.ShowInTaskbar = false;
            this.Text = "ServeTypeDialog";
            this.Deactivate += new System.EventHandler(this.ServeTypeDialog_Deactivate);
            this.ResumeLayout(false);

        }

        #endregion

        private FlexButton flexButton1;
        private FlexButton flexButton2;
        private FlexButton flexButton3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}