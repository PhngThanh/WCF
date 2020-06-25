using System;
using System.Drawing;
using System.Windows.Forms;
using POS.Repository;
using POS.Repository.ViewModels;

namespace POS.TableScreen
{
    public delegate void SelectOrderTypeEventHandler(OrderTypeEnum type, TableViewModel table);

    public partial class ServeTypeDialog : Form
    {
        private TableViewModel _table;
        public ServeTypeDialog(TableViewModel table)
        {
            InitializeComponent();
            GenerateLayout();

            RenderMode();
            
            StartPosition = FormStartPosition.CenterScreen;
            _table = table;
        }

        private void GenerateLayout()
        {
            label3.Text = MainForm.ResManager.GetString("Sys_Delivery", MainForm.CultureInfo);
            label2.Text = MainForm.ResManager.GetString("Sys_Take_Away", MainForm.CultureInfo);
            label1.Text = MainForm.ResManager.GetString("Sys_At_Store", MainForm.CultureInfo);
        }

        private void RenderMode()
        {
            bool isHaveDelivery = Convert.ToBoolean(MainForm.PosConfig.HasDelivery);
            bool isHaveAtStore = Convert.ToBoolean(MainForm.PosConfig.HasAtStore);
            bool isHaveTakeAway = Convert.ToBoolean(MainForm.PosConfig.HasTakeAway);

            //Duy -  Hide modes
            if (!isHaveDelivery)
            {
                // Hide Delivery mode
                flexButton3.Hide();
                label3.Hide();

                // Change location of Take Away mode
                flexButton2.Location = new Point(152, 66);
                label2.Location = new Point(152, 207);

                // Change location of At Store mode
                flexButton1.Location = new Point(326, 66);
                label1.Location = new Point(326, 207);
            }
            if (!isHaveTakeAway)
            {
                // Hide Take Away mode
                flexButton2.Hide();
                label2.Hide();

                // Change location of Delivery mode
                flexButton3.Location = new Point(152, 66);
                label3.Location = new Point(152, 207);

                // Change location of At Store mode
                flexButton1.Location = new Point(326, 66);
                label1.Location = new Point(326, 207);
            }
            if (!isHaveAtStore)
            {
                // Hide At Store mode
                flexButton1.Hide();
                label1.Hide();

                // Change location of Delivery mode
                flexButton3.Location = new Point(152, 66);
                label3.Location = new Point(152, 207);

                // Change location of Take Away mode
                flexButton2.Location = new Point(326, 66);
                label2.Location = new Point(326, 207);
            }
        }

        public event SelectOrderTypeEventHandler OrderTypeSelected;

        protected virtual void OnOrderTypeSelected(OrderTypeEnum type)
        {
            if (OrderTypeSelected != null)
                OrderTypeSelected(type, _table);
        }


        //Nhấn nút Delivery
        private void flexButton3_Click(object sender, EventArgs e)
        {
            Close();
            OnOrderTypeSelected(OrderTypeEnum.Delivery);
        }

        private void ServeTypeDialog_Deactivate(object sender, EventArgs e)
        {
            Close();
        }

        private void flexButton2_Click(object sender, EventArgs e)
        {
            Close();
            OnOrderTypeSelected(OrderTypeEnum.TakeAway);
        }

        private void flexButton1_Click(object sender, EventArgs e)
        {
            Close();
            OnOrderTypeSelected(OrderTypeEnum.AtStore);
        }

        private void flexButton2_Load(object sender, EventArgs e)
        {

        }
    }
}
