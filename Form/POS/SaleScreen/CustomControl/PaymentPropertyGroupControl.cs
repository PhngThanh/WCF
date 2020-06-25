using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using POS.Common;
using POS.SaleScreen.Data;
using POS.Service;
using POS.Data;
using System.Diagnostics;

namespace POS.SaleScreen.CustomControl
{
    public class PaymentPropertyGroupControl : Panel
    {
        public bool QuickCashClicked = false;
        private readonly Label _lblCash = new Label();
        private readonly Label _lblMembershipCard = new Label();
        private readonly Label _lblCreditCard = new Label();
        private readonly FlatTextBox _txtCash = new FlatTextBox();
        private readonly FlatTextBox _txtMembershipCard = new FlatTextBox();
        private readonly FlatTextBox _txtCreditCard = new FlatTextBox();
        private readonly TotalLabel _lblTotalLabel = new TotalLabel();
        private readonly Label _lblQuickCash = new Label();
        private PropertyControl _200KCash;
        private PropertyControl _100KCash;
        private PropertyControl _500KCash;
        private PropertyControl _50KCash;

        public PaymentPropertyGroupControl()
        {
            Width = 210;
            Height = DrawControlLibrary.PropertiesPanel.Height - DrawControlLibrary.PropertiesPanel.PaddingBottom -
                     DrawControlLibrary.PropertiesPanel.PaddingTop + 85;
            BackColor = Color.Transparent;
            Text = "";


            const int labelPaddingLeft = 13;

            _lblCreditCard.Text = MainForm.resManager.GetString("Credit_Card", MainForm.cultureInfo);
            _lblCreditCard.Top = 168;
            _lblCreditCard.Left = labelPaddingLeft;

            _lblQuickCash.Text = MainForm.resManager.GetString("PaymentPropertyGroupControl_Quick_Cash", MainForm.cultureInfo);
            _lblQuickCash.Top = 222;
            _lblQuickCash.Left = labelPaddingLeft;

            _lblMembershipCard.Text = MainForm.resManager.GetString("PaymentPropertyGroupControl_Membership_Card", MainForm.cultureInfo);
            _lblMembershipCard.Top = 114;
            _lblMembershipCard.Left = labelPaddingLeft;


            _lblCash.Text = MainForm.resManager.GetString("Cash", MainForm.cultureInfo);
            _lblCash.Top = 60;
            _lblCash.Left = labelPaddingLeft;

            _txtCash.Left = 15;
            _txtCash.Top = _lblCash.Top + 15;
            _txtCash.Width = Width - 30;
            _txtCash.BackgroundColor = Constant.Brown;
            _txtCash.BorderColor = Constant.Brown;
            _txtCash.TextColor = Constant.White;
            _txtCash.ShowClearButton = true;
            _txtCash.Click += TextBox_Click;
            _txtCash.ValueChange += Payment_ValueChanged;
            _txtCash.Font = new Font(DrawControlLibrary.PrivateFontCollection.Families[0], 10, FontStyle.Bold);
            Controls.Add(_txtCash);
            Controls.Add(_lblCash);

            _txtMembershipCard.Left = 15;
            _txtMembershipCard.Top = _lblMembershipCard.Top + 15;
            _txtMembershipCard.Width = Width - 30;
            _txtMembershipCard.BackgroundColor = Constant.Brown;
            _txtMembershipCard.BorderColor = Constant.Brown;
            _txtMembershipCard.TextColor = Constant.White;
            _txtMembershipCard.ShowClearButton = true;
            _txtMembershipCard.TabIndex = 0;
            _txtMembershipCard.Click += TextBox_Click;
            _txtMembershipCard.ValueChange += Payment_ValueChanged;
            _txtMembershipCard.Font = new Font(DrawControlLibrary.PrivateFontCollection.Families[0], 10, FontStyle.Bold);
            Controls.Add(_txtMembershipCard);
            Controls.Add(_lblMembershipCard);

            _txtCreditCard.Left = 15;
            _txtCreditCard.Top = _lblCreditCard.Top + 15;
            _txtCreditCard.Width = Width - 30;
            _txtCreditCard.BackgroundColor = Constant.Brown;
            _txtCreditCard.BorderColor = Constant.Brown;
            _txtCreditCard.TextColor = Constant.White;
            _txtCreditCard.ShowClearButton = true;
            _txtCreditCard.TabIndex = 0;
            _txtCreditCard.Click += TextBox_Click;
            _txtCreditCard.ValueChange += Payment_ValueChanged;
            _txtCreditCard.Font = new Font(DrawControlLibrary.PrivateFontCollection.Families[0], 10, FontStyle.Bold);

            _50KCash = new PropertyControl
            {
                Type = 1,
                Value = 50000,
                ButtonType = ButtonType.Click,
                DisplayText = "50k",
                Group = 0,
                Name = MainForm.resManager.GetString("Cash", MainForm.cultureInfo),
                TextSize = 12,
                Top = _lblQuickCash.Bottom - 3,
                Left = 20
            };
            _100KCash = new PropertyControl
            {
                Type = 1,
                Value = 100000,
                ButtonType = ButtonType.Click,
                DisplayText = "100k",
                Group = 0,
                Name = MainForm.resManager.GetString("Cash", MainForm.cultureInfo),
                TextSize = 12,
                Top = _50KCash.Top,
                Left = _50KCash.Right + 5
            };
            _200KCash = new PropertyControl
            {
                Type = 1,
                Value = 200000,
                ButtonType = ButtonType.Click,
                DisplayText = "200k",
                Group = 0,
                Name = MainForm.resManager.GetString("Cash", MainForm.cultureInfo),
                TextSize = 12,
                Top = _50KCash.Bottom + 5,
                Left = _50KCash.Left,
            };
            _500KCash = new PropertyControl
            {
                Type = 1,
                Value = 500000,
                ButtonType = ButtonType.Click,
                DisplayText = "500k",
                Group = 0,
                Name = MainForm.resManager.GetString("Cash", MainForm.cultureInfo),
                TextSize = 12,
                Top = _50KCash.Bottom + 5,
                Left = _100KCash.Left,
            };
            _500KCash.ClickEvent += QuickCash_ClickEvent;
            _200KCash.ClickEvent += QuickCash_ClickEvent;
            _100KCash.ClickEvent += QuickCash_ClickEvent;
            _50KCash.ClickEvent += QuickCash_ClickEvent;

            Controls.Add(_500KCash);
            Controls.Add(_200KCash);
            Controls.Add(_100KCash);
            Controls.Add(_50KCash);
            Controls.Add(_lblQuickCash);

            Controls.Add(_txtCreditCard);
            Controls.Add(_lblCreditCard);
            Controls.Add(_lblTotalLabel);
            //CommunicateBridge.PaymentInfoChanged += PaymentInfoChanged;
            
        }
        //tung
        public void EditCash()
        {
            if (!QuickCashClicked)
            {
                _txtCash.TabIndex = SaleScreen3.CurrentOrderManager.Order.FinalAmount;
                SaleScreen3.CurrentOrderManager.UpdatePayment(PaymentType.Cash, SaleScreen3.CurrentOrderManager.Order.FinalAmount, true);
                _txtCash.TextValue = SaleScreen3.CurrentOrderManager.Order.FinalAmount.ToString();
                _lblTotalLabel.Text = string.Format("{0:n0}", SaleScreen3.CurrentOrderManager.Order.TotalPayment);
            }
            else
            {
                Debug.WriteLine("editcash: true");
            }
        }

