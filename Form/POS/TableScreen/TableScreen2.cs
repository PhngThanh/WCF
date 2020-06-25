using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using POS.Repository;
using POS.Repository.ViewModels;
using POS.Repository.Entities.Services;
using POS.Repository.Entities.Repositories;

namespace POS.TableScreen
{
    /// <summary>
    /// Main panel for table/number selection.
    /// </summary>
    public partial class TableScreen2 : UserControl
    {
        private List<TableViewModel> Tables;
        //private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public TableTypeEnum LastTableTypeSelected { get; set; }
        public TableOrderTypeEnum LastOrderTypeSelected { get; set; }
        public int LastFloorSelected { get; set; }

        public List<TableViewModel> GetCurrentTables(bool refresh = false)
        {
            if (refresh)
            {
                var tableService = ServiceManager.GetService<TableService>(typeof(TableRepository));

                Tables = ServiceManager.GetTableViewModels(tableService.GetAvailableTables().ToList());
            }
            return Tables;
        }

        public TableScreen2()
        {
            InitializeComponent();
            // GenerateLayout();
            CreateTablePanel();
            //btnFloor0.Hide();
            //btnFloor1.Hide();

            LoadTables(TableTypeEnum.All, TableOrderTypeEnum.All); // Load default TableViewModel after initialize
        }

        //private void GenerateLayout()
        //{
        //    btnLogout.Text = MainForm.resManager.GetString("TableScreen2_Logout", MainForm.cultureInfo);
        //}

        private void CreateTablePanel()
        {
            try
            {
                var screenResolution = MainForm.StoreInfo.ComputerScreenResolution.Trim().ToLower();

                ////Default is mHD (1024*768)
                int column = 9;
                int row = 6;

                if (screenResolution == "hd")
                {
                    ////HD stands for 1366*768 or 1280*720
                    column = 12;
                }
                else if (screenResolution == "fhd")
                {
                    ////FHD stands for 1920*1080
                    column = 17;
                    row = 8;
                }

                tableContainerInner.ColumnCount = column; //So luong san pham thao chieu ngang
                tableContainerInner.RowCount = row; //So luong san pham theo chieu doc
                //Set grid layout column x row
                tableContainerInner.ColumnStyles.Clear();
                tableContainerInner.RowStyles.Clear();
                for (var i = 0; i < column; i++)
                {
                    //tableContainerInner.ColumnStyles.Add(
                    //    new ColumnStyle(SizeType.Percent, (float)100.0 / column));

                    tableContainerInner.ColumnStyles.Add(
                       new ColumnStyle(SizeType.AutoSize));
                }

                for (var i = 0; i < row; i++)
                {
                    //tableContainerInner.RowStyles.Add(
                    //    new RowStyle(SizeType.Percent, (float)100.0 / row));

                    tableContainerInner.RowStyles.Add(
                      new RowStyle(SizeType.AutoSize));
                }
            }
            catch (Exception ex)
            {
                //log.Error("CreateTablePanel - " + ex);
                //Program._log.SendLogError(ex);
            }
        }


