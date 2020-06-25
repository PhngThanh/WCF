using System.ComponentModel;
using System.Windows.Forms;

namespace POS.TableScreen
{
    partial class NotificationListControl
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
            this.pnlListInfo = new System.Windows.Forms.Panel();
            this.lblListName = new System.Windows.Forms.Label();
            this.lblListCount = new System.Windows.Forms.Label();
            this.pnlListDetail = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlListInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlListInfo
            // 
            this.pnlListInfo.Controls.Add(this.lblListCount);
            this.pnlListInfo.Controls.Add(this.lblListName);
            this.pnlListInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlListInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlListInfo.Name = "pnlListInfo";
            this.pnlListInfo.Size = new System.Drawing.Size(400, 56);
            this.pnlListInfo.TabIndex = 0;
            // 
            // lblListName
            // 
            this.lblListName.AutoSize = true;
            this.lblListName.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblListName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.lblListName.Location = new System.Drawing.Point(3, 13);
            this.lblListName.Name = "lblListName";
            this.lblListName.Size = new System.Drawing.Size(159, 28);
            this.lblListName.TabIndex = 1;
            this.lblListName.Text = "ONLINE ORDER";
            // 
            // lblListCount
            // 
            this.lblListCount.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblListCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.lblListCount.Location = new System.Drawing.Point(349, 13);
            this.lblListCount.Name = "lblListCount";
            this.lblListCount.Size = new System.Drawing.Size(48, 28);
            this.lblListCount.TabIndex = 1;
            this.lblListCount.Text = "2";
            this.lblListCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlListDetail
            // 
            this.pnlListDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlListDetail.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlListDetail.Location = new System.Drawing.Point(0, 56);
            this.pnlListDetail.Name = "pnlListDetail";
            this.pnlListDetail.Size = new System.Drawing.Size(400, 149);
            this.pnlListDetail.TabIndex = 1;
            // 
            // NotificationListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(118)))), ((int)(((byte)(118)))));
            this.Controls.Add(this.pnlListDetail);
            this.Controls.Add(this.pnlListInfo);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "NotificationListControl";
            this.Size = new System.Drawing.Size(400, 205);
            this.pnlListInfo.ResumeLayout(false);
            this.pnlListInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlListInfo;
        private Label lblListCount;
        private Label lblListName;
        private FlowLayoutPanel pnlListDetail;

    }
}
