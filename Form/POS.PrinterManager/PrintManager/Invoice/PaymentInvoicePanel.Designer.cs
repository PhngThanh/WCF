namespace POS.PrintManager.Invoice
{
    partial class PaymentInvoicePanel
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
            this.tlpPayment = new System.Windows.Forms.TableLayoutPanel();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblTotalAmountInput = new System.Windows.Forms.Label();
            this.lblAmountInWord = new System.Windows.Forms.Label();
            this.lblFinalAmount = new System.Windows.Forms.Label();
            this.lblFinalAmountInput = new System.Windows.Forms.Label();
            this.lblVATAmoutInput = new System.Windows.Forms.Label();
            this.lblVATAmout = new System.Windows.Forms.Label();
            this.lblVATRate = new System.Windows.Forms.Label();
            this.lblVATRateInput = new System.Windows.Forms.Label();
            this.tlpPayment.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPayment
            // 
            this.tlpPayment.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tlpPayment.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpPayment.ColumnCount = 2;
            this.tlpPayment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPayment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 179F));
            this.tlpPayment.Controls.Add(this.lblTotalAmount, 0, 0);
            this.tlpPayment.Controls.Add(this.lblTotalAmountInput, 1, 0);
            this.tlpPayment.Controls.Add(this.lblAmountInWord, 0, 4);
            this.tlpPayment.Controls.Add(this.lblFinalAmount, 0, 3);
            this.tlpPayment.Controls.Add(this.lblFinalAmountInput, 1, 3);
            this.tlpPayment.Controls.Add(this.lblVATAmoutInput, 1, 2);
            this.tlpPayment.Controls.Add(this.lblVATAmout, 0, 2);
            this.tlpPayment.Controls.Add(this.lblVATRate, 0, 1);
            this.tlpPayment.Controls.Add(this.lblVATRateInput, 1, 1);
            this.tlpPayment.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tlpPayment.Location = new System.Drawing.Point(15, 0);
            this.tlpPayment.Margin = new System.Windows.Forms.Padding(15, 0, 10, 15);
            this.tlpPayment.Name = "tlpPayment";
            this.tlpPayment.RowCount = 5;
            this.tlpPayment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpPayment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpPayment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpPayment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpPayment.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPayment.Size = new System.Drawing.Size(923, 182);
            this.tlpPayment.TabIndex = 23;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.Black;
            this.lblTotalAmount.Location = new System.Drawing.Point(6, 6);
            this.lblTotalAmount.Margin = new System.Windows.Forms.Padding(5);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(739, 20);
            this.lblTotalAmount.TabIndex = 17;
            this.lblTotalAmount.Text = "Tổng cộng tiền hàng (Total amount) :";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalAmountInput
            // 
            this.lblTotalAmountInput.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmountInput.ForeColor = System.Drawing.Color.Black;
            this.lblTotalAmountInput.Location = new System.Drawing.Point(756, 6);
            this.lblTotalAmountInput.Margin = new System.Windows.Forms.Padding(5);
            this.lblTotalAmountInput.Name = "lblTotalAmountInput";
            this.lblTotalAmountInput.Size = new System.Drawing.Size(161, 20);
            this.lblTotalAmountInput.TabIndex = 19;
            this.lblTotalAmountInput.Text = "1.000.000";
            this.lblTotalAmountInput.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAmountInWord
            // 
            this.lblAmountInWord.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmountInWord.ForeColor = System.Drawing.Color.Black;
            this.lblAmountInWord.Location = new System.Drawing.Point(6, 130);
            this.lblAmountInWord.Margin = new System.Windows.Forms.Padding(5);
            this.lblAmountInWord.Name = "lblAmountInWord";
            this.lblAmountInWord.Size = new System.Drawing.Size(739, 42);
            this.lblAmountInWord.TabIndex = 24;
            this.lblAmountInWord.Text = "Số tiền viết bằng chữ (In word) : ";
            this.lblAmountInWord.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFinalAmount
            // 
            this.lblFinalAmount.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinalAmount.ForeColor = System.Drawing.Color.Black;
            this.lblFinalAmount.Location = new System.Drawing.Point(6, 99);
            this.lblFinalAmount.Margin = new System.Windows.Forms.Padding(5);
            this.lblFinalAmount.Name = "lblFinalAmount";
            this.lblFinalAmount.Size = new System.Drawing.Size(739, 20);
            this.lblFinalAmount.TabIndex = 23;
            this.lblFinalAmount.Text = "Tổng tiền thanh toán (Grand total) :";
            this.lblFinalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFinalAmountInput
            // 
            this.lblFinalAmountInput.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinalAmountInput.ForeColor = System.Drawing.Color.Black;
            this.lblFinalAmountInput.Location = new System.Drawing.Point(756, 99);
            this.lblFinalAmountInput.Margin = new System.Windows.Forms.Padding(5);
            this.lblFinalAmountInput.Name = "lblFinalAmountInput";
            this.lblFinalAmountInput.Size = new System.Drawing.Size(161, 20);
            this.lblFinalAmountInput.TabIndex = 21;
            this.lblFinalAmountInput.Text = "1.000.000";
            this.lblFinalAmountInput.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVATAmoutInput
            // 
            this.lblVATAmoutInput.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVATAmoutInput.ForeColor = System.Drawing.Color.Black;
            this.lblVATAmoutInput.Location = new System.Drawing.Point(756, 68);
            this.lblVATAmoutInput.Margin = new System.Windows.Forms.Padding(5);
            this.lblVATAmoutInput.Name = "lblVATAmoutInput";
            this.lblVATAmoutInput.Size = new System.Drawing.Size(161, 20);
            this.lblVATAmoutInput.TabIndex = 20;
            this.lblVATAmoutInput.Text = "1.000.000";
            this.lblVATAmoutInput.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVATAmout
            // 
            this.lblVATAmout.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVATAmout.ForeColor = System.Drawing.Color.Black;
            this.lblVATAmout.Location = new System.Drawing.Point(6, 68);
            this.lblVATAmout.Margin = new System.Windows.Forms.Padding(5);
            this.lblVATAmout.Name = "lblVATAmout";
            this.lblVATAmout.Size = new System.Drawing.Size(739, 20);
            this.lblVATAmout.TabIndex = 25;
            this.lblVATAmout.Text = "Tiền thuế GTGT (VAT amount) :";
            this.lblVATAmout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVATRate
            // 
            this.lblVATRate.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVATRate.ForeColor = System.Drawing.Color.Black;
            this.lblVATRate.Location = new System.Drawing.Point(6, 37);
            this.lblVATRate.Margin = new System.Windows.Forms.Padding(5);
            this.lblVATRate.Name = "lblVATRate";
            this.lblVATRate.Size = new System.Drawing.Size(739, 20);
            this.lblVATRate.TabIndex = 26;
            this.lblVATRate.Text = "Thuế suất GTGT (VAT rate) :";
            this.lblVATRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVATRateInput
            // 
            this.lblVATRateInput.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVATRateInput.ForeColor = System.Drawing.Color.Black;
            this.lblVATRateInput.Location = new System.Drawing.Point(756, 37);
            this.lblVATRateInput.Margin = new System.Windows.Forms.Padding(5);
            this.lblVATRateInput.Name = "lblVATRateInput";
            this.lblVATRateInput.Size = new System.Drawing.Size(161, 20);
            this.lblVATRateInput.TabIndex = 27;
            this.lblVATRateInput.Text = "10 %";
            this.lblVATRateInput.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PaymentInvoicePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tlpPayment);
            this.Name = "PaymentInvoicePanel";
            this.Size = new System.Drawing.Size(955, 200);
            this.tlpPayment.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPayment;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblTotalAmountInput;
        private System.Windows.Forms.Label lblAmountInWord;
        private System.Windows.Forms.Label lblFinalAmount;
        private System.Windows.Forms.Label lblFinalAmountInput;
        private System.Windows.Forms.Label lblVATAmoutInput;
        private System.Windows.Forms.Label lblVATAmout;
        private System.Windows.Forms.Label lblVATRate;
        private System.Windows.Forms.Label lblVATRateInput;
    }
}
