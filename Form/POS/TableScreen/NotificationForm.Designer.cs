using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace POS.TableScreen
{
    partial class NotificationForm
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
            this.pnlNotificationContainer = new System.Windows.Forms.Panel();
            this.notificationListControl1 = new POS.TableScreen.NotificationListControl();
            this.pnlNotificationDetail = new System.Windows.Forms.Panel();
            this.orderDetailControl1 = new POS.OrderDetailForm.OrderDetailControl();
            this.pnlNotificationContainer.SuspendLayout();
            this.pnlNotificationDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(118)))), ((int)(((byte)(118)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(1038, 66);
            this.label1.TabIndex = 0;
            this.label1.Text = "Notification center";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlNotificationContainer
            // 
            this.pnlNotificationContainer.Controls.Add(this.notificationListControl1);
            this.pnlNotificationContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlNotificationContainer.Location = new System.Drawing.Point(0, 66);
            this.pnlNotificationContainer.Name = "pnlNotificationContainer";
            this.pnlNotificationContainer.Size = new System.Drawing.Size(400, 493);
            this.pnlNotificationContainer.TabIndex = 1;
            // 
            // notificationListControl1
            // 
            this.notificationListControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(66)))), ((int)(((byte)(67)))));
            this.notificationListControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notificationListControl1.Expanded = false;
            this.notificationListControl1.Location = new System.Drawing.Point(0, 0);
            this.notificationListControl1.Margin = new System.Windows.Forms.Padding(0);
            this.notificationListControl1.Name = "notificationListControl1";
            this.notificationListControl1.Size = new System.Drawing.Size(400, 493);
            this.notificationListControl1.TabIndex = 0;
            // 
            // pnlNotificationDetail
            // 
            this.pnlNotificationDetail.Controls.Add(this.orderDetailControl1);
            this.pnlNotificationDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNotificationDetail.Location = new System.Drawing.Point(0, 66);
            this.pnlNotificationDetail.Name = "pnlNotificationDetail";
            this.pnlNotificationDetail.Size = new System.Drawing.Size(1038, 493);
            this.pnlNotificationDetail.TabIndex = 2;
            // 
            // orderDetailControl1
            // 
            this.orderDetailControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(66)))), ((int)(((byte)(67)))));
            this.orderDetailControl1.Location = new System.Drawing.Point(403, 0);
            this.orderDetailControl1.Name = "orderDetailControl1";
            this.orderDetailControl1.Size = new System.Drawing.Size(698, 564);
            this.orderDetailControl1.TabIndex = 0;
            // 
            // NotificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(1038, 559);
            this.Controls.Add(this.pnlNotificationContainer);
            this.Controls.Add(this.pnlNotificationDetail);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NotificationForm";
            this.ShowInTaskbar = false;
            this.Text = "NotificationForm";
            this.pnlNotificationContainer.ResumeLayout(false);
            this.pnlNotificationDetail.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private Panel pnlNotificationContainer;
        private Panel pnlNotificationDetail;
        private NotificationListControl notificationListControl1;
        private OrderDetailForm.OrderDetailControl orderDetailControl1;



    }
}