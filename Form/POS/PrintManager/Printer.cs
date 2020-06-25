using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using POS.Utils;
using POS.SaleScreen;
using POS.Repository;
using POS.ApiThirdPartyDLL;
using POS.Repository.ViewModels;
using log4net;
using POS.DashboardScreen.MemberScreen;
using POS.Common;
using POS.Repository.Entities.Services;

namespace POS.PrintManager
{
    public class Printer
    {
        private static readonly ILog log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static CurrentOrderManager currentOrderManager = Program.context.getCurrentOrderManager();
        private const int MarginLeft = 2;
        private const int MarginTop = 0;
        private const int MarginRight = 270;
        private const int QuantityIndent = 50;
        private const int XIndent = 45;
        private const int ProductNameIndent = 65;

        public Printer() { }

        #region Base function

        public void CustomPrintLocation(PrintDocument printDocument, string name)
        {
            try
            {
                printDocument.PrinterSettings.PrintFileName = name;

                if (printDocument.PrinterSettings.PrinterName == "Microsoft Print to PDF")
                {
                    //D:\SkyPOS\Documents\2017-Jan\1-TEST-38-1ti6iks.pdf
                    var currentDir = Environment.CurrentDirectory;
                    var date = UtcDateTime.Now().ToString("dd");
                    var yearAndMonth = UtcDateTime.Now().ToString("yyyy-MMM");

                    var directory = currentDir + @"\Documents\" + yearAndMonth + @"\";
                    var fileName = date + "-" + name;
                    var filePath = directory + fileName;
                    var extension = ".pdf";
                    var endPath = extension;
                    var count = 0;

                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    while (File.Exists(filePath + endPath))
                    {
                        count++;
                        endPath = "(" + count.ToString() + ")" + extension;
                    }

                    printDocument.PrinterSettings.PrintFileName = filePath + endPath;
                    printDocument.PrinterSettings.PrintToFile = true;
                }

                printDocument.Print();
            }
            catch (Exception ex)
            {
                log.Error("CustomPrintLocation - " + ex);
            }
        }

        public void PrintBillDetail(OrderEditViewModel order, OrderDetailViewModel orderDetail,
                                    string printerName)
        {
            var fileName = order.OrderCode;
            var printDocument = new PrintDocument();
            printDocument.PrintPage += (sender, args)
                      =>
            {
                CreateCookBillDetail(args.Graphics, order, orderDetail);
            };
            printDocument.PrinterSettings.PrinterName = printerName;
            CustomPrintLocation(printDocument, fileName);
        }

