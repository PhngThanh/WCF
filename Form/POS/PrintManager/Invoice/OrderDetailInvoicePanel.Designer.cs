namespace POS.PrintManager.Invoice
{
    partial class OrderDetailInvoicePanel
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
            this.tlpOrderDetail = new System.Windows.Forms.TableLayoutPanel();
            this.lblNo = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblUnit = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblUnitPrice = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblNoInput = new System.Windows.Forms.Label();
            this.lblDescriptionInput = new System.Windows.Forms.Label();
            this.lblUnitInput = new System.Windows.Forms.Label();
            this.lblQuantityInput = new System.Windows.Forms.Label();
            this.lblUnitPriceInput = new System.Windows.Forms.Label();
            this.lblAmountInput = new System.Windows.Forms.Label();
            this.tlpOrderDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpOrderDetail
            // 
            this.tlpOrderDetail.BackColor = System.Drawing.Color.Transparent;
            this.tlpOrderDetail.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpOrderDetail.ColumnCount = 6;
            this.tlpOrderDetail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpOrderDetail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tlpOrderDetail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tlpOrderDetail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tlpOrderDetail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 145F));
            this.tlpOrderDetail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 179F));
            this.tlpOrderDetail.Controls.Add(this.lblNo, 0, 0);
            this.tlpOrderDetail.Controls.Add(this.lblDescription, 1, 0);
            this.tlpOrderDetail.Controls.Add(this.lblUnit, 2, 0);
            this.tlpOrderDetail.Controls.Add(this.lblQuantity, 3, 0);
            this.tlpOrderDetail.Controls.Add(this.lblUnitPrice, 4, 0);
            this.tlpOrderDetail.Controls.Add(this.lblAmount, 5, 0);
            this.tlpOrderDetail.Controls.Add(this.lblNoInput, 0, 1);
            this.tlpOrderDetail.Controls.Add(this.lblDescriptionInput, 1, 1);
            this.tlpOrderDetail.Controls.Add(this.lblUnitInput, 2, 1);
            this.tlpOrderDetail.Controls.Add(this.lblQuantityInput, 3, 1);
            this.tlpOrderDetail.Controls.Add(this.lblUnitPriceInput, 4, 1);
            this.tlpOrderDetail.Controls.Add(this.lblAmountInput, 5, 1);
            this.tlpOrderDetail.Location = new System.Drawing.Point(15, 15);
            this.tlpOrderDetail.Margin = new System.Windows.Forms.Padding(15, 15, 10, 0);
            this.tlpOrderDetail.Name = "tlpOrderDetail";
            this.tlpOrderDetail.RowCount = 2;
            this.tlpOrderDetail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpOrderDetail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpOrderDetail.Size = new System.Drawing.Size(923, 500);
            this.tlpOrderDetail.TabIndex = 22;
            // 
            // lblNo
            // 
            this.lblNo.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNo.ForeColor = System.Drawing.Color.Black;
            this.lblNo.Location = new System.Drawing.Point(6, 6);
            this.lblNo.Margin = new System.Windows.Forms.Padding(5);
            this.lblNo.Name = "lblNo";
            this.lblNo.Size = new System.Drawing.Size(40, 40);
            this.lblNo.TabIndex = 8;
            this.lblNo.Text = "STT\n(No.)";
            this.lblNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.Color.Black;
            this.lblDescription.Location = new System.Drawing.Point(57, 6);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(5);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(390, 40);
            this.lblDescription.TabIndex = 7;
            this.lblDescription.Text = "Tên hàng hóa, dịch vụ\n(Description)";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUnit
            // 
            this.lblUnit.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnit.ForeColor = System.Drawing.Color.Black;
            this.lblUnit.Location = new System.Drawing.Point(458, 6);
            this.lblUnit.Margin = new System.Windows.Forms.Padding(5);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(65, 40);
            this.lblUnit.TabIndex = 9;
            this.lblUnit.Text = "ĐVT\n(Unit)";
            this.lblUnit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblQuantity
            // 
            this.lblQuantity.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.ForeColor = System.Drawing.Color.Black;
            this.lblQuantity.Location = new System.Drawing.Point(534, 6);
            this.lblQuantity.Margin = new System.Windows.Forms.Padding(5);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(65, 40);
            this.lblQuantity.TabIndex = 10;
            this.lblQuantity.Text = "Số lượng\n(Quantity)";
            this.lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUnitPrice
            // 
            this.lblUnitPrice.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitPrice.ForeColor = System.Drawing.Color.Black;
            this.lblUnitPrice.Location = new System.Drawing.Point(610, 6);
            this.lblUnitPrice.Margin = new System.Windows.Forms.Padding(5);
            this.lblUnitPrice.Name = "lblUnitPrice";
            this.lblUnitPrice.Size = new System.Drawing.Size(135, 40);
            this.lblUnitPrice.TabIndex = 11;
            this.lblUnitPrice.Text = "Đơn giá\n(Unit Price)";
            this.lblUnitPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAmount
            // 
            this.lblAmount.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.ForeColor = System.Drawing.Color.Black;
            this.lblAmount.Location = new System.Drawing.Point(756, 6);
            this.lblAmount.Margin = new System.Windows.Forms.Padding(5);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(140, 40);
            this.lblAmount.TabIndex = 12;
            this.lblAmount.Text = "Thành tiền\n(Amount)";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNoInput
            // 
            this.lblNoInput.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoInput.ForeColor = System.Drawing.Color.Black;
            this.lblNoInput.Location = new System.Drawing.Point(6, 57);
            this.lblNoInput.Margin = new System.Windows.Forms.Padding(5);
            this.lblNoInput.Name = "lblNoInput";
            this.lblNoInput.Size = new System.Drawing.Size(40, 20);
            this.lblNoInput.TabIndex = 13;
            this.lblNoInput.Text = "1";
            this.lblNoInput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDescriptionInput
            // 
            this.lblDescriptionInput.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescriptionInput.ForeColor = System.Drawing.Color.Black;
            this.lblDescriptionInput.Location = new System.Drawing.Point(57, 57);
            this.lblDescriptionInput.Margin = new System.Windows.Forms.Padding(5);
            this.lblDescriptionInput.Name = "lblDescriptionInput";
            this.lblDescriptionInput.Size = new System.Drawing.Size(390, 20);
            this.lblDescriptionInput.TabIndex = 14;
            this.lblDescriptionInput.Text = "2";
            this.lblDescriptionInput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUnitInput
            // 
            this.lblUnitInput.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitInput.ForeColor = System.Drawing.Color.Black;
            this.lblUnitInput.Location = new System.Drawing.Point(458, 57);
            this.lblUnitInput.Margin = new System.Windows.Forms.Padding(5);
            this.lblUnitInput.Name = "lblUnitInput";
            this.lblUnitInput.Size = new System.Drawing.Size(65, 20);
            this.lblUnitInput.TabIndex = 15;
            this.lblUnitInput.Text = "3";
            this.lblUnitInput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblQuantityInput
            // 
            this.lblQuantityInput.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantityInput.ForeColor = System.Drawing.Color.Black;
            this.lblQuantityInput.Location = new System.Drawing.Point(534, 57);
            this.lblQuantityInput.Margin = new System.Windows.Forms.Padding(5);
            this.lblQuantityInput.Name = "lblQuantityInput";
            this.lblQuantityInput.Size = new System.Drawing.Size(65, 20);
            this.lblQuantityInput.TabIndex = 16;
            this.lblQuantityInput.Text = "4";
            this.lblQuantityInput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUnitPriceInput
            // 
            this.lblUnitPriceInput.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitPriceInput.ForeColor = System.Drawing.Color.Black;
            this.lblUnitPriceInput.Location = new System.Drawing.Point(610, 57);
            this.lblUnitPriceInput.Margin = new System.Windows.Forms.Padding(5);
            this.lblUnitPriceInput.Name = "lblUnitPriceInput";
            this.lblUnitPriceInput.Size = new System.Drawing.Size(135, 20);
            this.lblUnitPriceInput.TabIndex = 17;
            this.lblUnitPriceInput.Text = "5";
            this.lblUnitPriceInput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAmountInput
            // 
            this.lblAmountInput.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountInput.ForeColor = System.Drawing.Color.Black;
            this.lblAmountInput.Location = new System.Drawing.Point(756, 57);
            this.lblAmountInput.Margin = new System.Windows.Forms.Padding(5);
            this.lblAmountInput.Name = "lblAmountInput";
            this.lblAmountInput.Size = new System.Drawing.Size(140, 20);
            this.lblAmountInput.TabIndex = 19;
            this.lblAmountInput.Text = "6 = 4 x 5";
            this.lblAmountInput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OrderDetailInvoicePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tlpOrderDetail);
            this.Name = "OrderDetailInvoicePanel";
            this.Size = new System.Drawing.Size(955, 530);
            this.tlpOrderDetail.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpOrderDetail;
        private System.Windows.Forms.Label lblNo;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblUnitPrice;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblNoInput;
        private System.Windows.Forms.Label lblDescriptionInput;
        private System.Windows.Forms.Label lblUnitInput;
        private System.Windows.Forms.Label lblQuantityInput;
        private System.Windows.Forms.Label lblUnitPriceInput;
        private System.Windows.Forms.Label lblAmountInput;
    }
}
