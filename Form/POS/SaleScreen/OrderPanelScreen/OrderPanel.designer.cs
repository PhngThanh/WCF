using System.ComponentModel;
using System.Windows.Forms;
using POS.CustomControl;

namespace POS.SaleScreen
{
    partial class OrderPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;
        //private Label lblExchange;
        //private Label lblReceived;
        private Label lblPayment;
        private Label lblCancel;
        private Label lblTable;
        private Label lblDelivery;
        private Label lblTakeAway;
        private OrderPanelItemList pnlItemList;
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
            this.lblTable = new System.Windows.Forms.Label();
            this.lblPayment = new System.Windows.Forms.Label();
            this.lblCancel = new System.Windows.Forms.Label();
            this.lblDelivery = new System.Windows.Forms.Label();
            this.lblTakeAway = new System.Windows.Forms.Label();
            this.lblTotalProduct = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.pnlItemList = new POS.SaleScreen.OrderPanelItemList();
            this.pnlSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTable
            // 
            this.lblTable.BackColor = System.Drawing.Color.Transparent;
            this.lblTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 0.001F);
            this.lblTable.Location = new System.Drawing.Point(84, 20);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(61, 61);
            this.lblTable.TabIndex = 4;
            // 
            // lblPayment
            // 
            this.lblPayment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPayment.BackColor = System.Drawing.Color.Transparent;
            this.lblPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lblPayment.Location = new System.Drawing.Point(9, 437);
            this.lblPayment.Name = "lblPayment";
            this.lblPayment.Size = new System.Drawing.Size(118, 23);
            this.lblPayment.TabIndex = 2;
            this.lblPayment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //this.lblPayment.Click += new System.EventHandler(this.lblPayment_Click_1);
            // 
            // lblCancel
            // 
            this.lblCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCancel.BackColor = System.Drawing.Color.Transparent;
            this.lblCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lblCancel.Location = new System.Drawing.Point(150, 437);
            this.lblCancel.Name = "lblCancel";
            this.lblCancel.Size = new System.Drawing.Size(145, 23);
            this.lblCancel.TabIndex = 3;
            this.lblCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDelivery
            // 
            this.lblDelivery.BackColor = System.Drawing.Color.Transparent;
            this.lblDelivery.Location = new System.Drawing.Point(6, 39);
            this.lblDelivery.Name = "lblDelivery";
            this.lblDelivery.Size = new System.Drawing.Size(100, 23);
            this.lblDelivery.TabIndex = 1;
            // 
            // lblTakeAway
            // 
            this.lblTakeAway.BackColor = System.Drawing.Color.Transparent;
            this.lblTakeAway.Location = new System.Drawing.Point(198, 40);
            this.lblTakeAway.Name = "lblTakeAway";
            this.lblTakeAway.Size = new System.Drawing.Size(100, 23);
            this.lblTakeAway.TabIndex = 1;
            // 
            // lblTotalProduct
            // 
            this.lblTotalProduct.AutoSize = true;
            this.lblTotalProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalProduct.ForeColor = System.Drawing.Color.White;
            this.lblTotalProduct.Location = new System.Drawing.Point(7, 44);
            this.lblTotalProduct.Name = "lblTotalProduct";
            this.lblTotalProduct.Size = new System.Drawing.Size(0, 29);
            this.lblTotalProduct.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.label1.Location = new System.Drawing.Point(160, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tổng cộng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.label2.Location = new System.Drawing.Point(4, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "# Sản phẩm";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.White;
            this.lblTotalAmount.Location = new System.Drawing.Point(168, 44);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(0, 29);
            this.lblTotalAmount.TabIndex = 10;
            // 
            // pnlSummary
            // 
            this.pnlSummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSummary.BackColor = System.Drawing.Color.Transparent;
            this.pnlSummary.Controls.Add(this.lblTotalAmount);
            this.pnlSummary.Controls.Add(this.lblTotalProduct);
            this.pnlSummary.Controls.Add(this.label1);
            this.pnlSummary.Controls.Add(this.label2);
            this.pnlSummary.Location = new System.Drawing.Point(7, 341);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(292, 93);
            this.pnlSummary.TabIndex = 11;
            // 
            // pnlItemList
            // 
            this.pnlItemList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlItemList.BackColor = System.Drawing.Color.White;
            this.pnlItemList.Location = new System.Drawing.Point(3, 102);
            this.pnlItemList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlItemList.Name = "pnlItemList";
            this.pnlItemList.OrderEditViewModel = null;
            this.pnlItemList.Size = new System.Drawing.Size(300, 209);
            this.pnlItemList.TabIndex = 6;
            // 
            // OrderPanel
            // 
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.lblPayment);
            this.Controls.Add(this.lblCancel);
            this.Controls.Add(this.lblTable);
            this.Controls.Add(this.pnlItemList);
            this.Controls.Add(this.lblDelivery);
            this.Controls.Add(this.lblTakeAway);
            this.Controls.Add(this.pnlSummary);
            this.Name = "OrderPanel";
            this.Size = new System.Drawing.Size(306, 495);
            this.Load += new System.EventHandler(this.OrderPanel_Load);
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummary.PerformLayout();
            this.ResumeLayout(false);

        }

        private Label lblTotalProduct;
        private Label label1;
        private Label label2;
        private Label lblTotalAmount;
        private Panel pnlSummary;

        //private void SetPosition()
        //{
        //    // LongTN - thay đổi giao diện: thêm khoảng trống show list item
        //    lblExchange.Hide();
        //    lblReceived.Hide();

        //    lblExchange.Top = Height - 82
        //                      - 42 + 20;
        //    lblReceived.Top = lblExchange.Top - 55;
            //pnlSummary.Top = Height - 37 - 140; // - 93 //khi cần thêm lblReceived + lblExchange
        //    lblPayment.Top = Height - 42 - 2;
        //    lblCancel.Top = Height - 42 - 2;
        //    if (pnlItemList != null)
        //    {
        //        pnlItemList.Height = Height - 82 -
        //                            42 - 50 - pnlItemList.Top; // - 42 - 161
        //    }
        //    lblReceived.Invalidate();
        //}

        #endregion

    }
}