        public void PrintBill(OrderEditViewModel order, BillTypeEnum billType,
                                    string printerName, bool isPrintAllOrderDetail, int? printGroup = null)
        {
            try
            {
                var fileName = order.OrderCode;
                var printDocument = new PrintDocument();
                if (billType == BillTypeEnum.Customer)
                {
                    printDocument.PrintPage += (sender, args)
                        =>
                    { 
                        CreateReceipt(args.Graphics, order); 
                    };
                    printDocument.PrinterSettings.PrinterName = printerName;
                    CustomPrintLocation(printDocument, fileName);
                }
                else if (billType == BillTypeEnum.Cook)
                {
                    // Create order without Extra
                    var cookName = fileName + "---Cook";
                    printDocument.PrinterSettings.PrinterName = printerName;
                    printDocument.PrintPage += (sender, args)
                        =>
                    {
                        CreateCookBillExtra(args.Graphics, order, isPrintAllOrderDetail, printGroup);
                    };

                    CustomPrintLocation(printDocument, cookName);


                }
                else if (MainForm.StoreInfo.PrinterDetail.ToLower() == "true".ToLower())
                {
                    var whitelistSplit = MainForm.StoreInfo.Whitelist.Split('|');
                    var whitelistCode = new List<int>();
                    foreach (var item in whitelistSplit)
                    {
                        whitelistCode.Add(int.Parse(item));
                    }
                    var tmpOrders = order.OrderDetailEditViewModels;
                    var ordersOfMainDish = tmpOrders.Where(p => p.ParentId == null);
                    int count = 0;
                    foreach (var orderOfMainDish in ordersOfMainDish)
                    {
                        if (whitelistCode.Count > 0)
                        {
                            var product = Program.context.getAllProducts().FirstOrDefault(q => q.Code.Equals(orderOfMainDish.ProductCode));
                            if (whitelistCode.Any(q => q == product.CatID))
                            {
                                for (int i = 0; i < orderOfMainDish.ItemQuantity; ++i)
                                {
                                    var extraName = string.Format("{0}--Extra {1}", fileName, ++count);
                                    var printDocumentInner = new PrintDocument();
                                    printDocumentInner.PrintPage += (sender, args)
                                        =>
                                    {
                                        CreateCookBillWithExtra(args.Graphics, order, isPrintAllOrderDetail, orderOfMainDish.TmpDetailId ?? 0, orderOfMainDish.ItemQuantity);
                                    };
                                    printDocumentInner.PrinterSettings.PrinterName = MainForm.StoreInfo.PrinterLabel;
                                    CustomPrintLocation(printDocumentInner, extraName);
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                log.Error("PrintBill - " + ex);
            }
        }

        public void PrintBillMomo(OrderEditViewModel order, BillTypeEnum billType,
            string printerName, bool isPrintAllOrderDetail)
        {
            try
            {
                var fileName = order.OrderCode;
                var printDocument = new PrintDocument();
                if (billType == BillTypeEnum.Customer)
                {
                    printDocument.PrintPage += (sender, args)
                            =>
                        { CreateMomoReceipt(args.Graphics, order); };
                }

                printDocument.PrinterSettings.PrinterName = printerName;
                CustomPrintLocation(printDocument, fileName);
            }
            catch (Exception ex)
            {
                log.Error("PrintBill - " + ex);
            }
        }

        public void PrintWifiPassword(OrderEditViewModel order = null)
        {
            try
            {
                var fileName = "";
                if (order != null)
                {
                    fileName = "WIFI - " + order.OrderCode + " - " + DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss");
                }
                else
                {
                    fileName = "WIFI - " + DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss");
                }
                var printDocument = new PrintDocument();
                printDocument.PrintPage += (sender, args)
                    =>
                {
                    CreateWifiPassword(args.Graphics, order);
                };

                printDocument.PrinterSettings.PrinterName = MainForm.StoreInfo.PrinterBill;
                CustomPrintLocation(printDocument, fileName);
            }
            catch (Exception e)
            {
                log.Error("PrintWifiPassword - " + e);
                throw;
            }
        }

        public class LabelOrderModel
        {
            public OrderDetailEditViewModel ParentOrderDetail { get; set; }
            public List<OrderDetailEditViewModel> ListSubOrderDetail { get; set; }
        }

        public void PrintCooking(List<OrderDetailEditViewModel> orderDetails,
                                string orderCode, string tableNumber, string creator,
                                string note, int processItem, int totalItem)
        {
            try
            {
                var printDocument = new PrintDocument();

                printDocument.PrinterSettings.PrinterName = MainForm.StoreInfo.PrinterBill;
                printDocument.PrintPage += (sender, args) =>
                {
                    CreateCookingBill(args.Graphics, orderDetails, orderCode, tableNumber, creator, note, processItem, totalItem);
                }; // Add an event handler that will do the printing.

                var docName = orderCode + "---Cooking";
                CustomPrintLocation(printDocument, docName);
            }
            catch (Exception ex)
            {
                log.Error("PrintOpenSafe - " + ex);
            }
        }

        public void PrintOpenSafe(string creator, string reason)
        {
            try
            {
                var printDocument = new PrintDocument();

                printDocument.PrinterSettings.PrinterName = MainForm.StoreInfo.PrinterBill;
                printDocument.PrintPage += (sender, args) =>
                {
                    CreateOpenSafe(args.Graphics, creator, reason);
                }; // Add an event handler that will do the printing.

                var docName = creator + "---OpenSafe";
                CustomPrintLocation(printDocument, docName);
            }
            catch (Exception ex)
            {
                log.Error("PrintOpenSafe - " + ex);
            }
        }

        public void PrintStoreReport(StoreReportModel reportModel, string creator)
        {
            try
            {
                //var reportModel = new ReportModel();
                //reportModel.Init(order);

                var printDocument = new PrintDocument();

                printDocument.PrinterSettings.PrinterName = MainForm.StoreInfo.PrinterBill;
                printDocument.PrintPage += (sender, args) =>
                {
                    CreateReportQuantity(args.Graphics, reportModel, creator);
                }; // Add an event handler that will do the printing.

                var docName = creator + "---StoreReport";
                CustomPrintLocation(printDocument, docName);
            }
            catch (Exception ex)
            {
                log.Error("PrintStoreReport - " + ex);
            }
        }

        public Image GetImageReport(StoreReportModel reportModel, string creator)
        {

            var faker = new Bitmap(1, 1);
            var graphic = Graphics.FromImage(faker);
            var height = CreateReportQuantity(graphic, reportModel, creator);

            var pic = new Bitmap(280, height);
            graphic = Graphics.FromImage(pic);
            graphic.FillRectangle(Brushes.White, 0, 0, pic.Width, pic.Height);
            CreateReportQuantity(graphic, reportModel, creator);
            return pic;
        }

        public Image GetImageReport(OrderEditViewModel order)
        {

            var faker = new Bitmap(1, 1);
            var graphic = Graphics.FromImage(faker);
            var height = CreateReceipt(graphic, order);

            var pic = new Bitmap(280, height);
            graphic = Graphics.FromImage(pic);
            graphic.FillRectangle(Brushes.White, 0, 0, pic.Width, pic.Height);
            CreateReceipt(graphic, order);
            return pic;
        }

        //public  void PrintReportNonDetail(List<OrderEditViewModel> orders, string creator)
        //{
        //    var reportModel = new ReportModel();
        //    reportModel.Init(orders);

        //    var printDocument = new PrintDocument();

        //    printDocument.PrintPage += (sender, args) =>
        //    {
        //        CreateImageReportTotal(args.Graphics, reportModel, creator);
        //    }; // Add an event handler that will do the printing.

        //    printDocument.Print();
        //}

        //public  Image GetImageNonDetail(List<OrderEditViewModel> order, string creator)
        //{
        //    var reportModel = new ReportModel();
        //    reportModel.Init(order);
        //    var faker = new Bitmap(1, 1);
        //    var graphic = Graphics.FromImage(faker);
        //    var height = CreateImageReportTotal(graphic, reportModel, creator);

        //    var pic = new Bitmap(280, height);
        //    graphic = Graphics.FromImage(pic);
        //    graphic.FillRectangle(Brushes.White, 0, 0, pic.Width, pic.Height);
        //    CreateImageReportTotal(graphic, reportModel, creator);
        //    return pic;
        //}

        #endregion

        #region Creater function

        //private void CreateVAT(object sender, PrintPageEventArgs e, OrderEditViewModel order, CustomerInfoModel cusInfo)
        //{
        //    //Draw Invoice
        //    //Invoice A5 size = 1167 x 1653
        //    MainInvoicePanel invoice = new MainInvoicePanel();
        //    invoice.GenerateLayout(order, cusInfo);

        //    var printForm = new Form();
        //    printForm.Size = new Size(invoice.Width, invoice.Height);
        //    printForm.Controls.Add(invoice);
        //    printForm.Show();

        //    Bitmap bitmap = new Bitmap(1651, 2489);
        //    invoice.DrawToBitmap(bitmap, new Rectangle(invoice.Left, invoice.Top, invoice.Width, invoice.Height));

        //    double xScale = (double)bitmap.Width / invoice.Width;
        //    double yScale = (double)bitmap.Height / invoice.Height;
        //    Rectangle target = new Rectangle(0, 0, invoice.Width, invoice.Height);
        //    if (xScale < yScale)
        //    {
        //        target.Width = (int)(xScale * target.Width / yScale);
        //    }
        //    else
        //    {
        //        target.Height = (int)(yScale * target.Height / xScale);
        //    }
        //    e.Graphics.PageUnit = GraphicsUnit.Display;
        //    e.Graphics.DrawImage((Image)bitmap, target);

        //    //Draw Logo
        //    //Bitmap logo = (Bitmap)Image.FromFile("./Resources/" + MainForm.VATInvoice.InvoiceLogo);
        //    Rectangle logoRec = new Rectangle
        //    {
        //        Location = new Point(110, 110),
        //        Width = 178,        //356, 
        //        Height = 40,        //80, 
        //    };
        //    //e.Graphics.DrawImage((Image)logo, logoRec);

        //    printForm.Hide();
        //    printForm.Controls.Clear();
        //}

        private int CreateReceipt(Graphics graphic, OrderEditViewModel order)
        {
            var fVerdana9B = new Font("Verdana", 9, FontStyle.Bold);
            var fVerdana8 = new Font("Verdana", 8, FontStyle.Regular);
            var fVerdana6 = new Font("Verdana", 6, FontStyle.Regular);
            var fVerdana8B = new Font("Verdana", 8, FontStyle.Bold);
            var fVerdana13B = new Font("Verdana", 13, FontStyle.Bold);
            var fVerdana10B = new Font("Verdana", 10, FontStyle.Bold);
            var fCourier9B = new Font("Courier New", 9, FontStyle.Bold);

            int offset = 0;

            // Logo.
            offset = DrawLogo(graphic, offset);

            // Address.
            if (MainForm.StoreInfo.TerminalAddress != null)
            {
                string[] splitAddress = MainForm.StoreInfo.TerminalAddress.Split('|');
                foreach (string s in splitAddress)
                {
                    offset = WriteCenterText(graphic, offset + 10, fVerdana9B, s);
                }
            }

            // Hotline.
            var hotline = string.Format("Hotline Delivery: {0}", MainForm.StoreInfo.HotLine);
            offset = WriteCenterText(graphic, offset + 7, fVerdana9B, hotline);

            // Title. 
            if (order.OrderType == (int)OrderTypeEnum.Delivery
                || order.PaymentEditViewModels.Any(a => a.Type == (int)PaymentTypeEnum.GrabPay || a.Type == (int)PaymentTypeEnum.GrabPay))
            {
                offset = WriteCenterText(graphic, offset + 12, fVerdana13B, "PHIẾU TẠM TÍNH");
            }
            else
            {
                offset = WriteCenterText(graphic, offset + 12, fVerdana13B, "PHIẾU THANH TOÁN");
            }

            // Time.

            //var time = UtcDateTime.Now().ToString("dd/MM/yyyy  hh:mm:sstt");
            var time = order.CheckInDate.ToString("dd/MM/yyyy  hh:mm:sstt");
            offset = WriteCenterText(graphic, offset + 5, fVerdana8, time);

            // Cashier.
            var text = string.Format("NHÂN VIÊN:\t{0}", order.CheckInPerson);
            offset = WriteLeftText(graphic, offset + 7, fVerdana8, text);

            //In lan thu
            //var countPrint = string.Format("PRINT:\t{0}", order.TotalInvoicePrint.ToString()); 
            //offset = WriteLeftText(graphic, offset + 2, fVerdana8, countPrint);

            var countPrint = "PRINT: " + order.TotalInvoicePrint.ToString();

            // ID.
            text = MainForm.StoreInfo.OrderCodeText + string.Format(":\t{0}", order.OrderCode);
            text = text + "  " + countPrint;
            offset = WriteLeftText(graphic, offset + 2, fVerdana8, text);

            if (string.IsNullOrEmpty(order.TableNumber))
            {
                var tableViewModel
                    = Program.context.getAllTables().LastOrDefault(t => t.Id == order.TableId);

                if (tableViewModel != null)
                    order.TableNumber = tableViewModel.Number;
            }

            var textOnline = MainForm.StoreInfo.OnlineOrderText;
            // Table.
            var textTakeAway = MainForm.StoreInfo.TakeAwayText + string.Format(": {0}",
                order.TableId == null ? " - " + textOnline : order.TableNumber);
            var textAtStore = MainForm.StoreInfo.AtStoreText + string.Format(":\t\t{0}",
                order.TableId == null ? " - " + textOnline : order.TableNumber);
            var textDelivery = MainForm.StoreInfo.DeliveryText;
            //text = _order.OrderType == (int)OrderType.TakeAway ? textTakeAway : textAtStore;

            if (order.OrderType == (int)OrderTypeEnum.TakeAway)
            {
                text = textTakeAway;
            }
            else if (order.OrderType == (int)OrderTypeEnum.AtStore)
            {
                text = textAtStore;
            }
            else if (order.OrderType == (int)OrderTypeEnum.Delivery ||
                     order.DeliveryStatus == (int)DeliveryStatusEnum.Delivery)
            {
                text = textDelivery;
            }
            else
            {
                text = "";
            }


            var sortedOrderDetailList = GetSortedValidOrderDetail(order);

            offset = WriteLeftText(graphic, offset + 3, fVerdana13B, text);

            // Line 1.
            offset = DrawSolidLine(graphic, offset + 2);
            #region TTH
            foreach (OrderDetailEditViewModel orderDetailEditViewModel in sortedOrderDetailList)
            {
                var isExtraProduct = IsExtraProduct(orderDetailEditViewModel.ProductCode);
                if (!isExtraProduct)
                {
                    {
                        string productName = orderDetailEditViewModel.ProductName;
                        int charPerLine = 27;
                        if (productName.Length > charPerLine)
                        {
                            //productName = productName.Insert(28, "\n");
                            var multipleLines = this.BreakLines(productName, charPerLine);
                            offset += 10;
                            foreach (var line in multipleLines)
                            {
                                offset = WriteLeftText(graphic, offset, fCourier9B, line.ToUpper(), 0);
                            }
                        }
                        else
                        {
                            text = string.Format("{0}", productName.ToUpper());
                            offset = WriteLeftText(graphic, offset + 10, fCourier9B, text, 0);
                        }

                        //Origin
                        //offset = WriteLeftText(graphic, offset + 4, fCourier9B, text, ProductNameIndent);

                        var indentQuantity = 15;
                        var indentUnitPrice = 30;
                        if (orderDetailEditViewModel.Quantity > 99)
                        {
                            indentQuantity += 9;
                            indentUnitPrice += 7;
                            if (orderDetailEditViewModel.Quantity > 999)
                            {
                                indentQuantity += 9;
                                indentUnitPrice += 7;
                            }
                        }

                        // ProductViewModel amount price.
                        WriteLeftText(graphic, offset + 2, fCourier9B, orderDetailEditViewModel.Quantity.ToString(), 0);
                        WriteLeftText(graphic, offset + 2, fCourier9B, "x", indentQuantity);

                        // Price
                        WriteLeftText(graphic, offset + 2, fCourier9B, orderDetailEditViewModel.UnitPrice.ToString("N0"), indentUnitPrice);

                        // Total.
                        var total = orderDetailEditViewModel.TotalAmount;
                        offset = WriteRigth64Text(graphic, offset + 2, fCourier9B, total.ToString("N0"));
                    }
                }
                //ProductViewModel Child
                else
                {
                    text = string.Format("{0}", "+ " + orderDetailEditViewModel.ProductName);

                    //string itemQuantityChild = orderDetailEditViewModel.Quantity.ToString();
                    offset = WriteLeftText(graphic, offset + 4, fCourier9B, text /*+ " (x " + itemQuantityChild + ")"*/, 40);

                    // ProductViewModel amount price.
                    WriteLeftText(graphic, offset + 2, fCourier9B, orderDetailEditViewModel.Quantity.ToString(), 55);
                    WriteLeftText(graphic, offset + 2, fCourier9B, "x", 70);

                    // Price
                    WriteLeftText(graphic, offset + 2, fCourier9B, orderDetailEditViewModel.UnitPrice.ToString("N0"), 85);

                    // Total.
                    var total = orderDetailEditViewModel.TotalAmount;
                    offset = WriteRigth64Text(graphic, offset + 2, fCourier9B, total.ToString("N0"));
                }

                if (orderDetailEditViewModel.Discount > 0)
                {
                    // Discount.
                    text = string.Format("-{0}", orderDetailEditViewModel.Discount.ToString("N0"));
                    //text = "discount";
                    WriteCenterTextAlignRight(graphic, offset, fCourier9B, text);

                    // Payment.
                    offset = WriteRigth64Text(graphic, offset, fCourier9B, orderDetailEditViewModel.FinalAmount.ToString("N0"));
                }
            }

            #endregion

            // Line 2
            offset = DrawSolidLine(graphic, offset + 2);

            // TOTAL
            WriteLeftText(graphic, offset + 5, fVerdana8B, "TỔNG CỘNG", 5);
            offset = WriteRightText(graphic, offset + 5, fVerdana8B, order.SumFinalOrderDetail().ToString("N0"));

            // Promotion
            var appliedPromotions = new List<PromotionEditViewModel>();
            foreach (var mapping in order.OrderPromotionMappingEditViewModels)
            {
                var applied = appliedPromotions.FirstOrDefault(m => m.PromotionCode == mapping.PromotionCode);
                if (applied == null)
                {
                    var promotion = Program.context.getPromotions().FirstOrDefault(p => p.PromotionCode == mapping.PromotionCode);
                    if (promotion != null)
                    {
                        if (promotion.PromotionType != (int)PromotionTypeEnum.Internal)
                        {
                            appliedPromotions.Add(promotion);
                        }
                    }
                }
            }
            foreach (var od in order.OrderDetailEditViewModels)
            {
                foreach (var mapping in od.OrderDetailPromotionMappingEditViewModels)
                {
                    var applied = appliedPromotions.FirstOrDefault(m => m.PromotionCode == mapping.PromotionCode);
                    if (applied == null)
                    {
                        var promotion = Program.context.getPromotions().FirstOrDefault(p => p.PromotionCode == mapping.PromotionCode);
                        if (promotion != null)
                        {
                            if (promotion.PromotionType != (int)PromotionTypeEnum.Internal)
                            {
                                appliedPromotions.Add(promotion);
                            }
                        }
                    }
                }
            }

            if (appliedPromotions.Any())
            {
                offset += 3;
                WriteLeftText(graphic, offset + 3, fVerdana8, "Đã áp dụng khuyến mãi:");
                offset += 12;

                foreach (var promotion in appliedPromotions)
                {
                    text = promotion.Description;
                    offset = WriteRightText(graphic, offset + 3, fVerdana8, text);
                }
            }

            // Discount rate
            offset += 3;
            WriteLeftText(graphic, offset + 3, fVerdana8, "CHIẾT KHẤU (%):", 5);
            text = order.GetDiscountRate().ToString();
            offset = WriteRightText(graphic, offset + 3, fVerdana8, text + "%");

            // Discount
            WriteLeftText(graphic, offset + 2, fVerdana8, "GIẢM GIÁ (VNĐ):", 5);
            text = order.Discount.ToString("N0");
            offset = WriteRightText(graphic, offset + 2, fVerdana8, text);

            // VAT
            WriteLeftText(graphic, offset + 2, fVerdana8, "VAT:", 5);
            text = order.VATAmount.ToString("N0");
            offset = WriteRightText(graphic, offset + 2, fVerdana8, text);

            // FinalAmount.
            //Passio
            var orderVM = order.getPaymentEditViewModels().FirstOrDefault();
            PaymentTypeEnum orderTypeEnum = 0;
            if (orderVM != null)
            {
                orderTypeEnum = (PaymentTypeEnum)orderVM.Type;
            }
            string strThanhToan = "THANH TOÁN({0}):";
            if ((int)orderTypeEnum > 20)
            {
                strThanhToan = string.Format(strThanhToan, orderTypeEnum.ToString());
            }
            else
            {
                strThanhToan = "THANH TOÁN:";
            }
            WriteLeftText(graphic, offset + 2, fVerdana10B, strThanhToan, 5);

            //text = order.OrderPayment.FinalPayment.ToString("N0");
            var final = order.FinalAmount + order.VATAmount;
            text = final.ToString("N0");
            //PAssio
            offset = WriteRightText(graphic, offset + 2, fVerdana10B, text);

            // Line 3.
            offset = DrawDashLine(graphic, offset + 5);


            if (order.OrderType != (int)OrderTypeEnum.Delivery)
            {
                // Recieved.
                WriteLeftText(graphic, offset + 5, fVerdana8B, "KHÁCH TRẢ TỔNG CỘNG(VNĐ):", 5);
                //Tiền khách trả
                text = order.GuestPayment.ToString("N0");
                offset = WriteRightText(graphic, offset + 5, fVerdana8B, text);

                //Loại thanh toán
                var orderPayment = order.getPaymentEditViewModels();
                if (order.getPaymentEditViewModels().Any(p => p.Type != (int)PaymentTypeEnum.Cash
                                                        && p.Type != (int)PaymentTypeEnum.ExchangeCash))
                {
                    //Tiền mặt
                    var cash = order.getPaymentEditViewModels()
                        .Where(p => p.Type == (int)PaymentTypeEnum.Cash)
                        .Sum(p => p.Amount);
                    if (cash > 0)
                    {
                        offset += 3;
                        WriteLeftText(graphic, offset + 3, fVerdana8, "TIỀN MẶT:", 5);
                        text = cash.ToString("N0");
                        offset = WriteRightText(graphic, offset + 3, fVerdana8, text);
                    }

                    //Member
                    cash = order.getPaymentEditViewModels()
                        .Where(p => p.Type == (int)PaymentTypeEnum.MemberPayment)
                        .Sum(p => p.Amount);
                    if (cash > 0)
                    {
                        offset += 3;
                        WriteLeftText(graphic, offset + 3, fVerdana8, "THẺ THÀNH VIÊN:", 5);
                        text = cash.ToString("N0");
                        offset = WriteRightText(graphic, offset + 3, fVerdana8, text);

                        if (!currentOrderManager.isCurrentCustomerModelEmpty())
                        {
                            var accountCredit = currentOrderManager.getCurrentCustomerModel()
                                .Accounts.FirstOrDefault(a => a.Type == (int)CardAccountTypeEnum.CreditAccount);
                            if (accountCredit != null)
                            {
                                if (accountCredit.Balance != null)
                                {
                                    var cash2 = (decimal)accountCredit.Balance;
                                    text = cash2.ToString("N0");

                                    offset += 3;
                                    offset = WriteRightText(graphic, offset + 3, fVerdana8, "(Thẻ thành viên còn: " + text + ")");
                                }
                            }
                        }
                    }

                    //Visa, master
                    cash = order.getPaymentEditViewModels()
                        .Where(p => p.Type == (int)PaymentTypeEnum.Card
                                    || p.Type == (int)PaymentTypeEnum.VisaCard
                                    || p.Type == (int)PaymentTypeEnum.MasterCard)
                        .Sum(p => p.Amount);
                    if (cash > 0)
                    {
                        offset += 3;
                        WriteLeftText(graphic, offset + 3, fVerdana8, "THẺ:", 5);
                        text = cash.ToString("N0");
                        offset = WriteRightText(graphic, offset + 3, fVerdana8, text);
                    }

                    //MoMo
                    cash = order.getPaymentEditViewModels()
                        .Where(p => p.Type == (int)PaymentTypeEnum.MoMo)
                        .Sum(p => p.Amount);
                    if (cash > 0)
                    {
                        offset += 3;
                        WriteLeftText(graphic, offset + 3, fVerdana8, "MOMO:", 5);
                        text = cash.ToString("N0");
                        offset = WriteRightText(graphic, offset + 3, fVerdana8, text);
                    }

                    cash = order.getPaymentEditViewModels()
                        .Where(p => p.Type == (int)PaymentTypeEnum.ZaloPay)
                        .Sum(p => p.Amount);
                    if (cash > 0)
                    {
                        offset += 3;
                        WriteLeftText(graphic, offset + 3, fVerdana8, PaymentTypeEnum.ZaloPay.GetDisplayName() + ":", 5);
                        text = cash.ToString("N0");
                        offset = WriteRightText(graphic, offset + 3, fVerdana8, text);
                    }

                    //Khác
                    cash = order.getPaymentEditViewModels()
                        .Where(p => p.Type == (int)PaymentTypeEnum.AccountReceivable
                                    || p.Type == (int)PaymentTypeEnum.Other
                                    || p.Type == (int)PaymentTypeEnum.Voucher)
                        .Sum(p => p.Amount);
                    if (cash > 0)
                    {
                        offset += 3;
                        WriteLeftText(graphic, offset + 3, fVerdana8, "KHÁC:", 5);
                        text = cash.ToString("N0");
                        offset = WriteRightText(graphic, offset + 3, fVerdana8, text);
                    }
                }
                else if (order.OrderType == (int)OrderTypeEnum.OrderCard)
                {
                    var accountCredit = currentOrderManager.getCurrentCustomerModel()
                        .Accounts.FirstOrDefault(a => a.Type == (int)CardAccountTypeEnum.CreditAccount);
                    if (accountCredit != null)
                    {
                        if (accountCredit.Balance != null)
                        {
                            var cash2 = (decimal)((accountCredit.Balance ?? 0) + final);
                            text = cash2.ToString("N0");

                            offset += 3;
                            offset = WriteRightText(graphic, offset + 3, fVerdana8, "(Thẻ thành viên còn: " + text + ")");
                        }
                    }
                }

                // Exchange.
                //Passio

                var returnMoney = order.getPaymentEditViewModels().Where(p => p.Amount < 0).Sum(p => p.Amount);
                text = Math.Abs(returnMoney).ToString("N0");
                offset += 3;
                WriteLeftText(graphic, offset + 2, fVerdana8B, "TIỀN TRẢ LẠI (VNĐ):", 5);


                //Passio
                offset = WriteRightText(graphic, offset + 2, fVerdana8B, text);


                //offset = DrawSolidLine(graphic, offset + 2);
                //offset = DrawSolidLine(graphic, offset + 2);

                // Wifi.
                if (MainForm.StoreInfo.IsShowWifiInfo.Trim().ToLower() == "true")
                {
                    text = "WIFI: " + MainForm.StoreInfo.WifiName;
                    offset = WriteLeftText(graphic, offset + 5, fVerdana8, text, 5);

                    if (MainForm.StoreInfo.IsGeneratePassWifi.Trim().ToLower() == "true")
                    {
                        var passWifi = "";
                        if (!currentOrderManager.hasOrder())
                        {
                            passWifi = ApiThirdParty.GenerateWifiPassForLocation(MainForm.StoreInfo.WiSkyLocationId.Trim(), null);
                        }
                        else
                        {
                            passWifi = currentOrderManager.getOrderEditViewModel().PasswordWifi;

                            if (string.IsNullOrWhiteSpace(passWifi))
                            {
                                passWifi = ApiThirdParty.GenerateWifiPassForLocation(MainForm.StoreInfo.WiSkyLocationId.Trim(), currentOrderManager.getOrderEditViewModel().CheckInDate);
                                currentOrderManager.getOrderEditViewModel().PasswordWifi = passWifi;
                            }
                        }
                        text = "PASS: " + passWifi;
                    }
                    else
                    {
                        text = "PASS: " + MainForm.StoreInfo.WifiPassword;
                    }
                    offset = WriteLeftText(graphic, offset + 5, fVerdana8, text, 5);
                }
            }
            else
            {
                var cash = order.getPaymentEditViewModels()
                    .Where(p => p.Type == (int)PaymentTypeEnum.MemberPayment)
                    .Sum(p => p.Amount);
                if (cash > 0)
                {
                    offset += 3;
                    WriteLeftText(graphic, offset + 3, fVerdana8, "THẺ THÀNH VIÊN:", 5);
                    text = cash.ToString("N0");
                    offset = WriteRightText(graphic, offset + 3, fVerdana8, text);

                    if (!currentOrderManager.isCurrentCustomerModelEmpty())
                    {
                        var accountCredit = currentOrderManager.getCurrentCustomerModel()
                            .Accounts.FirstOrDefault(a => a.Type == (int)CardAccountTypeEnum.CreditAccount);
                        if (accountCredit != null)
                        {
                            if (accountCredit.Balance != null)
                            {
                                var cash2 = (decimal)accountCredit.Balance;
                                text = cash2.ToString("N0");

                                offset += 3;
                                offset = WriteRightText(graphic, offset + 3, fVerdana8, "(Thẻ thành viên còn: " + text + ")");
                            }
                        }
                    }
                }
                offset = WriteCenterText(graphic, offset + 12, fVerdana13B, "Thông tin khách hàng");
                text = string.Format("Khách hàng:\t{0}", order.DeliveryCustomer);
                offset = WriteLeftText(graphic, offset + 7, fVerdana8, text);
                text = string.Format("Điện thoại:\t{0}", order.DeliveryPhone);
                offset = WriteLeftText(graphic, offset + 7, fVerdana8, text);
                text = string.Format("Địa chỉ:\t{0}", order.DeliveryAddress);
                offset = WriteLeftText(graphic, offset + 7, fVerdana8, text);
                text = string.Format("Ghi chú:\t{0}", order.Notes);
                offset = WriteLeftText(graphic, offset + 7, fVerdana8, text);
            }

            // Thankyou.
            if (MainForm.StoreInfo.EndingTextOnBill != null)
            {
                var line = "---------------";
                offset = WriteCenterText(graphic, offset + 5, fVerdana8B, line);
                //offset = DrawDashLine(graphic, offset + 5);
                string[] splitEndText = MainForm.StoreInfo.EndingTextOnBill.Split('|');
                foreach (string s in splitEndText)
                {
                    var str = s.Trim();
                    offset = WriteCenterText(graphic, offset + 5, fVerdana8, str);
                }
            }

            var momo = false;
            //if (MainForm.StoreInfo.MomoEnable.Trim().ToLower() == "true")
            //{
            //    var momoCash = order.getPaymentEditViewModels()
            //        .Where(p => p.Type == (int)PaymentTypeEnum.MoMo)
            //        .Sum(p => p.Amount);
            //    if (momoCash > 0)
            //    {       
            //        momo = true;
            //        var serviceId = "passio";
            //        var dateTime = order.CheckInDate;
            //        var billId = order.OrderCode;
            //        var amount = momoCash.ToString();
            //        var description = "";
            //        offset = DrawQRCodeMoMo(graphic, offset + 15, serviceId, billId, amount, description, dateTime);

            //        var momoTxt = "QR Code MoMo";
            //        offset = WriteCenterText(graphic, offset + 10, fVerdana8B, momoTxt);
            //    }
            //}

            if (!momo)
            {
                if (MainForm.StoreInfo.QRCodeEnable.Trim().ToLower() == "true")
                {
                    text = MainForm.StoreInfo.QRCodeURL.ToString();
                    offset = DrawQRCode(graphic, offset + 15, text);

                    text = MainForm.StoreInfo.QRCodeDescription.ToString();
                    offset = WriteCenterText(graphic, offset + 10, fVerdana8B, text);
                }
            }


            offset = offset + 10;

            // End Line
            offset = DrawDashLine(graphic, offset + 5);

            return MarginTop + offset + 50;
        }

        private int CreateMomoReceipt(Graphics graphic, OrderEditViewModel order)
        {
            var fVerdana9B = new Font("Verdana", 9, FontStyle.Bold);
            var fVerdana8 = new Font("Verdana", 8, FontStyle.Regular);
            var fVerdana6 = new Font("Verdana", 6, FontStyle.Regular);
            var fVerdana8B = new Font("Verdana", 8, FontStyle.Bold);
            var fVerdana13B = new Font("Verdana", 13, FontStyle.Bold);
            var fVerdana10B = new Font("Verdana", 10, FontStyle.Bold);
            var fCourier9B = new Font("Courier New", 9, FontStyle.Bold);

            int offset = 0;

            // Logo.
            offset = DrawLogo(graphic, offset);

            // Address.
            if (MainForm.StoreInfo.TerminalAddress != null)
            {
                string[] splitAddress = MainForm.StoreInfo.TerminalAddress.Split('|');
                foreach (string s in splitAddress)
                {
                    offset = WriteCenterText(graphic, offset + 10, fVerdana9B, s);
                }
            }

            // Hotline.
            var hotline = string.Format("Hotline Delivery: {0}", MainForm.StoreInfo.HotLine);
            offset = WriteCenterText(graphic, offset + 7, fVerdana9B, hotline);

            // Title.
            if (order.OrderType == (int)OrderTypeEnum.Delivery)
            {
                offset = WriteCenterText(graphic, offset + 12, fVerdana13B, "PHIẾU TẠM TÍNH");
            }
            else
            {
                offset = WriteCenterText(graphic, offset + 12, fVerdana13B, "PHIẾU THANH TOÁN");
            }

            // Time.

            //var time = UtcDateTime.Now().ToString("dd/MM/yyyy  hh:mm:sstt");
            var time = order.CheckInDate.ToString("dd/MM/yyyy  hh:mm:sstt");
            offset = WriteCenterText(graphic, offset + 5, fVerdana8, time);

            // Cashier.
            var text = string.Format("NHÂN VIÊN:\t{0}", order.CheckInPerson);
            offset = WriteLeftText(graphic, offset + 7, fVerdana8, text);

            //In lan thu
            //var countPrint = string.Format("PRINT:\t{0}", order.TotalInvoicePrint.ToString()); 
            //offset = WriteLeftText(graphic, offset + 2, fVerdana8, countPrint);

            var countPrint = "PRINT: " + order.TotalInvoicePrint.ToString();

            // ID.
            text = MainForm.StoreInfo.OrderCodeText + string.Format(":\t{0}", order.OrderCode);
            text = text + "  " + countPrint;
            offset = WriteLeftText(graphic, offset + 2, fVerdana8, text);

            if (string.IsNullOrEmpty(order.TableNumber))
            {
                var tableViewModel
                    = Program.context.getAllTables().LastOrDefault(t => t.Id == order.TableId);

                if (tableViewModel != null)
                    order.TableNumber = tableViewModel.Number;
            }

            var textOnline = MainForm.StoreInfo.OnlineOrderText;
            // Table.
            var textTakeAway = MainForm.StoreInfo.TakeAwayText + string.Format(": {0}",
                order.TableId == null ? " - " + textOnline : order.TableNumber);
            var textAtStore = MainForm.StoreInfo.AtStoreText + string.Format(":\t\t{0}",
                order.TableId == null ? " - " + textOnline : order.TableNumber);
            var textDelivery = MainForm.StoreInfo.DeliveryText;
            //text = _order.OrderType == (int)OrderType.TakeAway ? textTakeAway : textAtStore;

            if (order.OrderType == (int)OrderTypeEnum.TakeAway)
            {
                text = textTakeAway;
            }
            else if (order.OrderType == (int)OrderTypeEnum.AtStore)
            {
                text = textAtStore;
            }
            else if (order.OrderType == (int)OrderTypeEnum.Delivery ||
                     order.DeliveryStatus == (int)DeliveryStatusEnum.Delivery)
            {
                text = textDelivery;
            }
            else
            {
                text = "";
            }


            var sortedOrderDetailList = GetSortedValidOrderDetail(order);

            offset = WriteLeftText(graphic, offset + 3, fVerdana13B, text);

            // Line 1.
            offset = DrawSolidLine(graphic, offset + 2);
            #region TTH
            foreach (OrderDetailEditViewModel orderDetailEditViewModel in sortedOrderDetailList)
            {
                var isExtraProduct = IsExtraProduct(orderDetailEditViewModel.ProductCode);
                if (!isExtraProduct)
                {
                    {
                        string productName = orderDetailEditViewModel.ProductName;
                        int charPerLine = 27;
                        if (productName.Length > charPerLine)
                        {
                            //productName = productName.Insert(28, "\n");
                            var multipleLines = this.BreakLines(productName, charPerLine);
                            offset += 10;
                            foreach (var line in multipleLines)
                            {
                                offset = WriteLeftText(graphic, offset, fCourier9B, line.ToUpper(), 0);
                            }
                        }
                        else
                        {
                            text = string.Format("{0}", productName.ToUpper());
                            offset = WriteLeftText(graphic, offset + 10, fCourier9B, text, 0);
                        }

                        //Origin
                        //offset = WriteLeftText(graphic, offset + 4, fCourier9B, text, ProductNameIndent);

                        var indentQuantity = 15;
                        var indentUnitPrice = 30;
                        if (orderDetailEditViewModel.Quantity > 99)
                        {
                            indentQuantity += 9;
                            indentUnitPrice += 7;
                            if (orderDetailEditViewModel.Quantity > 999)
                            {
                                indentQuantity += 9;
                                indentUnitPrice += 7;
                            }
                        }

                        // ProductViewModel amount price.
                        WriteLeftText(graphic, offset + 2, fCourier9B, orderDetailEditViewModel.Quantity.ToString(), 0);
                        WriteLeftText(graphic, offset + 2, fCourier9B, "x", indentQuantity);

                        // Price
                        WriteLeftText(graphic, offset + 2, fCourier9B, orderDetailEditViewModel.UnitPrice.ToString("N0"), indentUnitPrice);

                        // Total.
                        var total = orderDetailEditViewModel.TotalAmount;
                        offset = WriteRigth64Text(graphic, offset + 2, fCourier9B, total.ToString("N0"));
                    }
                }
                //ProductViewModel Child
                else
                {
                    text = string.Format("{0}", "+ " + orderDetailEditViewModel.ProductName);

                    //string itemQuantityChild = orderDetailEditViewModel.Quantity.ToString();
                    offset = WriteLeftText(graphic, offset + 4, fCourier9B, text /*+ " (x " + itemQuantityChild + ")"*/, 40);

                    // ProductViewModel amount price.
                    WriteLeftText(graphic, offset + 2, fCourier9B, orderDetailEditViewModel.Quantity.ToString(), 55);
                    WriteLeftText(graphic, offset + 2, fCourier9B, "x", 70);

                    // Price
                    WriteLeftText(graphic, offset + 2, fCourier9B, orderDetailEditViewModel.UnitPrice.ToString("N0"), 85);

                    // Total.
                    var total = orderDetailEditViewModel.TotalAmount;
                    offset = WriteRigth64Text(graphic, offset + 2, fCourier9B, total.ToString("N0"));
                }

                if (orderDetailEditViewModel.Discount > 0)
                {
                    // Discount.
                    text = string.Format("-{0}", orderDetailEditViewModel.Discount.ToString("N0"));
                    //text = "discount";
                    WriteCenterTextAlignRight(graphic, offset, fCourier9B, text);

                    // Payment.
                    offset = WriteRigth64Text(graphic, offset, fCourier9B, orderDetailEditViewModel.FinalAmount.ToString("N0"));
                }
            }

            #endregion

            // Line 2
            offset = DrawSolidLine(graphic, offset + 2);

            // TOTAL
            WriteLeftText(graphic, offset + 5, fVerdana8B, "TỔNG CỘNG", 5);
            offset = WriteRightText(graphic, offset + 5, fVerdana8B, order.SumFinalOrderDetail().ToString("N0"));

            // Promotion
            var appliedPromotions = new List<PromotionEditViewModel>();
            foreach (var mapping in order.OrderPromotionMappingEditViewModels)
            {
                var applied = appliedPromotions.FirstOrDefault(m => m.PromotionCode == mapping.PromotionCode);
                if (applied == null)
                {
                    var promotion = Program.context.getPromotions().FirstOrDefault(p => p.PromotionCode == mapping.PromotionCode);
                    if (promotion != null)
                    {
                        if (promotion.PromotionType != (int)PromotionTypeEnum.Internal)
                        {
                            appliedPromotions.Add(promotion);
                        }
                    }
                }
            }
            foreach (var od in order.OrderDetailEditViewModels)
            {
                foreach (var mapping in od.OrderDetailPromotionMappingEditViewModels)
                {
                    var applied = appliedPromotions.FirstOrDefault(m => m.PromotionCode == mapping.PromotionCode);
                    if (applied == null)
                    {
                        var promotion = Program.context.getPromotions().FirstOrDefault(p => p.PromotionCode == mapping.PromotionCode);
                        if (promotion != null)
                        {
                            if (promotion.PromotionType != (int)PromotionTypeEnum.Internal)
                            {
                                appliedPromotions.Add(promotion);
                            }
                        }
                    }
                }
            }

            if (appliedPromotions.Any())
            {
                offset += 3;
                WriteLeftText(graphic, offset + 3, fVerdana8, "Đã áp dụng khuyến mãi:");
                offset += 12;

                foreach (var promotion in appliedPromotions)
                {
                    text = promotion.Description;
                    offset = WriteRightText(graphic, offset + 3, fVerdana8, text);
                }
            }

            // Discount rate
            offset += 3;
            WriteLeftText(graphic, offset + 3, fVerdana8, "CHIẾT KHẤU (%):", 5);
            text = order.GetDiscountRate().ToString();
            offset = WriteRightText(graphic, offset + 3, fVerdana8, text + "%");

            // Discount
            WriteLeftText(graphic, offset + 2, fVerdana8, "GIẢM GIÁ (VNĐ):", 5);
            text = order.Discount.ToString("N0");
            offset = WriteRightText(graphic, offset + 2, fVerdana8, text);

            // VAT
            WriteLeftText(graphic, offset + 2, fVerdana8, "VAT:", 5);
            text = order.VATAmount.ToString("N0");
            offset = WriteRightText(graphic, offset + 2, fVerdana8, text);

            // FinalAmount.
            //Passio
            var orderVM = order.getPaymentEditViewModels().FirstOrDefault();
            PaymentTypeEnum orderTypeEnum = 0;
            if (orderVM != null)
            {
                orderTypeEnum = (PaymentTypeEnum)orderVM.Type;
            }
            string strThanhToan = "THANH TOÁN({0}):";
            if ((int)orderTypeEnum > 20)
            {
                strThanhToan = string.Format(strThanhToan, orderTypeEnum.ToString());
            }
            else
            {
                strThanhToan = "THANH TOÁN:";
            }
            WriteLeftText(graphic, offset + 2, fVerdana10B, strThanhToan, 5);

            //text = order.OrderPayment.FinalPayment.ToString("N0");
            var final = order.FinalAmount + order.VATAmount;
            text = final.ToString("N0");
            //PAssio
            offset = WriteRightText(graphic, offset + 2, fVerdana10B, text);

            // Line 3.
            offset = DrawDashLine(graphic, offset + 5);

            if (order.OrderType != (int)OrderTypeEnum.Delivery)
            {
                // Recieved.
                WriteLeftText(graphic, offset + 5, fVerdana8B, "KHÁCH TRẢ TỔNG CỘNG(VNĐ):", 5);
                //Tiền khách trả
                text = order.GuestPayment.ToString("N0");
                offset = WriteRightText(graphic, offset + 5, fVerdana8B, text);

                //Loại thanh toán

                // Exchange.
                //Passio

                //offset = DrawSolidLine(graphic, offset + 2);
                //offset = DrawSolidLine(graphic, offset + 2);

                // Wifi.
                if (MainForm.StoreInfo.IsShowWifiInfo.Trim().ToLower() == "true")
                {
                    text = "WIFI: " + MainForm.StoreInfo.WifiName;
                    offset = WriteLeftText(graphic, offset + 5, fVerdana8, text, 5);

                    if (MainForm.StoreInfo.IsGeneratePassWifi.Trim().ToLower() == "true")
                    {
                        var passWifi = "";
                        if (!currentOrderManager.hasOrder())
                        {
                            passWifi = ApiThirdParty.GenerateWifiPassForLocation(MainForm.StoreInfo.WiSkyLocationId.Trim(), null);
                        }
                        else
                        {
                            passWifi = currentOrderManager.getOrderEditViewModel().PasswordWifi;

                            if (string.IsNullOrWhiteSpace(passWifi))
                            {
                                passWifi = ApiThirdParty.GenerateWifiPassForLocation(MainForm.StoreInfo.WiSkyLocationId.Trim(), currentOrderManager.getOrderEditViewModel().CheckInDate);
                                currentOrderManager.getOrderEditViewModel().PasswordWifi = passWifi;
                            }
                        }
                        text = "PASS: " + passWifi;
                    }
                    else
                    {
                        text = "PASS: " + MainForm.StoreInfo.WifiPassword;
                    }
                    offset = WriteLeftText(graphic, offset + 5, fVerdana8, text, 5);
                }
            }
            else
            {
                offset = WriteCenterText(graphic, offset + 12, fVerdana13B, "Thông tin khách hàng");
                text = string.Format("Khách hàng:\t{0}", order.DeliveryCustomer);
                offset = WriteLeftText(graphic, offset + 7, fVerdana8, text);
                text = string.Format("Điện thoại:\t{0}", order.DeliveryPhone);
                offset = WriteLeftText(graphic, offset + 7, fVerdana8, text);
                text = string.Format("Địa chỉ:\t{0}", order.DeliveryAddress);
                offset = WriteLeftText(graphic, offset + 7, fVerdana8, text);
                text = string.Format("Ghi chú:\t{0}", order.Notes);
                offset = WriteLeftText(graphic, offset + 7, fVerdana8, text);
            }

            // Thankyou.
            if (MainForm.StoreInfo.EndingTextOnBill != null)
            {
                var line = "---------------";
                offset = WriteCenterText(graphic, offset + 5, fVerdana8B, line);
                //offset = DrawDashLine(graphic, offset + 5);
                string[] splitEndText = MainForm.StoreInfo.EndingTextOnBill.Split('|');
                foreach (string s in splitEndText)
                {
                    var str = s.Trim();
                    offset = WriteCenterText(graphic, offset + 5, fVerdana8, str);
                }
            }

            //var serviceId = "passio";
            //var paymentType = Program.context.getCurrentOrderManager().paymentType;
            //var dateTime = order.CheckInDate;
            //var billId = order.OrderCode;
            //var amount = final.ToString();
            //var description = "";
            ////MoMo
            //var partnerPaymentTxt = "";
            //if (MainForm.StoreInfo.SkyConnectEnable.Trim().ToLower() == "true")
            //{

            //    if (paymentType == PaymentTypeEnum.MoMo)
            //    {
            //        if (MainForm.StoreInfo.MomoEnable.Trim().ToLower() == "true")
            //        {
            //            offset = SkyConnectDrawQRCode(graphic, offset + 15, billId, amount, dateTime);
            //            partnerPaymentTxt = "QR Code MoMo";

            //        }
            //    }

            //    //Zalo
            //    if (paymentType == PaymentTypeEnum.Zalo)
            //    {
            //        if (MainForm.StoreInfo.ZaloEnable.Trim().ToLower() == "true")
            //        {
            //            offset = SkyConnectDrawQRCode(graphic, offset + 15, billId, amount, dateTime);
            //            partnerPaymentTxt = "QR Code Zalo";
            //        }

            //    }

            //}
            //else
            //{
            //    offset = DrawQRCodeMoMo(graphic, offset + 15,
            //       serviceId, billId, amount, description, dateTime);

            //    partnerPaymentTxt = "QR Code MoMo";
            //}

            //offset = WriteCenterText(graphic, offset + 10, fVerdana8B, partnerPaymentTxt);

            //offset = offset + 10;

            // End Line
            offset = DrawDashLine(graphic, offset + 5);

            return MarginTop + offset + 50;
        }

        private void CreateWifiPassword(Graphics graphic, OrderEditViewModel order = null)
        {
            var fVerdana9B = new Font("Verdana", 9, FontStyle.Bold);
            var fVerdana8 = new Font("Verdana", 8, FontStyle.Regular);
            var fVerdana6 = new Font("Verdana", 6, FontStyle.Regular);
            var fVerdana8B = new Font("Verdana", 8, FontStyle.Bold);
            var fVerdana13B = new Font("Verdana", 13, FontStyle.Bold);
            var fVerdana10B = new Font("Verdana", 10, FontStyle.Bold);
            var fCourier9B = new Font("Courier New", 9, FontStyle.Bold);

            int offset = 0;

            // Logo.
            offset = DrawLogo(graphic, offset);

            // Address.
            if (MainForm.StoreInfo.TerminalAddress != null)
            {
                string[] splitAddress = MainForm.StoreInfo.TerminalAddress.Split('|');
                foreach (string s in splitAddress)
                {
                    offset = WriteCenterText(graphic, offset + 10, fVerdana9B, s);
                }
            }

            // Hotline.
            var hotline = string.Format("Hotline Delivery: {0}", MainForm.StoreInfo.HotLine);
            offset = WriteCenterText(graphic, offset + 7, fVerdana9B, hotline);

            // Title.
            offset = WriteCenterText(graphic, offset + 12, fVerdana13B, "PHIẾU IN PASS WIFI");

            // Time.

            //var time = UtcDateTime.Now().ToString("dd/MM/yyyy  hh:mm:sstt");
            var time = "";
            if (order != null)
            {
                time = order.CheckInDate.ToString("dd/MM/yyyy  hh:mm:sstt");
            }
            else
            {
                time = DateTime.Now.ToString("dd/MM/yyyy  hh:mm:sstt");
            }
            offset = WriteCenterText(graphic, offset + 5, fVerdana8, time);


            var text = "";
            if (order != null)
            {
                text = string.Format("NHÂN VIÊN:\t{0}", order.CheckInPerson);
                offset = WriteLeftText(graphic, offset + 7, fVerdana8, text);

                text = MainForm.StoreInfo.OrderCodeText + string.Format(":\t{0}", order.OrderCode);
                offset = WriteLeftText(graphic, offset + 2, fVerdana8, text);
            }

            text = "WIFI: " + MainForm.StoreInfo.WifiName;
            offset = WriteLeftText(graphic, offset + 5, fVerdana8, text, 5);

            if (MainForm.StoreInfo.IsGeneratePassWifi.Trim().ToLower() == "true")
            {
                var passWifi = "";
                if (order == null)
                {
                    passWifi = ApiThirdParty.GenerateWifiPassForLocation(MainForm.StoreInfo.WiSkyLocationId.Trim(), null);
                }
                else
                {
                    passWifi = order.PasswordWifi;

                    if (string.IsNullOrWhiteSpace(passWifi))
                    {
                        passWifi = ApiThirdParty.GenerateWifiPassForLocation(MainForm.StoreInfo.WiSkyLocationId.Trim(), order.CheckInDate);
                        order.PasswordWifi = passWifi;
                    }
                }
                text = "PASS: " + passWifi;
            }
            else
            {
                text = "PASS: " + MainForm.StoreInfo.WifiPassword;
            }
            offset = WriteLeftText(graphic, offset + 5, fVerdana8, text, 5);

            if (MainForm.StoreInfo.EndingTextOnBill != null)
            {
                var line = "---------------";
                offset = WriteCenterText(graphic, offset + 5, fVerdana8B, line);
                //offset = DrawDashLine(graphic, offset + 5);
                string[] splitEndText = MainForm.StoreInfo.EndingTextOnBill.Split('|');
                foreach (string s in splitEndText)
                {
                    var str = s.Trim();
                    offset = WriteCenterText(graphic, offset + 5, fVerdana8, str);
                }
            }
        }

        /// <summary>
        /// Create cook bill for main dish
        /// </summary>
        /// <param name="graphic"></param>
        /// <param name="order"></param>
        /// <param name="isPrintAllOrderDetail"></param>
        private void CreateCookBill(Graphics graphic, OrderEditViewModel order, bool isPrintAllOrderDetail)
        {
            int charPerLine = 27;

            var fVerdana9B = new Font("Verdana", 9, FontStyle.Bold);
            var fVerdana8 = new Font("Verdana", 10, FontStyle.Regular);
            var fVerdana6 = new Font("Verdana", 6, FontStyle.Regular);
            var fVerdana8B = new Font("Verdana", 8, FontStyle.Bold);
            var fVerdana13B = new Font("Verdana", 13, FontStyle.Bold);
            var fVerdana10B = new Font("Verdana", 9, FontStyle.Bold);
            var fCourier10B = new Font("Courier New", 10, FontStyle.Bold);
            var fontItem = new Font("Courier New", 9, FontStyle.Bold);

            var offset = 0;

            //            var fontItem = new Font("Verdana", 12, FontStyle.Regular);
            //var fontItem = new Font("Courier New", 11, FontStyle.Bold);
            var penSolid1 = new Pen(Color.Black);

            var text = UtcDateTime.Now().ToString("dd/MM/yyyy HH:mm");
            graphic.DrawString(text, fontItem, Brushes.Black, new PointF(120, MarginTop + offset));
            offset += (int)fontItem.GetHeight();

            // Table.
            offset += 3;
            var textTakeAway = string.Format("MANG ĐI {0}",
                order.TableId == null ? " - Online order" : "");
            var textAtStore = string.Format("TẠI QUÁN");
            var textDelivery = string.Format("DELIVERY {0}",
                order.TableId == null ? " - Online order" : "");
            //text = _order.OrderType == (int)OrderType.TakeAway ? textTakeAway : textAtStore; 
            if (order.OrderType == (int)OrderTypeEnum.TakeAway)
            {
                text = textTakeAway;
            }
            else if (order.OrderType == (int)OrderTypeEnum.AtStore)
            {
                text = textAtStore;
            }
            else if (order.DeliveryStatus == (int)DeliveryStatusEnum.Delivery ||
                order.OrderType == (int)OrderTypeEnum.Delivery)
            {
                text = textDelivery;
            }
            else
            {
                text = "";
            }

            var fontTable = new Font("Courier New", 14, FontStyle.Bold);
            graphic.DrawString(text, fontTable, Brushes.Black, new PointF(MarginLeft, MarginTop + offset));
            offset += (int)fontTable.GetHeight();

            var tableFont = new Font("Courier New", 30, FontStyle.Bold);
            graphic.DrawString(order.TableNumber, tableFont, Brushes.Black, new PointF(MarginLeft, MarginTop + offset));
            offset += (int)tableFont.GetHeight();


            text = string.Format("Số bill:\t{0}", order.OrderCode);
            graphic.DrawString(text, fVerdana10B, Brushes.Black, new PointF(MarginLeft, MarginTop + offset));
            offset += (int)fVerdana10B.GetHeight();

            text = string.Format("P.Vu\t{0}", order.CheckInPerson);
            graphic.DrawString(text, fontItem, Brushes.Black, new PointF(MarginLeft, MarginTop + offset));
            offset += (int)fontItem.GetHeight();

            offset += 2;
            graphic.DrawLine(penSolid1, MarginLeft, MarginTop + offset, MarginRight, MarginTop + offset);
            offset += 1;


            List<OrderDetailEditViewModel> sortedOrderDetailList = new List<OrderDetailEditViewModel>();
            if (isPrintAllOrderDetail)
            {
                sortedOrderDetailList = GetSortedValidOrderDetail(order); //Get alls valid OrderEditViewModel details to 
            }
            else
            {
                sortedOrderDetailList = GetSortedNewOrderDetail(order); //Lấy tất cả New OrderDetailViewModel đem đi in
            }

            int count = 0;

            foreach (var item in sortedOrderDetailList)
            {
                if (item.ParentId == null) //Is not extra product
                {
                    // ProductViewModel amount price.
                    WriteLeftText(graphic, offset, fontItem, item.Quantity.ToString(), 0);
                    var indent = 20;
                    if (item.Quantity > 99)
                    {
                        indent = 25;
                        charPerLine = 24;
                    }
                    string productName = item.ProductName;
                    if (productName.Length > charPerLine)
                    {
                        //productName = productName.Insert(28, "\n");
                        var multipleLines = this.BreakLines(productName, charPerLine);
                        foreach (var line in multipleLines)
                        {
                            WriteLeftText(graphic, offset, fontItem, line, indent);
                            offset += (int)fontItem.GetHeight() + 5;
                        }
                    }
                    else
                    {
                        //                            text = string.Format("{0}", productName.ToUpper());
                        //Text
                        WriteLeftText(graphic, offset, fontItem, productName, 20);
                        offset += (int)fontItem.GetHeight() + 5;
                    }

                    //                        WriteLeftText(graphic, offset, fontItem, productName, 20);
                    //                        offset += (int)fontItem.GetHeight() + 5;
                    count += item.Quantity;
                    if (item.Notes != null && item.Notes.Length <= 0) continue;
                    offset = WriteRightText(graphic, offset, fontItem, item.Notes);
                    offset += 5;

                }
                else
                {
                    WriteLeftText(graphic, offset, fontItem, "+", 25);
                    WriteLeftText(graphic, offset, fontItem,
                        item.Quantity + " " + item.ProductName + " (x " + item.ItemQuantity.ToString() + ")", 50);
                    offset += (int)fontItem.GetHeight() + 5;
                    if (item.Notes != null && item.Notes.Length <= 0) continue;
                    offset = WriteRightText(graphic, offset, fontItem, item.Notes);
                    offset += 5;
                }
            }


            offset += 2;
            graphic.DrawLine(penSolid1, MarginLeft, MarginTop + offset, MarginRight, MarginTop + offset);
            offset += 3;

            text = string.Format("Tổng số\t{0}", count);
            graphic.DrawString(text, fontItem, Brushes.Black, new PointF(MarginLeft, MarginTop + offset));
            //In ra tổng tiền
            text = string.Format("Tổng tiền\t{0}", order.TotalAmount);
            graphic.DrawString(text, fontItem, Brushes.Black, new PointF(MarginLeft, MarginTop + offset));

            var notes = "Ghi chú: " + order.Notes;
            if (!string.IsNullOrWhiteSpace(notes))
            {
                charPerLine = 20;
                offset += (int)fontItem.GetHeight() + 2;
                graphic.DrawLine(penSolid1, MarginLeft, MarginTop + offset, MarginRight, MarginTop + offset);
                offset += 3;

                if (notes.Length > charPerLine)
                {
                    var multipleLines = this.BreakLines(notes, charPerLine);
                    foreach (var line in multipleLines)
                    {
                        WriteLeftText(graphic, offset, fontItem, line.Trim(), 0);
                        offset += (int)fontItem.GetHeight() + 5;
                    }
                }
                else
                {
                    WriteLeftText(graphic, offset, fontItem, notes, 20);
                    offset += (int)fontItem.GetHeight() + 5;
                }
            }
        }

        private void CreateCookBillDetail(Graphics graphic, OrderEditViewModel order, OrderDetailViewModel orderDetail)
        {
            int charPerLine = 27;

            var fVerdana9B = new Font("Verdana", 9, FontStyle.Bold);
            var fVerdana8 = new Font("Verdana", 10, FontStyle.Regular);
            var fVerdana6 = new Font("Verdana", 6, FontStyle.Regular);
            var fVerdana8B = new Font("Verdana", 8, FontStyle.Bold);
            var fVerdana13B = new Font("Verdana", 13, FontStyle.Bold);
            var fVerdana10B = new Font("Verdana", 9, FontStyle.Bold);
            var fCourier10B = new Font("Courier New", 10, FontStyle.Bold);
            var fontItem = new Font("Courier New", 9, FontStyle.Bold);

            var offset = 0;

            //            var fontItem = new Font("Verdana", 12, FontStyle.Regular);
            //var fontItem = new Font("Courier New", 11, FontStyle.Bold);
            var penSolid1 = new Pen(Color.Black);

            var text = UtcDateTime.Now().ToString("dd/MM/yyyy HH:mm");
            graphic.DrawString(text, fontItem, Brushes.Black, new PointF(120, MarginTop + offset));
            offset += (int)fontItem.GetHeight();

            // Table.
            offset += 3;
            var textTakeAway = string.Format("MANG ĐI {0}",
                order.TableId == null ? " - Online order" : "");
            var textAtStore = string.Format("TẠI QUÁN");
            var textDelivery = string.Format("DELIVERY {0}",
                order.TableId == null ? " - Online order" : "");
            //text = _order.OrderType == (int)OrderType.TakeAway ? textTakeAway : textAtStore; 
            if (order.OrderType == (int)OrderTypeEnum.TakeAway)
            {
                text = textTakeAway;
            }
            else if (order.OrderType == (int)OrderTypeEnum.AtStore)
            {
                text = textAtStore;
            }
            else if (order.DeliveryStatus == (int)DeliveryStatusEnum.Delivery ||
                order.OrderType == (int)OrderTypeEnum.Delivery)
            {
                text = textDelivery;
            }
            else
            {
                text = "";
            }

            var fontTable = new Font("Courier New", 14, FontStyle.Bold);
            graphic.DrawString(text, fontTable, Brushes.Black, new PointF(MarginLeft, MarginTop + offset));
            offset += (int)fontTable.GetHeight();

            var tableFont = new Font("Courier New", 30, FontStyle.Bold);
            graphic.DrawString(order.TableNumber, tableFont, Brushes.Black, new PointF(MarginLeft, MarginTop + offset));
            offset += (int)tableFont.GetHeight();


            text = string.Format("Số bill:\t{0}", order.OrderCode);
            graphic.DrawString(text, fVerdana10B, Brushes.Black, new PointF(MarginLeft, MarginTop + offset));
            offset += (int)fVerdana10B.GetHeight();

            text = string.Format("P.Vu\t{0}", order.CheckInPerson);
            graphic.DrawString(text, fontItem, Brushes.Black, new PointF(MarginLeft, MarginTop + offset));
            offset += (int)fontItem.GetHeight();

            offset += 2;
            graphic.DrawLine(penSolid1, MarginLeft, MarginTop + offset, MarginRight, MarginTop + offset);
            offset += 1;
            WriteLeftText(graphic, offset, fontItem, orderDetail.Quantity.ToString(), 0);
            var indent = 20;
            if (orderDetail.Quantity > 99)
            {
                indent = 25;
                charPerLine = 24;
            }
            string productName = orderDetail.ProductName;
            if (productName.Length > charPerLine)
            {
                //productName = productName.Insert(28, "\n");
                var multipleLines = this.BreakLines(productName, charPerLine);
                foreach (var line in multipleLines)
                {
                    WriteLeftText(graphic, offset, fontItem, line, indent);
                    offset += (int)fontItem.GetHeight() + 5;
                }
            }
            else
            {
                //                            text = string.Format("{0}", productName.ToUpper());
                //Text
                WriteLeftText(graphic, offset, fontItem, productName, 20);
                offset += (int)fontItem.GetHeight() + 5;
            }

            //                        WriteLeftText(graphic, offset, fontItem, productName, 20);
            //                        offset += (int)fontItem.GetHeight() + 5;
            if (!string.IsNullOrEmpty(orderDetail.Notes))
            {
                offset = WriteRightText(graphic, offset, fontItem, orderDetail.Notes);
                offset += 5;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="graphic"></param>
        /// <param name="order"></param>
        /// <param name="isPrintAllOrderDetail"></param>
        private void CreateCookBillExtra(Graphics graphic, OrderEditViewModel order, bool isPrintAllOrderDetail, int? printGroup = null)
        {
            int charPerLine = 27;

            var fVerdana9B = new Font("Verdana", 9, FontStyle.Bold);
            var fVerdana8 = new Font("Verdana", 10, FontStyle.Regular);
            var fVerdana6 = new Font("Verdana", 6, FontStyle.Regular);
            var fVerdana8B = new Font("Verdana", 8, FontStyle.Bold);
            var fVerdana13B = new Font("Verdana", 13, FontStyle.Bold);
            var fVerdana10B = new Font("Verdana", 9, FontStyle.Bold);
            var fCourier10B = new Font("Courier New", 10, FontStyle.Bold);
            var fontItem = new Font("Courier New", 9, FontStyle.Bold);

            var offset = 0;

            //            var fontItem = new Font("Verdana", 12, FontStyle.Regular);
            //var fontItem = new Font("Courier New", 11, FontStyle.Bold);
            var penSolid1 = new Pen(Color.Black);

            var text = UtcDateTime.Now().ToString("dd/MM/yyyy HH:mm");
            graphic.DrawString(text, fontItem, Brushes.Black, new PointF(120, MarginTop + offset));
            offset += (int)fontItem.GetHeight();

            // Table.
            offset += 3;
            var textTakeAway = string.Format("MANG ĐI {0}",
                order.TableId == null ? " - Online order" : "");
            var textAtStore = string.Format("TẠI QUÁN");
            var textDelivery = string.Format("DELIVERY {0}",
                order.TableId == null ? " - Online order" : "");
            //text = _order.OrderType == (int)OrderType.TakeAway ? textTakeAway : textAtStore; 
            if (order.OrderType == (int)OrderTypeEnum.TakeAway)
            {
                text = textTakeAway;
            }
            else if (order.OrderType == (int)OrderTypeEnum.AtStore)
            {
                text = textAtStore;
            }
            else if (order.DeliveryStatus == (int)DeliveryStatusEnum.Delivery ||
                order.OrderType == (int)OrderTypeEnum.Delivery)
            {
                text = textDelivery;
            }
            else
            {
                text = "";
            }

            var fontTable = new Font("Courier New", 14, FontStyle.Bold);
            graphic.DrawString(text, fontTable, Brushes.Black, new PointF(MarginLeft, MarginTop + offset));
            offset += (int)fontTable.GetHeight();

            var tableFont = new Font("Courier New", 30, FontStyle.Bold);
            graphic.DrawString(order.TableNumber, tableFont, Brushes.Black, new PointF(MarginLeft, MarginTop + offset));
            offset += (int)tableFont.GetHeight();


            text = string.Format("Số bill:\t{0}", order.OrderCode);
            graphic.DrawString(text, fVerdana10B, Brushes.Black, new PointF(MarginLeft, MarginTop + offset));
            offset += (int)fVerdana10B.GetHeight();

            text = string.Format("P.Vu\t{0}", order.CheckInPerson);
            graphic.DrawString(text, fontItem, Brushes.Black, new PointF(MarginLeft, MarginTop + offset));
            offset += (int)fontItem.GetHeight();

            offset += 2;
            graphic.DrawLine(penSolid1, MarginLeft, MarginTop + offset, MarginRight, MarginTop + offset);
            offset += 1;


            List<OrderDetailEditViewModel> sortedOrderDetailList = new List<OrderDetailEditViewModel>();
            if (isPrintAllOrderDetail)
            {
                sortedOrderDetailList = GetSortedValidOrderDetail(order); //Get alls valid OrderEditViewModel details to 
            }
            else
            {
                sortedOrderDetailList = GetSortedNewOrderDetail(order); //Lấy tất cả New OrderDetailViewModel đem đi in
            }

            int count = 0;

            foreach (var item in sortedOrderDetailList)
            {
                if (item.ParentId == null) //Is not extra product
                {
                    // ProductViewModel amount price.
                    WriteLeftText(graphic, offset, fontItem, item.Quantity.ToString(), 0);
                    var indent = 20;
                    if (item.Quantity > 99)
                    {
                        indent = 25;
                        charPerLine = 24;
                    }
                    string productName = item.ProductName;
                    if (productName.Length > charPerLine)
                    {
                        //productName = productName.Insert(28, "\n");
                        var multipleLines = this.BreakLines(productName, charPerLine);
                        foreach (var line in multipleLines)
                        {
                            WriteLeftText(graphic, offset, fontItem, line, indent);
                            offset += (int)fontItem.GetHeight() + 5;
                        }
                    }
                    else
                    {
                        //                            text = string.Format("{0}", productName.ToUpper());
                        //Text
                        WriteLeftText(graphic, offset, fontItem, productName, 20);
                        offset += (int)fontItem.GetHeight() + 5;
                    }

                    //                        WriteLeftText(graphic, offset, fontItem, productName, 20);
                    //                        offset += (int)fontItem.GetHeight() + 5;
                    count += item.Quantity;
                    if (item.Notes != null && item.Notes.Length <= 0) continue;
                    //offset = WriteRightText(graphic, offset, fontItem, item.Notes);
                    //offset += 5;
                }
                else
                {
                    WriteLeftText(graphic, offset, fontItem, "+", 25);
                    WriteLeftText(graphic, offset, fontItem,
                        item.ItemQuantity + " " + item.ProductName, 50);
                    if (item.Notes != null && item.Notes.Length <= 0) continue;
                    offset = WriteRightText(graphic, offset, fontItem, item.Notes);
                }
            }


            offset += 2;
            graphic.DrawLine(penSolid1, MarginLeft, MarginTop + offset, MarginRight, MarginTop + offset);
            offset += 3;

            text = string.Format("Tổng số\t{0}", count);
            graphic.DrawString(text, fontItem, Brushes.Black, new PointF(MarginLeft, MarginTop + offset));

            var notes = "Ghi chú: " + order.Notes;
            if (!string.IsNullOrWhiteSpace(notes))
            {
                charPerLine = 20;
                offset += (int)fontItem.GetHeight() + 2;
                graphic.DrawLine(penSolid1, MarginLeft, MarginTop + offset, MarginRight, MarginTop + offset);
                offset += 3;

                if (notes.Length > charPerLine)
                {
                    var multipleLines = this.BreakLines(notes, charPerLine);
                    foreach (var line in multipleLines)
                    {
                        WriteLeftText(graphic, offset, fontItem, line.Trim(), 0);
                        offset += (int)fontItem.GetHeight() + 5;
                    }
                }
                else
                {
                    WriteLeftText(graphic, offset, fontItem, notes, 20);
                    offset += (int)fontItem.GetHeight() + 5;
                }
            }
        }
        /// <summary>
        /// Create cook bill for main dish
        /// </summary>
        /// <param name="graphic"></param>
        /// <param name="order"></param>
        /// <param name="isPrintAllOrderDetail"></param>
        private void CreateCookBillWithExtra(Graphics graphic, OrderEditViewModel order, bool isPrintAllOrderDetail, int mainOrderId, int mainOrderItemQuantity)
        {
            int charPerLine = 27;

            var fVerdana9B = new Font("Verdana", 9, FontStyle.Bold);
            var fVerdana8 = new Font("Verdana", 10, FontStyle.Regular);
            var fVerdana6 = new Font("Verdana", 6, FontStyle.Regular);
            var fVerdana8B = new Font("Verdana", 8, FontStyle.Bold);
            var fVerdana13B = new Font("Verdana", 13, FontStyle.Bold);
            var fVerdana10B = new Font("Verdana", 9, FontStyle.Bold);
            var fCourier10B = new Font("Courier New", 10, FontStyle.Bold);
            var fontItem = new Font("Courier New", 9, FontStyle.Bold);

            var offset = 0;

            //            var fontItem = new Font("Verdana", 12, FontStyle.Regular);
            //var fontItem = new Font("Courier New", 11, FontStyle.Bold);
            var penSolid1 = new Pen(Color.Black);

            //var text = UtcDateTime.Now().ToString("dd/MM/yyyy HH:mm");
            //graphic.DrawString(text, fontItem, Brushes.Black, new PointF(120, MarginTop + offset));
            //offset += (int)fontItem.GetHeight();

            // Table.
            offset += 3;

            //var text = _order.OrderType == (int)OrderType.TakeAway ? textTakeAway : textAtStore;
            string text;
            text = string.Format("Bàn:\t{0}", order.TableNumber);


            var fontTable = new Font("Courier New", 14, FontStyle.Bold);
            graphic.DrawString(text, fontTable, Brushes.Black, new PointF(MarginLeft, MarginTop + offset));
            offset += (int)fontTable.GetHeight();

            //var tableFont = new Font("Courier New", 30, FontStyle.Bold);
            //graphic.DrawString(order.TableNumber, tableFont, Brushes.Black, new PointF(MarginLeft, MarginTop + offset));
            //offset += (int)tableFont.GetHeight();

            text = string.Format("HĐ:{0}", order.OrderCode);
            graphic.DrawString(text, fCourier10B, Brushes.Black, new PointF(MarginLeft, MarginTop + offset));
            offset += (int)fVerdana10B.GetHeight();

            //text = string.Format("P.Vu\t{0}", order.CheckInPerson);
            //graphic.DrawString(text, fontItem, Brushes.Black, new PointF(MarginLeft, MarginTop + offset));
            //offset += (int)fontItem.GetHeight();

            offset += 2;
            graphic.DrawLine(penSolid1, MarginLeft, MarginTop + offset, MarginRight, MarginTop + offset);
            offset += 1;


            List<OrderDetailEditViewModel> sortedOrderDetailList = new List<OrderDetailEditViewModel>();
            if (isPrintAllOrderDetail)
            {
                sortedOrderDetailList = GetSortedValidOrderDetail(order); //Get alls valid OrderEditViewModel details to 
            }
            else
            {
                sortedOrderDetailList = GetSortedNewOrderDetail(order); //Lấy tất cả New OrderDetailViewModel đem đi in
            }

            sortedOrderDetailList = sortedOrderDetailList.Where(p => p.ParentId == mainOrderId || p.TmpDetailId == mainOrderId).ToList();

            int count = 0;

            foreach (var item in sortedOrderDetailList)
            {

                if (item.ParentId == null) //Is not extra product
                {
                    // ProductViewModel amount price.
                    WriteLeftText(graphic, offset, fontItem, (item.Quantity / item.Quantity).ToString(), 0);
                    var indent = 20;
                    if (item.Quantity > 99)
                    {
                        indent = 25;
                        charPerLine = 24;
                    }
                    string productName = item.ProductName;
                    if (productName.Length > charPerLine)
                    {
                        //productName = productName.Insert(28, "\n");
                        var multipleLines = this.BreakLines(productName, charPerLine);
                        foreach (var line in multipleLines)
                        {
                            WriteLeftText(graphic, offset, fontItem, line, indent);
                            offset += 2;
                        }
                    }
                    else
                    {
                        //text = string.Format("{0}", productName.ToUpper());
                        //Text
                        WriteLeftText(graphic, offset, fontItem, productName, 20);
                        offset += 2;
                    }

                    //                        WriteLeftText(graphic, offset, fontItem, productName, 20);
                    //                        offset += (int)fontItem.GetHeight() + 5;
                    count += item.Quantity;
                    if (item.Notes != null && item.Notes.Length <= 0) continue;
                    offset = WriteRightText(graphic, offset, fontItem, item.Notes);
                    offset += 5;
                }
                else
                {
                    WriteLeftText(graphic, offset, fontItem, "+", 25);
                    WriteLeftText(graphic, offset, fontItem,
                        item.ItemQuantity + " " + item.ProductName, 50);
                    offset += 2;
                    if (item.Notes != null && item.Notes.Length <= 0) continue;
                    offset = WriteRightText(graphic, offset, fontItem, item.Notes);
                }
            }


            offset += 2;
            graphic.DrawLine(penSolid1, MarginLeft, MarginTop + offset, MarginRight, MarginTop + offset);
            offset += 2;

            //text = string.Format("Tổng số\t{0}", count);
            //graphic.DrawString(text, fontItem, Brushes.Black, new PointF(MarginLeft, MarginTop + offset));

            var notes = "Ghi chú: " + order.Notes;
            //if (!string.IsNullOrWhiteSpace(notes))
            //{
            //    charPerLine = 20;
            //    offset += (int)fontItem.GetHeight() + 2;
            //    graphic.DrawLine(penSolid1, MarginLeft, MarginTop + offset, MarginRight, MarginTop + offset);
            //    offset += 3;

            //    if (notes.Length > charPerLine)
            //    {
            //        var multipleLines = this.BreakLines(notes, charPerLine);
            //        foreach (var line in multipleLines)
            //        {
            //            WriteLeftText(graphic, offset, fontItem, line.Trim(), 0);
            //            offset += (int)fontItem.GetHeight() + 5;
            //        }
            //    }
            //    else
            //    {
            //        WriteLeftText(graphic, offset, fontItem, notes, 20);
            //        offset += (int)fontItem.GetHeight() + 5;
            //    }
            //}
        }


        private void CreateCookingBill(Graphics graphic, List<OrderDetailEditViewModel> orderDetails,
                                        string orderCode, string tableNumber, string staffName,
                                        string note, int processItem, int totalItem)
        {
            int charPerLine = 27;

            var fVerdana9B = new Font("Verdana", 9, FontStyle.Bold);
            var fVerdana8 = new Font("Verdana", 10, FontStyle.Regular);
            var fVerdana6 = new Font("Verdana", 6, FontStyle.Regular);
            var fVerdana8B = new Font("Verdana", 8, FontStyle.Bold);
            var fVerdana13B = new Font("Verdana", 13, FontStyle.Bold);
            var fVerdana10B = new Font("Verdana", 9, FontStyle.Bold);
            var fCourier10B = new Font("Courier New", 10, FontStyle.Bold);
            var fontItem = new Font("Courier New", 9, FontStyle.Bold);

            var offset = 0;

            var penSolid1 = new Pen(Color.Black);

            var text = UtcDateTime.Now().ToString("dd/MM/yyyy HH:mm");
            graphic.DrawString(text, fontItem, Brushes.Black, new PointF(120, MarginTop + offset));
            offset += (int)fontItem.GetHeight();

            // Table.
            var tableFont = new Font("Courier New", 25, FontStyle.Bold);
            text = string.Format("Bàn:\t{0}", tableNumber);
            graphic.DrawString(text, tableFont, Brushes.Black, new PointF(MarginLeft, MarginTop + offset));
            offset += (int)tableFont.GetHeight();

            text = string.Format("Mã:\t{0}", orderCode);
            graphic.DrawString(text, fVerdana10B, Brushes.Black, new PointF(MarginLeft, MarginTop + offset));
            offset += (int)fVerdana10B.GetHeight();

            text = string.Format("P.Vu:\t{0}", staffName);
            graphic.DrawString(text, fontItem, Brushes.Black, new PointF(MarginLeft, MarginTop + offset));
            offset += (int)fontItem.GetHeight();

            offset += 2;
            graphic.DrawLine(penSolid1, MarginLeft, MarginTop + offset, MarginRight, MarginTop + offset);
            offset += 1;


            int count = 0;

            foreach (var item in orderDetails)
            {
                if (item.ParentId == null) //Is not extra product
                {
                    // ProductViewModel amount price.
                    WriteLeftText(graphic, offset, fontItem, item.Quantity.ToString(), 0);
                    var indent = 20;
                    if (item.Quantity > 99)
                    {
                        indent = 25;
                        charPerLine = 24;
                    }
                    string productName = item.ProductName;
                    if (productName.Length > charPerLine)
                    {
                        //productName = productName.Insert(28, "\n");
                        var multipleLines = this.BreakLines(productName, charPerLine);
                        foreach (var line in multipleLines)
                        {
                            WriteLeftText(graphic, offset, fontItem, line, indent);
                            offset += (int)fontItem.GetHeight() + 5;
                        }
                    }
                    else
                    {
                        WriteLeftText(graphic, offset, fontItem, productName, 20);
                        offset += (int)fontItem.GetHeight() + 5;
                    }

                    count += item.Quantity;
                    if (item.Notes != null && item.Notes.Length <= 0) continue;
                    offset = WriteRightText(graphic, offset, fontItem, item.Notes);
                    offset += 5;

                }
                else
                {
                    WriteLeftText(graphic, offset, fontItem, "+", 25);
                    WriteLeftText(graphic, offset, fontItem,
                        item.Quantity + " " + item.ProductName + " (x " + item.ItemQuantity.ToString() + ")", 50);
                    offset += (int)fontItem.GetHeight() + 5;
                    if (item.Notes != null && item.Notes.Length <= 0) continue;
                    offset = WriteRightText(graphic, offset, fontItem, item.Notes);
                    offset += 5;
                }
            }

            offset += 2;
            graphic.DrawLine(penSolid1, MarginLeft, MarginTop + offset, MarginRight, MarginTop + offset);
            offset += 3;

            text = string.Format("Còn lại:\t{0} / {1}", processItem, totalItem);
            graphic.DrawString(text, fontItem, Brushes.Black, new PointF(MarginLeft, MarginTop + offset));

            var strNote = "Ghi chú: " + note;
            if (!string.IsNullOrWhiteSpace(strNote))
            {
                charPerLine = 20;
                offset += (int)fontItem.GetHeight() + 2;
                graphic.DrawLine(penSolid1, MarginLeft, MarginTop + offset, MarginRight, MarginTop + offset);
                offset += 3;

                if (strNote.Length > charPerLine)
                {
                    var multipleLines = this.BreakLines(strNote, charPerLine);
                    foreach (var line in multipleLines)
                    {
                        WriteLeftText(graphic, offset, fontItem, line.Trim(), 0);
                        offset += (int)fontItem.GetHeight() + 5;
                    }
                }
                else
                {
                    WriteLeftText(graphic, offset, fontItem, strNote, 20);
                    offset += (int)fontItem.GetHeight() + 5;
                }
            }
        }

        private int CreateReportQuantity(Graphics graphic, StoreReportModel reportModel, string creator)
        {
            var fVerdana9B = new Font("Verdana", 9, FontStyle.Bold);
            var fVerdana8 = new Font("Verdana", 8, FontStyle.Regular);
            var fTimesNr9 = new Font("Times New Roman", 9, FontStyle.Regular);
            var fTimesNr9B = new Font("Times New Roman", 9, FontStyle.Bold);
            int offset = 0;

            // Logo.
            offset = DrawLogo(graphic, offset);

            // Address.
            offset = WriteCenterText(graphic, offset + 10, fVerdana9B, MainForm.StoreInfo.TerminalAddress == null ? "" : MainForm.StoreInfo.TerminalAddress.ToUpper());

            // Hotline.
            var hotline = string.Format("{0}", MainForm.StoreInfo.TerminalName);
            offset = WriteCenterText(graphic, offset + 7, fVerdana9B, hotline);

            // Title.
            offset = WriteCenterText(graphic, offset + 12, fVerdana9B, "BÁO CÁO BÁN HÀNG CHI TIẾT");

            // Time.
            //var time = UtcDateTime.Now().ToString("dd/MM/yyyy HH:mm");
            //if (reportModel.IsRangeReport)
            //{

            if (reportModel.FromDate.Date != reportModel.ToDate.Date)
            {
                var time = string.Format("{0}  -  {1}", reportModel.FromDate.ToString("dd/MM/yy"),
                    reportModel.ToDate.ToString("dd/MM/yy"));
                offset = WriteCenterText(graphic, offset + 5, fVerdana8, time);
            }
            else
            {
                var time = string.Format(reportModel.FromDate.ToString("dd/MM/yy"));
                offset = WriteCenterText(graphic, offset + 5, fVerdana8, time);
            }


            // Cashier.
            //var text = string.Format("NHÂN VIÊN:\t{0}\tCA {1}", _cashier, _reportModel.Session);
            var text = string.Format("NGƯỜI LẬP:\t{0}", creator);
            offset = WriteLeftText(graphic, offset + 7, fVerdana8, text);

            // Line 1.
            offset = DrawSolidLine(graphic, offset + 2);

            //double finalAmount = 0;
            int totalQuantity = 0;
            double totalDiscount = 0;
            int hotProduct = 0;
            int iceProduct = 0;
            int orderProduct = 0;

            foreach (var category in reportModel.Categories)
            {
                if (category.TotalQuantity > 0)
                {
                    string categoryName = category.CategoryName;
                    int charPerLine = 27;
                    var finalAmountCategoryReport = category.TotalAmount;
                    //- category.Discount;
                    if (MainForm.PosConfig.IsShowMoneyReport.Trim().ToLower() == "true")
                    {
                        WriteRigth64Text(graphic, offset + 15, fTimesNr9B,
                            string.Format("{0:n0}", finalAmountCategoryReport));
                    }

                    if (categoryName.Length > charPerLine)
                    {
                        //productName = productName.Insert(28, "\n");
                        var multipleLines = this.BreakLines(categoryName, charPerLine);
                        foreach (var line in multipleLines)
                        {
                            offset = WriteLeftText(graphic, offset + 15, fTimesNr9B, line.ToUpper(), 5);
                        }
                    }
                    else
                    {
                        //Text
                        offset = WriteLeftText(graphic, offset + 15, fTimesNr9B, categoryName.ToUpper(), 5);
                    }
                    //                    if (categoryName.Length > charPerLine)
                    //                    {
                    //                        categoryName = this.BreakLines(categoryName, charPerLine);
                    //                    }
                    //                    offset = WriteLeftText(graphic, offset + 15, fTimesNr9B, categoryName.ToUpper(), 5);
                    //Category quantity
                    totalQuantity += category.TotalQuantity;
                    WriteLeftText(graphic, offset + 2, fTimesNr9B, category.TotalQuantity.ToString(),
                        QuantityIndent);
                    //Discount
                    totalDiscount += category.Discount;
                    //WriteCenterTextAlignRight(graphic, offset + 2, fTimesNr9B, category.Discount.ToString("N0"));
                    //Final Amount 
                    //finalAmount += (category.TotalAmount - category.Discount );
                    offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, "");
                    // Line 2.
                    offset = DrawSolidLine(graphic, offset + 2, 1);


                    foreach (var productReportModel in category.ProductReportModels)
                    {
                        if (productReportModel.Quantity > 0)
                        {
                            // ProductViewModel name.
                            text = string.Format("{0} {1}", productReportModel.ProductCode,
                                productReportModel.ProductName.ToUpper());

                            var finalAmountProductReport = productReportModel.TotalAmount;
                            //- productReportModel.TotalDiscount;
                            if (MainForm.PosConfig.IsShowMoneyReport.Trim().ToLower() == "true")
                            {
                                WriteRigth64Text(graphic, offset + 3, fTimesNr9B,
                                     string.Format("{0:n0}", finalAmountProductReport));
                            }
                            //                            int charPerLine = 28;
                            if (text.Length > charPerLine)
                            {

                                //productName = productName.Insert(28, "\n");
                                var multipleLines = this.BreakLines(text, charPerLine);
                                foreach (var line in multipleLines)
                                {
                                    offset = WriteLeftText(graphic, offset + 4, fTimesNr9, line, 5);
                                }
                            }
                            else
                            {
                                //Text
                                offset = WriteLeftText(graphic, offset + 4, fTimesNr9, text, 5);
                            }

                            // ProductViewModel amount price.
                            WriteLeftText(graphic, offset + 2, fTimesNr9, productReportModel.Quantity.ToString(),
                                QuantityIndent);

                            // Discount.
                            //WriteCenterTextAlignRight(graphic, offset + 2, fTimesNr9,
                            //    productReportModel.TotalDiscount.ToString("N0"));

                            // Total.
                            offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9, "");

                            //productReportModel.ProductType
                            var code = productReportModel.ProductCode;
                            ProductViewModel tmpProduct = Program.context.getAllProducts().FirstOrDefault(p => p.Code == code);

                            if (tmpProduct != null)
                            {
                                //if (tmpProduct.Group == (int)ProductGroup.Hot)
                                //{
                                //    hotProduct += productReportModel.Quantity;
                                //}
                                //else if (tmpProduct.Group == (int)ProductGroup.Ice)
                                //{
                                //    iceProduct += productReportModel.Quantity;
                                //}
                                //else if (tmpProduct.Group == (int)ProductGroup.Other)
                                //{
                                //    orderProduct += productReportModel.Quantity;
                                //}

                                //TODO: remove HARDCODE
                                if (tmpProduct.Att2 != null)
                                {
                                    if (tmpProduct.Att2.Equals("Hot"))
                                    {
                                        hotProduct += productReportModel.Quantity;
                                    }
                                    if (tmpProduct.Att2.Equals("Cold"))
                                    {
                                        iceProduct += productReportModel.Quantity;
                                    }
                                    if (tmpProduct.Att2.Equals("Other"))
                                    {
                                        orderProduct += productReportModel.Quantity;
                                    }
                                }
                            }

                        }
                    }
                }
            }

            // Print category name.
            offset = WriteLeftText(graphic, offset + 4, fTimesNr9B, "TỔNG CỘNG", 5);

            // Line.
            offset = DrawSolidLine(graphic, offset + 5);

            //  total quantity.

            WriteLeftText(graphic, offset + 2, fTimesNr9B, totalQuantity.ToString() + " (sản phẩm)", QuantityIndent);

            //// Total Discount.

            //WriteCenterTextAlignRight(graphic, offset + 2, fTimesNr9B, totalDiscount.ToString("N0"));

            //// Total
            //offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, finalAmount.ToString("N0"));
            offset += 5;
            // Doanh số
            //WriteLeftText(graphic, offset + 2, fTimesNr9B, "Doanh số (chưa giảm):", 5);
            var totalAmount = reportModel.AtStoreReport.TotalAmount
                            + reportModel.TakeAwayReport.TotalAmount
                            + reportModel.DeliveryReport.TotalAmount
                            + reportModel.CardReport.TotalAmount;

            //offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, totalAmount.ToString("N0"));
            offset += 5;
            //Chi tiet doanh so
            if (totalAmount > 0)
            {
                text = string.Format(" - AtStore: {0} \n - TakeAway: {1} \n - Delivery: {2} \n - Card: {3})",
                                        reportModel.AtStoreReport.TotalAmount,
                                        reportModel.TakeAwayReport.TotalAmount,
                                        reportModel.DeliveryReport.TotalAmount,
                                        reportModel.CardReport.TotalAmount);
                //offset = WriteLeftText(graphic, offset + 2, fTimesNr9B, text, 5);
                //offset += 30;
            }
            // Discount on bill.
            //WriteLeftText(graphic, offset + 2, fTimesNr9B, "Giảm trên hóa đơn:", 5);
            var totalDiscountO = reportModel.AtStoreReport.OrderDiscountAmount
                                + reportModel.TakeAwayReport.OrderDiscountAmount
                                + reportModel.DeliveryReport.OrderDiscountAmount
                                + reportModel.CardReport.OrderDiscountAmount;

            if (totalDiscountO > 0)
            {
                text = "";
            }
            else
            {
                text = "";
            }
            //offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, text);
            offset += 5;
            //Chi tiet giảm hóa đơn
            text = string.Format("( {0} + {1} + {2} + {3})",
                    reportModel.AtStoreReport.OrderDiscountAmount,
                    reportModel.TakeAwayReport.OrderDiscountAmount,
                    reportModel.DeliveryReport.OrderDiscountAmount,
                    reportModel.CardReport.OrderDiscountAmount);
            //offset = WriteLeftText(graphic, offset + 2, fTimesNr9B, text, 5);
            offset += 5;
            // Discount on product.
            //WriteLeftText(graphic, offset + 2, fTimesNr9B, "Giảm trên sản phẩm:", 5);


            var detaiDiscount = reportModel.AtStoreReport.DetailDiscountAmount
                                + reportModel.TakeAwayReport.DetailDiscountAmount
                                + reportModel.DeliveryReport.DetailDiscountAmount
                                + reportModel.CardReport.OrderDiscountAmount;
            if (detaiDiscount > 0)
            {
                text = "";
            }
            else
            {
                text = "";
            }
            offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, text);
            offset += 5;
            //Chi tiet giảm hóa đơn
            if (totalDiscount > 0)
            {
                text = string.Format("( {0} + {1} + {2} + {3})",
                            reportModel.AtStoreReport.DetailDiscountAmount,
                            reportModel.TakeAwayReport.DetailDiscountAmount,
                            reportModel.DeliveryReport.DetailDiscountAmount,
                            reportModel.CardReport.DetailDiscountAmount);
                offset = WriteLeftText(graphic, offset + 2, fTimesNr9B, "", 5);
                offset += 5;
            }
            // Total invoice.
            //WriteLeftText(graphic, offset + 2, fTimesNr9B, "TỔNG THU:", 5);

            // Final Total.
            //            var totalFinal = reportModel.AtStoreReport.FinalAmount +
            //                                reportModel.TakeAwayReport.FinalAmount +
            //                                reportModel.DeliveryReport.FinalAmount;
            //offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, "");
            //text = string.Format("( {0} + {1} + {2})", reportModel.AtStoreReport.FinalAmount
            //    , reportModel.TakeAwayReport.FinalAmount, reportModel.DeliveryReport.FinalAmount);
            WriteLeftText(graphic, offset + 2, fTimesNr9B, "", 5);

            #region Hóa đơn
            offset += 5;

            int totalOrderCanceled = reportModel.AtStoreReport.OrderCancel
                                    + reportModel.TakeAwayReport.OrderCancel
                                    + reportModel.DeliveryReport.OrderCancel
                                    + reportModel.CardReport.OrderCancel;
            int totalOrderPreCanceled = reportModel.AtStoreReport.OrderPrecancel
                                    + reportModel.TakeAwayReport.OrderPrecancel
                                    + reportModel.DeliveryReport.OrderPrecancel
                                    + reportModel.CardReport.OrderPrecancel;
            int totalOrderFinish = reportModel.AtStoreReport.OrderFinish
                                    + reportModel.TakeAwayReport.OrderFinish
                                    + reportModel.DeliveryReport.OrderFinish
                                    + reportModel.CardReport.OrderFinish;
            var totalAmountOrderCanceled = reportModel.AtStoreReport.TotalAmountCanceled
                                    + reportModel.TakeAwayReport.TotalAmountCanceled
                                    + reportModel.DeliveryReport.TotalAmountCanceled
                                    + reportModel.CardReport.TotalAmountCanceled;
            var totalAmountOrderPreCanceled = reportModel.AtStoreReport.TotalAmountPreCanceled
                                    + reportModel.TakeAwayReport.TotalAmountPreCanceled
                                    + reportModel.DeliveryReport.TotalAmountPreCanceled
                                    + reportModel.CardReport.TotalAmountPreCanceled;
            var totalAmountOrderFinish = reportModel.AtStoreReport.TotalAmount
                                    + reportModel.TakeAwayReport.TotalAmount
                                    + reportModel.DeliveryReport.TotalAmount
                                    + reportModel.CardReport.TotalAmount;

            var totalAmountOrders = totalAmountOrderCanceled + totalAmountOrderPreCanceled + totalAmountOrderFinish;
            var totalAmountStore = reportModel.AtStoreReport.TotalAmount
                                      + reportModel.TakeAwayReport.TotalAmount
                                      + reportModel.DeliveryReport.TotalAmount
                                      + reportModel.CardReport.TotalAmount;
            var finalAmountStore = reportModel.AtStoreReport.FinalAmount
                                   + reportModel.TakeAwayReport.FinalAmount
                                   + reportModel.DeliveryReport.FinalAmount
                                   + reportModel.CardReport.FinalAmount;
            //if (MainForm.PosConfig.IsShowMoneyReport.Trim().ToLower() == "true")
            //{

            //    WriteLeftText(graphic, offset + 2, fTimesNr9B, "Tổng giá trị hóa đơn: ", 5);
            //    offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, string.Format("{0:n0}", totalAmountOrders));
            //    WriteLeftText(graphic, offset + 2, fTimesNr9B, "  Giảm giá trên hóa đơn: ", 5);
            //    offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, string.Format("{0:n0}", totalAmountStore - finalAmountStore-  reportModel.Categories.Sum(s => s.Discount)));
            //    //tổng giá trị sản phẩm
            //    offset += 5;
            //    WriteLeftText(graphic, offset + 2, fTimesNr9B, "Tổng giá trị sản phẩm: ", 5);
            //    offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, string.Format("{0:n0}", reportModel.Categories.Sum(s => s.TotalAmount)));
            //    //WriteLeftText(graphic, offset + 2, fTimesNr9B, "  Tổng giảm giá trên sản phẩm: ", 5);
            //    //offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, string.Format("{0:n0}", reportModel.Categories.Sum(s => s.Discount)));

            //    //
            //    //offset += 5;
            //    //WriteLeftText(graphic, offset + 2, fTimesNr9B, "  Giá trị hóa đơn hủy: ", 5);
            //    //offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, string.Format("{0:n0}", totalAmountOrderPreCanceled));

            //    //offset += 5;
            //    //WriteLeftText(graphic, offset + 2, fTimesNr9B, "  Giá trị hóa đơn hủy trước chế biến: ", 5);
            //    //offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, string.Format("{0:n0}", totalAmountOrderCanceled));
            //}

            #endregion

            if (MainForm.PosConfig.IsShowMoneyReport.Trim().ToLower() == "true")
            {
                #region Doanh Thu
                offset += 5;
                WriteLeftText(graphic, offset + 2, fTimesNr9B, "Doanh Thu Bán Hàng: ", 5);
                //Tong doanh thu
                offset += 15;
                WriteLeftText(graphic, offset + 2, fTimesNr9B, "  Doanh thu trước giám giá (1): ", 5);
                var totalDiscountStore = totalAmountStore - finalAmountStore;
                offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, string.Format("{0:n0}", totalAmountStore - reportModel.CardReport.FinalAmount));

                WriteLeftText(graphic, offset + 2, fTimesNr9B, "    Giảm giá sản phẩm (2): ", 5);
                offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, string.Format("{0:n0}", reportModel.Categories.Sum(s => s.Discount)));
                WriteLeftText(graphic, offset + 2, fTimesNr9B, "    Giảm giá trên hóa đơn (3): ", 5);
                offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, string.Format("{0:n0}", totalAmountStore - finalAmountStore - reportModel.Categories.Sum(s => s.Discount)));
                WriteLeftText(graphic, offset + 2, fTimesNr9B, "    Tiền giảm giá (4) = (2) + (3) : ", 5);
                offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, string.Format("{0:n0}", totalDiscountStore));
                WriteLeftText(graphic, offset + 2, fTimesNr9B, "  Doanh thu sau giảm giá: ", 5);
                offset += 10;
                WriteLeftText(graphic, offset + 2, fTimesNr9B, "  (5) = (1) - (4): ", 5);
                offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, string.Format("{0:n0}", finalAmountStore - reportModel.CardReport.FinalAmount));
                WriteLeftText(graphic, offset + 2, fTimesNr9B, "  Tổng thuế VAT (5.1): ", 5);
                offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, string.Format("{0:n0}", reportModel.TotalVATAmount));

