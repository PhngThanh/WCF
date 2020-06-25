using System.ComponentModel;
using System.Windows.Forms;
using POS.Common;

namespace POS.DashboardScreen.ReportScreen
{
    partial class ReportDateFilterDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtToDate = new POS.Common.RoundTextbox();
            this.txtFromDate = new POS.Common.RoundTextbox();
            this.btnClose = new POS.Common.FlexButton();
            this.btnViewReport = new POS.Common.FlexButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStaff = new POS.Common.RoundTextbox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(27, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "From Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(27, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "To Date";
            // 
            // txtToDate
            // 
            this.txtToDate.BackColor = System.Drawing.Color.Transparent;
            this.txtToDate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.txtToDate.BorderRadius = 2;
            this.txtToDate.BorderThick = 1;
            this.txtToDate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToDate.ForeColor = System.Drawing.Color.White;
            this.txtToDate.Location = new System.Drawing.Point(27, 95);
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.PasswordChar = '\0';
            this.txtToDate.ReadOnly = false;
            this.txtToDate.Size = new System.Drawing.Size(289, 29);
            this.txtToDate.TabIndex = 7;
            this.txtToDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtToDate.TextBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.txtToDate.Click += new System.EventHandler(this.txtToDate_Click);
            this.txtToDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtToDate_KeyPress);
            // 
            // txtFromDate
            // 
            this.txtFromDate.BackColor = System.Drawing.Color.Transparent;
            this.txtFromDate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.txtFromDate.BorderRadius = 2;
            this.txtFromDate.BorderThick = 1;
            this.txtFromDate.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromDate.ForeColor = System.Drawing.Color.White;
            this.txtFromDate.Location = new System.Drawing.Point(27, 40);
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.PasswordChar = '\0';
            this.txtFromDate.ReadOnly = false;
            this.txtFromDate.Size = new System.Drawing.Size(289, 29);
            this.txtFromDate.TabIndex = 6;
            this.txtFromDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtFromDate.TextBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.txtFromDate.Click += new System.EventHandler(this.txtFromDate_Click);
            this.txtFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFromDate_KeyPress);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BorderColor = System.Drawing.Color.White;
            this.btnClose.BorderRadius = 3;
            this.btnClose.BorderThick = 1;
            this.btnClose.Caption = "CLOSE";
            this.btnClose.CenterImageDisable = null;
            this.btnClose.CenterImageNormal = null;
            this.btnClose.CenterImagePress = null;
            this.btnClose.DisableColor = System.Drawing.Color.Empty;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.IsActivated = false;
            this.btnClose.LeftImageDisable = null;
            this.btnClose.LeftImageGap = 0;
            this.btnClose.LeftImageNornal = null;
            this.btnClose.LeftImagePress = null;
            this.btnClose.Location = new System.Drawing.Point(177, 208);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnClose.PressColor = System.Drawing.Color.White;
            this.btnClose.Size = new System.Drawing.Size(139, 37);
            this.btnClose.TabIndex = 1;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnViewReport
            // 
            this.btnViewReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnViewReport.BorderColor = System.Drawing.Color.White;
            this.btnViewReport.BorderRadius = 3;
            this.btnViewReport.BorderThick = 1;
            this.btnViewReport.Caption = "VIEW";
            this.btnViewReport.CenterImageDisable = null;
            this.btnViewReport.CenterImageNormal = null;
            this.btnViewReport.CenterImagePress = null;
            this.btnViewReport.DisableColor = System.Drawing.Color.Empty;
            this.btnViewReport.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewReport.IsActivated = false;
            this.btnViewReport.LeftImageDisable = null;
            this.btnViewReport.LeftImageGap = 0;
            this.btnViewReport.LeftImageNornal = null;
            this.btnViewReport.LeftImagePress = null;
            this.btnViewReport.Location = new System.Drawing.Point(27, 208);
            this.btnViewReport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.NormalColor = System.Drawing.Color.White;
            this.btnViewReport.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.btnViewReport.Size = new System.Drawing.Size(135, 37);
            this.btnViewReport.TabIndex = 0;
            this.btnViewReport.Load += new System.EventHandler(this.btnViewReport_Load);
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(27, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Staff";
            // 
            // txtStaff
            // 
            this.txtStaff.BackColor = System.Drawing.Color.Transparent;
            this.txtStaff.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.txtStaff.BorderRadius = 2;
            this.txtStaff.BorderThick = 1;
            this.txtStaff.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStaff.ForeColor = System.Drawing.Color.White;
            this.txtStaff.Location = new System.Drawing.Point(27, 153);
            this.txtStaff.Name = "txtStaff";
            this.txtStaff.PasswordChar = '\0';
            this.txtStaff.ReadOnly = false;
            this.txtStaff.Size = new System.Drawing.Size(289, 29);
            this.txtStaff.TabIndex = 7;
            this.txtStaff.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtStaff.TextBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.txtStaff.Click += new System.EventHandler(this.txtStaff_Click);
            // 
            // ReportDateFilterDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(346, 269);
            this.Controls.Add(this.txtStaff);
            this.Controls.Add(this.txtToDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFromDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnViewReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReportDateFilterDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MessageDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FlexButton btnViewReport;
        private FlexButton btnClose;
        private Label label1;
        private Label label2;
        private RoundTextbox txtFromDate;
        private RoundTextbox txtToDate;
        private Label label3;
        private RoundTextbox txtStaff;
    }
}