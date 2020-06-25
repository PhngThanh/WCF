using System;
using System.Windows.Forms;

namespace POS
{
    public partial class FunctionPanel : UserControl
    {
        public FunctionPanel()
        {
            InitializeComponent();
          //  GenerateLayout();
        }

        private void GenerateLayout()
        {
            btnHide.Caption = MainForm.ResManager.GetString("Sys_Hide", MainForm.CultureInfo);
            btnMainFunction.Caption = MainForm.ResManager.GetString("Sys_FunctionPanel_Main_Function", MainForm.CultureInfo);
        }

        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            Program.MainForm.LoadDashboard();
        }
       
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Program.MainForm.LoadOnlineOrderScreen();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            Program.MainForm.HideMainForm();
        }

        //public void SetOnlineOrderNumber(int num)
        //{
        //    if (num > 0)
        //    {
        //        lblNumber.Visible = true;
        //        lblNumber.Text = num.ToString();
        //        pictureBox1.Image = Properties.Resources.delivery_brown;

        //        Program.MainForm.PlayNotiSound();
        //    }
        //    else
        //    {
        //        lblNumber.Visible = false;
        //        lblNumber.Text = "";
        //        pictureBox1.Image = Properties.Resources.delivery;

        //        Program.MainForm.StopNotiSound();
        //    }

        //}

        private void btnMainFunction_Load(object sender, EventArgs e)
        {

        }
    }


}