                //
                offset += 5;
                WriteLeftText(graphic, offset + 2, fTimesNr9B, "Nạp Thẻ Thành Viên: ", 5);
                offset += 15;
                WriteLeftText(graphic, offset + 2, fTimesNr9B, "  Tổng tiền nạp thẻ (6): ", 5);
                offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B,
                    string.Format("{0:n0}", reportModel.CardReport.FinalAmount));
                //

                offset += 5;
                WriteLeftText(graphic, offset + 2, fTimesNr9B, "Tổng Thu Khách Hàng: ", 5);
                offset += 10;

                WriteLeftText(graphic, offset + 2, fTimesNr9B, "  (7) = (6) + (5) + (5.1) ", 5);
                offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B,
                    string.Format("{0:n0}", reportModel.TotalVATAmount + finalAmountStore));
                offset += 15;
                //WriteLeftText(graphic, offset + 2, fTimesNr9B, "  Thẻ: ", 5);
                //offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B,
                //    string.Format("{0:n0}", reportModel.CardReport.FinalAmount));


                WriteLeftText(graphic, offset + 2, fTimesNr9B, "  Tại quán: ", 5);
                offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B,
                    string.Format("{0:n0}", reportModel.AtStoreReport.FinalAmount));
                WriteLeftText(graphic, offset + 2, fTimesNr9B, "  Mang về: ", 5);
                offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B,
                    string.Format("{0:n0}", reportModel.TakeAwayReport.FinalAmount));
                WriteLeftText(graphic, offset + 2, fTimesNr9B, "  Giao hàng: ", 5);
                offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B,
                    string.Format("{0:n0}", reportModel.DeliveryReport.FinalAmount));


                //VAT
                //WriteLeftText(graphic, offset + 2, fTimesNr9B, "VAT: ", 5);
                //offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, string.Format("{0:n0}", reportModel.TotalVATAmount));
                //offset += 10;


                #endregion

                #region Payment

                var cashPayment = reportModel.AtStoreReport.CashPayment
                                    + reportModel.TakeAwayReport.CashPayment
                                    + reportModel.DeliveryReport.CashPayment
                                    + reportModel.CardReport.CashPayment;
                var memberShipPayment = reportModel.AtStoreReport.MembershipPayment
                                    + reportModel.TakeAwayReport.MembershipPayment
                                    + reportModel.DeliveryReport.MembershipPayment
                                    + reportModel.CardReport.MembershipPayment;
                var creditPayment = reportModel.AtStoreReport.CreditCardPayment
                                    + reportModel.TakeAwayReport.CreditCardPayment
                                    + reportModel.DeliveryReport.CreditCardPayment
                                    + reportModel.CardReport.CreditCardPayment;
                var otherPayment = reportModel.AtStoreReport.OtherPayment
                                    + reportModel.TakeAwayReport.OtherPayment
                                    + reportModel.DeliveryReport.OtherPayment
                                    + reportModel.CardReport.OtherPayment;
                var moMoPayment = reportModel.AtStoreReport.MoMoPayment
                                    + reportModel.TakeAwayReport.MoMoPayment
                                    + reportModel.DeliveryReport.MoMoPayment;
                var zaloPayPayment = reportModel.AtStoreReport.ZaloPayPayment
                                    + reportModel.TakeAwayReport.ZaloPayPayment
                                    + reportModel.DeliveryReport.ZaloPayPayment;
                var giftTalkPayment = reportModel.AtStoreReport.GiftTalkPayment
                                    + reportModel.TakeAwayReport.GiftTalkPayment
                                    + reportModel.DeliveryReport.GiftTalkPayment
                                    + reportModel.CardReport.GiftTalkPayment;
                var grabPayPayment = reportModel.AtStoreReport.GrabPayPayment
                                    + reportModel.TakeAwayReport.GrabPayPayment
                                    + reportModel.DeliveryReport.GrabPayPayment
                                    + reportModel.CardReport.GrabPayPayment;
                var grabFoodPayment = reportModel.AtStoreReport.GrabFoodPayment
                                   + reportModel.TakeAwayReport.GrabFoodPayment
                                   + reportModel.DeliveryReport.GrabFoodPayment
                                   + reportModel.CardReport.GrabFoodPayment;
                var totalPayment = cashPayment + memberShipPayment + creditPayment + otherPayment
                    + moMoPayment + zaloPayPayment + grabPayPayment + grabFoodPayment;

                WriteLeftText(graphic, offset + 2, fTimesNr9B, "Tổng thanh toán: ", 5);
                offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, string.Format("{0:n0}", totalPayment));

                WriteLeftText(graphic, offset + 2, fTimesNr9B, "  Tiền mặt: ", 5);
                offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B,
                    string.Format("{0:n0}", cashPayment));
                WriteLeftText(graphic, offset + 2, fTimesNr9B, "  Thẻ thành viên: ", 5);
                offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B,
                    string.Format("{0:n0}", memberShipPayment));
                WriteLeftText(graphic, offset + 2, fTimesNr9B, "  Thẻ tín dụng: ", 5);
                offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B,
                    string.Format("{0:n0}", creditPayment));
                WriteLeftText(graphic, offset + 2, fTimesNr9B, "  Khác: ", 5);
                offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B,
                    string.Format("{0:n0}", otherPayment));
                //Momo
                WriteLeftText(graphic, offset + 2, fTimesNr9B, "  MoMo: ", 5);
                offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B,
                    string.Format("{0:n0}", moMoPayment));
                //ZaloPay
                WriteLeftText(graphic, offset + 2, fTimesNr9B, "  ZaloPay: ", 5);
                offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B,
                    string.Format("{0:n0}", zaloPayPayment));
                //GiftTalk
                WriteLeftText(graphic, offset + 2, fTimesNr9B, "  GiftTalk: ", 5);
                offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B,
                    string.Format("{0:n0}", giftTalkPayment));

                //grabpay
                WriteLeftText(graphic, offset + 2, fTimesNr9B, "  GrabPay: ", 5);
                offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B,
                    string.Format("{0:n0}", grabPayPayment));

                WriteLeftText(graphic, offset + 2, fTimesNr9B, "  GrabFood: ", 5);
                offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B,
                    string.Format("{0:n0}", grabFoodPayment));
                offset += 10;
                #endregion
            }

            #region Thống kê sản phẩm nóng lạnh của PASSIO

            offset += 5;
            WriteLeftText(graphic, offset + 2, fTimesNr9B, "Tổng số sản phẩm: ", 5);
            offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, totalQuantity.ToString());

            //WriteLeftText(graphic, offset + 2, fTimesNr9B, "Tổng số ly nóng: ", 5);
            //offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, hotProduct.ToString());


            //WriteLeftText(graphic, offset + 2, fTimesNr9B, "Tổng số ly đá: ", 5);
            //offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, iceProduct.ToString());

            //WriteLeftText(graphic, offset + 2, fTimesNr9B, "Sản phẩm khác: ", 5);
            //offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, orderProduct.ToString());

            #endregion

            #region Tổng số hóa đơn
            //Tong so hoa don
            offset += 8;
            WriteLeftText(graphic, offset + 2, fTimesNr9B, "Tổng số hóa đơn: ", 5);
            offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, (totalOrderFinish + (totalOrderPreCanceled + totalOrderCanceled)).ToString());

            //WriteLeftText(graphic, offset + 2, fTimesNr9B, "Hóa đơn HỦY: ", 5);
            //offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, (totalOrderPreCanceled + totalOrderCanceled).ToString());
            //WriteLeftText(graphic, offset + 2, fTimesNr9B, "    Hủy trước chế biến: ", 5);
            //offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, totalOrderPreCanceled.ToString());

            //WriteLeftText(graphic, offset + 2, fTimesNr9B, "    Hủy sau chế biến: ", 5);
            //offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, totalOrderCanceled.ToString());

            WriteLeftText(graphic, offset + 2, fTimesNr9B, "Hóa đơn HOÀN THÀNH: ", 5);
            offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, totalOrderFinish.ToString());

            WriteLeftText(graphic, offset + 2, fTimesNr9B, "    Tại quán: ", 5);
            offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, reportModel.AtStoreReport.OrderFinish.ToString());

            WriteLeftText(graphic, offset + 2, fTimesNr9B, "    Mang về: ", 5);
            offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, reportModel.TakeAwayReport.OrderFinish.ToString());

            WriteLeftText(graphic, offset + 2, fTimesNr9B, "    Giao hàng: ", 5);
            offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, reportModel.DeliveryReport.OrderFinish.ToString());

            WriteLeftText(graphic, offset + 2, fTimesNr9B, "    Thẻ: ", 5);
            offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, reportModel.CardReport.OrderFinish.ToString());

            if (MainForm.PosConfig.IsShowMoneyReport.Trim().ToLower() == "true")
            {
                offset += 5;
                WriteLeftText(graphic, offset + 2, fTimesNr9B, "Bình quân hóa đơn: ", 5);
                offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, string.Format("{0:n0}", (totalAmountOrders / totalOrderFinish)).ToString());
            }

            #endregion

            // Date.
            text = UtcDateTime.Now().ToString("dd/MM/yyyy HH:mm");
            offset = WriteCenterText(graphic, offset + 20, fVerdana8, text);

            // Date.
            offset += 5;
            offset += WriteCenterText(graphic, offset + 5, fVerdana8, "Người lập biểu");

            return MarginTop + offset + 50;
        }

        private int CreateReceiptPaymentMember(Graphics graphic, string cardCode, string cardName, double currentAmount, double paymentAmount)
        {
            var fVerdana9B = new Font("Verdana", 9, FontStyle.Bold);
            var fVerdana8 = new Font("Verdana", 8, FontStyle.Regular);
            var fVerdana6 = new Font("Verdana", 6, FontStyle.Regular);
            var fVerdana8B = new Font("Verdana", 8, FontStyle.Bold);
            var fVerdana13B = new Font("Verdana", 13, FontStyle.Bold);
            var fVerdana10B = new Font("Verdana", 10, FontStyle.Bold);
            var fCourier9B = new Font("Courier New", 9, FontStyle.Bold);

            int offset = 0;

            // Logo.
            offset = DrawLogo(graphic, offset);

            // Address.
            if (MainForm.StoreInfo.TerminalAddress != null)
            {
                string[] splitAddress = MainForm.StoreInfo.TerminalAddress.Split('|');
                foreach (string s in splitAddress)
                {
                    offset = WriteCenterText(graphic, offset + 10, fVerdana9B, s);
                }
            }

            // Hotline.
            var hotline = string.Format("Hotline Delivery: {0}", MainForm.StoreInfo.HotLine);
            offset = WriteCenterText(graphic, offset + 7, fVerdana9B, hotline);

            // Title.
            offset = WriteCenterText(graphic, offset + 12, fVerdana13B, "PHIẾU THANH TOÁN");

            // Time.
            var time = UtcDateTime.Now().ToString("dd/MM/yyyy hh:mm:sstt");
            offset = WriteCenterText(graphic, offset + 5, fVerdana8, time);

            // Cashier.
            var text = string.Format("NHÂN VIÊN:\t{0}", MainForm.CurrentAccount.AccountId);
            offset = WriteLeftText(graphic, offset + 7, fVerdana8, text);

            // Line 1. ----------------------------
            offset = DrawSolidLine(graphic, offset + 10);

            //Thẻ thành viên
            var code = "";
            var tmpCode = cardCode.Split('_').Last();
            while (tmpCode.Length > 0)
            {
                var lastChar = tmpCode.Last().ToString();
                tmpCode = tmpCode.Remove(tmpCode.Length - 1);

                if (code.Length > 3)
                {
                    lastChar = "X";
                }
                code = lastChar + code;
            }

            //Mã thẻ
            WriteLeftText(graphic, offset + 5, fVerdana8B, "MÃ THẺ", 5);
            offset = WriteRightText(graphic, offset + 5, fVerdana8B, code);

            //Chủ thẻ
            WriteLeftText(graphic, offset + 5, fVerdana8B, "CHỦ THẺ", 5);
            offset = WriteRightText(graphic, offset + 5, fVerdana8B, cardName);

            //Tài khoản
            WriteLeftText(graphic, offset + 5, fVerdana8B, "TÀI KHOẢN TRƯỚC", 5);
            offset = WriteRightText(graphic, offset + 5, fVerdana8B, currentAmount.ToString("N0"));

            // Line 2. ----------------------------
            offset = DrawSolidLine(graphic, offset + 10);

            //Text
            text = string.Format("{0}", "NẠP THÊM TIỀN VÀO THẺ THANH TOÁN");
            offset = WriteLeftText(graphic, offset + 10, fCourier9B, text, 0);

            //Text
            offset = WriteLeftText(graphic, offset + 10, fCourier9B, "Số tiền nạp", 0);
            offset = WriteRigth64Text(graphic, offset + 5, fCourier9B, paymentAmount.ToString("N0"));

            // Line 3. ----------------------------
            offset = DrawSolidLine(graphic, offset + 10);

            // TOTAL
            WriteLeftText(graphic, offset + 5, fVerdana8B, "TỔNG CỘNG", 5);
            offset = WriteRightText(graphic, offset + 5, fVerdana8B, paymentAmount.ToString("N0"));

            // Recieved.
            WriteLeftText(graphic, offset + 5, fVerdana8B, "KHÁCH TRẢ (VNĐ):", 5);
            offset = WriteRightText(graphic, offset + 5, fVerdana8B, paymentAmount.ToString("N0"));

            // Thankyou.
            if (MainForm.StoreInfo.EndingTextOnBill != null)
            {
                var line = "---------------";
                offset = WriteCenterText(graphic, offset + 5, fVerdana8B, line);
                //offset = DrawDashLine(graphic, offset + 5);
                string[] splitEndText = MainForm.StoreInfo.EndingTextOnBill.Split('|');
                foreach (string s in splitEndText)
                {
                    offset = WriteLeftText(graphic, offset + 5, fVerdana8, s, 5);
                }
            }

            return MarginTop + offset + 50;
        }

        private int CreateReport(Graphics graphic, StoreReportModel reportModel, string creator)
        {

            var fVerdana9B = new Font("Verdana", 9, FontStyle.Bold);
            var fVerdana8 = new Font("Verdana", 8, FontStyle.Regular);
            var fTimesNr9 = new Font("Times New Roman", 9, FontStyle.Regular);
            var fTimesNr9B = new Font("Times New Roman", 9, FontStyle.Bold);
            int offset = 0;

            // Logo.
            offset = DrawLogo(graphic, offset);

            // Address.
            offset = WriteCenterText(graphic, offset + 10, fVerdana9B, MainForm.StoreInfo.TerminalAddress == null ? "" : MainForm.StoreInfo.TerminalAddress.ToUpper());

            // Hotline.
            var hotline = string.Format("{0}", MainForm.StoreInfo.TerminalName);
            offset = WriteCenterText(graphic, offset + 7, fVerdana9B, hotline);

            // Title.
            offset = WriteCenterText(graphic, offset + 12, fVerdana9B, "BÁO CÁO BÁN HÀNG CHI TIẾT");

            // Time.
            //var time = UtcDateTime.Now().ToString("dd/MM/yyyy HH:mm");
            //if (reportModel.IsRangeReport)
            //{

            if (reportModel.FromDate.Date == reportModel.ToDate.Date)
            {
                var time = string.Format("{0} - {1}", reportModel.FromDate.ToString("dd/MM/yy"),
                    reportModel.ToDate.ToString("dd/MM/yy"));
                offset = WriteCenterText(graphic, offset + 5, fVerdana8, time);
            }
            else
            {
                var time = string.Format(reportModel.FromDate.ToString("dd/MM/yy"));
                offset = WriteCenterText(graphic, offset + 5, fVerdana8, time);
            }


            // Cashier.
            //var text = string.Format("NHÂN VIÊN:\t{0}\tCA {1}", _cashier, _reportModel.Session);
            var text = string.Format("NGƯỜI LẬP:\t{0}", creator);
            offset = WriteLeftText(graphic, offset + 7, fVerdana8, text);

            // Line 1.
            offset = DrawSolidLine(graphic, offset + 2);

            double finalAmount = 0;
            int totalQuantity = 0;
            double totalDiscount = 0;
            int hotProduct = 0;
            int iceProduct = 0;
            int orderProduct = 0;

            foreach (var category in reportModel.Categories)
            {
                if (category.TotalQuantity > 0)
                {
                    offset = WriteLeftText(graphic, offset + 15, fTimesNr9B, category.CategoryName.ToUpper(), 5);
                    //Category quantity
                    totalQuantity += category.TotalQuantity;
                    WriteLeftText(graphic, offset + 2, fTimesNr9B, category.TotalQuantity.ToString(),
                        QuantityIndent);
                    //Discount
                    totalDiscount += category.Discount;
                    WriteCenterTextAlignRight(graphic, offset + 2, fTimesNr9B, category.Discount.ToString("N0"));
                    //Final Amount 
                    finalAmount += (category.TotalAmount - category.Discount);
                    offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B,
                        (category.TotalAmount - category.Discount).ToString("N0"));
                    // Line 2.
                    offset = DrawSolidLine(graphic, offset + 2, 1);


                    foreach (var productReportModel in category.ProductReportModels)
                    {
                        if (productReportModel.Quantity > 0)
                        {
                            // ProductViewModel name.
                            text = string.Format("{0} {1}", productReportModel.ProductCode,
                                productReportModel.ProductName.ToUpper());
                            offset = WriteLeftText(graphic, offset + 4, fTimesNr9, text, 5);

                            // ProductViewModel amount price.
                            WriteLeftText(graphic, offset + 2, fTimesNr9, productReportModel.Quantity.ToString(),
                                QuantityIndent);

                            // Discount.
                            WriteCenterTextAlignRight(graphic, offset + 2, fTimesNr9,
                                productReportModel.TotalDiscount.ToString("N0"));

                            // Total.
                            offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9,
                                productReportModel.TotalAmount.ToString("N0"));

                            //TODO: HUY LA LANG

                            //if (productReportModel.ProductType == (int)ProductGroup.Hot)
                            //{
                            //    hotProduct += productReportModel.Quantity;
                            //}
                            //else if (productReportModel.ProductType == (int)ProductGroup.Ice)
                            //{
                            //    iceProduct += productReportModel.Quantity;
                            //}
                            //else if (productReportModel.ProductType == (int)ProductGroup.Other)
                            //{
                            //    orderProduct += productReportModel.Quantity;
                            //}
                        }
                    }
                }


            }

            //foreach (var cate in DataController.Categories)
            //{
            //    var printGroup =
            //        DataController.Products.Where(
            //            p =>
            //                p.CatID == cate.Code &&
            //                reportModel.ProductItems.Any(a => a.ProductId == p.ProductId))
            //            .Select(a => reportModel.ProductItems.FirstOrDefault(b => b.ProductId == a.ProductId))
            //            .ToList();
            //    if (printGroup.Any())
            //    {
            //        var count = printGroup.Sum(c => c.Quantity);
            //        var total = printGroup.Sum(c => c.Total);
            //        var discount = printGroup.Sum(c => c.Discount);

            //        // Print category name.
            //        offset = WriteLeftText(graphic, offset + 15, fTimesNr9B, cate.Name.ToUpper(), 5);

            //        // Category total amount.
            //        WriteLeftText(graphic, offset + 2, fTimesNr9B, count.ToString(), QuantityIndent);

            //        // Discount.
            //        if (discount > 0)
            //        {
            //            text = "-" + discount.ToString("N0");
            //        }
            //        else
            //        {
            //            text = "0";
            //        }
            //        WriteCenterTextAlignRight(graphic, offset + 2, fTimesNr9B, text);

            //        // Total.
            //        offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, total.ToString("N0"));

            //        // Line 2.
            //        offset = DrawSolidLine(graphic, offset + 2, 1);

            //        foreach (var item in printGroup)
            //        {
            //            // ProductViewModel name.
            //            text = string.Format("{0} {1}", item.ProductCode, item.ProductName.ToUpper());
            //            offset = WriteLeftText(graphic, offset + 4, fTimesNr9, text, 5);

            //            // ProductViewModel amount price.
            //            WriteLeftText(graphic, offset + 2, fTimesNr9, item.Quantity.ToString(), QuantityIndent);

            //            // Discount.
            //            if (item.Discount > 0)
            //            {
            //                text = "-" + item.Discount.ToString("N0");
            //            }
            //            else
            //            {
            //                text = "0";
            //            }
            //            WriteCenterTextAlignRight(graphic, offset + 2, fTimesNr9, text);

            //            // Total.
            //            offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9, item.Total.ToString("N0"));
            //        }
            //    }
            //}

            // Print category name.
            offset = WriteLeftText(graphic, offset + 4, fTimesNr9B, "TỔNG CỘNG", 5);

            // Line.
            offset = DrawSolidLine(graphic, offset + 5);

            //  total quantity.

            WriteLeftText(graphic, offset + 2, fTimesNr9B, totalQuantity.ToString(), QuantityIndent);

            //// Total Discount.

            WriteCenterTextAlignRight(graphic, offset + 2, fTimesNr9B, totalDiscount.ToString("N0"));

            //// Total

            offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, finalAmount.ToString("N0"));
            offset += 5;
            // Doanh số
            WriteLeftText(graphic, offset + 2, fTimesNr9B, "Doanh số (chưa giảm):", 5);
            var totalAmount = reportModel.AtStoreReport.TotalAmount
                            + reportModel.TakeAwayReport.TotalAmount
                            + reportModel.DeliveryReport.TotalAmount
                            + reportModel.CardReport.TotalAmount;

            offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, totalAmount.ToString("N0"));
            offset += 5;
            //Chi tiet doanh so
            if (totalAmount > 0)
            {
                text = string.Format(" - AtStore: {0} \n - TakeAway: {1} \n - Delivery: {2} \n - Card: {3})",
                                reportModel.AtStoreReport.TotalAmount,
                                reportModel.TakeAwayReport.TotalAmount,
                                reportModel.DeliveryReport.TotalAmount,
                                reportModel.CardReport.TotalAmount);
                offset = WriteLeftText(graphic, offset + 2, fTimesNr9B, text, 5);
                offset += 30;
            }
            // Discount on bill.
            WriteLeftText(graphic, offset + 2, fTimesNr9B, "Giảm trên hóa đơn:", 5);
            var totalDiscountO = reportModel.AtStoreReport.OrderDiscountAmount
                                + reportModel.TakeAwayReport.OrderDiscountAmount
                                + reportModel.DeliveryReport.OrderDiscountAmount
                                + reportModel.CardReport.OrderDiscountAmount;

            if (totalDiscountO > 0)
            {
                text = "-" + totalDiscountO.ToString("N0");
            }
            else
            {
                text = "0";
            }
            offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, text);
            offset += 5;
            //Chi tiet giảm hóa đơn
            text = string.Format("( {0} + {1} + {2} + {3})",
                        reportModel.AtStoreReport.OrderDiscountAmount,
                        reportModel.TakeAwayReport.OrderDiscountAmount,
                        reportModel.DeliveryReport.OrderDiscountAmount,
                        reportModel.CardReport.OrderDiscountAmount);
            offset = WriteLeftText(graphic, offset + 2, fTimesNr9B, text, 5);
            offset += 5;
            // Discount on product.
            WriteLeftText(graphic, offset + 2, fTimesNr9B, "Giảm trên sản phẩm:", 5);


            var detaiDiscount = reportModel.AtStoreReport.DetailDiscountAmount
                                + reportModel.TakeAwayReport.DetailDiscountAmount
                                + reportModel.DeliveryReport.DetailDiscountAmount
                                + reportModel.CardReport.DetailDiscountAmount;
            if (detaiDiscount > 0)
            {
                text = "-" + totalDiscount.ToString("N0");
            }
            else
            {
                text = "0";
            }
            offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, text);
            offset += 5;
            //Chi tiet giảm hóa đơn
            if (totalDiscount > 0)
            {
                text = string.Format("( {0} + {1} + {2} + {3})",
                            reportModel.AtStoreReport.DetailDiscountAmount,
                            reportModel.TakeAwayReport.DetailDiscountAmount,
                            reportModel.DeliveryReport.DetailDiscountAmount,
                            reportModel.CardReport.DetailDiscountAmount);
                offset = WriteLeftText(graphic, offset + 2, fTimesNr9B, text, 5);
                offset += 5;
            }
            // Total invoice.
            WriteLeftText(graphic, offset + 2, fTimesNr9B, "TỔNG THU:", 5);

            // Final Total.
            var totalFinal = reportModel.AtStoreReport.FinalAmount
                            + reportModel.TakeAwayReport.FinalAmount
                            + reportModel.DeliveryReport.FinalAmount
                            + reportModel.CardReport.FinalAmount;
            offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, totalFinal.ToString("N0"));
            //text = string.Format("( {0} + {1} + {2})", reportModel.AtStoreReport.FinalAmount
            //    , reportModel.TakeAwayReport.FinalAmount, reportModel.DeliveryReport.FinalAmount);
            // WriteLeftText(graphic, offset + 2, fTimesNr9B,text, 5);



            offset += 5;
            WriteLeftText(graphic, offset + 2, fTimesNr9B, "Tổng số sản phẩm: ", 5);
            offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, totalQuantity.ToString());


            WriteLeftText(graphic, offset + 2, fTimesNr9B, "Tổng số ly nóng: ", 5);
            offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, hotProduct.ToString());


            WriteLeftText(graphic, offset + 2, fTimesNr9B, "Tổng số ly đá: ", 5);
            offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, iceProduct.ToString());

            WriteLeftText(graphic, offset + 2, fTimesNr9B, "Sản phẩm khác: ", 5);
            offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, orderProduct.ToString());

            //Tong so hoa don
            offset += 5;
            WriteLeftText(graphic, offset + 2, fTimesNr9B, "Tổng số bill: ", 5);
            int totalOrder = reportModel.AtStoreReport.OrderFinish
                            + reportModel.TakeAwayReport.OrderFinish
                            + reportModel.DeliveryReport.OrderFinish
                            + reportModel.CardReport.OrderFinish;
            offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, totalOrder.ToString());

            WriteLeftText(graphic, offset + 2, fTimesNr9B, "Tổng số bill (Store): ", 5);
            offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, reportModel.AtStoreReport.OrderFinish.ToString());

            WriteLeftText(graphic, offset + 2, fTimesNr9B, "Tổng số bill (TakeAway): ", 5);
            offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, reportModel.TakeAwayReport.OrderFinish.ToString());

            WriteLeftText(graphic, offset + 2, fTimesNr9B, "Tổng số bill (Delivery): ", 5);
            offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, reportModel.DeliveryReport.OrderFinish.ToString());

            WriteLeftText(graphic, offset + 2, fTimesNr9B, "Tổng số bill (Card): ", 5);
            offset = WriteRigth64Text(graphic, offset + 2, fTimesNr9B, reportModel.CardReport.OrderFinish.ToString());

            // Date.
            text = UtcDateTime.Now().ToString("dd/MM/yyyy HH:mm");
            offset = WriteCenterText(graphic, offset + 20, fVerdana8, text);

            // Date.
            offset += 5;
            offset += WriteCenterText(graphic, offset + 5, fVerdana8, "Người lập biểu: " + creator);

            return MarginTop + offset + 50;
        }

        private void CreateOpenSafe(Graphics graphic, string name, string reason)
        {
            var fVerdana9B = new Font("Verdana", 9, FontStyle.Bold);
            var fVerdana8 = new Font("Verdana", 10, FontStyle.Regular);
            var fVerdana6 = new Font("Verdana", 6, FontStyle.Regular);
            var fVerdana8B = new Font("Verdana", 8, FontStyle.Bold);
            var fVerdana13B = new Font("Verdana", 13, FontStyle.Bold);
            var fVerdana10B = new Font("Verdana", 10, FontStyle.Bold);
            var fCourier9B = new Font("Courier New", 9, FontStyle.Bold);

            var offset = 0;

            var fontItem = new Font("Verdana", 8, FontStyle.Regular);
            var penSolid1 = new Pen(Color.Black);

            var text = UtcDateTime.Now().ToString("dd/MM/yyyy HH:mm");
            offset = WriteCenterText(graphic, offset + 5, fVerdana8, text);
            offset += (int)fontItem.GetHeight();

            //var fontTable = new Font("Verdana", 14, FontStyle.Bold);
            //graphic.DrawString(text, fontTable, Brushes.Black, new PointF(MarginLeft, MarginTop + offset));
            //offset += (int)fontTable.GetHeight();


            text = MainForm.ResManager.GetString("Printer_OpenSafe_Title", MainForm.CultureInfo);
            offset = WriteCenterText(graphic, offset + 5, fVerdana10B, text);
            offset += (int)fontItem.GetHeight();

            text = string.Format(MainForm.ResManager.GetString("Printer_Username_Opensafe", MainForm.CultureInfo) + ":\t{0}", name);
            offset = WriteCenterText(graphic, offset + 5, fVerdana8, text);
            offset += (int)fontItem.GetHeight();

            text = string.Format(MainForm.ResManager.GetString("Printer_Reason_Opensafe", MainForm.CultureInfo) + ":\t{0}", reason);
            offset = WriteCenterText(graphic, offset + 5, fVerdana8, text);
            offset += (int)fontItem.GetHeight();
        }


        /// <summary>
        /// Get all valid OrderDetailViewModel and sort by OrderEditViewModel : mainitem -> extraitem of mainitem
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        private List<OrderDetailEditViewModel> GetSortedValidOrderDetail(OrderEditViewModel order)
        {
            var validOrderDetils = order.OrderDetailEditViewModels.Where(od => (od.Status != (int)OrderDetailStatusEnum.Cancel
                                                                      && od.Status != (int)OrderDetailStatusEnum.PosCancel
                                                                       && od.Status != (int)OrderDetailStatusEnum.PosPreCancel
                                                                        && od.Status != (int)OrderDetailStatusEnum.PreCancel));

            var sortedOrderDetailList = new List<OrderDetailEditViewModel>();
            foreach (var mainOrderDetail in validOrderDetils.Where(od => od.ParentId == null))
            {
                sortedOrderDetailList.AddRange(validOrderDetils.Where(od => od.OrderDetailID == mainOrderDetail.OrderDetailID ||
                                                                  od.ParentId == mainOrderDetail.OrderDetailID)
                    .OrderBy(od => od.ParentId)
                    .ToList());
            }
            return sortedOrderDetailList;
        }

        private List<OrderDetailEditViewModel> GetSortedNewOrderDetail(OrderEditViewModel order)
        {
            var validOrderDetils = order.OrderDetailEditViewModels.Where(od => (od.Status == (int)OrderDetailStatusEnum.New));

            var sortedOrderDetailList = new List<OrderDetailEditViewModel>();
            foreach (var mainOrderDetail in validOrderDetils.Where(od => od.ParentId == null))
            {
                sortedOrderDetailList.AddRange(validOrderDetils.Where(od => od.OrderDetailID == mainOrderDetail.OrderDetailID ||
                                                                  od.ParentId == mainOrderDetail.OrderDetailID)
                    .OrderBy(od => od.ParentId)
                    .ToList());
            }
            return sortedOrderDetailList;
        }

        /// <summary>
        /// Break down long single string to multiple string 
        /// </summary>
        /// <param name="singleLineText">text need to be broken</param>
        /// <param name="charPerLine">characters per line</param>
        /// <returns>return list of line</returns>
        private List<string> BreakLines(string singleLineText, int charPerLine)
        {
            var multipleLines = new List<string>();
            string charInLine = "";
            int currentLenght = 0;
            List<string> words = singleLineText.Split(' ').ToList();

            for (int i = 0; i < words.Count; i++)
            {
                currentLenght += words[i].Length;

                if (currentLenght > charPerLine)
                {
                    multipleLines.Add(charInLine);
                    charInLine = "   ";
                    charInLine += words[i] + " ";
                    currentLenght = 0;
                }
                else
                {
                    charInLine += words[i] + " ";
                }

                if (i == words.Count - 1)
                {
                    multipleLines.Add(charInLine);
                }
            }

            return multipleLines;
        }


        #endregion

        #region Draw function

        private int DrawDashLine(Graphics graphic, int offset, int width = 1)
        {
            var penSolid = new Pen(Color.Black)
            {
                Width = width,
                DashStyle = DashStyle.Dash
            };
            graphic.DrawLine(penSolid, MarginLeft, MarginTop + offset, MarginRight, MarginTop + offset);
            return offset + width;
        }

        private static int DrawSolidLine(Graphics graphic, int offset, int width = 2)
        {
            var penSolid = new Pen(Color.Black)
            {
                Width = width
            };
            graphic.DrawLine(penSolid, MarginLeft, MarginTop + offset, MarginRight, MarginTop + offset);
            return offset + width;
        }

        private int DrawLogo(Graphics graphic, int offset)
        {
            //return -1;
            //var logo = Resources.logo_print_passio;
            var logo = MainForm.GetImage((string)MainForm.StoreInfo.LogoPrint);

            var width = MarginRight - 20 - (MarginLeft + 20); // Margin 20 from left and right.
            var height = logo.Height * width / logo.Width; // Calculate scaled height.
            Bitmap objBitmap = new Bitmap(logo, new Size(width, height)); ;

            graphic.DrawImage(objBitmap, MarginLeft + 20, MarginTop, width, height); // Drawing.
            return offset + height;
        }

        #endregion

        #region Writer function

        private static int WriteRigth64Text(Graphics graphic, int offset, Font font, string text)
        {
            var formatRight = new StringFormat { Alignment = StringAlignment.Far };
            var rectF = new RectangleF(MarginRight * 6 / 10, MarginTop + offset, MarginRight * 4 / 10, font.GetHeight());
            graphic.DrawString(text, font, Brushes.Black, rectF, formatRight);

            return offset + (int)font.GetHeight();
        }

        private static int WriteCenterTextAlignRight(Graphics graphic, int offset, Font font, string text)
        {
            var formatRight = new StringFormat { Alignment = StringAlignment.Far };
            var rectF = new RectangleF(XIndent, MarginTop + offset, MarginRight * 6 / 10 - XIndent, font.GetHeight());
            graphic.DrawString(text, font, Brushes.Black, rectF, formatRight);
            return offset + (int)font.GetHeight();
        }

        private int WriteRightText(Graphics graphic, int offset, Font font, string text)
        {
            var formatRight = new StringFormat { Alignment = StringAlignment.Far };
            var rectF = new RectangleF(MarginLeft, MarginTop + offset, MarginRight - MarginLeft, font.GetHeight());
            graphic.DrawString(text, font, Brushes.Black, rectF, formatRight);
            return offset + (int)font.GetHeight();
        }

        private int WriteLeftText(Graphics graphic, int offset, Font font, string text, int indent = 0)
        {
            graphic.DrawString(text, font, Brushes.Black, MarginLeft + indent, MarginTop + offset);
            return offset + (int)font.GetHeight();
        }

        private static int WriteCenterText(Graphics graphic, int offset, Font font, string text)
        {
            var formatCenter = new StringFormat { Alignment = StringAlignment.Center };
            var rectF = new RectangleF(MarginLeft, MarginTop + offset, MarginRight - MarginLeft, font.GetHeight());
            graphic.DrawString(text, font, Brushes.Black, rectF, formatCenter);

            return offset + (int)font.GetHeight();
        }

        private static int DrawQRCode(Graphics graphic, int offset, string url)
        {
            var formatCenter = new StringFormat { Alignment = StringAlignment.Center };
            var size = 100;             //QR size nhỏ
            var ix = (250 - size) / 2;  //Canh giữa cho QR

            Bitmap bitmap = QRCode.GenerateQR(size, size, url);
            var rectF = new RectangleF(ix, MarginTop + offset, bitmap.Height, bitmap.Width);
            graphic.DrawImage(bitmap, rectF);

            return offset + (int)rectF.Height;
        }

        private static int SkyConnectDrawQRCode(Graphics graphic, int offset,
                                            string billId, string amount, DateTime time)
        {
            var formatCenter = new StringFormat { Alignment = StringAlignment.Center };
            var size = 100;             //QR size nhỏ
            var ix = (250 - size) / 2;  //Canh giữa cho QR
            var url = QRCode.SkyConnectGenerateStrQRCode(billId, amount, time);
            if (url == null)
            {
                var message = "Server bị lỗi. Thử lại hoặc liên hệ với bên hỗ trợ";
                PosMessageDialog.ShowMessage(message);
                return 0;
            }

            Bitmap bitmap = QRCode.GenerateQR(size, size, url);
            var rectF = new RectangleF(ix, MarginTop + offset, bitmap.Height, bitmap.Width);
            graphic.DrawImage(bitmap, rectF);

            return offset + (int)rectF.Height;
        }

        private static int DrawQRCodeMoMo(Graphics graphic, int offset,
                                            string serviceId, string billId, string amount, string description,
                                            DateTime time)
        {
            var formatCenter = new StringFormat { Alignment = StringAlignment.Center };
            var size = 100;             //QR size nhỏ
            var ix = (250 - size) / 2;  //Canh giữa cho QR
            var isSkyConnectEnable = bool.Parse(MainForm.StoreInfo.SkyConnectEnable.Trim().ToLower());
            var url = QRCode.GenerateStrMomo(serviceId, billId, amount, description, time);
            Bitmap bitmap = QRCode.GenerateQR(size, size, url);
            var rectF = new RectangleF(ix, MarginTop + offset, bitmap.Height, bitmap.Width);
            graphic.DrawImage(bitmap, rectF);

            return offset + (int)rectF.Height;
        }

        #endregion

        private bool IsExtraProduct(string productCode)
        {
            var product = Program.context.getAllProducts().FirstOrDefault(p => p.Code == productCode);
            var category = Program.context.getAvailableCategories().LastOrDefault(c => product != null && c.Code == product.CatID);

            if (category != null && (category.IsExtra == 0 || category.IsExtra == null))
            {
                return false;
            }

            return true;
        }

    }
}
