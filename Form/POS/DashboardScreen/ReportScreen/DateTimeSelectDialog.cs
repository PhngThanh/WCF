using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using POS.Common;
using POS.Utils;

namespace POS.DashboardScreen.ReportScreen
{
    public partial class DateTimeSelectDialog : Form
    {
        private NumPadDialog _numPadMonth;
        private NumPadDialog _numPadYear;

        private int _month;
        private int _year;

        public string SelectedDate { get; set; }

        public DateTimeSelectDialog()
        {
            InitializeComponent();
            calendar1.Date = UtcDateTime.Now();
            for (var i = 0; i < 59; i++)
            {
                var str = "0";
                if (i < 10)
                {
                    str += i;
                }
                else
                {
                    str = i.ToString();
                }
                if (i < 24)
                {
                    udHour.Values.Add(str);
                }
                udMinute.Values.Add(str);
                btnOK.Caption = MainForm.ResManager.GetString("Sys_OK",MainForm.CultureInfo);
            }

            udHour.Values = udHour.Values;
            udMinute.Values = udMinute.Values;

            //_numPadMonth = new NumPadDialog(txtMonth,CallOutPosition.MiddleLeft);
            //_numPadYear = new NumPadDialog(txtYear, CallOutPosition.MiddleLeft);
            //_numPadMonth.VisibleChanged += ValidateMonthYear;
            //_numPadYear.VisibleChanged += ValidateMonthYear;
            //_numPadMonth.NormalNumber = true;
            //_numPadYear.NormalNumber = true;

            //_month = UtcDateTime.Now().Month;
            //_year = UtcDateTime.Now().Year;
            //LoadData(_month, _year);
            //txtMonth.Text = _month.ToString();
            //txtMonth.TabIndex = _month;
            //txtYear.TabIndex = _year;
           // txtYear.Text = _year.ToString();

           // var today = dayContainer.Controls.OfType<DayRadioButton>().FirstOrDefault(c => c.Text == UtcDateTime.Now().Day.ToString());
           // if (today != null) today.Checked = true;
        }

        //void ValidateMonthYear(object sender, EventArgs e)
        //{
        //    var numpad = sender as NumPadDialog;
        //    if (numpad == null) return;

        //    if (numpad.Visible == false)
        //    {
        //        var month = -1;
        //        int.TryParse(txtMonth.Text, out month);
        //        if (month >= 1 && month <= 12)
        //        {
        //            var year = -1;
        //            int.TryParse(txtYear.Text, out year);
        //            if (year >= DateTime.MinValue.Year && year <= DateTime.MaxValue.Year)
        //            {
        //                LoadData(month, year);
        //                _month = month;
        //                _year = year;
        //            }
        //            else
        //            {
        //                txtYear.Text = _year.ToString();
        //            }
        //        }
        //        else
        //        {
        //            txtMonth.Text = _month.ToString();
        //        }
        //    }
        //}

        //private void LoadData(int month, int year)
        //{
        //    foreach (var result in dayContainer.Controls.OfType<DayRadioButton>())
        //    {
        //        result.Enabled = true;
        //    }
        //}

        private void DateSelectDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
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
            //var selected = dayContainer.Controls.OfType<DayRadioButton>().FirstOrDefault(c => c.Checked);
            //if (selected == null)
            //{
            //    using (var mbox = new MessageDialog("Please select a day!", "OK"))
            //    {
            //        mbox.ShowDialog();
            //    }
            //}
            //else
            //{
                SelectedDate = string.Format("{2}/{1}/{0} {3}:{4}:{5}", calendar1.Date.Day.ToString().PadLeft(2, '0'),
                    calendar1.Date.Month.ToString().PadLeft(2, '0'), calendar1.Date.Year, udHour.SelectedValue, udMinute.SelectedValue,"00");
                DialogResult = DialogResult.OK;
                Hide();
        
            //}
        }


    }

}
