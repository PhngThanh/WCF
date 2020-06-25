using System.ComponentModel;
using System.Windows.Forms;
using POS.CustomControl;

namespace POS.DashboardScreen.ReportScreen
{
    partial class UpDownControl
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
            this.lblUp = new System.Windows.Forms.Label();
            this.lblDown = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblUp
            // 
            this.lblUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.lblUp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUp.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblUp.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUp.ForeColor = System.Drawing.Color.White;
            this.lblUp.Location = new System.Drawing.Point(-90, 0);
            this.lblUp.Name = "lblUp";
            this.lblUp.Size = new System.Drawing.Size(45, 0);
            this.lblUp.TabIndex = 1;
            this.lblUp.Text = "+";
            this.lblUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDown
            // 
            this.lblDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.lblDown.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDown.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDown.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDown.ForeColor = System.Drawing.Color.White;
            this.lblDown.Location = new System.Drawing.Point(-45, 0);
            this.lblDown.Name = "lblDown";
            this.lblDown.Size = new System.Drawing.Size(45, 0);
            this.lblDown.TabIndex = 2;
            this.lblDown.Text = "-";
            this.lblDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblText
            // 
            this.lblText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.lblText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.ForeColor = System.Drawing.Color.Black;
            this.lblText.Location = new System.Drawing.Point(0, 0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(0, 0);
            this.lblText.TabIndex = 0;
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UpDownControl
            // 
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.lblUp);
            this.Controls.Add(this.lblDown);
            this.ResumeLayout(false);

        }

        #endregion

        private Label lblUp;
        private Label lblDown;
        private Label lblText;
    }
}
