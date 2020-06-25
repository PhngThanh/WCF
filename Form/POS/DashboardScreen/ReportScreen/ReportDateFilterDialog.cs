using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using log4net;
using POS.Common;
using POS.Utils;
using POS.Repository.Entities.Repositories;
using POS.Repository.Entities.Services;
using StoreReportModel = POS.Repository.ViewModels.StoreReportModel;

namespace POS.DashboardScreen.ReportScreen
{
    public partial class ReportDateFilterDialog : Form
    {
        private DateTime _fromDate;
        private DateTime _toDate;
        private Form _staffSelectForm;
        private readonly HashSet<int> _selectedSessions;
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public ReportDateFilterDialog()
        {
            InitializeComponent();
            GenerateLayout();

            _fromDate = DateTime.Today;
            _toDate = UtcDateTime.Now();

            txtFromDate.Text = _fromDate.ToString("dd/MM/yyyy 00:00");
            txtToDate.Text = _toDate.ToString("dd/MM/yyyy HH:mm");
            txtStaff.Text = MainForm.ResManager.GetString("ReportDateFilterDialog_All_Staff", MainForm.CultureInfo);
            txtStaff.Tag = false;

            _selectedSessions = new HashSet<int>();


            InitStaffDialog();
        }

        private void GenerateLayout()
        {
            label1.Text = MainForm.ResManager.GetString("ReportDateFilterDialog_From_Date", MainForm.CultureInfo);
            label2.Text = MainForm.ResManager.GetString("ReportDateFilterDialog_To_Date", MainForm.CultureInfo);
            label3.Text = MainForm.ResManager.GetString("ReportDateFilterDialog_Staff", MainForm.CultureInfo);
            btnViewReport.Caption = MainForm.ResManager.GetString("ReportDateFilterDialog_View", MainForm.CultureInfo);
            btnClose.Caption = MainForm.ResManager.GetString("Sys_Close", MainForm.CultureInfo);
        }

