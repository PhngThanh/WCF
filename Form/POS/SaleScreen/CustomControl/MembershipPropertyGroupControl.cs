using System.Drawing;
using System.Windows.Forms;

using POS.Common;
using POS.SaleScreen.Data;
using POS.Data;

namespace POS.SaleScreen.CustomControl
{
    public class MembershipPropertyGroupControl : Panel
    {
        private readonly int[] _position = { 60, 114, 168, 222, 276 };
        public MembershipPropertyGroupControl()
        {
            InitControl();
        }

        private void InitControl()
        {

            Width = 210;
            Height = DrawControlLibrary.PropertiesPanel.Height - DrawControlLibrary.PropertiesPanel.PaddingBottom -
                     DrawControlLibrary.PropertiesPanel.PaddingTop;
            BackColor = Color.Transparent;
            Text = @"MEMBERSHIP";
            var count = 0;

            _lblCardNum.Text = @"Card Number";
            _lblCardNum.Top = _position[0];
            _lblCardNum.Left = 15;

            //if (CommunicateBridge.UseCsvForCustomerCard())
            //{
                count++;
                _lblCsvNum.Text = @"CSV Number";
                _lblCsvNum.Top = _position[count];
                _lblCsvNum.Left = 15;
                _txtCsvNum.Left = 15;
                _txtCsvNum.Top = _lblCsvNum.Top + 15;
                _txtCsvNum.Width = Width - 30;
                _txtCsvNum.BackgroundColor = Constant.Brown;
                _txtCsvNum.BorderColor = Constant.Brown;
                _txtCsvNum.TextColor = Constant.White;
                _txtCsvNum.ShowClearButton = false;
                _txtCsvNum.Font = new Font(DrawControlLibrary.PrivateFontCollection.Families[0], 10, FontStyle.Bold);
                Controls.Add(_txtCsvNum);
                Controls.Add(_lblCsvNum);
            //}
            count++;
            _lblMobile.Text = @"Mobile";
            _lblMobile.Top = _position[count];
            _lblMobile.Left = 15;

            count++;
            _lblName.Text = @"Name";
            _lblName.Top = _position[count];
            _lblName.Left = 15;

            count++;
            _lblTotalPoint.Text = @"Point";
            _lblTotalPoint.Top = _position[count];
            _lblTotalPoint.Left = 15;

            count++;
            _lblBalance.Text = @"Balance";
            _lblBalance.Top = _position[4];
            _lblBalance.Left = 15;


            _txtCardNum.Left = 15;
            _txtCardNum.Top = _lblCardNum.Top + 15;
            _txtCardNum.Width = Width - 30;
            _txtCardNum.BackgroundColor = Constant.Brown;
            _txtCardNum.BorderColor = Constant.Brown;
            _txtCardNum.TextColor = Constant.White;
            _txtCardNum.ShowClearButton = true;
            _txtCardNum.Font = new Font(DrawControlLibrary.PrivateFontCollection.Families[0], 10, FontStyle.Bold);
            Controls.Add(_txtCardNum);
            Controls.Add(_lblCardNum);

            _txtMobile.Left = 15;
            _txtMobile.Top = _lblMobile.Top + 15;
            _txtMobile.Width = Width - 30;
            _txtMobile.BackgroundColor = Constant.Green;
            _txtMobile.BorderColor = Constant.Brown;
            _txtMobile.TextColor = Constant.Brown;
            _txtMobile.ShowClearButton = false;
            _txtMobile.Font = new Font(DrawControlLibrary.PrivateFontCollection.Families[0], 10, FontStyle.Regular);
            Controls.Add(_txtMobile);
            Controls.Add(_lblMobile);

            _txtName.Left = 15;
            _txtName.Top = _lblName.Top + 15;
            _txtName.Width = Width - 30;
            _txtName.BackgroundColor = Constant.Green;
            _txtName.BorderColor = Constant.Brown;
            _txtName.TextColor = Constant.Brown;
            _txtName.ShowClearButton = false;
            _txtName.Font = new Font(DrawControlLibrary.PrivateFontCollection.Families[0], 10, FontStyle.Regular);
            Controls.Add(_txtName);
            Controls.Add(_lblName);

            _txtTotalPoint.Left = 15;
            _txtTotalPoint.Top = _lblTotalPoint.Top + 15;
            _txtTotalPoint.Width = Width - 30;
            _txtTotalPoint.BackgroundColor = Constant.Green;
            _txtTotalPoint.BorderColor = Constant.Brown;
            _txtTotalPoint.TextColor = Constant.Brown;
            _txtTotalPoint.ShowClearButton = false;
            _txtTotalPoint.Font = new Font(DrawControlLibrary.PrivateFontCollection.Families[0], 10, FontStyle.Regular);
            Controls.Add(_txtTotalPoint);
            Controls.Add(_lblTotalPoint);

            _txtBalance.Left = 15;
            _txtBalance.Top = _lblBalance.Top + 15;
            _txtBalance.Width = Width - 30;
            _txtBalance.BackgroundColor = Constant.Green;
            _txtBalance.BorderColor = Constant.Brown;
            _txtBalance.TextColor = Constant.Brown;
            _txtBalance.ShowClearButton = false;
            _txtBalance.Font = new Font(DrawControlLibrary.PrivateFontCollection.Families[0], 10, FontStyle.Regular);
            Controls.Add(_txtBalance);
            Controls.Add(_lblBalance);

            _btnUseBalance = new PropertyControl
            {
                ButtonType = ButtonType.Click,
                Name = "Use balance",
                DisplayText = ">",
                TextSize = 18,
            
                Left = 15,
                Top = _txtBalance.Top + _txtBalance.Height + 10
            };
            _btnUseBalance.MouseClick += btnUseBalance_MouseClick;
            Controls.Add(_btnUseBalance);
        }

        private void btnUseBalance_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private readonly Label _lblCardNum = new Label();
        private readonly Label _lblTotalPoint = new Label();
        private readonly Label _lblCsvNum = new Label();
        private readonly Label _lblMobile = new Label();
        private readonly Label _lblName = new Label();
        private readonly Label _lblBalance = new Label();
        private readonly FlatTextBox _txtTotalPoint = new FlatTextBox();
        private readonly FlatTextBox _txtCardNum = new FlatTextBox();
        private readonly FlatTextBox _txtCsvNum = new FlatTextBox();
        private readonly FlatTextBox _txtMobile = new FlatTextBox();
        private readonly FlatTextBox _txtName = new FlatTextBox();
        private readonly FlatTextBox _txtBalance = new FlatTextBox();
        private PropertyControl _btnUseBalance;
        public Membership Membership { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawControlLibrary.PropertiesPanel.DrawGroupProperties(this, e);
        }

        public void LoadMembershipInfo()
        {
            //Membership = CommunicateBridge.GetMembership(_txtCardNum.Text, _txtCsvNum.Text);
            //var order = CommunicateBridge.GetCurrentOrder();
            if (Membership != null)
            {
                _txtMobile.Text = Membership.Phone;
                _txtName.Text = Membership.MembershipName;
                _txtTotalPoint.Text = Membership.Balance.ToString("n0");
                _txtBalance.Text =
                    (Membership.Balance).ToString("n0");
                //order.MembershipInfo = Membership;
            }
            else
            {
                using (var msg = new MessageDialog("Can not load membership infomation", "OK"))
                {
                    msg.ShowDialog();
                }
            }
        }
    }
}
