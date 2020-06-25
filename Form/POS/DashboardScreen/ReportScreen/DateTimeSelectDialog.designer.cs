using System.ComponentModel;
using System.Windows.Forms;
using POS.Common;

namespace POS.DashboardScreen.ReportScreen
{
    partial class DateTimeSelectDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DateTimeSelectDialog));
            this.btnCancel = new POS.Common.FlexButton();
            this.btnOK = new POS.Common.FlexButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.udMinute = new POS.DashboardScreen.ReportScreen.UpDownControl();
            this.udHour = new POS.DashboardScreen.ReportScreen.UpDownControl();
            this.calendar1 = new Thn.Interface.Vcl.Calendar();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BorderColor = System.Drawing.Color.White;
            this.btnCancel.BorderRadius = 2;
            this.btnCancel.BorderThick = 1;
            this.btnCancel.Caption = "Cancel";
            this.btnCancel.CenterImageDisable = null;
            this.btnCancel.CenterImageNormal = null;
            this.btnCancel.CenterImagePress = null;
            this.btnCancel.DisableColor = System.Drawing.Color.Empty;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.IsActivated = false;
            this.btnCancel.LeftImageDisable = null;
            this.btnCancel.LeftImageGap = 0;
            this.btnCancel.LeftImageNornal = null;
            this.btnCancel.LeftImagePress = null;
            this.btnCancel.Location = new System.Drawing.Point(386, 385);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormalColor = POS.CustomControl.ColorScheme.GetColor(POS.CustomControl.BootstrapColorEnum.MainColor);
            this.btnCancel.PressColor = System.Drawing.Color.White;
            this.btnCancel.Size = new System.Drawing.Size(108, 40);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.BorderColor = System.Drawing.Color.White;
            this.btnOK.BorderRadius = 2;
            this.btnOK.BorderThick = 1;
            this.btnOK.Caption = "OK";
            this.btnOK.CenterImageDisable = null;
            this.btnOK.CenterImageNormal = null;
            this.btnOK.CenterImagePress = null;
            this.btnOK.DisableColor = System.Drawing.Color.Empty;
            this.btnOK.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.IsActivated = false;
            this.btnOK.LeftImageDisable = null;
            this.btnOK.LeftImageGap = 0;
            this.btnOK.LeftImageNornal = null;
            this.btnOK.LeftImagePress = null;
            this.btnOK.Location = new System.Drawing.Point(271, 386);
            this.btnOK.Margin = new System.Windows.Forms.Padding(5);
            this.btnOK.Name = "btnOK";
            this.btnOK.NormalColor = System.Drawing.Color.White;
            this.btnOK.PressColor = POS.CustomControl.ColorScheme.GetColor(POS.CustomControl.BootstrapColorEnum.MainColor);
            this.btnOK.Size = new System.Drawing.Size(106, 39);
            this.btnOK.TabIndex = 3;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.udMinute);
            this.groupBox2.Controls.Add(this.udHour);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(12, 309);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(483, 71);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Time:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Minute";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hour";
            // 
            // udMinute
            // 
            this.udMinute.BackColor = System.Drawing.Color.Black;
            this.udMinute.Location = new System.Drawing.Point(318, 27);
            this.udMinute.Name = "udMinute";
            this.udMinute.Padding = new System.Windows.Forms.Padding(10);
            this.udMinute.Size = new System.Drawing.Size(140, 30);
            this.udMinute.TabIndex = 0;
            this.udMinute.Values = ((System.Collections.Generic.List<string>)(resources.GetObject("udMinute.Values")));
            // 
            // udHour
            // 
            this.udHour.BackColor = System.Drawing.Color.Black;
            this.udHour.Location = new System.Drawing.Point(87, 27);
            this.udHour.Name = "udHour";
            this.udHour.Padding = new System.Windows.Forms.Padding(10);
            this.udHour.Size = new System.Drawing.Size(140, 30);
            this.udHour.TabIndex = 0;
            this.udHour.Values = ((System.Collections.Generic.List<string>)(resources.GetObject("udHour.Values")));
            // 
            // calendar1
            // 
            this.calendar1.ControlSize = new System.Drawing.Size(482, 290);
            this.calendar1.Date = new System.DateTime(2016, 2, 29, 0, 0, 0, 0);
            this.calendar1.Location = new System.Drawing.Point(13, 13);
            this.calendar1.Name = "calendar1";
            this.calendar1.OriginX = 241F;
            this.calendar1.OriginY = 145F;
            this.calendar1.Size = new System.Drawing.Size(482, 290);
            this.calendar1.TabIndex = 7;
            // 
            // DateTimeSelectDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = POS.CustomControl.ColorScheme.GetColor(POS.CustomControl.BootstrapColorEnum.MainColor);
            this.ClientSize = new System.Drawing.Size(507, 438);
            this.Controls.Add(this.calendar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DateTimeSelectDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DateSelectDialog";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DateSelectDialog_FormClosing);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FlexButton btnOK;
        private FlexButton btnCancel;
        private GroupBox groupBox2;
        private UpDownControl udHour;
        private Label label1;
        private Label label2;
        private UpDownControl udMinute;
        private Thn.Interface.Vcl.Calendar calendar1;
    }
}