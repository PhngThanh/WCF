using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using POS;
using POS.Common;
using POS.CustomControl;
using POS.TableScreen;
using POS.Repository;
using POS.Repository.Entities.Repositories;
using POS.Repository.Entities.Services;
using POS.Repository.ViewModels;
using POS.Utils;

namespace POS.SaleScreen
{
    public partial class TableChangeForm : Form
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private List<TableViewModel> _tableViewModels;
        private CurrentOrderManager currentOrderManager = Program.context.getCurrentOrderManager();
        private TableViewModel _currentTable = null;
        private TableViewModel _newTable = null;

        private List<OrderDetailStatusEnum> _showOptions = new List<OrderDetailStatusEnum>
        {
            OrderDetailStatusEnum.New,
            OrderDetailStatusEnum.Processing,
            OrderDetailStatusEnum.PosFinished,
            OrderDetailStatusEnum.Finish,
        };


        public TableChangeForm()
        {
            InitializeComponent();
            GenerateLayout();

            currentOrderManager.setTmpOrderEditViewModel(new OrderEditViewModel());

            pnlItemListCurrent.OrderItemClickEvent += MoveRight;
            pnlItemListNew.OrderItemClickEvent += MoveLeft;
        }

        public void FastChangeTableShow()
        {
            int defaultFloor = 0;
            bool changeTable = true;

            btnSave.Hide();

            this.Show();
            LoadScreenSelectTablePanel(defaultFloor, changeTable);
        }

        public void SplitOrderDetailShow()
        {
            btnSave.Show();
            this.Show();

            LoadScreenListOrderPanel();
        }

        private void GenerateLayout()
        {
            ResetTableChangeForm();
            CreateTablePanel();
            LoadScreenListOrderPanel();

            pnlItemListNew.BackColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
            pnlItemListCurrent.BackColor = ColorScheme.GetColor(BootstrapColorEnum.MainColor);
        }


        int _tablePanelColumn = 8;
        int _tablePanelRow = 7;

