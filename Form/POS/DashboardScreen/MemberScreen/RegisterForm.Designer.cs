using System.Windows.Forms;
using POS.CustomControl;

namespace POS.DashboardScreen.MemberScreen
{
    partial class RegisterForm : Form

    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.btnCancel = new POS.CustomControl.BootstrapButton();
            this.btnFinish = new POS.CustomControl.BootstrapButton();
            this.lblTitle = new POS.CustomControl.BootstrapButton();
            this.bsBtnMembershipCard = new POS.CustomControl.BootstrapButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bootstrapButton3 = new POS.CustomControl.BootstrapButton();
            this.btnSearchMember = new POS.CustomControl.BootstrapButton();
            this.ddlCardType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlMain = new POS.CustomControl.BootstrapPanel();
            this.rdbFemale = new System.Windows.Forms.RadioButton();
            this.rdbMale = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRefreshInfo = new POS.CustomControl.BootstrapButton();
            this.btnCreateCustomer = new POS.CustomControl.BootstrapButton();
            this.txtCardCode = new System.Windows.Forms.TextBox();
            this.phone = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtDistrict = new System.Windows.Forms.TextBox();
            this.txtCMND = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnSearchPhone = new POS.CustomControl.BootstrapButton();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.btnRefreshPhone = new POS.CustomControl.BootstrapButton();
            this.bootstrapButton6 = new POS.CustomControl.BootstrapButton();
            this.ddlType = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDefaultBalance = new System.Windows.Forms.Label();
            this.bootstrapButton7 = new POS.CustomControl.BootstrapButton();
            this.txtCardType = new System.Windows.Forms.Label();
            this.bsBtnCustomerPhone = new POS.CustomControl.BootstrapButton();
            this.bootstrapButton1 = new POS.CustomControl.BootstrapButton();
            this.ddlYear = new System.Windows.Forms.ComboBox();
            this.ddlMonth = new System.Windows.Forms.ComboBox();
            this.ddlDay = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnRefreshCode = new POS.CustomControl.BootstrapButton();
            this.bootstrapButton2 = new POS.CustomControl.BootstrapButton();
            this.errorCustomerName = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorTxtPhone = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider4 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider5 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorEmail = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorDateTime = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorIDCard = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider9 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorCardCode = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorPhone = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtCardStatus = new System.Windows.Forms.Label();
            this.btnAddNewCustomer = new POS.CustomControl.BootstrapButton();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFinish)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBtnMembershipCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bootstrapButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchMember)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefreshInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCreateCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefreshPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bootstrapButton6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bootstrapButton7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBtnCustomerPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bootstrapButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefreshCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bootstrapButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorCustomerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorTxtPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorDateTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorIDCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorCardCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddNewCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnCancel.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(51)))));
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(51)))));
            this.btnCancel.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Warning;
            this.btnCancel.BorderRadius = 0;
            this.btnCancel.BorderThick = 0;
            this.btnCancel.ButtonValue = "";
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageColor = System.Drawing.Color.White;
            this.btnCancel.ImageCss = "ban";
            this.btnCancel.ImageFontSize = 30F;
            this.btnCancel.ImageTextPadding = 0;
            this.btnCancel.IsActive = false;
            this.btnCancel.IsAutoScaleWidth = false;
            this.btnCancel.IsVerticalImageText = false;
            this.btnCancel.Location = new System.Drawing.Point(666, 496);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 51);
            this.btnCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnCancel.TabIndex = 3;
            this.btnCancel.TabStop = false;
            this.btnCancel.TextColor = System.Drawing.Color.White;
            this.btnCancel.TextFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.btnCancel.TextValue = "Hủy";
            this.btnCancel.ToggleGroup = 0;
            this.btnCancel.Type = POS.CustomControl.ButtonType.Click;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnFinish.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnFinish.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Primary;
            this.btnFinish.BorderRadius = 0;
            this.btnFinish.BorderThick = 0;
            this.btnFinish.ButtonValue = "";
            this.btnFinish.Image = ((System.Drawing.Image)(resources.GetObject("btnFinish.Image")));
            this.btnFinish.ImageColor = System.Drawing.Color.White;
            this.btnFinish.ImageCss = "check";
            this.btnFinish.ImageFontSize = 30F;
            this.btnFinish.ImageTextPadding = 0;
            this.btnFinish.IsActive = false;
            this.btnFinish.IsAutoScaleWidth = false;
            this.btnFinish.IsVerticalImageText = false;
            this.btnFinish.Location = new System.Drawing.Point(839, 496);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(136, 51);
            this.btnFinish.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnFinish.TabIndex = 4;
            this.btnFinish.TabStop = false;
            this.btnFinish.TextColor = System.Drawing.Color.White;
            this.btnFinish.TextFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.btnFinish.TextValue = "Hoàn tất";
            this.btnFinish.ToggleGroup = 0;
            this.btnFinish.Type = POS.CustomControl.ButtonType.Click;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.lblTitle.ActiveBackgroudColor = System.Drawing.Color.Empty;
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
            this.lblTitle.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.BackColor;
            this.lblTitle.BorderRadius = 0;
            this.lblTitle.BorderThick = 0;
            this.lblTitle.ButtonValue = "";
            this.lblTitle.Image = ((System.Drawing.Image)(resources.GetObject("lblTitle.Image")));
            this.lblTitle.ImageColor = System.Drawing.Color.White;
            this.lblTitle.ImageCss = "id-card-o";
            this.lblTitle.ImageFontSize = 25F;
            this.lblTitle.ImageTextPadding = 0;
            this.lblTitle.IsActive = false;
            this.lblTitle.IsAutoScaleWidth = false;
            this.lblTitle.IsVerticalImageText = false;
            this.lblTitle.Location = new System.Drawing.Point(1, 4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(284, 29);
            this.lblTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.lblTitle.TabIndex = 21;
            this.lblTitle.TabStop = false;
            this.lblTitle.TextColor = System.Drawing.Color.White;
            this.lblTitle.TextFont = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.TextValue = "Thông tin thẻ thành viên";
            this.lblTitle.ToggleGroup = 0;
            this.lblTitle.Type = POS.CustomControl.ButtonType.Click;
            // 
            // bsBtnMembershipCard
            // 
            this.bsBtnMembershipCard.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.bsBtnMembershipCard.ActiveBackgroudColor = System.Drawing.Color.Empty;
            this.bsBtnMembershipCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.bsBtnMembershipCard.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.bsBtnMembershipCard.BorderRadius = 0;
            this.bsBtnMembershipCard.BorderThick = 0;
            this.bsBtnMembershipCard.ButtonValue = "";
            this.bsBtnMembershipCard.Image = ((System.Drawing.Image)(resources.GetObject("bsBtnMembershipCard.Image")));
            this.bsBtnMembershipCard.ImageColor = System.Drawing.Color.Black;
            this.bsBtnMembershipCard.ImageCss = "credit-card";
            this.bsBtnMembershipCard.ImageFontSize = 25F;
            this.bsBtnMembershipCard.ImageTextPadding = 0;
            this.bsBtnMembershipCard.IsActive = false;
            this.bsBtnMembershipCard.IsAutoScaleWidth = false;
            this.bsBtnMembershipCard.IsVerticalImageText = false;
            this.bsBtnMembershipCard.Location = new System.Drawing.Point(7, 4);
            this.bsBtnMembershipCard.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.bsBtnMembershipCard.Name = "bsBtnMembershipCard";
            this.bsBtnMembershipCard.Size = new System.Drawing.Size(211, 25);
            this.bsBtnMembershipCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.bsBtnMembershipCard.TabIndex = 33;
            this.bsBtnMembershipCard.TabStop = false;
            this.bsBtnMembershipCard.TextColor = System.Drawing.Color.Black;
            this.bsBtnMembershipCard.TextFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.bsBtnMembershipCard.TextValue = "Mã thẻ thành viên";
            this.bsBtnMembershipCard.ToggleGroup = 0;
            this.bsBtnMembershipCard.Type = POS.CustomControl.ButtonType.Click;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(224, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(5, 415);
            this.panel2.TabIndex = 48;
            // 
            // bootstrapButton3
            // 
            this.bootstrapButton3.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.bootstrapButton3.ActiveBackgroudColor = System.Drawing.Color.Empty;
            this.bootstrapButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.bootstrapButton3.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.bootstrapButton3.BorderRadius = 0;
            this.bootstrapButton3.BorderThick = 0;
            this.bootstrapButton3.ButtonValue = "";
            this.bootstrapButton3.Image = ((System.Drawing.Image)(resources.GetObject("bootstrapButton3.Image")));
            this.bootstrapButton3.ImageColor = System.Drawing.Color.Black;
            this.bootstrapButton3.ImageCss = "user-circle";
            this.bootstrapButton3.ImageFontSize = 25F;
            this.bootstrapButton3.ImageTextPadding = 0;
            this.bootstrapButton3.IsActive = false;
            this.bootstrapButton3.IsAutoScaleWidth = false;
            this.bootstrapButton3.IsVerticalImageText = false;
            this.bootstrapButton3.Location = new System.Drawing.Point(236, 9);
            this.bootstrapButton3.Name = "bootstrapButton3";
            this.bootstrapButton3.Size = new System.Drawing.Size(255, 41);
            this.bootstrapButton3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.bootstrapButton3.TabIndex = 56;
            this.bootstrapButton3.TabStop = false;
            this.bootstrapButton3.TextColor = System.Drawing.Color.Black;
            this.bootstrapButton3.TextFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.bootstrapButton3.TextValue = "Thông tin khách hàng";
            this.bootstrapButton3.ToggleGroup = 0;
            this.bootstrapButton3.Type = POS.CustomControl.ButtonType.Click;
            // 
            // btnSearchMember
            // 
            this.btnSearchMember.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnSearchMember.ActiveBackgroudColor = System.Drawing.Color.Empty;
            this.btnSearchMember.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnSearchMember.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Primary;
            this.btnSearchMember.BorderRadius = 3;
            this.btnSearchMember.BorderThick = 3;
            this.btnSearchMember.ButtonValue = "";
            this.btnSearchMember.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchMember.Image")));
            this.btnSearchMember.ImageColor = System.Drawing.Color.White;
            this.btnSearchMember.ImageCss = "question";
            this.btnSearchMember.ImageFontSize = 12F;
            this.btnSearchMember.ImageTextPadding = 0;
            this.btnSearchMember.IsActive = false;
            this.btnSearchMember.IsAutoScaleWidth = false;
            this.btnSearchMember.IsVerticalImageText = true;
            this.btnSearchMember.Location = new System.Drawing.Point(119, 71);
            this.btnSearchMember.Name = "btnSearchMember";
            this.btnSearchMember.Size = new System.Drawing.Size(99, 34);
            this.btnSearchMember.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnSearchMember.TabIndex = 64;
            this.btnSearchMember.TabStop = false;
            this.btnSearchMember.TextColor = System.Drawing.Color.White;
            this.btnSearchMember.TextFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnSearchMember.TextValue = "Tìm kiếm";
            this.btnSearchMember.ToggleGroup = 0;
            this.btnSearchMember.Type = POS.CustomControl.ButtonType.Click;
            this.btnSearchMember.Click += new System.EventHandler(this.btnSearchMember_Click);
            // 
            // ddlCardType
            // 
            this.ddlCardType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(66)))), ((int)(((byte)(67)))));
            this.ddlCardType.DropDownHeight = 250;
            this.ddlCardType.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlCardType.ForeColor = System.Drawing.SystemColors.Info;
            this.ddlCardType.FormattingEnabled = true;
            this.ddlCardType.IntegralHeight = false;
            this.ddlCardType.ItemHeight = 21;
            this.ddlCardType.Location = new System.Drawing.Point(5, 139);
            this.ddlCardType.Name = "ddlCardType";
            this.ddlCardType.Size = new System.Drawing.Size(213, 29);
            this.ddlCardType.TabIndex = 96;
            this.ddlCardType.TextChanged += new System.EventHandler(this.ddlCardType_TextChanged);
            this.ddlCardType.Click += new System.EventHandler(this.ddlCardType_Click);
            this.ddlCardType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ddlCardType_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(235, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 23);
            this.label1.TabIndex = 97;
            this.label1.Text = "Họ tên:*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(235, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 23);
            this.label4.TabIndex = 100;
            this.label4.Text = "Địa chỉ:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(235, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 23);
            this.label5.TabIndex = 101;
            this.label5.Text = "Điện thoại:";
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.pnlMain.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.pnlMain.Controls.Add(this.rdbFemale);
            this.pnlMain.Controls.Add(this.rdbMale);
            this.pnlMain.Controls.Add(this.label2);
            this.pnlMain.Controls.Add(this.btnRefreshInfo);
            this.pnlMain.Controls.Add(this.btnCreateCustomer);
            this.pnlMain.Controls.Add(this.txtCardCode);
            this.pnlMain.Controls.Add(this.phone);
            this.pnlMain.Controls.Add(this.txtCity);
            this.pnlMain.Controls.Add(this.txtDistrict);
            this.pnlMain.Controls.Add(this.txtCMND);
            this.pnlMain.Controls.Add(this.txtEmail);
            this.pnlMain.Controls.Add(this.txtPhone);
            this.pnlMain.Controls.Add(this.txtAddress);
            this.pnlMain.Controls.Add(this.btnSearchPhone);
            this.pnlMain.Controls.Add(this.txtCustomerName);
            this.pnlMain.Controls.Add(this.btnRefreshPhone);
            this.pnlMain.Controls.Add(this.bootstrapButton6);
            this.pnlMain.Controls.Add(this.ddlType);
            this.pnlMain.Controls.Add(this.label11);
            this.pnlMain.Controls.Add(this.txtDefaultBalance);
            this.pnlMain.Controls.Add(this.bootstrapButton7);
            this.pnlMain.Controls.Add(this.txtCardType);
            this.pnlMain.Controls.Add(this.bsBtnCustomerPhone);
            this.pnlMain.Controls.Add(this.bootstrapButton1);
            this.pnlMain.Controls.Add(this.ddlYear);
            this.pnlMain.Controls.Add(this.ddlMonth);
            this.pnlMain.Controls.Add(this.ddlDay);
            this.pnlMain.Controls.Add(this.label6);
            this.pnlMain.Controls.Add(this.label7);
            this.pnlMain.Controls.Add(this.label8);
            this.pnlMain.Controls.Add(this.label9);
            this.pnlMain.Controls.Add(this.label10);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.ddlCardType);
            this.pnlMain.Controls.Add(this.btnSearchMember);
            this.pnlMain.Controls.Add(this.btnRefreshCode);
            this.pnlMain.Controls.Add(this.bootstrapButton3);
            this.pnlMain.Controls.Add(this.bootstrapButton2);
            this.pnlMain.Controls.Add(this.panel2);
            this.pnlMain.Controls.Add(this.bsBtnMembershipCard);
            this.pnlMain.Location = new System.Drawing.Point(0, 64);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1327, 426);
            this.pnlMain.TabIndex = 1;
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // rdbFemale
            // 
            this.rdbFemale.AutoSize = true;
            this.rdbFemale.Font = new System.Drawing.Font("Tahoma", 15F);
            this.rdbFemale.Location = new System.Drawing.Point(832, 234);
            this.rdbFemale.Name = "rdbFemale";
            this.rdbFemale.Size = new System.Drawing.Size(53, 28);
            this.rdbFemale.TabIndex = 137;
            this.rdbFemale.TabStop = true;
            this.rdbFemale.Text = "Nữ";
            this.rdbFemale.UseVisualStyleBackColor = true;
            // 
            // rdbMale
            // 
            this.rdbMale.AutoSize = true;
            this.rdbMale.Font = new System.Drawing.Font("Tahoma", 15F);
            this.rdbMale.ForeColor = System.Drawing.Color.Black;
            this.rdbMale.Location = new System.Drawing.Point(737, 234);
            this.rdbMale.Name = "rdbMale";
            this.rdbMale.Size = new System.Drawing.Size(69, 28);
            this.rdbMale.TabIndex = 136;
            this.rdbMale.TabStop = true;
            this.rdbMale.Text = "Nam";
            this.rdbMale.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(637, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 23);
            this.label2.TabIndex = 135;
            this.label2.Text = "Giới tính:";
            // 
            // btnRefreshInfo
            // 
            this.btnRefreshInfo.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnRefreshInfo.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(51)))));
            this.btnRefreshInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(51)))));
            this.btnRefreshInfo.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Warning;
            this.btnRefreshInfo.BorderRadius = 3;
            this.btnRefreshInfo.BorderThick = 3;
            this.btnRefreshInfo.ButtonValue = "";
            this.btnRefreshInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshInfo.Image")));
            this.btnRefreshInfo.ImageColor = System.Drawing.Color.White;
            this.btnRefreshInfo.ImageCss = "refresh";
            this.btnRefreshInfo.ImageFontSize = 30F;
            this.btnRefreshInfo.ImageTextPadding = 0;
            this.btnRefreshInfo.IsActive = false;
            this.btnRefreshInfo.IsAutoScaleWidth = false;
            this.btnRefreshInfo.IsVerticalImageText = false;
            this.btnRefreshInfo.Location = new System.Drawing.Point(335, 357);
            this.btnRefreshInfo.Name = "btnRefreshInfo";
            this.btnRefreshInfo.Size = new System.Drawing.Size(246, 51);
            this.btnRefreshInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnRefreshInfo.TabIndex = 22;
            this.btnRefreshInfo.TabStop = false;
            this.btnRefreshInfo.TextColor = System.Drawing.Color.White;
            this.btnRefreshInfo.TextFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.btnRefreshInfo.TextValue = "Làm mới";
            this.btnRefreshInfo.ToggleGroup = 0;
            this.btnRefreshInfo.Type = POS.CustomControl.ButtonType.Click;
            this.btnRefreshInfo.Click += new System.EventHandler(this.btnRefreshInfo_Click);
            // 
            // btnCreateCustomer
            // 
            this.btnCreateCustomer.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Success;
            this.btnCreateCustomer.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnCreateCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnCreateCustomer.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Primary;
            this.btnCreateCustomer.BorderRadius = 3;
            this.btnCreateCustomer.BorderThick = 3;
            this.btnCreateCustomer.ButtonValue = "";
            this.btnCreateCustomer.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateCustomer.Image")));
            this.btnCreateCustomer.ImageColor = System.Drawing.Color.White;
            this.btnCreateCustomer.ImageCss = "check";
            this.btnCreateCustomer.ImageFontSize = 30F;
            this.btnCreateCustomer.ImageTextPadding = 0;
            this.btnCreateCustomer.IsActive = false;
            this.btnCreateCustomer.IsAutoScaleWidth = false;
            this.btnCreateCustomer.IsVerticalImageText = false;
            this.btnCreateCustomer.Location = new System.Drawing.Point(729, 357);
            this.btnCreateCustomer.Name = "btnCreateCustomer";
            this.btnCreateCustomer.Size = new System.Drawing.Size(245, 51);
            this.btnCreateCustomer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnCreateCustomer.TabIndex = 23;
            this.btnCreateCustomer.TabStop = false;
            this.btnCreateCustomer.TextColor = System.Drawing.Color.White;
            this.btnCreateCustomer.TextFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.btnCreateCustomer.TextValue = "Tạo khách hàng";
            this.btnCreateCustomer.ToggleGroup = 0;
            this.btnCreateCustomer.Type = POS.CustomControl.ButtonType.Click;
            this.btnCreateCustomer.Click += new System.EventHandler(this.btnCreateCustomer_Click);
            // 
            // txtCardCode
            // 
            this.txtCardCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(66)))), ((int)(((byte)(67)))));
            this.txtCardCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtCardCode.ForeColor = System.Drawing.SystemColors.Info;
            this.txtCardCode.Location = new System.Drawing.Point(7, 35);
            this.txtCardCode.Name = "txtCardCode";
            this.txtCardCode.Size = new System.Drawing.Size(209, 29);
            this.txtCardCode.TabIndex = 134;
            this.txtCardCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCardCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCardCode_KeyDown);
            // 
            // phone
            // 
            this.phone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(66)))), ((int)(((byte)(67)))));
            this.phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.phone.ForeColor = System.Drawing.SystemColors.Info;
            this.phone.Location = new System.Drawing.Point(5, 348);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(211, 29);
            this.phone.TabIndex = 133;
            this.phone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.phone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.phone_KeyDown);
            // 
            // txtCity
            // 
            this.txtCity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(66)))), ((int)(((byte)(67)))));
            this.txtCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtCity.ForeColor = System.Drawing.SystemColors.Info;
            this.txtCity.Location = new System.Drawing.Point(729, 307);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(245, 29);
            this.txtCity.TabIndex = 132;
            this.txtCity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDistrict
            // 
            this.txtDistrict.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(66)))), ((int)(((byte)(67)))));
            this.txtDistrict.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtDistrict.ForeColor = System.Drawing.SystemColors.Info;
            this.txtDistrict.Location = new System.Drawing.Point(341, 304);
            this.txtDistrict.Name = "txtDistrict";
            this.txtDistrict.Size = new System.Drawing.Size(245, 29);
            this.txtDistrict.TabIndex = 131;
            this.txtDistrict.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCMND
            // 
            this.txtCMND.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(66)))), ((int)(((byte)(67)))));
            this.txtCMND.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtCMND.ForeColor = System.Drawing.SystemColors.Info;
            this.txtCMND.Location = new System.Drawing.Point(729, 107);
            this.txtCMND.Name = "txtCMND";
            this.txtCMND.Size = new System.Drawing.Size(245, 29);
            this.txtCMND.TabIndex = 130;
            this.txtCMND.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCMND.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCMND_KeyDown);
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(66)))), ((int)(((byte)(67)))));
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtEmail.ForeColor = System.Drawing.SystemColors.Info;
            this.txtEmail.Location = new System.Drawing.Point(729, 52);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(245, 29);
            this.txtEmail.TabIndex = 129;
            this.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(66)))), ((int)(((byte)(67)))));
            this.txtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtPhone.ForeColor = System.Drawing.SystemColors.Info;
            this.txtPhone.Location = new System.Drawing.Point(335, 113);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(245, 29);
            this.txtPhone.TabIndex = 128;
            this.txtPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPhone_KeyDown);
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(66)))), ((int)(((byte)(67)))));
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtAddress.ForeColor = System.Drawing.SystemColors.Info;
            this.txtAddress.Location = new System.Drawing.Point(335, 239);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(245, 29);
            this.txtAddress.TabIndex = 127;
            this.txtAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSearchPhone
            // 
            this.btnSearchPhone.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnSearchPhone.ActiveBackgroudColor = System.Drawing.Color.Empty;
            this.btnSearchPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(133)))), ((int)(((byte)(244)))));
            this.btnSearchPhone.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Primary;
            this.btnSearchPhone.BorderRadius = 3;
            this.btnSearchPhone.BorderThick = 3;
            this.btnSearchPhone.ButtonValue = "";
            this.btnSearchPhone.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchPhone.Image")));
            this.btnSearchPhone.ImageColor = System.Drawing.Color.White;
            this.btnSearchPhone.ImageCss = "question";
            this.btnSearchPhone.ImageFontSize = 12F;
            this.btnSearchPhone.ImageTextPadding = 0;
            this.btnSearchPhone.IsActive = false;
            this.btnSearchPhone.IsAutoScaleWidth = false;
            this.btnSearchPhone.IsVerticalImageText = true;
            this.btnSearchPhone.Location = new System.Drawing.Point(117, 383);
            this.btnSearchPhone.Name = "btnSearchPhone";
            this.btnSearchPhone.Size = new System.Drawing.Size(99, 34);
            this.btnSearchPhone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnSearchPhone.TabIndex = 117;
            this.btnSearchPhone.TabStop = false;
            this.btnSearchPhone.TextColor = System.Drawing.Color.White;
            this.btnSearchPhone.TextFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnSearchPhone.TextValue = "Tìm kiếm";
            this.btnSearchPhone.ToggleGroup = 0;
            this.btnSearchPhone.Type = POS.CustomControl.ButtonType.Click;
            this.btnSearchPhone.Click += new System.EventHandler(this.btnSearchPhone_Click);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(66)))), ((int)(((byte)(67)))));
            this.txtCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtCustomerName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtCustomerName.Location = new System.Drawing.Point(335, 57);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(245, 29);
            this.txtCustomerName.TabIndex = 126;
            this.txtCustomerName.Tag = "";
            this.txtCustomerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnRefreshPhone
            // 
            this.btnRefreshPhone.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnRefreshPhone.ActiveBackgroudColor = System.Drawing.Color.Empty;
            this.btnRefreshPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(51)))));
            this.btnRefreshPhone.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Warning;
            this.btnRefreshPhone.BorderRadius = 3;
            this.btnRefreshPhone.BorderThick = 3;
            this.btnRefreshPhone.ButtonValue = "";
            this.btnRefreshPhone.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshPhone.Image")));
            this.btnRefreshPhone.ImageColor = System.Drawing.Color.White;
            this.btnRefreshPhone.ImageCss = "refresh";
            this.btnRefreshPhone.ImageFontSize = 12F;
            this.btnRefreshPhone.ImageTextPadding = 0;
            this.btnRefreshPhone.IsActive = false;
            this.btnRefreshPhone.IsAutoScaleWidth = false;
            this.btnRefreshPhone.IsVerticalImageText = true;
            this.btnRefreshPhone.Location = new System.Drawing.Point(5, 383);
            this.btnRefreshPhone.Name = "btnRefreshPhone";
            this.btnRefreshPhone.Size = new System.Drawing.Size(100, 34);
            this.btnRefreshPhone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnRefreshPhone.TabIndex = 116;
            this.btnRefreshPhone.TabStop = false;
            this.btnRefreshPhone.TextColor = System.Drawing.Color.White;
            this.btnRefreshPhone.TextFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefreshPhone.TextValue = "Làm mới";
            this.btnRefreshPhone.ToggleGroup = 0;
            this.btnRefreshPhone.Type = POS.CustomControl.ButtonType.Click;
            this.btnRefreshPhone.Click += new System.EventHandler(this.bootstrapButton5_Click);
            // 
            // bootstrapButton6
            // 
            this.bootstrapButton6.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.bootstrapButton6.ActiveBackgroudColor = System.Drawing.Color.Empty;
            this.bootstrapButton6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.bootstrapButton6.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.bootstrapButton6.BorderRadius = 0;
            this.bootstrapButton6.BorderThick = 0;
            this.bootstrapButton6.ButtonValue = "";
            this.bootstrapButton6.Image = ((System.Drawing.Image)(resources.GetObject("bootstrapButton6.Image")));
            this.bootstrapButton6.ImageColor = System.Drawing.Color.Black;
            this.bootstrapButton6.ImageCss = "phone";
            this.bootstrapButton6.ImageFontSize = 25F;
            this.bootstrapButton6.ImageTextPadding = 0;
            this.bootstrapButton6.IsActive = false;
            this.bootstrapButton6.IsAutoScaleWidth = false;
            this.bootstrapButton6.IsVerticalImageText = false;
            this.bootstrapButton6.Location = new System.Drawing.Point(7, 316);
            this.bootstrapButton6.Name = "bootstrapButton6";
            this.bootstrapButton6.Size = new System.Drawing.Size(135, 25);
            this.bootstrapButton6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.bootstrapButton6.TabIndex = 120;
            this.bootstrapButton6.TabStop = false;
            this.bootstrapButton6.TextColor = System.Drawing.Color.Black;
            this.bootstrapButton6.TextFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.bootstrapButton6.TextValue = "Điện thoại";
            this.bootstrapButton6.ToggleGroup = 0;
            this.bootstrapButton6.Type = POS.CustomControl.ButtonType.Click;
            // 
            // ddlType
            // 
            this.ddlType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(66)))), ((int)(((byte)(67)))));
            this.ddlType.DropDownHeight = 250;
            this.ddlType.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlType.ForeColor = System.Drawing.SystemColors.Info;
            this.ddlType.FormattingEnabled = true;
            this.ddlType.IntegralHeight = false;
            this.ddlType.Location = new System.Drawing.Point(335, 174);
            this.ddlType.Name = "ddlType";
            this.ddlType.Size = new System.Drawing.Size(246, 29);
            this.ddlType.TabIndex = 125;
            this.ddlType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ddlType_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(235, 177);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 23);
            this.label11.TabIndex = 124;
            this.label11.Text = "Loại:";
            // 
            // txtDefaultBalance
            // 
            this.txtDefaultBalance.AutoSize = true;
            this.txtDefaultBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDefaultBalance.Location = new System.Drawing.Point(12, 285);
            this.txtDefaultBalance.Name = "txtDefaultBalance";
            this.txtDefaultBalance.Size = new System.Drawing.Size(130, 22);
            this.txtDefaultBalance.TabIndex = 122;
            this.txtDefaultBalance.Text = "012345678910";
            // 
            // bootstrapButton7
            // 
            this.bootstrapButton7.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.bootstrapButton7.ActiveBackgroudColor = System.Drawing.Color.Empty;
            this.bootstrapButton7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.bootstrapButton7.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.bootstrapButton7.BorderRadius = 0;
            this.bootstrapButton7.BorderThick = 0;
            this.bootstrapButton7.ButtonValue = "";
            this.bootstrapButton7.Image = ((System.Drawing.Image)(resources.GetObject("bootstrapButton7.Image")));
            this.bootstrapButton7.ImageColor = System.Drawing.Color.Black;
            this.bootstrapButton7.ImageCss = "money";
            this.bootstrapButton7.ImageFontSize = 25F;
            this.bootstrapButton7.ImageTextPadding = 0;
            this.bootstrapButton7.IsActive = false;
            this.bootstrapButton7.IsAutoScaleWidth = false;
            this.bootstrapButton7.IsVerticalImageText = false;
            this.bootstrapButton7.Location = new System.Drawing.Point(3, 249);
            this.bootstrapButton7.Name = "bootstrapButton7";
            this.bootstrapButton7.Size = new System.Drawing.Size(183, 25);
            this.bootstrapButton7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.bootstrapButton7.TabIndex = 121;
            this.bootstrapButton7.TabStop = false;
            this.bootstrapButton7.TextColor = System.Drawing.Color.Black;
            this.bootstrapButton7.TextFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.bootstrapButton7.TextValue = "Số dư ban đầu";
            this.bootstrapButton7.ToggleGroup = 0;
            this.bootstrapButton7.Type = POS.CustomControl.ButtonType.Click;
            // 
            // txtCardType
            // 
            this.txtCardType.AutoSize = true;
            this.txtCardType.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardType.Location = new System.Drawing.Point(6, 216);
            this.txtCardType.Name = "txtCardType";
            this.txtCardType.Size = new System.Drawing.Size(130, 22);
            this.txtCardType.TabIndex = 119;
            this.txtCardType.Text = "012345678910";
            // 
            // bsBtnCustomerPhone
            // 
            this.bsBtnCustomerPhone.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.bsBtnCustomerPhone.ActiveBackgroudColor = System.Drawing.Color.Empty;
            this.bsBtnCustomerPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.bsBtnCustomerPhone.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.bsBtnCustomerPhone.BorderRadius = 0;
            this.bsBtnCustomerPhone.BorderThick = 0;
            this.bsBtnCustomerPhone.ButtonValue = "";
            this.bsBtnCustomerPhone.Image = ((System.Drawing.Image)(resources.GetObject("bsBtnCustomerPhone.Image")));
            this.bsBtnCustomerPhone.ImageColor = System.Drawing.Color.Black;
            this.bsBtnCustomerPhone.ImageCss = "credit-card";
            this.bsBtnCustomerPhone.ImageFontSize = 25F;
            this.bsBtnCustomerPhone.ImageTextPadding = 0;
            this.bsBtnCustomerPhone.IsActive = false;
            this.bsBtnCustomerPhone.IsAutoScaleWidth = false;
            this.bsBtnCustomerPhone.IsVerticalImageText = false;
            this.bsBtnCustomerPhone.Location = new System.Drawing.Point(-1, 180);
            this.bsBtnCustomerPhone.Name = "bsBtnCustomerPhone";
            this.bsBtnCustomerPhone.Size = new System.Drawing.Size(135, 25);
            this.bsBtnCustomerPhone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.bsBtnCustomerPhone.TabIndex = 118;
            this.bsBtnCustomerPhone.TabStop = false;
            this.bsBtnCustomerPhone.TextColor = System.Drawing.Color.Black;
            this.bsBtnCustomerPhone.TextFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.bsBtnCustomerPhone.TextValue = "Loại thẻ";
            this.bsBtnCustomerPhone.ToggleGroup = 0;
            this.bsBtnCustomerPhone.Type = POS.CustomControl.ButtonType.Click;
            // 
            // bootstrapButton1
            // 
            this.bootstrapButton1.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.bootstrapButton1.ActiveBackgroudColor = System.Drawing.Color.Empty;
            this.bootstrapButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(51)))));
            this.bootstrapButton1.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Warning;
            this.bootstrapButton1.BorderRadius = 3;
            this.bootstrapButton1.BorderThick = 3;
            this.bootstrapButton1.ButtonValue = "";
            this.bootstrapButton1.Image = ((System.Drawing.Image)(resources.GetObject("bootstrapButton1.Image")));
            this.bootstrapButton1.ImageColor = System.Drawing.Color.White;
            this.bootstrapButton1.ImageCss = "refresh";
            this.bootstrapButton1.ImageFontSize = 12F;
            this.bootstrapButton1.ImageTextPadding = 0;
            this.bootstrapButton1.IsActive = false;
            this.bootstrapButton1.IsAutoScaleWidth = false;
            this.bootstrapButton1.IsVerticalImageText = true;
            this.bootstrapButton1.Location = new System.Drawing.Point(1143, 7);
            this.bootstrapButton1.Name = "bootstrapButton1";
            this.bootstrapButton1.Size = new System.Drawing.Size(100, 34);
            this.bootstrapButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.bootstrapButton1.TabIndex = 113;
            this.bootstrapButton1.TabStop = false;
            this.bootstrapButton1.TextColor = System.Drawing.Color.White;
            this.bootstrapButton1.TextFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.bootstrapButton1.TextValue = "Làm mới";
            this.bootstrapButton1.ToggleGroup = 0;
            this.bootstrapButton1.Type = POS.CustomControl.ButtonType.Click;
            this.bootstrapButton1.Click += new System.EventHandler(this.bootstrapButton1_Click_1);
            // 
            // ddlYear
            // 
            this.ddlYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(66)))), ((int)(((byte)(67)))));
            this.ddlYear.DropDownHeight = 250;
            this.ddlYear.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlYear.ForeColor = System.Drawing.SystemColors.Info;
            this.ddlYear.FormattingEnabled = true;
            this.ddlYear.IntegralHeight = false;
            this.ddlYear.Location = new System.Drawing.Point(881, 173);
            this.ddlYear.MaxLength = 100;
            this.ddlYear.Name = "ddlYear";
            this.ddlYear.Size = new System.Drawing.Size(94, 29);
            this.ddlYear.TabIndex = 112;
            this.ddlYear.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ddlYear_KeyDown);
            // 
            // ddlMonth
            // 
            this.ddlMonth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(66)))), ((int)(((byte)(67)))));
            this.ddlMonth.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlMonth.ForeColor = System.Drawing.SystemColors.Info;
            this.ddlMonth.FormattingEnabled = true;
            this.ddlMonth.Location = new System.Drawing.Point(807, 173);
            this.ddlMonth.MaxLength = 100;
            this.ddlMonth.Name = "ddlMonth";
            this.ddlMonth.Size = new System.Drawing.Size(72, 29);
            this.ddlMonth.TabIndex = 111;
            this.ddlMonth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ddlMonth_KeyDown);
            // 
            // ddlDay
            // 
            this.ddlDay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(66)))), ((int)(((byte)(67)))));
            this.ddlDay.DropDownHeight = 250;
            this.ddlDay.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlDay.ForeColor = System.Drawing.SystemColors.Info;
            this.ddlDay.FormattingEnabled = true;
            this.ddlDay.IntegralHeight = false;
            this.ddlDay.ItemHeight = 21;
            this.ddlDay.Location = new System.Drawing.Point(729, 173);
            this.ddlDay.MaxDropDownItems = 10;
            this.ddlDay.MaxLength = 100;
            this.ddlDay.Name = "ddlDay";
            this.ddlDay.Size = new System.Drawing.Size(76, 29);
            this.ddlDay.TabIndex = 110;
            this.ddlDay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ddlDay_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(623, 313);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 23);
            this.label6.TabIndex = 106;
            this.label6.Text = "Thành phố:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(235, 310);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 23);
            this.label7.TabIndex = 105;
            this.label7.Text = "Quận:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(623, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 104;
            this.label8.Text = "Ngày sinh:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(623, 113);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 23);
            this.label9.TabIndex = 103;
            this.label9.Text = "CMND:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(623, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 23);
            this.label10.TabIndex = 102;
            this.label10.Text = "Email:";
            // 
            // btnRefreshCode
            // 
            this.btnRefreshCode.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.btnRefreshCode.ActiveBackgroudColor = System.Drawing.Color.Empty;
            this.btnRefreshCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(187)))), ((int)(((byte)(51)))));
            this.btnRefreshCode.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Warning;
            this.btnRefreshCode.BorderRadius = 3;
            this.btnRefreshCode.BorderThick = 3;
            this.btnRefreshCode.ButtonValue = "";
            this.btnRefreshCode.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshCode.Image")));
            this.btnRefreshCode.ImageColor = System.Drawing.Color.White;
            this.btnRefreshCode.ImageCss = "refresh";
            this.btnRefreshCode.ImageFontSize = 12F;
            this.btnRefreshCode.ImageTextPadding = 0;
            this.btnRefreshCode.IsActive = false;
            this.btnRefreshCode.IsAutoScaleWidth = false;
            this.btnRefreshCode.IsVerticalImageText = true;
            this.btnRefreshCode.Location = new System.Drawing.Point(7, 71);
            this.btnRefreshCode.Name = "btnRefreshCode";
            this.btnRefreshCode.Size = new System.Drawing.Size(100, 34);
            this.btnRefreshCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnRefreshCode.TabIndex = 63;
            this.btnRefreshCode.TabStop = false;
            this.btnRefreshCode.TextColor = System.Drawing.Color.White;
            this.btnRefreshCode.TextFont = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefreshCode.TextValue = "Làm mới";
            this.btnRefreshCode.ToggleGroup = 0;
            this.btnRefreshCode.Type = POS.CustomControl.ButtonType.Click;
            this.btnRefreshCode.Click += new System.EventHandler(this.btnRefreshCode_Click);
            // 
            // bootstrapButton2
            // 
            this.bootstrapButton2.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Default;
            this.bootstrapButton2.ActiveBackgroudColor = System.Drawing.Color.Empty;
            this.bootstrapButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(206)))), ((int)(((byte)(56)))));
            this.bootstrapButton2.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.MainColor;
            this.bootstrapButton2.BorderRadius = 0;
            this.bootstrapButton2.BorderThick = 0;
            this.bootstrapButton2.ButtonValue = "";
            this.bootstrapButton2.Image = ((System.Drawing.Image)(resources.GetObject("bootstrapButton2.Image")));
            this.bootstrapButton2.ImageColor = System.Drawing.Color.Black;
            this.bootstrapButton2.ImageCss = "credit-card";
            this.bootstrapButton2.ImageFontSize = 25F;
            this.bootstrapButton2.ImageTextPadding = 0;
            this.bootstrapButton2.IsActive = false;
            this.bootstrapButton2.IsAutoScaleWidth = false;
            this.bootstrapButton2.IsVerticalImageText = false;
            this.bootstrapButton2.Location = new System.Drawing.Point(-16, 111);
            this.bootstrapButton2.Name = "bootstrapButton2";
            this.bootstrapButton2.Size = new System.Drawing.Size(166, 25);
            this.bootstrapButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.bootstrapButton2.TabIndex = 54;
            this.bootstrapButton2.TabStop = false;
            this.bootstrapButton2.TextColor = System.Drawing.Color.Black;
            this.bootstrapButton2.TextFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.bootstrapButton2.TextValue = "Mẫu thẻ";
            this.bootstrapButton2.ToggleGroup = 0;
            this.bootstrapButton2.Type = POS.CustomControl.ButtonType.Click;
            // 
            // errorCustomerName
            // 
            this.errorCustomerName.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // errorTxtPhone
            // 
            this.errorTxtPhone.ContainerControl = this;
            // 
            // errorProvider4
            // 
            this.errorProvider4.ContainerControl = this;
            // 
            // errorProvider5
            // 
            this.errorProvider5.ContainerControl = this;
            // 
            // errorEmail
            // 
            this.errorEmail.ContainerControl = this;
            // 
            // errorDateTime
            // 
            this.errorDateTime.ContainerControl = this;
            // 
            // errorIDCard
            // 
            this.errorIDCard.ContainerControl = this;
            // 
            // errorProvider9
            // 
            this.errorProvider9.ContainerControl = this;
            // 
            // errorCardCode
            // 
            this.errorCardCode.ContainerControl = this;
            // 
            // errorPhone
            // 
            this.errorPhone.ContainerControl = this;
            // 
            // txtCardStatus
            // 
            this.txtCardStatus.AutoSize = true;
            this.txtCardStatus.BackColor = System.Drawing.Color.DimGray;
            this.txtCardStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardStatus.ForeColor = System.Drawing.Color.Cornsilk;
            this.txtCardStatus.Location = new System.Drawing.Point(340, 18);
            this.txtCardStatus.Name = "txtCardStatus";
            this.txtCardStatus.Size = new System.Drawing.Size(173, 29);
            this.txtCardStatus.TabIndex = 55;
            this.txtCardStatus.Text = "Thẻ tạm dừng";
            // 
            // btnAddNewCustomer
            // 
            this.btnAddNewCustomer.ActiveBackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Success;
            this.btnAddNewCustomer.ActiveBackgroudColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnAddNewCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNewCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(81)))));
            this.btnAddNewCustomer.BackgroudBootstrapColor = POS.CustomControl.BootstrapColorEnum.Success;
            this.btnAddNewCustomer.BorderRadius = 0;
            this.btnAddNewCustomer.BorderThick = 0;
            this.btnAddNewCustomer.ButtonValue = "";
            this.btnAddNewCustomer.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewCustomer.Image")));
            this.btnAddNewCustomer.ImageColor = System.Drawing.Color.White;
            this.btnAddNewCustomer.ImageCss = "user-plus";
            this.btnAddNewCustomer.ImageFontSize = 30F;
            this.btnAddNewCustomer.ImageTextPadding = 0;
            this.btnAddNewCustomer.IsActive = false;
            this.btnAddNewCustomer.IsAutoScaleWidth = false;
            this.btnAddNewCustomer.IsVerticalImageText = false;
            this.btnAddNewCustomer.Location = new System.Drawing.Point(7, 496);
            this.btnAddNewCustomer.Name = "btnAddNewCustomer";
            this.btnAddNewCustomer.Size = new System.Drawing.Size(248, 51);
            this.btnAddNewCustomer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnAddNewCustomer.TabIndex = 135;
            this.btnAddNewCustomer.TabStop = false;
            this.btnAddNewCustomer.TextColor = System.Drawing.Color.White;
            this.btnAddNewCustomer.TextFont = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.btnAddNewCustomer.TextValue = "Thêm khách hàng mới";
            this.btnAddNewCustomer.ToggleGroup = 0;
            this.btnAddNewCustomer.Type = POS.CustomControl.ButtonType.Click;
            this.btnAddNewCustomer.Click += new System.EventHandler(this.btnAddNewCustomer_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1008, 563);
            this.Controls.Add(this.btnAddNewCustomer);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtCardStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SettingScreen";
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFinish)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBtnMembershipCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bootstrapButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchMember)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefreshInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCreateCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefreshPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bootstrapButton6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bootstrapButton7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBtnCustomerPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bootstrapButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefreshCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bootstrapButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorCustomerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorTxtPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorDateTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorIDCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorCardCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddNewCustomer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CustomControl.BootstrapButton btnCancel;
        private CustomControl.BootstrapButton btnFinish;
        private CustomControl.BootstrapButton lblTitle;
        private BootstrapButton bsBtnMembershipCard;
        private Panel panel2;
        private BootstrapButton bootstrapButton3;
        private BootstrapButton btnSearchMember;
        private ComboBox ddlCardType;
        private Label label1;
        private Label label4;
        private Label label5;
        private BootstrapPanel pnlMain;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private ErrorProvider errorCustomerName;
        private ErrorProvider errorProvider2;
        private ErrorProvider errorTxtPhone;
        private ErrorProvider errorProvider4;
        private ErrorProvider errorProvider5;
        private ErrorProvider errorEmail;
        private ComboBox ddlYear;
        private ComboBox ddlMonth;
        private ComboBox ddlDay;
        private ErrorProvider errorDateTime;
        private ErrorProvider errorIDCard;
        private ErrorProvider errorProvider9;
        private BootstrapButton bootstrapButton1;
        private BootstrapButton btnRefreshPhone;
        private Label txtDefaultBalance;
        private BootstrapButton bootstrapButton7;
        private BootstrapButton bootstrapButton6;
        private Label txtCardType;
        private BootstrapButton bsBtnCustomerPhone;
        private BootstrapButton btnRefreshInfo;
        private Label label11;
        private ComboBox ddlType;
        private TextBox txtCustomerName;
        private TextBox txtCity;
        private TextBox txtDistrict;
        private TextBox txtCMND;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private TextBox txtAddress;
        private BootstrapButton btnCreateCustomer;
        private BootstrapButton btnSearchPhone;
        private BootstrapButton btnRefreshCode;
        private ErrorProvider errorCardCode;
        private ErrorProvider errorPhone;
        private TextBox txtCardCode;
        private TextBox phone;
        private Label txtCardStatus;
        private BootstrapButton bootstrapButton2;
        private BootstrapButton btnAddNewCustomer;
        private RadioButton rdbFemale;
        private RadioButton rdbMale;
        private Label label2;
    }
}