        /// <summary>
        /// Load table, make a set of buttons and fill to the view
        /// each button represent a table.
        /// </summary>
        /// <param name="tableType">Type of table: Circle, Rectangle, All. Default = All</param>
        /// <param name="floor">Floor of Tables</param>
        public void LoadTables(TableTypeEnum tableType, TableOrderTypeEnum orderType, int floor = 0)
        {
            int count = 0;
            try
            {
                LastTableTypeSelected = tableType;
                LastOrderTypeSelected = orderType;
                LastFloorSelected = floor;

                var tableService = ServiceManager.GetService<TableService>(typeof(TableRepository));
                Tables = ServiceManager.GetTableViewModels(tableService.GetAvailableTables().ToList());

                if (Tables != null && Tables.Count > 0)
                {
                    tableContainerInner.Controls.Clear();
                    foreach (Control c in this.tableContainerInner.Controls)
                    {
                        c.Dispose();
                    }

                    // Add buttons.
                    int tableRow;
                    int tableColumn;
                    int tableSpanRow;
                    int tableSpanColumn;
                    bool isCircle;
                    foreach (var table in Tables)
                    {
                        count++;
                        if (floor == table.Floor)
                        {
                            if (tableType == TableTypeEnum.Circle)
                            {
                                if (table.IsCircle != true)
                                {
                                    continue;   //skip
                                }
                                if (orderType != TableOrderTypeEnum.All)
                                {
                                    if (table.ForOrderType != null
                                        && table.ForOrderType != (int)TableOrderTypeEnum.All
                                        && table.ForOrderType != (int)orderType)
                                    {
                                        continue;   //skip
                                    }
                                }
                            }
                            else if (tableType == TableTypeEnum.Rectangle)
                            {
                                if (table.IsCircle == true)
                                {
                                    continue;   //skip
                                }
                            }
                            else if (tableType == TableTypeEnum.All)
                            {
                                //Do nothing, show all Table
                            }

                            tableRow = table.TableRow;
                            tableColumn = table.TableColumn;
                            tableSpanRow = table.SpanTableRow;
                            tableSpanColumn = table.SpanTableColumn;
                            isCircle = table.IsCircle;

                            TableControl tableControl = new TableControl(table, isCircle, tableSpanRow, tableSpanColumn, count);
                            tableControl.Click += table_Click;
                            //tableControl.ChangeStatus += TableControl_ChangeStatus;

                            tableContainerInner.Controls.Add(tableControl, tableColumn, tableRow);
                            tableContainerInner.SetRowSpan(tableControl, tableSpanRow);
                            tableContainerInner.SetColumnSpan(tableControl, tableSpanColumn);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //log.Error("LoadTables - " + ex);
                //Program._log.SendLogError(ex);
            }

        }


        public void UpdateTables(int id)
        {
            int count = 0;
            foreach (var tableControl in tableContainerInner.Controls)
            {
                count++;
                if (tableControl is TableControl)
                {
                    var table = tableControl as TableControl;

                    if (table.TableViewModel.Id == id)
                    {
                        tableContainerInner.Controls.Remove(table);
                        table.Dispose();

                        var tableService = ServiceManager.GetService<TableService>(typeof(TableRepository));
                        TableViewModel selectedTable =
                                       ServiceManager.GetTableViewModel(
                                           tableService.GetAvailableTables().FirstOrDefault(t => t.Id == id));

                        if (selectedTable != null)
                        {
                            var tableRow = selectedTable.TableRow;
                            var tableColumn = selectedTable.TableColumn;
                            var tableSpanRow = selectedTable.SpanTableRow;
                            var tableSpanColumn = selectedTable.SpanTableColumn;
                            var tableType = selectedTable.IsCircle;

                            TableControl newTableControl = new TableControl(selectedTable,
                                tableType, tableSpanRow, tableSpanColumn, count);
                            newTableControl.Click += table_Click;

                            tableContainerInner.Controls.Add(newTableControl, tableColumn, tableRow);
                            tableContainerInner.SetRowSpan(newTableControl, tableSpanRow);
                            tableContainerInner.SetColumnSpan(newTableControl, tableSpanColumn);
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Update the status of the TableViewModel button. If the TableViewModel is in use, the button
        /// will be updated to focus state. If the TableViewModel is ready, the button will be
        /// updated to normal state.
        /// </summary>
        public void UpdateTablesStatus(TableViewModel TableViewModel = null)
        {
            if (TableViewModel == null)
            {
                var tableButtons = tableContainerInner.Controls.OfType<TableControl>().Where(c => c.Tag != null);
                foreach (var button in tableButtons)
                {
                    var b = button.Tag as TableViewModel;
                    if (b == null) continue;

                    button.IsFocus = (b.Status != (int)TableStatusEnum.Ready);
                }
            }
            else
            {
                //int index = _tables.FindIndex(a => a.Id == table.Id);
                //_tables[index] = table;

                //var tableButtons = tableContainerInner.Controls;
                //foreach (var button in tableButtons)
                //{
                //    var b = (TableControl)button;
                //    if (b.Table.Id == table.Id)
                //    {
                //        b.IsFocus = (table.Status == (int)TableStatus.InUse);
                //    }
                //}
            }
        }


        /// <summary>
        /// Scroll down.
        /// </summary>
        //private void btnDown_Click(object sender, EventArgs e)
        //{
        //    var top = tableContainerInner.Top - tabletContainerOuter.Height * 3 / 4;
        //    if (top + tableContainerInner.Height <= tabletContainerOuter.Height)
        //    {
        //        btnDown.Enabled = false;
        //        top = tabletContainerOuter.Height - tableContainerInner.Height;
        //    }
        //    tableContainerInner.Top = top;
        //    btnUp.Enabled = true;
        //}

        /// <summary>
        /// Scroll up.
        /// </summary>
        //private void btnUp_Click(object sender, EventArgs e)
        //{
        //    var top = tableContainerInner.Top + tabletContainerOuter.Height * 3 / 4;
        //    if (top >= 0)
        //    {
        //        btnUp.Enabled = false;
        //        top = 0;
        //    }
        //    tableContainerInner.Top = top;
        //    btnDown.Enabled = true;
        //}

        private void table_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Program.MainForm.IsChangeTableMode)
                {
                    var tableItem = sender as TableControl;
                    if (tableItem == null) return;
                    bool isHaveDelivery = Convert.ToBoolean(MainForm.PosConfig.HasDelivery);
                    bool isHaveAtStore = Convert.ToBoolean(MainForm.PosConfig.HasAtStore);
                    bool isHaveTakeAway = Convert.ToBoolean(MainForm.PosConfig.HasTakeAway);

                    if (tableItem.Status == TableStatusEnum.InUse) //Bàn đang sử dụng
                    {
                        //OrderEditViewModel OrderEditViewModel = orderService.GetOrderByIdWithoutCache((int)tableItem.Table.CurrentOrderId);
                        if (tableItem.TableViewModel.CurrentOrderId != null)
                        {
                            int orderId = (int)tableItem.TableViewModel.CurrentOrderId;
                            var orderService = ServiceManager.GetService<OrderService>(typeof(OrderRepository));
                            OrderEditViewModel orderEditViewModel =
                                ServiceManager.GetOrderEditViewModel(orderService.FirstOrDefault(o => o.OrderId == orderId));

                            orderEditViewModel.UpdateDateAfterLoad(); //Update lại những dữ liệu thiếu

                            LoadOrder(orderEditViewModel, OrderTypeEnum.AtStore, tableItem.TableViewModel);
                        }
                    }
                    //For only Delivery
                    else if (isHaveDelivery && !isHaveAtStore && !isHaveTakeAway)
                    {
                        serveTypeDlg_OrderTypeSelected(OrderTypeEnum.Delivery, tableItem.TableViewModel);

                    }
                    //For only At Store
                    else if (!isHaveDelivery && isHaveAtStore && !isHaveTakeAway)
                    {
                        serveTypeDlg_OrderTypeSelected(OrderTypeEnum.AtStore, tableItem.TableViewModel);
                    }
                    //For only Take Away
                    else if (!isHaveDelivery && !isHaveAtStore && isHaveTakeAway)
                    {
                        serveTypeDlg_OrderTypeSelected(OrderTypeEnum.TakeAway, tableItem.TableViewModel);
                    }
                    else
                    {
                        if (MainForm.PosConfig.EnableServeTypeDialog.Trim().ToLower() == "true")
                        {
                            var serveTypeDlg = new ServeTypeDialog(tableItem.TableViewModel);
                            serveTypeDlg.Show();
                            serveTypeDlg.OrderTypeSelected += serveTypeDlg_OrderTypeSelected; //Chọn loại giao hàng
                        }
                        else
                        {
                            var orderType = Program.MainForm.GetCurrentOrderType();
                            if (orderType == OrderTypeEnum.AtStore)
                            {
                                serveTypeDlg_OrderTypeSelected(OrderTypeEnum.AtStore, tableItem.TableViewModel);
                            }
                            else if (orderType == OrderTypeEnum.Delivery)
                            {
                                serveTypeDlg_OrderTypeSelected(OrderTypeEnum.Delivery, tableItem.TableViewModel);
                            }
                            else if (orderType == OrderTypeEnum.TakeAway)
                            {
                                serveTypeDlg_OrderTypeSelected(OrderTypeEnum.TakeAway, tableItem.TableViewModel);
                            }
                        }
                    }
                }
                else
                {
                    // when select from Change TableViewModel step
                    Program.MainForm.IsChangeTableMode = false;
                }
            }
            catch (Exception ex)
            {
                //log.Error("table_Click - " + ex);
                //Program._log.SendLogError(ex);
            }

        }

        //Load OrderEditViewModel
        private void LoadOrder(OrderEditViewModel order, OrderTypeEnum type, TableViewModel table)
        {
            if (table == null)
            {
                var tableService = ServiceManager.GetService<TableService>(typeof(TableRepository));
                const int notUse = (int)TableStatusEnum.NotUse;
                var tmpTable = tableService.Get(t => t.Status != notUse).FirstOrDefault();

                table = ServiceManager.GetTableViewModel(tmpTable);
            }
            Program.MainForm.LoadSaleScreen(order, type, table);
        }

        void serveTypeDlg_OrderTypeSelected(OrderTypeEnum type, TableViewModel table)
        {
            LoadOrder(null, type, table);
        }

        //private void TablePanel_SizeChanged(object sender, EventArgs e)
        //{
        //    AdjustTableContainerInnerHeight();
        //}

        public void GenerateListNotifications(List<OrderEditViewModel> orders)
        {
            //            foreach (var order in orders)
            //            {
            //                var notification = new Notification()
            //                {
            //                    CreateTime = order.CheckInDate,
            //                    IsReaded = false,
            //                    Message = order.DeliveryAddress + "-" + order.DeliveryPhone,
            //                    Tag = order.OrderId,
            //                    Title = order.DeliveryCustomer
            //                };
            //                notifications.Add(notification);
            //            }
            //
            //            if (notificationForm.Visible)
            //            {
            //                notificationForm.Hide();
            //            }
            //
            //            int count = notificationForm.GenerateListNotifications(notifications);
            //            btnNotification.Text = count.ToString();
        }
    }
}