        private void InitStaffDialog()
        {
            AccountService accountService = ServiceManager.GetService<AccountService>(typeof(AccountRepository));
            var accounts = accountService.Get().ToList();

            _staffSelectForm = new Form
            {
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.Manual
            };
            var pnlStaffContainer = new FlowLayoutPanel
            {
                Width = 450,
                Height = (txtStaff.Height + 2 + 6) * (accounts.Count / 2 + 1),
                BackColor = txtStaff.BorderColor
            };
            var allStaff = new Label
            {
                Text = MainForm.ResManager.GetString("ReportDateFilterDialog_All_Staff", MainForm.CultureInfo),
                Width = 438 / 2,
                Height = txtStaff.Height + 2,
                BackColor = Color.DodgerBlue,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Tahoma", 15, FontStyle.Bold),
                Tag = false,
                Margin = new Padding(3)
            };
            allStaff.Click += staffControl_Click;
            pnlStaffContainer.Controls.Add(allStaff);
            foreach (var account in accounts)
            {
                var staffControl = new Label
                {
                    Text = account.AccountId,
                    Width = 438 / 2,
                    Height = txtStaff.Height + 2,
                    BackColor = Color.DodgerBlue,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Tahoma", 15, FontStyle.Bold),
                    Tag = true,
                    Margin = new Padding(3)
                };
                staffControl.Click += staffControl_Click;
                pnlStaffContainer.Controls.Add(staffControl);
            }
            _staffSelectForm.Size = pnlStaffContainer.Size;
            pnlStaffContainer.Dock = DockStyle.Fill;
            _staffSelectForm.Controls.Add(pnlStaffContainer);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            try
            {
                //message:Đang thống kê...
                var text = MainForm.ResManager.GetString(
                            "ReportDateFilterDialog_Generate_Report_Waiting",
                            MainForm.CultureInfo);
                Program.MainForm.ShowSplashForm(text);

                if (_fromDate == DateTime.MinValue
                    || _toDate == DateTime.MinValue
                    || txtFromDate.Text == ""
                    || txtToDate.Text == "")
                {
                    Program.MainForm.HideSplashForm();
                    //message:Xin chọn ngày!!!
                    PosMessageDialog.ShowMessage(
                        MainForm.ResManager.GetString("ReportDateFilterDialog_Please_Enter_Date", MainForm.CultureInfo));
                    return;
                }

                if (_fromDate > _toDate)
                {
                    Program.MainForm.HideSplashForm();
                    //message:Ngày bắt đầu không thể nhỏ hơn ngày kết thúc
                    PosMessageDialog.ShowMessage(
                        MainForm.ResManager.GetString("ReportDateFilterDialog_Form_Date_Greater_To_Date", MainForm.CultureInfo));
                    return;
                }

                // Preparing data 
                var reportService = new ReportService();
                var username = txtStaff.Text;
                var storeReport = new StoreReportModel();
                storeReport = reportService.GenerateStoreReport(_fromDate, _toDate, username);

                // Get print image.
                Program.MainForm.HideSplashForm();

                // Showing.
                using (var rpDialog = new SessionReportDialog(storeReport))
                {
                    rpDialog.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                log.Error("btnViewReport_Click - " + ex);

                Program.MainForm.HideSplashForm();
                //message:Vui lòng thử lại sau!
                var msg = new MessageDialog(
                    MainForm.ResManager.GetString("Sys_Generate_Report_Failed",
                    MainForm.CultureInfo),
                    MainForm.ResManager.GetString("Sys_OK", MainForm.CultureInfo));
                msg.ShowDialog();
            }
        }


        private void txtFromDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtToDate_Click(object sender, EventArgs e)
        {
            //SoundEngine.ClickSound.Play();

            using (var mbox = new DateTimeSelectDialog())
            {
                mbox.ShowDialog();
                if (!string.IsNullOrEmpty(mbox.SelectedDate))
                {
                    try
                    {
                        _toDate = DateTime.Parse(mbox.SelectedDate);
                        txtToDate.Text = _toDate.ToString("dd/MM/yyyy HH:mm");
                    }
                    catch
                    {
                        //message:Ngày không hợp lệ, xin chọn lại!!!
                        PosMessageDialog.ShowMessage(
                           MainForm.ResManager.GetString("ReportDateFilterDialog_Invalid_Date", MainForm.CultureInfo));
                        //txtFromDate.Text = _fromDate.ToString("dd/MM/yyyy HH:mm");
                        _toDate = DateTime.MinValue;
                    }
                    //var res = DateTime.TryParseExact(mbox.SelectedDate, "dd/MM/yyyy HH:mm", null,
                    //    DateTimeStyles.None, out _toDate);
                    //if (res)
                    //{
                    //    txtToDate.Text = _toDate.ToString("dd/MM/yyyy HH:mm");
                    //}
                    //else
                    //{
                    //    //message:Ngày không hợp lệ, xin chọn lại!!!
                    //    PosMessageDialog.ShowMessage(
                    //        MainForm.ResManager.GetString("ReportDateFilterDialog_Invalid_Date", MainForm.CultureInfo));
                    //    _toDate = DateTime.MinValue;
                    //}
                }
            }
        }

        private void txtToDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtFromDate_Click(object sender, EventArgs e)
        {
            //SoundEngine.ClickSound.Play();

            using (var mbox = new DateTimeSelectDialog())
            {
                mbox.ShowDialog();
                if (!string.IsNullOrEmpty(mbox.SelectedDate))
                {
                    try
                    {
                        _fromDate = DateTime.Parse(mbox.SelectedDate);
                        txtFromDate.Text = _fromDate.ToString("dd/MM/yyyy HH:mm");
                    }
                    catch
                    {
                        //message:Ngày không hợp lệ, xin chọn lại!!!
                        PosMessageDialog.ShowMessage(
                           MainForm.ResManager.GetString("ReportDateFilterDialog_Invalid_Date", MainForm.CultureInfo));
                        //txtFromDate.Text = _fromDate.ToString("dd/MM/yyyy HH:mm");
                        _fromDate = DateTime.MinValue;
                    }
                }
            }
        }

        private void txtStaff_Click(object sender, EventArgs e)
        {
            _staffSelectForm.Top = Top + txtStaff.Top;
            _staffSelectForm.Left = Left + txtStaff.Left;
            _staffSelectForm.ShowDialog();
        }

        private void staffControl_Click(object sender, EventArgs e)
        {
            var staffControl = (Label)sender;
            _staffSelectForm.Hide();
            txtStaff.Text = staffControl.Text;
            txtStaff.Tag = staffControl.Tag;
            btnViewReport.Focus();
        }

        private void btnViewReport_Load(object sender, EventArgs e)
        {

        }
    }
}
