using System;
using POS.Common;
using POS.CustomControl;
using POS.Repository;
using POS.Repository.ViewModels;

namespace POS.TableScreen
{
    public delegate void ChangeStatusEventHandler(TableViewModel table);
    class TableControl : BaseTableControl
    {
        public TableViewModel TableViewModel { get; set; }
        public event ChangeStatusEventHandler ChangeStatus;
        public TableControl(TableViewModel table, bool tableType, int tableSpanRow, int tableSpanColumn, int count, int pixel = 40)
        {
            IsCircle = tableType;
            if (IsCircle)
            {
                Radius = tableSpanRow * pixel;
            }
            else
            {
                Height1 = tableSpanRow * pixel;
                Width1 = tableSpanColumn * pixel;
            }

            CenterText = table.Number;

            if (table.CurrentOrderDate != null)
            {
                DateTime time = (DateTime)table.CurrentOrderDate;
                MiniCenterText = time.ToString("HH:mm");
            }
            else
            {
                MiniCenterText = "";
            }

            Margin = pixel / 4;
            Padding = pixel / 4;
            //NormalColor = Color.FromArgb(70, 66, 67);
            //ActiveColor = Color.FromArgb(166, 206, 57);
            NormalColor = ColorScheme.GetColor(BootstrapColorEnum.BackColor);
            ActiveColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
            TableViewModel = table;
            Status = (TableStatusEnum) table.Status;
            Name = count.ToString();
        }


        private TableStatusEnum _status;
        public TableStatusEnum Status
        {
            get
            {
                return _status;
            }

            set
            {
                if (_status != value)
                {
                    _status = value;
                    TableViewModel.Status = (int) value;
                    //Notify changestatus event 
                    if (ChangeStatus != null)
                    {
                        ChangeStatus(TableViewModel);
                    }

                    //Update UI
                    IsFocus = (_status != TableStatusEnum.Ready);
                    this.Refresh();
                }
            }
        }
    }
}
