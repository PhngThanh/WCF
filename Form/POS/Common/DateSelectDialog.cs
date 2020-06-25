using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using POS.Repository;
using POS.Utils;

namespace POS.Common
{
    public partial class DateSelectDialog : Form
    {
        private NumPadDialog _numPadMonth;
        private NumPadDialog _numPadYear;

        private int _month;
        private int _year;

        public DateTime SelectedDate { get; set; }

        public DateSelectDialog(DateTime SelectedDate)
        {
            InitializeComponent();

            _numPadMonth = new NumPadDialog(txtMonth, CallOutPositionEnum.MiddleLeft);
            _numPadYear = new NumPadDialog(txtYear, CallOutPositionEnum.MiddleLeft);
            _numPadMonth.NormalNumber = true;
            _numPadYear.NormalNumber = true;
            _numPadMonth.VisibleChanged += ValidateMonthYear;
            _numPadYear.VisibleChanged += ValidateMonthYear;

            _month = SelectedDate.Month;
            _year = SelectedDate.Year;
            LoadData();
            txtMonth.Text = _month.ToString();
            txtYear.Text = _year.ToString();
            btnOK.Caption = MainForm.ResManager.GetString("Sys_OK",MainForm.CultureInfo);
            var today = dayContainer.Controls.OfType<DayRadioButton>().FirstOrDefault(c => c.Text == SelectedDate.Day.ToString());
            if (today != null) today.Checked = true;
        }

        void ValidateMonthYear(object sender, EventArgs e)
        {
            var numpad = sender as NumPadDialog;
            if (numpad == null) return;

            if (numpad.Visible == false)
            {
                int month;
                int.TryParse(txtMonth.Text, out month);
                if (month >= 1 && month <= 12)
                {
                    int year;
                    int.TryParse(txtYear.Text, out year);
                    if (year >= DateTime.MinValue.Year && year <= DateTime.MaxValue.Year)
                    {
                        LoadData();
                        _month = month;
                        _year = year;
                    }
                    else
                    {
                        txtYear.Text = _year.ToString();
                    }
                }
                else
                {
                    txtMonth.Text = _month.ToString();
                }
            }
        }

        private void LoadData()
        {
            foreach (var result in dayContainer.Controls.OfType<DayRadioButton>())
            {
                result.Enabled = true;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen pen = new Pen(Color.FromArgb(124, 124, 124), 5))
            {
                pen.Alignment = PenAlignment.Inset;
                e.Graphics.DrawRectangle(pen, ClientRectangle);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Hide();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var selected = dayContainer.Controls.OfType<DayRadioButton>().FirstOrDefault(c => c.Checked);
            if (selected == null)
            {
                using (var mbox = new MessageDialog("Please select a day!", MainForm.ResManager.GetString("Sys_OK", MainForm.CultureInfo)))
                {
                    mbox.ShowDialog();
                }
            }
            else
            {
                SelectedDate = new DateTime(_year, _month, int.Parse(selected.Text)); 
                DialogResult = DialogResult.OK;
                Hide();
            }
        }


    }

    public class DayRadioButton : RadioButton
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            if (!Enabled)
            {
                pevent.Graphics.FillRectangle(new SolidBrush(Parent.BackColor), ClientRectangle);
                var format = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                pevent.Graphics.DrawString(Text, Font, Brushes.OliveDrab, ClientRectangle, format);
            }
            else
            {
                base.OnPaint(pevent);
            }
        }
    }
}
