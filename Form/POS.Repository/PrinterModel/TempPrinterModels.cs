using POS.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.PrinterModel
{
    /// <summary>
    /// Class này tạm thời để lưu trữ printermodel để test máy in
    /// </summary>
    public class TempPrinterModels
    {
        public static List<OrderPrinterModel> orderPrinterModels;
        static TempPrinterModels()
        {
            orderPrinterModels = new List<OrderPrinterModel>();
        }

        public static void AddModel(OrderPrinterModel orderPrinterModel)
        {
            orderPrinterModels.Add(orderPrinterModel);
        }

        public static void RemoveModel(string orderCode)
        {
            orderPrinterModels.Remove(orderPrinterModels.FirstOrDefault(o => o.OrderCode == orderCode));
        }

        public static OrderPrinterModel GetModel(string orderCode)
        {
            return orderPrinterModels.FirstOrDefault(o => o.OrderCode == orderCode);
        }

       
    }
}
