using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace POS.Common
{
    public sealed class CustomDropDownControl : Control
    {
        private readonly List<Tuple<string, Color>> _dataSource;
        private readonly DropDownDialog _dropDownDialog;
        public event EventHandler ItemSelected;

        public CustomDropDownControl()
        {
            _dataSource = new List<Tuple<string, Color>>();
            _dropDownDialog = new DropDownDialog(_dataSource);
            _dropDownDialog.ItemSelected += ItemSelected_Handler;
            Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            Height = 29;
        }

        public int BorderRadius { get; set; }

        public CustomDropDownControl(List<Tuple<string, Color>> dataSource)
        {
            _dataSource = dataSource;
            _dropDownDialog = new DropDownDialog(_dataSource);
            _dropDownDialog.ItemSelected += ItemSelected_Handler;
            Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            BackColor = _dataSource[0].Item2;
            Text = _dataSource[0].Item1;
            SelectedItem = _dataSource[0].Item1;
            Height = 29;
        }

        public List<Tuple<string, Color>> DataSource { get { return _dataSource; } }
        public string SelectedItem { get; private set; }

        private void ItemSelected_Handler(object sender, EventArgs e)
        {
            SelectedItem = _dropDownDialog.SelectedText;
            Text = SelectedItem;
            BackgroundColor = _dropDownDialog.SelectedColor;
            Invalidate();
            OnItemSelected();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var fillPath =
                DrawUtility.DrawBorderRadiusRectangle(
                    new Rectangle(Point.Empty, new Size(Width - BorderSize, Height - BorderSize)), BorderRadius);
            var borderPath =
                DrawUtility.DrawBorderRadiusRectangle(
                    new Rectangle(BorderSize - 1, BorderSize - 1, Width - BorderSize * 2, Height - BorderSize * 2), BorderRadius);
            var stringFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            e.Graphics.FillPath(new SolidBrush(BackgroundColor), fillPath);
            e.Graphics.DrawPath(new Pen(BorderColor, BorderSize), borderPath);
            e.Graphics.DrawString(Text, Font, new SolidBrush(Color.White), new Rectangle(Point.Empty, Size),
                stringFormat);
        }

        public Color BorderColor { get; set; }

        public int BorderSize { get; set; }

        public Color BackgroundColor { get; set; }


        private void OnItemSelected()
        {
            var handler = ItemSelected;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Height = 29;
            _dropDownDialog.Width = Width;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            _dropDownDialog.Show();
            var location = PointToScreen(Point.Empty);
            _dropDownDialog.Left = location.X;
            _dropDownDialog.Top = location.Y + Height;
        }

        private sealed class DropDownDialog : Form
        {
            private readonly FlowLayoutPanel _flowPanel;
            public event EventHandler ItemSelected;
            private Tuple<string, Color> _selectedItem;
            private readonly IList<Tuple<string, Color>> _dataSource;
            public DropDownDialog(IList<Tuple<string, Color>> dataSource)
            {
                FormBorderStyle = FormBorderStyle.None;
                ShowInTaskbar = false;
                _flowPanel = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    FlowDirection = FlowDirection.TopDown
                };
                _flowPanel.SizeChanged += (sender, args) =>
                {
                    foreach (var control in _flowPanel.Controls.Cast<Control>())
                    {
                        control.Width = _flowPanel.Width;
                    }
                };
                var height = 0;
                foreach (var item in dataSource)
                {
                    var label = new Label
                    {
                        Text = item.Item1,
                        BackColor = item.Item2,
                        Margin = new Padding(0, 7, 0, 0),
                        AutoSize = false,
                        Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                        ForeColor = Color.White,
                        Height = 48,
                        TextAlign = ContentAlignment.MiddleCenter,
                    };
                    height += 55;
                    label.Click += ItemClicked_Handler;
                    label.Tag = item;
                    _flowPanel.Controls.Add(label);
                }
                Height = height;
                Controls.Add(_flowPanel);
                _dataSource = dataSource;
                BackColor = Color.DarkGray;
            }

            private void ItemClicked_Handler(object sender, EventArgs e)
            {
                var label = sender as Label;
                if (label == null) return;
                _selectedItem = (Tuple<string, Color>)label.Tag;
                OnItemSelected();
            }

            public string SelectedText { get { return _selectedItem.Item1; } }
            public Color SelectedColor { get { return _selectedItem.Item2; } }

            private void OnItemSelected()
            {
                var handler = ItemSelected;
                if (handler != null) handler(_selectedItem, EventArgs.Empty);
                Hide();
            }

            protected override void OnDeactivate(EventArgs e)
            {
                base.OnDeactivate(e);
                Hide();
            }

            public void Reset()
            {
                _flowPanel.Controls.Clear();
                foreach (Control c in this._flowPanel.Controls)
                {
                    c.Dispose();
                }

                var height = 0;
                foreach (var item in _dataSource)
                {
                    var label = new Label
                    {
                        Text = item.Item1,
                        BackColor = item.Item2,
                        Margin = new Padding(0, 7, 0, 0),
                        AutoSize = false,
                        Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                        ForeColor = Color.White,
                        Height = 48,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Width = _flowPanel.Width
                    };
                    height += 55;
                    label.Click += ItemClicked_Handler;
                    label.Tag = item;
                    _flowPanel.Controls.Add(label);
                }
                Height = height;
            }
        }

        public void Reset()
        {
            _dropDownDialog.Reset();
            Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            BackColor = _dataSource[0].Item2;
            Text = _dataSource[0].Item1;
            SelectedItem = _dataSource[0].Item1;
            Height = 29;
        }
    }
}
