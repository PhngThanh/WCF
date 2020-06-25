using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.ReportService
{
    public class StoreReportModel
    {
        public string CheckInPerson { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public TypeReportModel AtStoreReport { get; set; }
        public TypeReportModel TakeAwayReport  { get; set; }
        public TypeReportModel DeliveryReport  { get; set; }
        
        public List<CategoryReportModel> Categories { get; set; }

        
     
    }


    public class TypeReportModel
    {
        //Quantity
        public int OrderQuantity { get; set; } //Tổng số hóa đơn
        public int OrderFinish { get; set; } //Tổng hóa đơn đã hoàn thành POSFinished, Finished 
        public int OrderPrecancel { get; set; }//Tổng hóa đơn hủy trước chế biến
        public int OrderCancel { get; set; } // Tổng hóa đơn hủy sau chế biến

        

        //Accounting
        public double TotalAmount { get; set; } //Tong doanh so
        public double DetailDiscountAmount { get; set; }//Giam gia tren tung san pham
        public double OrderDiscountAmount { get; set; }//Giam gia tren hoa don
        public double FinalAmount { get; set; }//Tong doanh so sau giam gia
        public double TotalAmountCanceled { get; set; } //Tong tien cua hoa don HUY
        public double TotalAmountPreCanceled { get; set; } //Tong tien cua hoa don HUY truoc che sbien


        //Payment
        public double CashPayment { get; set; } //Tổng thanh toán bằng tiền mặt
        public double MembershipPayment { get; set; }//Thanh toán bằng thẻ thành viên
        public double CreditCardPayment { get; set; } // Thẻ tín dụng

    }


    public class CategoryReportModel
    {
        public int Code { get; set; }
        public string CategoryName { get; set; }

        public int TotalQuantity { get; set; }

        public double TotalAmount { get; set; }

        public double Discount { get; set; }

        public List<ProductReportModel> ProductReportModels { get; set; }

       

        public CategoryReportModel()
        {
            ProductReportModels = new List<ProductReportModel>();
        }
    }

    public class ProductReportModel
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public int ProductType { get; set; }
        public int Group { get; set; }
  
        //Quantity
        public int Quantity { get; set; }
        public int AtStoreQuantity { get; set; }
        public int TakeAwayQuantity { get; set; }
        public int DeliveryQuantity { get; set; }

        public double TotalAmount { get; set; } //Tổng danh số
        public double AtStoreAmount { get; set; }
        public double TakeAwayAmount { get; set; }
        public double DeliveryAmount { get; set; }

        public double TotalDiscount { get; set; } //Tổng giảm giá trên sản phẩm
        public double AtStoreDiscount { get; set; }
        public double TakeAwayDiscount { get; set; }
        public double DeliveryDiscount { get; set; }

      


      
    }
}
