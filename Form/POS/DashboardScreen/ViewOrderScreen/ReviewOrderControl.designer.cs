using POS.Properties;
using System.Windows.Forms;

namespace POS.DashboardScreen.ViewOrderScreen
{
    partial class ReviewOrderControl
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
            this.lbTableNumber = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.lbOrderCode = new System.Windows.Forms.Label();
            this.lbQuantity = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblFinalAmount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbTableNumber
            // 
            this.lbTableNumber.AutoSize = true;
            this.lbTableNumber.BackColor = System.Drawing.Color.Transparent;
            this.lbTableNumber.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTableNumber.ForeColor = System.Drawing.Color.White;
            this.lbTableNumber.Location = new System.Drawing.Point(4, 9);
            this.lbTableNumber.Name = "lbTableNumber";
            this.lbTableNumber.Size = new System.Drawing.Size(42, 16);
            this.lbTableNumber.TabIndex = 1;
            this.lbTableNumber.Text = "Table";
            this.lbTableNumber.Click += new System.EventHandler(this.child_Click);
            // 
            // lbTime
            // 
            this.lbTime.BackColor = System.Drawing.Color.Transparent;
            this.lbTime.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTime.ForeColor = System.Drawing.Color.White;
            this.lbTime.Location = new System.Drawing.Point(177, 9);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(60, 16);
            this.lbTime.TabIndex = 2;
            this.lbTime.Text = "10:30";
            this.lbTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbTime.Click += new System.EventHandler(this.child_Click);
            // 
            // lbOrderCode
            // 
            this.lbOrderCode.AutoSize = true;
            this.lbOrderCode.BackColor = System.Drawing.Color.Transparent;
            this.lbOrderCode.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOrderCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.lbOrderCode.Location = new System.Drawing.Point(21, 40);
            this.lbOrderCode.Name = "lbOrderCode";
            this.lbOrderCode.Size = new System.Drawing.Size(174, 16);
            this.lbOrderCode.TabIndex = 3;
            this.lbOrderCode.Text = "OrderEditViewModel Code";
            this.lbOrderCode.Click += new System.EventHandler(this.child_Click);
            // 
            // lbQuantity
            // 
            this.lbQuantity.AutoSize = true;
            this.lbQuantity.BackColor = System.Drawing.Color.Transparent;
            this.lbQuantity.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.lbQuantity.Location = new System.Drawing.Point(21, 65);
            this.lbQuantity.Name = "lbQuantity";
            this.lbQuantity.Size = new System.Drawing.Size(48, 16);
            this.lbQuantity.TabIndex = 4;
            this.lbQuantity.Text = "1 / 10";
            this.lbQuantity.Click += new System.EventHandler(this.child_Click);
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalAmount.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.lblTotalAmount.Location = new System.Drawing.Point(21, 89);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(71, 16);
            this.lblTotalAmount.TabIndex = 5;
            this.lblTotalAmount.Text = "5000 VNĐ";
            this.lblTotalAmount.Click += new System.EventHandler(this.child_Click);
            // 
            // lblFinalAmount
            // 
            this.lblFinalAmount.AutoSize = true;
            this.lblFinalAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblFinalAmount.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinalAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(124)))));
            this.lblFinalAmount.Location = new System.Drawing.Point(21, 112);
            this.lblFinalAmount.Name = "lblFinalAmount";
            this.lblFinalAmount.Size = new System.Drawing.Size(71, 16);
            this.lblFinalAmount.TabIndex = 5;
            this.lblFinalAmount.Text = "5000 VNĐ";
            this.lblFinalAmount.Click += new System.EventHandler(this.child_Click);
            // 
            // ReviewOrderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblFinalAmount);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.lbQuantity);
            this.Controls.Add(this.lbOrderCode);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.lbTableNumber);
            this.MaximumSize = new System.Drawing.Size(245, 155);
            this.MinimumSize = new System.Drawing.Size(240, 135);
            this.Name = "ReviewOrderControl";
            this.Size = new System.Drawing.Size(245, 155);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label lbTableNumber;
        private Label lbTime;
        private Label lbOrderCode;
        private Label lbQuantity;
        private Label lblTotalAmount;
        private Label lblFinalAmount;
    }
}