        public void ResetData()
        {
            _txtCash.TabIndex = 0;
            _txtCreditCard.TabIndex = 0;
            _txtMembershipCard.TabIndex = 0;

            _txtCash.ValueChange -= Payment_ValueChanged;
            _txtCash.TextValue = "";
            _txtCash.ValueChange += Payment_ValueChanged;

            _txtCreditCard.ValueChange -= Payment_ValueChanged;
            _txtCreditCard.TextValue = "";
            _txtCreditCard.ValueChange += Payment_ValueChanged;

            _txtMembershipCard.ValueChange -= Payment_ValueChanged;
            _txtMembershipCard.TextValue = "";
            _txtMembershipCard.ValueChange += Payment_ValueChanged;

            _lblTotalLabel.Text = "0";
            _lblTotalLabel.Invalidate();
        }

        
        private void QuickCash_ClickEvent(PropertyControl arg1)
        {
            SaleScreen3.CurrentOrderManager.UpdatePayment(PaymentType.Cash, arg1.Value,true);
            _txtCash.TabIndex = arg1.Value;
            _txtCash.ValueChange -= Payment_ValueChanged;
            _txtCash.TextValue = string.Format("{0:n0}", arg1.Value);
            _txtCash.ValueChange += Payment_ValueChanged;
            _lblTotalLabel.Text = string.Format("{0:n0}", SaleScreen3.CurrentOrderManager.Order.TotalPayment);
            _lblTotalLabel.Invalidate();
            QuickCashClicked = true;
        }

