using System.ComponentModel;
using POS.Common;
using POS.Properties;

namespace POS.SaleScreen.CustomControl
{
    partial class NumPadPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NumPadPanel));
            this.btnDel = new POS.Common.FlexButton();
            this.btn9 = new POS.Common.FlexButton();
            this.btn6 = new POS.Common.FlexButton();
            this.btn3 = new POS.Common.FlexButton();
            this.btn0 = new POS.Common.FlexButton();
            this.btn000 = new POS.Common.FlexButton();
            this.btn8 = new POS.Common.FlexButton();
            this.btn7 = new POS.Common.FlexButton();
            this.btn5 = new POS.Common.FlexButton();
            this.btn4 = new POS.Common.FlexButton();
            this.btn2 = new POS.Common.FlexButton();
            this.btn1 = new POS.Common.FlexButton();
            this.SuspendLayout();
            // 
            // btnDel
            // 
            this.btnDel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.btnDel.BorderRadius = 1;
            this.btnDel.BorderThick  = 3;
            this.btnDel.Caption = "";
            this.btnDel.CenterImageDisable = null;
            this.btnDel.CenterImageNormal = ((System.Drawing.Image)(resources.GetObject("btnDel.CenterImageNormal")));
            this.btnDel.CenterImagePress = ((System.Drawing.Image)(resources.GetObject("btnDel.CenterImagePress")));
            this.btnDel.DisableColor = System.Drawing.Color.Empty;
            this.btnDel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.IsActivated = false;
            this.btnDel.LeftImageDisable = null;
            this.btnDel.LeftImageGap = 0;
            this.btnDel.LeftImageNornal = null;
            this.btnDel.LeftImagePress = null;
            this.btnDel.Location = new System.Drawing.Point(154, 228);
            this.btnDel.Margin = new System.Windows.Forms.Padding(6);
            this.btnDel.Name = "btnDel";
            this.btnDel.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.btnDel.PressColor = System.Drawing.Color.White;
            this.btnDel.Size = new System.Drawing.Size(75, 75);
            this.btnDel.TabIndex = 38;
            this.btnDel.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn9
            // 
            this.btn9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.btn9.BorderRadius = 1;
            this.btn9.BorderThick  = 3;
            this.btn9.Caption = "9";
            this.btn9.CenterImageDisable = null;
            this.btn9.CenterImageNormal = null;
            this.btn9.CenterImagePress = null;
            this.btn9.DisableColor = System.Drawing.Color.Empty;
            this.btn9.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn9.IsActivated = false;
            this.btn9.LeftImageDisable = null;
            this.btn9.LeftImageGap = 0;
            this.btn9.LeftImageNornal = null;
            this.btn9.LeftImagePress = null;
            this.btn9.Location = new System.Drawing.Point(154, 153);
            this.btn9.Margin = new System.Windows.Forms.Padding(6);
            this.btn9.Name = "btn9";
            this.btn9.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.btn9.PressColor = System.Drawing.Color.White;
            this.btn9.Size = new System.Drawing.Size(75, 75);
            this.btn9.TabIndex = 35;
            this.btn9.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn6
            // 
            this.btn6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.btn6.BorderRadius = 1;
            this.btn6.BorderThick  = 3;
            this.btn6.Caption = "6";
            this.btn6.CenterImageDisable = null;
            this.btn6.CenterImageNormal = null;
            this.btn6.CenterImagePress = null;
            this.btn6.DisableColor = System.Drawing.Color.Empty;
            this.btn6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn6.IsActivated = false;
            this.btn6.LeftImageDisable = null;
            this.btn6.LeftImageGap = 0;
            this.btn6.LeftImageNornal = null;
            this.btn6.LeftImagePress = null;
            this.btn6.Location = new System.Drawing.Point(154, 78);
            this.btn6.Margin = new System.Windows.Forms.Padding(6);
            this.btn6.Name = "btn6";
            this.btn6.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.btn6.PressColor = System.Drawing.Color.White;
            this.btn6.Size = new System.Drawing.Size(75, 75);
            this.btn6.TabIndex = 36;
            this.btn6.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn3
            // 
            this.btn3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.btn3.BorderRadius = 1;
            this.btn3.BorderThick  = 3;
            this.btn3.Caption = "3";
            this.btn3.CenterImageDisable = null;
            this.btn3.CenterImageNormal = null;
            this.btn3.CenterImagePress = null;
            this.btn3.DisableColor = System.Drawing.Color.Empty;
            this.btn3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn3.IsActivated = false;
            this.btn3.LeftImageDisable = null;
            this.btn3.LeftImageGap = 0;
            this.btn3.LeftImageNornal = null;
            this.btn3.LeftImagePress = null;
            this.btn3.Location = new System.Drawing.Point(154, 3);
            this.btn3.Margin = new System.Windows.Forms.Padding(6);
            this.btn3.Name = "btn3";
            this.btn3.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.btn3.PressColor = System.Drawing.Color.White;
            this.btn3.Size = new System.Drawing.Size(75, 75);
            this.btn3.TabIndex = 37;
            this.btn3.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn0
            // 
            this.btn0.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn0.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.btn0.BorderRadius = 1;
            this.btn0.BorderThick  = 3;
            this.btn0.Caption = "0";
            this.btn0.CenterImageDisable = null;
            this.btn0.CenterImageNormal = null;
            this.btn0.CenterImagePress = null;
            this.btn0.DisableColor = System.Drawing.Color.Empty;
            this.btn0.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn0.IsActivated = false;
            this.btn0.LeftImageDisable = null;
            this.btn0.LeftImageGap = 0;
            this.btn0.LeftImageNornal = null;
            this.btn0.LeftImagePress = null;
            this.btn0.Location = new System.Drawing.Point(79, 228);
            this.btn0.Margin = new System.Windows.Forms.Padding(0);
            this.btn0.Name = "btn0";
            this.btn0.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.btn0.PressColor = System.Drawing.Color.White;
            this.btn0.Size = new System.Drawing.Size(75, 75);
            this.btn0.TabIndex = 27;
            this.btn0.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn000
            // 
            this.btn000.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn000.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.btn000.BorderRadius = 1;
            this.btn000.BorderThick  = 3;
            this.btn000.Caption = ".000";
            this.btn000.CenterImageDisable = null;
            this.btn000.CenterImageNormal = null;
            this.btn000.CenterImagePress = null;
            this.btn000.DisableColor = System.Drawing.Color.Empty;
            this.btn000.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn000.IsActivated = false;
            this.btn000.LeftImageDisable = null;
            this.btn000.LeftImageGap = 0;
            this.btn000.LeftImageNornal = null;
            this.btn000.LeftImagePress = null;
            this.btn000.Location = new System.Drawing.Point(4, 228);
            this.btn000.Margin = new System.Windows.Forms.Padding(0);
            this.btn000.Name = "btn000";
            this.btn000.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.btn000.PressColor = System.Drawing.Color.White;
            this.btn000.Size = new System.Drawing.Size(75, 75);
            this.btn000.TabIndex = 28;
            this.btn000.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn8
            // 
            this.btn8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.btn8.BorderRadius = 1;
            this.btn8.BorderThick  = 3;
            this.btn8.Caption = "8";
            this.btn8.CenterImageDisable = null;
            this.btn8.CenterImageNormal = null;
            this.btn8.CenterImagePress = null;
            this.btn8.DisableColor = System.Drawing.Color.Empty;
            this.btn8.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn8.IsActivated = false;
            this.btn8.LeftImageDisable = null;
            this.btn8.LeftImageGap = 0;
            this.btn8.LeftImageNornal = null;
            this.btn8.LeftImagePress = null;
            this.btn8.Location = new System.Drawing.Point(79, 153);
            this.btn8.Margin = new System.Windows.Forms.Padding(6);
            this.btn8.Name = "btn8";
            this.btn8.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.btn8.PressColor = System.Drawing.Color.White;
            this.btn8.Size = new System.Drawing.Size(75, 75);
            this.btn8.TabIndex = 29;
            this.btn8.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn7
            // 
            this.btn7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.btn7.BorderRadius = 1;
            this.btn7.BorderThick  = 3;
            this.btn7.Caption = "7";
            this.btn7.CenterImageDisable = null;
            this.btn7.CenterImageNormal = null;
            this.btn7.CenterImagePress = null;
            this.btn7.DisableColor = System.Drawing.Color.Empty;
            this.btn7.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn7.IsActivated = false;
            this.btn7.LeftImageDisable = null;
            this.btn7.LeftImageGap = 0;
            this.btn7.LeftImageNornal = null;
            this.btn7.LeftImagePress = null;
            this.btn7.Location = new System.Drawing.Point(4, 153);
            this.btn7.Margin = new System.Windows.Forms.Padding(6);
            this.btn7.Name = "btn7";
            this.btn7.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.btn7.PressColor = System.Drawing.Color.White;
            this.btn7.Size = new System.Drawing.Size(75, 75);
            this.btn7.TabIndex = 30;
            this.btn7.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn5
            // 
            this.btn5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.btn5.BorderRadius = 1;
            this.btn5.BorderThick  = 3;
            this.btn5.Caption = "5";
            this.btn5.CenterImageDisable = null;
            this.btn5.CenterImageNormal = null;
            this.btn5.CenterImagePress = null;
            this.btn5.DisableColor = System.Drawing.Color.Empty;
            this.btn5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn5.IsActivated = false;
            this.btn5.LeftImageDisable = null;
            this.btn5.LeftImageGap = 0;
            this.btn5.LeftImageNornal = null;
            this.btn5.LeftImagePress = null;
            this.btn5.Location = new System.Drawing.Point(79, 78);
            this.btn5.Margin = new System.Windows.Forms.Padding(6);
            this.btn5.Name = "btn5";
            this.btn5.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.btn5.PressColor = System.Drawing.Color.White;
            this.btn5.Size = new System.Drawing.Size(75, 75);
            this.btn5.TabIndex = 31;
            this.btn5.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn4
            // 
            this.btn4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.btn4.BorderRadius = 1;
            this.btn4.BorderThick  = 3;
            this.btn4.Caption = "4";
            this.btn4.CenterImageDisable = null;
            this.btn4.CenterImageNormal = null;
            this.btn4.CenterImagePress = null;
            this.btn4.DisableColor = System.Drawing.Color.Empty;
            this.btn4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn4.IsActivated = false;
            this.btn4.LeftImageDisable = null;
            this.btn4.LeftImageGap = 0;
            this.btn4.LeftImageNornal = null;
            this.btn4.LeftImagePress = null;
            this.btn4.Location = new System.Drawing.Point(4, 78);
            this.btn4.Margin = new System.Windows.Forms.Padding(6);
            this.btn4.Name = "btn4";
            this.btn4.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.btn4.PressColor = System.Drawing.Color.White;
            this.btn4.Size = new System.Drawing.Size(75, 75);
            this.btn4.TabIndex = 32;
            this.btn4.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn2
            // 
            this.btn2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.btn2.BorderRadius = 1;
            this.btn2.BorderThick  = 3;
            this.btn2.Caption = "2";
            this.btn2.CenterImageDisable = null;
            this.btn2.CenterImageNormal = null;
            this.btn2.CenterImagePress = null;
            this.btn2.DisableColor = System.Drawing.Color.Empty;
            this.btn2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn2.IsActivated = false;
            this.btn2.LeftImageDisable = null;
            this.btn2.LeftImageGap = 0;
            this.btn2.LeftImageNornal = null;
            this.btn2.LeftImagePress = null;
            this.btn2.Location = new System.Drawing.Point(79, 3);
            this.btn2.Margin = new System.Windows.Forms.Padding(6);
            this.btn2.Name = "btn2";
            this.btn2.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.btn2.PressColor = System.Drawing.Color.White;
            this.btn2.Size = new System.Drawing.Size(75, 75);
            this.btn2.TabIndex = 33;
            this.btn2.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn1
            // 
            this.btn1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn1.BorderColor = System.Drawing.Color.White;
            this.btn1.BorderRadius = 1;
            this.btn1.BorderThick  = 3;
            this.btn1.Caption = "1";
            this.btn1.CenterImageDisable = null;
            this.btn1.CenterImageNormal = null;
            this.btn1.CenterImagePress = null;
            this.btn1.DisableColor = System.Drawing.Color.Empty;
            this.btn1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1.IsActivated = false;
            this.btn1.LeftImageDisable = null;
            this.btn1.LeftImageGap = 0;
            this.btn1.LeftImageNornal = null;
            this.btn1.LeftImagePress = null;
            this.btn1.Location = new System.Drawing.Point(4, 3);
            this.btn1.Margin = new System.Windows.Forms.Padding(6);
            this.btn1.Name = "btn1";
            this.btn1.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.btn1.PressColor = System.Drawing.Color.White;
            this.btn1.Size = new System.Drawing.Size(75, 75);
            this.btn1.TabIndex = 34;
            this.btn1.Click += new System.EventHandler(this.btn_Click);
            // 
            // NumPadPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.btn000);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Name = "NumPadPanel";
            this.Size = new System.Drawing.Size(234, 303);
            this.ResumeLayout(false);

        }

        #endregion

        private FlexButton btnDel;
        private FlexButton btn9;
        private FlexButton btn6;
        private FlexButton btn3;
        private FlexButton btn0;
        private FlexButton btn000;
        private FlexButton btn8;
        private FlexButton btn7;
        private FlexButton btn5;
        private FlexButton btn4;
        private FlexButton btn2;
        private FlexButton btn1;
    }
}
