using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyConnect.POSLib.Utils
{
    public enum SkyConnectPartnerTypeEnum
    {
        [Display(Name = "Ví điện tử")]
        Wallet = 1,
        [Display(Name = "Gift Card")]
        GiftCard = 2,
        [Display(Name = "Khuyến mãi")]
        Promotion = 3
    }

    public enum SkyConnectTransactionStatusEnum
    {
        [Display(Name = "Mới")]
        New = 0,
        [Display(Name = "Đã duyệt")]
        Approve = 1,
        [Display(Name = "Đã hủy")]
        Cancel = 2,
    }


    /// <summary>
    /// --------------------------------------
    /// 1. CreditAccount: Tài khoản trừ tiền khi thanh toán
    /// 2. GiftAccount: Tài khoản trừ số lượng sản phẩm khi thanh toán
    /// 3. PointAccount: Tài khoản + điểm khi mua hàng
    /// --------------------------------------
    /// 
    /// 
    /// 
    /// </summary>
    public enum SkyConnectAccountTypeEnum
    {
        [Display(Name = "Tài khoản thanh toán")]
        CreditAccount = 1,
        [Display(Name = "Tài khoản sản phẩm")]
        GiftAccount = 2,
        [Display(Name = "Tài khoản tích điểm")]
        PointAccount = 3
    }
    public enum SkyConnectPartnerEnum
    {
        [Display(Name = "Tự cung cấp")]
        InHouse = 0,
        [Display(Name = "Metee")]
        Metee = 1,
        [Display(Name = "Momo")]
        Momo = 2,
        [Display(Name = "Gif Talk")]
        GiftTalk = 3,
        [Display(Name = "ZaloPay")]
        ZaloPay = 5,
        [Display(Name = "VTPay")]
        VTPay = 7
    }
    public enum SkyConnectOrderStatusEnum
    {
        [Display(Name = "Mới")]
        New = 8, //Đơn hàng mới tạo, từ tổng đài,web...//DeliveryStatus: New,Assgigned

        //Hai truong hop: Khach dang uong tai quan - Don hang Delivery dang duoc xu ly
        [Display(Name = "Đang xử lý tại POS")]
        PosProcessing = 17,
        [Display(Name = "Đang xử lý")]
        Processing = 10,//DeliveryStatus: POSAccepted, PosUnAccepted, Delivery

        [Display(Name = "Hoàn thành tại POS")]
        PosFinished = 11,//Ket thuc o POS: POSFinished ->Finish//For POS online
        [Display(Name = "Hoàn thành")]
        Finish = 2,//Don hang da gui len Server thanh cong: 

        [Display(Name = "Hủy sau chế biến tại POS")]
        PosCancel = 13,
        [Display(Name = "Hủy sau chế biến")]
        Cancel = 3,// Don hang da bi huy SAU KHI CHẾ BIẾN//DeliveryStatus: Cancel,Fail,Precancel

        [Display(Name = "Hủy trước chế biến tại POS")]
        PosPreCancel = 12,//Don hang bi huy truoc khi che bien - CHUA SUBMIT LEN SERVER
        [Display(Name = "Hủy trước chế biến")]
        PreCancel = 4,//Don hang bi huy truoc khi che bien - DA SUBMIT LEN SERVER

        [Display(Name = "Đã nhận tiền")]
        Paid = 5,// Hoa don da nhan tien
        [Display(Name = "Chưa nhận tiền")]
        Unpaid = 6,// Hoa don chua nhan tien
        [Display(Name = "Tạo mới ở Website")]
        WebNew = 14, // Hóa đơn mới được tạo
        [Display(Name = "Đã duyệt")]
        WebApproved = 15, // Hóa đơn đã được duyệt
    }
    /// <summary>
    /// Loại hóa đơn cho loại hình Cafe, Giao hàng --Database: OrderType 
    /// </summary>
    public enum SkyConnectOrderTypeEnum
    {
        [Display(Name = "Tại quán")]
        AtStore = 4,
        [Display(Name = "Mang đi")]
        TakeAway = 5,
        [Display(Name = "Giao hàng")]
        Delivery = 6,
        [Display(Name = "Bị hủy")]
        DropProduct = 8,
        [Display(Name = "Đặt hàng Online")]
        OnlineProduct = 1, // sản phẩm được đặt online
        [Display(Name = "Nạp thẻ")]
        OrderCard = 7
    }

    public enum SkyConnectTransactionTypeEnum
    {
        // Payment hệ thống
        [Display(Name = "Thành viên thanh toán")]
        MemberPayment = 1,
        [Display(Name = "Hoàn tiền")]
        RollBack = 2,
        [Display(Name = "Kích hoạt thẻ")]
        ActiveCard = 3,
        /// <summary>
        /// Payment đối tác
        /// </summary>
        [Display(Name = "Dịch vụ thanh toán")]
        PartnerPayment = 4,
        /// <summary>
        /// Tích điểm trong hệ thống
        /// </summary>
        [Display(Name = "Thanh viên tích điểm")]
        MemberPoint = 5,
        /// <summary>
        /// Tích điểm cho đối tác
        /// </summary>
        [Display(Name = "Dịch vụ tích điểm")]
        PartnerPoint = 6,
        [Display(Name = "Nạp tiện thành viên")]
        MemberCharge = 7
    }

    public enum SkyConnectMembershipStatusEnum
    {
        [Display(Name = "Chưa kích hoạt")]
        Inactive = 0,
        [Display(Name = "Đang sử dụng")]
        Active = 1,
        [Display(Name = "Tạm dừng")]
        Suspensed = 2,
    }

}
