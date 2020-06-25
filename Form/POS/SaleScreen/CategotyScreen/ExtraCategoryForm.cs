using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using POS.SaleScreen.CustomControl;
using log4net;
using POS.Repository.ViewModels;
using POS.Properties;
using POS.Utils;

namespace POS.SaleScreen
{
    public partial class ExtraCategoryForm : Form
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Panel _topPanel = new Panel();

        public OrderDetailEditViewModel ParentOrderDetail;

        //CategoryService categoryService;
        List<CategoryViewModel> _categories;

        public ExtraCategoryForm(OrderDetailEditViewModel orderDetail)
        {
            ParentOrderDetail = orderDetail;

            //Load extra categories
            //categoryService = ServiceManager.GetService<CategoryService>(typeof(CategoryRepository));
            //categories = categoryService.GetCategories().Where..
            _categories = Program.context.getAvailableCategories().Where(a => a.IsExtra == 1).OrderBy(b => b.DisplayOrder).ToList();

            InitializeComponent();
            GenerateLayout();


        }

        private void GenerateLayout()
        {
            try
            {
                pnlMainContainer.BackColor = Constant.CategoryGray;
                pnlBottomPanel.BackColor = Constant.Gray2;
                pnlTopPanel.BackColor = Constant.Gray2;

                lblFinish.Text = MainForm.ResManager.GetString("Sys_Finish", MainForm.CultureInfo);
                lblFinish.Paint += DrawControlLibrary.PropertiesPanel.DrawControlButtonR;
                lblFinish.Click += lblFinish_Click;

                pnlBottomPanel.Controls.Add(lblFinish);

                _topPanel.Width = 720;
                _topPanel.Paint += (sender, args) => DrawControlLibrary.CategoryPanel.DrawPanelGray(args, Width);

                pnlTopPanel.Controls.Add(_topPanel);


                // Long TN
                // Tạm thời chỉ giải quyết 6 - 7 extra, 
                // nhiều hơn cần làm thêm menu 
                //for (int i = 0; i < 7 && i < categories.Count; i++)
                //for (int i = 0; i <  categories.Count; i++)
                //{
                //    var cate = categories.ElementAt(i);

                //    var item = new CategoryItemControl(Resources.tall14, Resources.tall14_2, cate.Code, cate.Name);
                //   // item.Click += categoryItem_Click;
                //    _topPanel.Controls.Add(item);
                //}

                var attItem = new CategoryItemControl(Resources.tall14, Resources.tall14_2, 0, "Att");
                attItem.Click += ShowGeneralInfo;
                _topPanel.Controls.Add(attItem);

                //CreateProductsPanel();
            }
            catch (Exception ex)
            {
                log.Error("GenerateLayout - " + ex);
            }
        }


        private void ShowGeneralInfo(object sender, EventArgs e)
        {
            var generalPanel = new OrderDetailPropetyPanel();

            pnlMainContainer.Controls.Clear();
            foreach (Control c in this.pnlMainContainer.Controls)
            {
                c.Dispose();
            }

            generalPanel.Dock = DockStyle.Fill;

            pnlMainContainer.Controls.Add(generalPanel);
        }

        //int column = 5;
        //int row = 4;

        //private static int maxProductPage = 1;
        //private static int currentProductPage = 1;
        //private static int currentCategoryId = -1;


        private void HideForm()
        {
            this.Hide();
        }

        private void lblFinish_Click(object sender, EventArgs e)
        {
            HideForm();
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            HideForm();
        }

        protected override void OnShown(EventArgs e)
        {
            try
            {
                base.OnShown(e);

                ResetPanel();

                this.Left = Screen.PrimaryScreen.Bounds.Width - 290 - this.Width - 5;
                this.Top = Screen.PrimaryScreen.Bounds.Height / 2 - this.Height / 2;
                this.Show();
            }
            catch (Exception ex)
            {
                log.Error("OnShown - " + ex);
            }

        }

        public void ResetPanel()
        {
            try
            {
                DeactiveAllCategory();
                var categoryControl = (CategoryItemControl)_topPanel.Controls[0];
                categoryControl.IsActive = true;
                //ShowProducts();
            }
            catch (Exception ex)
            {
                log.Error("ResetPanel - " + ex);
            }
        }

        private void DeactiveAllCategory()
        {
            foreach (var itm in _topPanel.Controls.Cast<CategoryItemControl>().Where(itm => itm.IsActive))
            {
                itm.IsActive = false;
            }
        }
    }
}