        private void CreateTablePanel()
        {
            try
            {
                // 
                // selectTablePanel
                // 
                selectTablePanel = new TableLayoutPanel();

                this.selectTablePanel.Anchor = ((System.Windows.Forms.AnchorStyles)
                    ((((System.Windows.Forms.AnchorStyles.Top
                    | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
                this.selectTablePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(78)))));
                this.selectTablePanel.Location = new System.Drawing.Point(5, 65);
                this.selectTablePanel.Size = new System.Drawing.Size(790, 600);
                this.selectTablePanel.Name = "selectTablePanel";

                selectTablePanel.ColumnCount = _tablePanelColumn; //So luong san pham thao chieu ngang
                selectTablePanel.RowCount = _tablePanelRow; //So luong san pham theo chieu doc

                //Set grid layout column x row
                selectTablePanel.ColumnStyles.Clear();
                selectTablePanel.RowStyles.Clear();

                for (var i = 0; i < _tablePanelColumn; i++)
                {
                    selectTablePanel.ColumnStyles.Add(
                        new ColumnStyle(SizeType.AutoSize));
                }
                for (var i = 0; i < _tablePanelRow; i++)
                {
                    selectTablePanel.RowStyles.Add(
                        new RowStyle(SizeType.AutoSize));
                }
            }
            catch (Exception ex)
            {
                log.Error("CreateTablePanel - " + ex);
            }
        }

        private void LoadTables(int floor, bool changeTable)
        {
            try
            {
                _tableViewModels = Program.MainForm._tablePanel.GetCurrentTables(true);
                _tableViewModels = _tableViewModels.Where(t => t.Floor == floor).ToList();

                if (_tableViewModels != null && _tableViewModels.Count > 0)
                {
                    selectTablePanel.Controls.Clear();
                    foreach (Control c in this.selectTablePanel.Controls)
                    {
                        c.Dispose();
                    }

                    // Add buttons.
                    int tableRow;
                    int tableColumn;
                    int tableSpanRow;
                    int tableSpanColumn;
                    bool tableType;

                    int pixel = 36;

                    foreach (var tableViewModel in _tableViewModels)
                    {
                        //Chỉ load bàn vuông :v
                        if (tableViewModel.IsCircle == true)
                        {
                            continue;
                        }

                        if (floor == tableViewModel.Floor)
                        {
                            tableRow = tableViewModel.TableRow;
                            tableColumn = tableViewModel.TableColumn;
                            tableSpanRow = tableViewModel.SpanTableRow;
                            tableSpanColumn = tableViewModel.SpanTableColumn;
                            tableType = tableViewModel.IsCircle;

                            TableControl tableControl = new TableControl(tableViewModel, tableType, tableSpanRow, tableSpanColumn, pixel);

                            if (changeTable)
                            {
                                tableControl.Click += table_Click_ChangeTable;
                            }
                            else
                            {
                                tableControl.Click += table_Click_SplitOrderDetail;
                            }

                            selectTablePanel.Controls.Add(tableControl, tableColumn, tableRow);
                            selectTablePanel.SetRowSpan(tableControl, tableSpanRow);
                            selectTablePanel.SetColumnSpan(tableControl, tableSpanColumn);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                log.Error("LoadTables - " + ex);
            }

        }

        private void LoadScreenSelectTablePanel(int floor = 0, bool changeTable = false)
        {
            lblChooseTable.Text = "Chọn bàn sẽ chuyển: ";
            lblCurrentTable.Text = "";
            btnNewTable.TextValue = "";

            pnlMain.Controls.Remove(btnNewTable);
            pnlMain.Controls.Remove(lblCurrentTable);
            pnlMain.Controls.Remove(pnlItemListCurrent);
            pnlMain.Controls.Remove(pnlItemListNew);
            pnlMain.Controls.Remove(btnMoveLeftAll);
            pnlMain.Controls.Remove(btnMoveRightAll);

            pnlMain.Controls.Add(selectTablePanel);
            pnlMain.Controls.Add(lblChooseTable);

            LoadTables(floor, changeTable);
        }

        private void LoadScreenListOrderPanel()
        {
            lblChooseTable.Text = "";
            lblCurrentTable.Text = "Chuyển từ bàn: " + _currentTable.Number;

            if (_newTable != null)
            {
                btnNewTable.TextValue = "Đến bàn: " + _newTable.Number
                    + " (Có sẵn "
                    + currentOrderManager.GetTotalProductOfTempOrder()
                    + " sản phẩm)";
            }
            else
            {
                btnNewTable.TextValue = "Bấm vào đây để chọn bàn!";
            }


            pnlMain.Controls.Remove(selectTablePanel);
            pnlMain.Controls.Remove(lblChooseTable);

            pnlMain.Controls.Add(btnNewTable);
            pnlMain.Controls.Add(lblCurrentTable);
            pnlMain.Controls.Add(pnlItemListCurrent);
            pnlMain.Controls.Add(pnlItemListNew);
            pnlMain.Controls.Add(btnMoveRightAll);
            pnlMain.Controls.Add(btnMoveLeftAll);
        }

        private void LoadPanelItemList()
        {
            bool isCheckSplitState = true;  //Check Split State Status : New / Moved 
            pnlItemListCurrent.RenderLayoutFromOrder(isCheckSplitState, _showOptions);
            pnlItemListNew.RenderLayoutFromOrder(isCheckSplitState, _showOptions);
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            Hide();
        }

        private void LoadOrder(TableControl tableItem)
        {
            OrderEditViewModel tmpOrderEditViewModel = new OrderEditViewModel();
            tmpOrderEditViewModel.TableId = _newTable.Id;
            tmpOrderEditViewModel.TableNumber = _newTable.Number;

            if (tableItem.Status == TableStatusEnum.InUse)//Bàn đang sử dụng
            {
                if (tableItem.TableViewModel.CurrentOrderId != null)
                {
                    int orderId = (int)tableItem.TableViewModel.CurrentOrderId;
                    var orderService = ServiceManager.GetService<OrderService>(typeof(OrderRepository));
                    tmpOrderEditViewModel = ServiceManager.GetOrderEditViewModel(orderService.FirstOrDefault(o => o.OrderId == orderId));
                }
                tmpOrderEditViewModel.UpdateDateAfterLoad(); //Update lại những dữ liệu thiếu
            }

            currentOrderManager.setTmpOrderEditViewModel(tmpOrderEditViewModel);
        }

        private void table_Click_ChangeTable(object sender, EventArgs e)
        {
            var tableItem = sender as TableControl;
            if (tableItem == null) return;

            _newTable = tableItem.TableViewModel;

            if (_newTable.Id == _currentTable.Id)
            {
                PosMessageDialog.ShowMessage("Không thể chọn chính bàn đang sử dụng!");

                FastChangeTableShow();
            }
            else if (pnlItemListCurrent.OrderEditViewModel.getOrderDetailEditViewModelsList().Count == 0)
            {
                PosMessageDialog.ShowMessage("Không có sản phầm trong đơn hàng!");
            }
            else
            {
                var rs = PosMessageDialog.ConfirmMessage("Chuyển sang bàn " + _newTable.Number + " ?");

                if (rs)
                {
                    LoadOrder(tableItem);

                    btnMoveRightAll_Click(null, null);
                    SplitOrderDetail();
                }
                else
                {
                    FastChangeTableShow();
                }
            }
        }

        private void table_Click_SplitOrderDetail(object sender, EventArgs e)
        {
            try
            {
                var tableItem = sender as TableControl;
                if (tableItem == null) return;

                _newTable = tableItem.TableViewModel;

                if (_newTable.Id == _currentTable.Id)
                {
                    PosMessageDialog.ShowMessage("Không thể chọn chính bàn đang sử dụng!");

                    this.Show();
                    LoadScreenSelectTablePanel();
                }
                else
                {
                    LoadOrder(tableItem);
                    LoadScreenListOrderPanel();
                }
            }
            catch (Exception ex)
            {
                log.Error("table_Click_SplitOrderDetail - " + ex);
            }
        }

        private void btnNewTable_Click(object sender, EventArgs e)
        {
            LoadScreenSelectTablePanel();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            ResetTableChangeForm();
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_newTable == null)
            {
                PosMessageDialog.ShowMessage("Xin chọn bàn!");
                this.Show();
            }
            else if (pnlItemListNew.OrderEditViewModel.getOrderDetailEditViewModelsList().Count == 0)
            {
                PosMessageDialog.ShowMessage("Xin chọn món sẽ tách!");
                this.Show();
            }
            else
            {
                var rs = PosMessageDialog.ConfirmMessage("Bạn có muốn lưu hóa đơn vào bàn " + _newTable.Id + " ?");

                if (rs)
                {
                    SplitOrderDetail();
                }
                else
                {
                    this.Show();
                }
            }
        }

        private void btnMoveRightAll_Click(object sender, EventArgs e)
        {
            var items = pnlItemListCurrent.GetAvailableOrderDetails(true, true, _showOptions);
            foreach (List<OrderDetailEditViewModel> item in items)
            {
                MoveRight(item);
            }
        }

        private void btnMoveLeftAll_Click(object sender, EventArgs e)
        {
            var items = pnlItemListNew.GetAvailableOrderDetails(true, true, _showOptions);
            foreach (List<OrderDetailEditViewModel> item in items)
            {
                MoveLeft(item);
            }
        }

        private void MoveRight(List<OrderDetailEditViewModel> selectedOrderDetails)
        {
            foreach (OrderDetailEditViewModel orderDetail in selectedOrderDetails)
            {
                var od = pnlItemListCurrent.OrderEditViewModel.OrderDetailEditViewModels.
                    FirstOrDefault(o => o.OrderDetailID == orderDetail.OrderDetailID);

                OrderDetailEditViewModel newOd = new OrderDetailEditViewModel();
                AutoMapper.Mapper.Map<OrderDetailEditViewModel, OrderDetailEditViewModel>(od, newOd);
                if (od != null)
                {
                    newOd.OrderDetailID = od.OrderDetailID;

                    pnlItemListNew.OrderEditViewModel.OrderDetailEditViewModels.Add(newOd);
                    od.SplitState = (int)SplitOrderDetailStateEnum.Moved;
                }
            }

            LoadPanelItemList();
        }

        private void MoveLeft(List<OrderDetailEditViewModel> selectedOrderDetails)
        {
            foreach (OrderDetailEditViewModel orderDetail in selectedOrderDetails)
            {
                var od = pnlItemListCurrent.OrderEditViewModel.OrderDetailEditViewModels.
                    FirstOrDefault(o => o.OrderDetailID == orderDetail.OrderDetailID);

                pnlItemListNew.OrderEditViewModel.OrderDetailEditViewModels.Remove(orderDetail);
                od.SplitState = (int)SplitOrderDetailStateEnum.New;
            }

            LoadPanelItemList();
        }

        /// <summary>
        /// Save
        /// </summary>
        private void SplitOrderDetail()
        {
            currentOrderManager.SplitOrderDetails();
            ResetTableChangeForm();
        }

        /// <summary>
        /// Reset new TableViewModel + item list
        /// </summary>
        public void ResetTableChangeForm()
        {
            _tableViewModels = Program.MainForm._tablePanel.GetCurrentTables(true);

            _currentTable = _tableViewModels.FirstOrDefault(t => t.Id == currentOrderManager.getOrderEditViewModel().TableId);
            _newTable = null;

            ResetList();
            LoadScreenListOrderPanel();
        }

        /// <summary>
        /// Reset item list only
        /// </summary>
        private void ResetList()
        {
            pnlItemListCurrent.GenerateOrderPanelItemList(currentOrderManager.getOrderEditViewModel());
            pnlItemListNew.GenerateOrderPanelItemList(new OrderEditViewModel());

            foreach (OrderDetailEditViewModel orderDetails in pnlItemListCurrent.OrderEditViewModel.OrderDetailEditViewModels)
            {
                orderDetails.SplitState = (int)SplitOrderDetailStateEnum.New;
            }

            LoadPanelItemList();
        }
    }
}
