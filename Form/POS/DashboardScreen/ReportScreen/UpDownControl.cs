using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace POS.DashboardScreen.ReportScreen
{
    public partial class UpDownControl : Control
    {
        public UpDownControl()
        {
            InitializeComponent();
            Width = 130;
            Height = 35;
            lblDown.Click += lblDown_Click;
            lblText.Click += lblDown_Click;
            lblUp.Click += lblDown_Click;

            lblUp.MouseDown += lblUp_MouseDown;
            lblUp.MouseUp += lblUp_MouseUp;
            lblDown.MouseDown += lblUp_MouseDown;
            lblDown.MouseUp += lblUp_MouseUp;

            CurrentValue = 0;
            _values = new List<string>();
            BackColor = Color.Black;
            timer = new Timer
            {
                Interval = 500
            };
            timer.Tick += timer_Tick;
        }

        private void lblUp_MouseUp(object sender, MouseEventArgs e)
        {
            if (timer.Interval == 500)
            {
            }
            StopTimer();
        }

        private void lblUp_MouseDown(object sender, MouseEventArgs e)
        {
            _inscrease = (sender == lblUp);
            timer.Start();
        }

        private void StopTimer()
        {
            timer.Stop();
            timer.Interval = 500;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (_inscrease)
            {
                lblDown_Click(lblUp,null);
                //SoundEngine.ClickSound.Play();
            }
            else
            {
                lblDown_Click(lblDown, null);
                //SoundEngine.ClickSound.Play();
            }
            timer.Interval = 100;
        }

        private bool _inscrease;
        private readonly Timer timer;

        private void lblDown_Click(object sender, EventArgs e)
        {
            if (sender == lblDown)
            {
                CurrentValue = (CurrentValue - 1) % Values.Count;
            }
            else
            {
                CurrentValue = (CurrentValue + 1) % Values.Count;
            }
            CurrentValue = CurrentValue < 0 ? Values.Count + CurrentValue : CurrentValue;
            lblText.Text = Values[CurrentValue];
        }

        public string SelectedValue
        {
            get { return Values.Count == 0 ? "" : Values[CurrentValue]; }
        }

        public override string Text
        {
            get { return lblText.Text; }
        }

        public override Font Font
        {
            get { return lblText.Font; }
            set { lblText.Font = value; }
        }

        public override Color ForeColor
        {
            get { return lblText.ForeColor; }
            set { lblText.ForeColor = value; }
        }

        private List<string> _values;

        public int CurrentValue { get; private set; }

        public List<string> Values
        {
            get
            {
                return _values;
            }
            set
            {
                _values = value;
                if (_values != null && _values.Any())
                {
                    lblText.Text = _values[0];
                    CurrentValue = 0;
                }
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Height = 30;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