        public void Payment_ValueChanged()
        {
            _lblTotalLabel.Text = string.Format("{0:n0}", SaleScreen3.CurrentOrderManager.Order.TotalPayment);
            _lblTotalLabel.Invalidate();
        }

        private void Payment_ValueChanged(object sender, EventArgs e)
        {
            int amount = ((FlatTextBox) sender).TabIndex;//Cùi bắp, nhưng do NumPadDialog đã set vào TabIndex
            if (sender == _txtCash)
            {
                SaleScreen3.CurrentOrderManager.UpdatePayment(PaymentType.Cash,amount,true);
            }
            else if (sender == _txtMembershipCard)
            {
                SaleScreen3.CurrentOrderManager.UpdatePayment(PaymentType.MemberCard, amount,true);
            }
            else
            {
                SaleScreen3.CurrentOrderManager.UpdatePayment(PaymentType.Card, amount,true);
            }
            
            _lblTotalLabel.Text = string.Format("{0:n0}", SaleScreen3.CurrentOrderManager.Order.TotalPayment);
            _lblTotalLabel.Invalidate();
        }

        public event EventHandler TextBoxFocus;
        
        private void TextBox_Click(object sender, EventArgs e)
        {
           if (TextBoxFocus != null)
            {
                TextBoxFocus(sender, e);
            }
        }


        private class TotalLabel : Panel
        {
            public TotalLabel()
            {
                BackColor = Color.Transparent;
                Height = 150;
                Dock = DockStyle.Bottom;
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);

                var fontS = new Font(DrawControlLibrary.PrivateFontCollection.Families[0], 15, FontStyle.Underline);
                var fontM = new Font(DrawControlLibrary.PrivateFontCollection.Families[0], 20, FontStyle.Regular);
                var fontL = new Font(DrawControlLibrary.PrivateFontCollection.Families[0], 22, FontStyle.Regular);

                var format = new StringFormat
                {
                    Alignment = StringAlignment.Far
                };

                string exchange = string.Format("{0:n0}", SaleScreen3.CurrentOrderManager.Order.TotalPayment
                     - SaleScreen3.CurrentOrderManager.Order.FinalAmount);

                e.Graphics.DrawLine(new Pen(Constant.Brown), 5, 1, Width - 5, 1);
                // Payment
                e.Graphics.DrawString(
                    MainForm.resManager.GetString("Received", MainForm.cultureInfo)
                    , fontS, new SolidBrush(Constant.Brown), 10, 25);
                e.Graphics.DrawString(Text, fontL, new SolidBrush(Constant.Brown), Width - 22, 50, format);
                // Exchange
                e.Graphics.DrawString(
                    MainForm.resManager.GetString("Exchange", MainForm.cultureInfo)
                    , fontS, new SolidBrush(Constant.Brown), 10, 90);
                e.Graphics.DrawString(exchange, fontM, new SolidBrush(Constant.Brown), Width - 22, 115, format);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawControlLibrary.PropertiesPanel.DrawGroupProperties(this, e);
        }

       
    }
}
