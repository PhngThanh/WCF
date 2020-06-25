using POS.Properties;

namespace POS.DashboardScreen.OnlineOrderScreen
{
    partial class OnlineOrderControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picIcons = new System.Windows.Forms.PictureBox();
            this.lbOrderId = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.lbPersonName = new System.Windows.Forms.Label();
            this.lbPhoneNumber = new System.Windows.Forms.Label();
            this.lbAmount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picIcons)).BeginInit();
            this.SuspendLayout();
            // 
            // picIcons
            // 
            this.picIcons.Image = Resources.icons;
            this.picIcons.Location = new System.Drawing.Point(9, 48);
            this.picIcons.Name = "picIcons";
            this.picIcons.Size = new System.Drawing.Size(16, 70);
            this.picIcons.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picIcons.TabIndex = 0;
            this.picIcons.TabStop = false;
            this.picIcons.Click += new System.EventHandler(this.child_Click);
            // 
            // lbOrderId
            // 
            this.lbOrderId.AutoSize = true;
            this.lbOrderId.BackColor = System.Drawing.Color.Transparent;
            this.lbOrderId.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOrderId.ForeColor = System.Drawing.Color.White;
            this.lbOrderId.Location = new System.Drawing.Point(4, 9);
            this.lbOrderId.Name = "lbOrderId";
            this.lbOrderId.Size = new System.Drawing.Size(57, 16);
            this.lbOrderId.TabIndex = 1;
            this.lbOrderId.Text = "#02635";
            this.lbOrderId.Click += new System.EventHandler(this.child_Click);
            // 
            // lbTime
            // 
            this.lbTime.BackColor = System.Drawing.Color.Transparent;
            this.lbTime.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTime.ForeColor = System.Drawing.Color.White;
            this.lbTime.Location = new System.Drawing.Point(104, 9);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(133, 16);
            this.lbTime.TabIndex = 2;
            this.lbTime.Text = "10:30 02/05/2014";
            this.lbTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbTime.Click += new System.EventHandler(this.child_Click);
            // 
            // lbPersonName
            // 
            this.lbPersonName.AutoSize = true;
            this.lbPersonName.BackColor = System.Drawing.Color.Transparent;
            this.lbPersonName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPersonName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.lbPersonName.Location = new System.Drawing.Point(30, 47);
            this.lbPersonName.Name = "lbPersonName";
            this.lbPersonName.Size = new System.Drawing.Size(184, 16);
            this.lbPersonName.TabIndex = 3;
            this.lbPersonName.Text = "HOÀNG TRUNG THIÊN VƯƠNG";
            this.lbPersonName.Click += new System.EventHandler(this.child_Click);
            // 
            // lbPhoneNumber
            // 
            this.lbPhoneNumber.AutoSize = true;
            this.lbPhoneNumber.BackColor = System.Drawing.Color.Transparent;
            this.lbPhoneNumber.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPhoneNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.lbPhoneNumber.Location = new System.Drawing.Point(31, 74);
            this.lbPhoneNumber.Name = "lbPhoneNumber";
            this.lbPhoneNumber.Size = new System.Drawing.Size(100, 16);
            this.lbPhoneNumber.TabIndex = 4;
            this.lbPhoneNumber.Text = "0123-152-582";
            this.lbPhoneNumber.Click += new System.EventHandler(this.child_Click);
            // 
            // lbAmount
            // 
            this.lbAmount.AutoSize = true;
            this.lbAmount.BackColor = System.Drawing.Color.Transparent;
            this.lbAmount.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.lbAmount.Location = new System.Drawing.Point(31, 102);
            this.lbAmount.Name = "lbAmount";
            this.lbAmount.Size = new System.Drawing.Size(16, 16);
            this.lbAmount.TabIndex = 5;
            this.lbAmount.Text = "5";
            this.lbAmount.Click += new System.EventHandler(this.child_Click);
            // 
            // OnlineOrderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbAmount);
            this.Controls.Add(this.lbPhoneNumber);
            this.Controls.Add(this.lbPersonName);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.lbOrderId);
            this.Controls.Add(this.picIcons);
            this.MaximumSize = new System.Drawing.Size(240, 135);
            this.MinimumSize = new System.Drawing.Size(240, 135);
            this.Name = "OnlineOrderControl";
            this.Size = new System.Drawing.Size(240, 135);
            ((System.ComponentModel.ISupportInitialize)(this.picIcons)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picIcons;
        private System.Windows.Forms.Label lbOrderId;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Label lbPersonName;
        private System.Windows.Forms.Label lbPhoneNumber;
        private System.Windows.Forms.Label lbAmount;
    }
}
