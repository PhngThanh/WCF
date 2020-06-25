using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using POS;
using POS.SaleScreen.CustomControl;
using System.Diagnostics;

namespace POS.SaleScreen
{
    public sealed class PropertyGroupControl : Panel
    {

        //public string Title { get; set; }
        public int SortIndex { get; set; }

        public PropertyGroupControl(List<PropertyControl> p)
        {
            Properties = p;
            //Width = Properties.Count * 75 + 10;
            Width = 220;
            Height = 220;

            BackColor = Color.Transparent;
            //Text = propertyGroup.Name;
            Margin = new Padding(0);
        }

        //private void propertyControl_EndClick(OrderItemProperty property, PropertyControl control)
        //{
        //    if (PropertyEndClick == null)
        //    {
        //        return;
        //    }
        //    PropertyEndClick(property, control);
        //}

        private void propertyControl_Click(PropertyControl control)
        {
            if (PropertyClick == null)
            {
                return;
            }
            PropertyClick( control);
        }

        private List<PropertyControl> _propertiesControl;
        //public int WidthGrid { get; set; }
        //public int HeightGrid { get; set; }
        public event Action<PropertyControl> PropertyClick;

        public List<PropertyControl> Properties
        {
            get { return _propertiesControl; }
            set
            {
                _propertiesControl = value ?? new List<PropertyControl>();
                Controls.Clear();
                foreach (var control in _propertiesControl)
                {
                    
                         control.Top = control.Y *
                              (DrawControlLibrary.PropertiesPanel.PropertySize +
                               DrawControlLibrary.PropertiesPanel.PropertyMargin) + 60;
                         control.Left = control.X *
                               (DrawControlLibrary.PropertiesPanel.PropertySize +
                                DrawControlLibrary.PropertiesPanel.PropertyMargin) + 15;
                         control.TabIndex = 0;
                    
                     control.ClickEvent += propertyControl_Click;//Khi control duoc click -> Property

                     Controls.Add(control);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawControlLibrary.PropertiesPanel.DrawGroupProperties(this, e);
        }
    }

    public class PropertyControl : Label
    {

        public int X { get; set; }
        public int Y { get; set; }
        public string Name { get; set; }

        //for promotion 
        //public string PromotionName { get; set; }
        //public List<string> PromotionArguments { get; set; } 

        public string DisplayText { get; set; }
        public int Value { get; set; }
        //public string TextValue { get; set; }

        public float TextSize { get; set; }


        private ButtonType _buttonType;
        public ButtonType ButtonType {
            get { return _buttonType; }
            set {

                _buttonType = value;
                switch (_buttonType)
                {
                    case ButtonType.Toggle://Dua vao Group de chuyen doi
                        Click += PropertyControl_Click;
                        break;
                    case ButtonType.Click:
                        MouseDown += PropertyControl_MouseDown;
                        MouseUp += PropertyControl_MouseUp;
                        break;
                    case ButtonType.Switch:
                        Click += PropertyControl_Switch;
                        break;
                }
            }

        }
        public int Group { get; set; }
        public int Type { get; set; }
        public string Notes { get; set; }
      
        public object Tag { get; set; }
     
        private bool _isActive;

        public bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                _isActive = value;
                Invalidate();
            }
        }

      

        public event Action<PropertyControl> ClickEvent;
        //public event Action<OrderItemProperty, PropertyControl> EndClickEvent;

        public PropertyControl()
        {
            IsActive = false;
            TextSize = 10;
            Width = DrawControlLibrary.PropertiesPanel.PropertySize;
            Height = DrawControlLibrary.PropertiesPanel.PropertySize;
        }

        private void PropertyControl_Switch(object sender, EventArgs e)
        {
            //Tim tat ca cac phan tu co cung Group
            //Deactive tat ca
            var controls = Parent.Controls.Cast<PropertyControl>()
                .Where(propertyControl =>
                    propertyControl.Group ==Group && propertyControl.IsActive);
            foreach (var propertyControl in controls)
            {
                propertyControl.IsActive = false;
            }
            IsActive = true;
            //Phat ra su kien 
            if (ClickEvent != null)
            {
                ClickEvent( this);
            }
        }

        private void PropertyControl_MouseUp(object sender, MouseEventArgs e)
        {
            IsActive = false;
            //if (EndClickEvent != null)
            //{
            //    Property.IsActive = _isActive;
            //    EndClickEvent(Property, this);
            //}
        }

        private void PropertyControl_MouseDown(object sender, MouseEventArgs e)
        {
            IsActive = true;
            if (ClickEvent == null) return;
            ClickEvent(this);
        }

        private void PropertyControl_Click(object sender, EventArgs e)
        {
           
            //False =>True: tim phan tu dang la True -> False
            if (!_isActive)
            {
                var controls = Parent.Controls.Cast<Control>().Where(a => a.GetType() == typeof(PropertyControl)).Cast<PropertyControl>()
                    .Where(propertyControl =>
                        propertyControl.Group == Group && propertyControl.IsActive);
                foreach (var propertyControl in controls)
                {
                    propertyControl.IsActive = false;
                    Debug.WriteLine("Test 1:" + propertyControl.Width);
                }
                
            }
            IsActive = !IsActive;//Toggle button
            if (ClickEvent != null)
            {
                ClickEvent(this);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawControlLibrary.PropertiesPanel.DrawProperty(this, e);
           
        }
    }

    public enum ButtonType
    {
        Toggle,
        Switch,
        Click
    }
}
