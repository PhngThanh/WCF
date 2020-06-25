using System.ComponentModel;
using System.Windows.Forms;

namespace POS.TableScreen
{
    partial class NotificationItemControl
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblNewNotification = new System.Windows.Forms.Label();
            this.lblArriveTime = new System.Windows.Forms.Label();
            this.lblEstimate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Enabled = false;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(14, 29);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(138, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Tilte of notification";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // lblNewNotification
            // 
            this.lblNewNotification.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(57)))));
            this.lblNewNotification.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblNewNotification.Location = new System.Drawing.Point(0, 0);
            this.lblNewNotification.Name = "lblNewNotification";
            this.lblNewNotification.Size = new System.Drawing.Size(7, 58);
            this.lblNewNotification.TabIndex = 2;
            // 
            // lblArriveTime
            // 
            this.lblArriveTime.AutoSize = true;
            this.lblArriveTime.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblArriveTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(57)))));
            this.lblArriveTime.Location = new System.Drawing.Point(14, 14);
            this.lblArriveTime.Name = "lblArriveTime";
            this.lblArriveTime.Size = new System.Drawing.Size(165, 13);
            this.lblArriveTime.TabIndex = 0;
            this.lblArriveTime.Text = "WED, 31TH MAY, 2015 09:05:15";
            this.lblArriveTime.Click += new System.EventHandler(this.lblArriveTime_Click);
            // 
            // lblEstimate
            // 
            this.lblEstimate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEstimate.AutoSize = true;
            this.lblEstimate.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblEstimate.ForeColor = System.Drawing.Color.White;
            this.lblEstimate.Location = new System.Drawing.Point(354, 13);
            this.lblEstimate.Name = "lblEstimate";
            this.lblEstimate.Size = new System.Drawing.Size(36, 15);
            this.lblEstimate.TabIndex = 0;
            this.lblEstimate.Text = "20:19";
            this.lblEstimate.Click += new System.EventHandler(this.lblEstimate_Click);
            // 
            // NotificationItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.Controls.Add(this.lblNewNotification);
            this.Controls.Add(this.lblArriveTime);
            this.Controls.Add(this.lblEstimate);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.MaximumSize = new System.Drawing.Size(398, 58);
            this.MinimumSize = new System.Drawing.Size(398, 58);
            this.Name = "NotificationItemControl";
            this.Size = new System.Drawing.Size(398, 58);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblTitle;
        private Label lblNewNotification;
        private Label lblArriveTime;
        private Label lblEstimate;
    }
}
