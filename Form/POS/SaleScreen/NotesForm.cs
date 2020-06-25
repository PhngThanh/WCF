using System;
using System.Collections.Generic;
using System.Windows.Forms;
using POS.Common;
using POS.CustomControl;
using POS.Repository.ViewModels;

namespace POS.SaleScreen
{

    public partial class NotesForm : Form
    {
        private OrderDetailEditViewModel _mainOrderDetail;

        public NotesForm(OrderDetailEditViewModel od)
        {
            InitializeComponent();
            _mainOrderDetail = od;

            this.BackColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
            btnSave.NormalColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
            btnCancel.NormalColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);

            if (MainForm.PosConfig.EnableOnscreenKeyboard.Trim().ToLower() == "true")
            {
                OnScreenKeyboardDialog.Instance.AddTextbox(txtNotes);
            }

            txtNotes.Text = _mainOrderDetail.Notes ?? "";
            this.lblFormName.Text = MainForm.ResManager.GetString("Sys_Note_Title", MainForm.CultureInfo);
            this.btnCancel.Text= MainForm.ResManager.GetString("Sys_Cancel", MainForm.CultureInfo);
            this.btnSave.Text = MainForm.ResManager.GetString("Sys_Save", MainForm.CultureInfo);
        }

        public void ResetTextbox(bool resetInOrder = false)
        {
            txtNotes.Text = "";
            UpdateNotes();
        }

        public void HideFrom()
        {
            this.TopMost = false;
            this.Hide();
        }

        /*
        protected override void OnDeactivate(EventArgs e)
        {
            Hide();
        }
        */

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Left = Screen.PrimaryScreen.Bounds.Width - 370 - this.Width - 5;
            this.Top = Screen.PrimaryScreen.Bounds.Height / 2 - this.Height/2 - 20;
            this.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.UpdateNotes();
            HideFrom();

            SaleScreen3.ShowOrderDetailForm(new List<OrderDetailEditViewModel> { _mainOrderDetail});
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetTextbox();
            HideFrom();

            SaleScreen3.ShowOrderDetailForm(new List<OrderDetailEditViewModel> { _mainOrderDetail });
        }

        /// <summary>
        /// Save Notes to CurrentOrderManager.OrderEditViewModel
        /// </summary>+
        private void UpdateNotes()
        {
            _mainOrderDetail.Notes = txtNotes.Text;
            Program.context.getCurrentOrderManager().UpdateNoteOfOrderDetail(_mainOrderDetail, _mainOrderDetail.Notes);
        }
    }
}
