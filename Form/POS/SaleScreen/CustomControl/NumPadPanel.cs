using System;
using System.Windows.Forms;

using POS.Common;
using POS.SaleScreen;

namespace POS.SaleScreen.CustomControl
{
    public partial class NumPadPanel : UserControl
    {
        public NumPadPanel()
        {
            InitializeComponent();
        }

        private FlatTextBox _textbox;

        public FlatTextBox Textbox
        {
            get { return _textbox; }
            set
            {
                if (_textbox != null)
                {
                    _textbox.Active = false;
                }
                _textbox = value;
                _customDiscount = null;
                if (value==null)
                {
                    return;
                }
                _textbox.Active = true;
            }
        }

        private PropertyControl _customDiscount;

        public PropertyControl CustomDiscount
        {
            get { return _customDiscount; }
            set
            {
                _customDiscount = value;
                if (value==null)
                {
                    return;
                }
                if (_textbox != null)
                {
                    _textbox.Active = false;
                }
                _textbox = null;
            }
        }

        public void ResetTextBoxValue()
        {
            if (_textbox != null)
            {
                _textbox.Value = "";
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            var btn = sender as FlexButton;
            if (btn == null) return;

            if (_textbox==null)
            {
                if (_customDiscount==null)
                {
                    return;
                }
                if (btn == btn1 && (_customDiscount.TabIndex == 0 || _customDiscount.TabIndex*10+1 <= 100))
                {
                    _customDiscount.TabIndex = _customDiscount.TabIndex * 10 + 1;
                }
                if (btn == btn2 && (_customDiscount.TabIndex == 0 || _customDiscount.TabIndex * 10 + 2 <= 100))
                {
                    _customDiscount.TabIndex = _customDiscount.TabIndex * 10 + 2;
                }
                if (btn == btn3 && (_customDiscount.TabIndex == 0 || _customDiscount.TabIndex * 10 + 3 <= 100))
                {
                    _customDiscount.TabIndex = _customDiscount.TabIndex * 10 + 3;
                }
                if (btn == btn4 && (_customDiscount.TabIndex == 0 || _customDiscount.TabIndex * 10 + 4<= 100))
                {
                    _customDiscount.TabIndex = _customDiscount.TabIndex * 10 + 4;
                }
                if (btn == btn5 && (_customDiscount.TabIndex == 0 || _customDiscount.TabIndex * 10 + 5 <= 100))
                {
                    _customDiscount.TabIndex = _customDiscount.TabIndex * 10 + 5;
                }
                if (btn == btn6 && (_customDiscount.TabIndex == 0 || _customDiscount.TabIndex * 10 + 6 <= 100))
                {
                    _customDiscount.TabIndex = _customDiscount.TabIndex * 10 + 6;
                }
                if (btn == btn7 && (_customDiscount.TabIndex == 0 || _customDiscount.TabIndex * 10 + 7 <= 100))
                {
                    _customDiscount.TabIndex = _customDiscount.TabIndex * 10 + 7;
                }
                if (btn == btn8 && (_customDiscount.TabIndex == 0 || _customDiscount.TabIndex * 10 + 8 <= 100))
                {
                    _customDiscount.TabIndex = _customDiscount.TabIndex * 10 + 8;
                }
                if (btn == btn9 && (_customDiscount.TabIndex == 0 || _customDiscount.TabIndex * 10 + 9 <= 100))
                {
                    _customDiscount.TabIndex = _customDiscount.TabIndex * 10 + 9;
                }
                if (btn == btn0 && (_customDiscount.TabIndex == 0 || _customDiscount.TabIndex * 10 <= 100))
                {
                    _customDiscount.TabIndex = _customDiscount.TabIndex * 10;
                }
                if (btn == btn000 )
                {
                    return;
                }
                if (btn == btnDel)
                {
                    _customDiscount.TabIndex = _customDiscount.TabIndex / 10;
                }
                _customDiscount.DisplayText = string.Format("-{0:n0}%", _customDiscount.TabIndex);
                _customDiscount.Value = _customDiscount.TabIndex;
                //var OrderEditViewModel = CommunicateBridge.GetCurrentOrder();
                //order.DiscountRate = _customDiscount.TabIndex;
                //CommunicateBridge.UpdatePaymentInfo();
                _customDiscount.IsActive = _customDiscount.IsActive;
                return;
            }

            var textboxValue = 0;
            if (_textbox.Value != "")
            {
                textboxValue = int.Parse(_textbox.Value);
            }
            if (btn == btn1 && (textboxValue == 0 || (int.MaxValue - 1) / textboxValue > 10))
            {
                textboxValue = textboxValue * 10 + 1;
            }
            if (btn == btn2 && (textboxValue == 0 || (int.MaxValue - 2) / textboxValue > 10))
            {
                textboxValue = textboxValue * 10 + 2;
            }
            if (btn == btn3 && (textboxValue == 0 || (int.MaxValue - 3) / textboxValue > 10))
            {
                textboxValue = textboxValue * 10 + 3;
            }
            if (btn == btn4 && (textboxValue == 0 || (int.MaxValue - 5) / textboxValue > 10))
            {
                textboxValue = textboxValue * 10 + 4;
            }
            if (btn == btn5 && (textboxValue == 0 || (int.MaxValue - 5) / textboxValue > 10))
            {
                textboxValue = textboxValue * 10 + 5;
            }
            if (btn == btn6 && (textboxValue == 0 || (int.MaxValue - 6) / textboxValue > 10))
            {
                textboxValue = textboxValue * 10 + 6;
            }
            if (btn == btn7 && (textboxValue == 0 || (int.MaxValue - 7) / textboxValue > 10))
            {
                textboxValue = textboxValue * 10 + 7;
            }
            if (btn == btn8 && (textboxValue == 0 || (int.MaxValue - 8) / textboxValue > 10))
            {
                textboxValue = textboxValue * 10 + 8;
            }
            if (btn == btn9 && (textboxValue == 0 || (int.MaxValue - 9) / textboxValue > 10))
            {
                textboxValue = textboxValue * 10 + 9;
            }
            if (btn == btn0 && (textboxValue == 0 || int.MaxValue / textboxValue >= 10))
            {
                textboxValue = textboxValue * 10;
            }
            if (btn == btn000 && (textboxValue == 0 || int.MaxValue / textboxValue >= 1000))
            {
                textboxValue = textboxValue * 1000;
            }
            if (btn == btnDel)
            {
                textboxValue = textboxValue / 10;
            }

            if (sender is LoginFlatTextBox)
            {
                (sender as LoginFlatTextBox).Text = string.Format("{0:n0}", textboxValue);
                return;
            }

            _textbox.Value = string.Format("{0:####}", textboxValue);
            _textbox.TextValue = string.Format("{0:n0}", textboxValue);
        }

    }
}
