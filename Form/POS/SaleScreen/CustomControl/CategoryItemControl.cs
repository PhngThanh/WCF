using System.Drawing;
using System.Windows.Forms;

namespace POS.SaleScreen.CustomControl
{
    public class CategoryItemControl : Label
    {
        public CategoryItemControl()
        {
            Height = DrawControlLibrary.CategoryPanel.Bottom - 6;
        }

        public CategoryItemControl(Bitmap activeImage, Bitmap normalImage, int id, string categoryName)
        {
            ActiveImage = activeImage;
            NormalImage = normalImage;
            Id = id;
            CategoryName = categoryName;
            Top = 0;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // DrawControlLibrary.CategoryPanel.CategoryItem.DrawItem(this, e);
            #region Drawing

            #endregion





















            var index = this.Parent.Controls.IndexOf(this);
            if (index == 0)
            {
                Left = 0;
            }
            else
            {
                Left = Parent.Controls[index - 1].Left + Parent.Controls[index - 1].Width + 5;
            }
        }



        private bool _isActive;

        private Bitmap _activeImage;
        private Bitmap _normalImage;
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                _isActive = value;
                Invalidate();
            }
        }
        public Bitmap ActiveImage
        {
            get { return _activeImage; }
            set { _activeImage = new Bitmap(value, new Size(value.Width * 24 / value.Height, 24)); }
        }

        public Bitmap NormalImage
        {
            get { return _normalImage; }
            set { _normalImage = new Bitmap(value, new Size(value.Width * 24 / value.Height, 24)); }
        }
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
