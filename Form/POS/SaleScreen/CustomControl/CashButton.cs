using System;
using System.Drawing;
using System.Windows.Forms;

namespace POS.SaleScreen.CustomControl
{
    public class CashButton : Control
    {
        private int _quantity;

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                HasValue = value > 0;
                Invalidate();
            }
        }

        private int _value;

        public int Value
        {
            get { return _value; }
            set
            {
                _value = value;
                btnDisplayPrice.Invalidate();
            }
        }

        private bool _hasValue;

        public bool HasValue
        {
            get { return _hasValue; }
            set
            {
                _hasValue = value;
                if (value)
                {
                    btnDisplayPrice.Left = 6;
                    btnDisplayPrice.Top = 6;
                    btnDisplayPrice.Width = 77;
                    btnDisplayPrice.Height = 77;
                }
                else
                {
                    btnDisplayPrice.Left = 0;
                    btnDisplayPrice.Top = 1;
                    btnDisplayPrice.Width = 87;
                    btnDisplayPrice.Height = 86;
                }
                Invalidate();
                btnDisplayPrice.Invalidate();
            }
        }

        private bool _isDowning;

        public bool IsDowning
        {
            get { return _isDowning; }
            set
            {
                _isDowning = value;
                Invalidate();
            }
        }


        private readonly Control btnDisplayPrice;
        private readonly Timer _timer;
        private bool _inscrease;

        public CashButton()
        {
            btnDisplayPrice = new Label();
            Control btnMinus = new Label();
            _timer = new Timer();

            btnDisplayPrice.Paint += btnDisplayPrice_Paint;
            btnDisplayPrice.MouseDown += btnDisplayPrice_MouseDown;
            btnDisplayPrice.MouseUp += btnDisplayPrice_MouseUp;
            btnDisplayPrice.Visible = true;
            btnDisplayPrice.BackColor = Color.Transparent;
            btnDisplayPrice.Left = 6;
            btnDisplayPrice.Top = 6;
            btnDisplayPrice.Width = 77;
            btnDisplayPrice.Tag = false;
            btnDisplayPrice.Height = 77;

            btnMinus.Paint += btnMinus_Paint;
            btnMinus.MouseDown += btnMinus_MouseDown;
            btnMinus.MouseUp += btnMinus_MouseUp;
            btnMinus.Tag = false;
            btnMinus.Top = 44;
            btnMinus.Left = 0;
            btnMinus.AutoSize = false;
            btnMinus.Width = 130;
            btnMinus.Height = 44;
            btnMinus.BackColor = Color.Transparent;

            _timer.Tick += timer_Tick;
            _timer.Interval = 500;

            HasValue = true;
            Controls.Add(btnDisplayPrice);
            Controls.Add(btnMinus);
            MaximumSize = new Size(132, 90);
            MinimumSize = new Size(132, 90);
            Margin = new Padding(26, 10, 26, 10);
        }

        public event Action<CashButton, int> QuantityChanged;

        private void StopTimer()
        {
            _timer.Stop();
            _timer.Interval = 500;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (_inscrease)
            {
                Quantity = _quantity + 1;
                ChangeQuantity();
            }
            else if (!_inscrease && Quantity > 0)
            {
                Quantity = _quantity - 1;
                ChangeQuantity();
            }
            _timer.Interval = 100;
        }

        private void ChangeQuantity()
        {
            if (QuantityChanged != null)
            {
                QuantityChanged(this, _inscrease ? 1 : -1);
            }
        }

        private void btnDisplayPrice_MouseUp(object sender, MouseEventArgs e)
        {
            btnDisplayPrice.Tag = false;
            if (_timer.Interval == 500)
            {
                Quantity = _quantity + 1;
                ChangeQuantity();
            }
            StopTimer();
            ////CommunicateBridge.PlayClickSound();
            btnDisplayPrice.Invalidate();
        }

        private void btnDisplayPrice_MouseDown(object sender, MouseEventArgs e)
        {
            btnDisplayPrice.Tag = true;
            btnDisplayPrice.Invalidate();
            _inscrease = true;
            _timer.Start();
        }

        private void btnMinus_MouseUp(object sender, MouseEventArgs e)
        {
            if (_timer.Interval == 500 && Quantity > 0)
            {
                Quantity = _quantity - 1;
                ChangeQuantity();
            }
            StopTimer();
            IsDowning = false;
           // //CommunicateBridge.PlayClickSound();
        }

        private void btnMinus_MouseDown(object sender, MouseEventArgs e)
        {
            IsDowning = true;
            _inscrease = false;
            _timer.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
//            DrawControlLibrary.CashButtonDraw.DrawButton(this, e, _isDowning);
        }

        private void btnMinus_Paint(object sender, PaintEventArgs e)
        {
//            DrawControlLibrary.CashButtonDraw.DrawMinute(e, false);
        }

        private void btnDisplayPrice_Paint(object sender, PaintEventArgs e)
        {
//            DrawControlLibrary.CashButtonDraw.DrawValue(e, string.Format("{0:N0}", _value), _hasValue, (bool)btnDisplayPrice.Tag);
        }
    }

    public class GrowButton : Control
    {
        public Color BorderColor { get; set; }
        public float BorderSize { get; set; }
        public string StringValue { get; set; }
        public Color BackgroundColor { get; set; }

        public GrowButton()
        {
            AutoSize = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
//            DrawControlLibrary.GrowButtonDraw.DrawButton(this, e);
        }
    }
}
