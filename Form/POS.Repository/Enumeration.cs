

using System.ComponentModel.DataAnnotations;

namespace POS.Repository
{

    #region SYNC WITH SKYPLUS

    /// <summary>
    /// Trạng thái của đơn hàng là quán cafe hoặc giao hàng
    /// 
    /// ===================================================
    /// BUSINESS RULES
    /// 1. Nhận đơn hàng từ WEB, TONG Đài : OrderStatusEnum = New - DeliveryStatus = New
    /// 2. Assign cho cửa hàng :  OrderStatusEnum = New - DeliveryStatus = Assigned
    /// 
    /// 3a. Cửa hàng chấp nhận:  OrderStatusEnum = Processing - DeliveryStatus = PosAccepted
    /// 
    /// 3b. Cửa hàng Reject: [POS] OrderStatusEnum = PosPreCancel -  DeliveryStatus = PosRejected 
    ///                      Console lâu lâu đẩy lên server
    /// 
    ///                      [Server] OrderStatusEnum = Processing - DeliveryStatus = PosRejected
    ///                      [POS] OrderStatusEnum = PreCancel -  DeliveryStatus = PosRejected [FINAL]
    /// 
    /// 3b.1 Đơn hàng Reject được Assign cửa hàng khác: [SERVER] OrderStatusEnum = New - DeliveryStatus = Assigned
    /// 4. Nhân viên đang giao hàng: OrderStatusEnum = Processing - DeliveryStatus = Delivery
    /// 
    /// 5. Giao hàng thành công: OrderStatusEnum = [POS] PosFinished - DeliveryStatus = Finish 
    /// 
    ///     Submit đơn hàng lên Server : OrderStatusEnum = Finish - DeliveryStatus = Finish [FINAL]
    /// 
    /// 5a. Giao hàng không thành công: [POS] OrderStatusEnum = PosFinished - DeliveryStatus = Fail
    ///     Submit đơn hàng lên Server : OrderStatusEnum = Cancel - DeliveryStatus = Fail [FINAL]
    /// 
    /// 5b. Đơn hàng hủy trước chế biến: [POS] OrderStatusEnum = PosFinished - DeliveryStatus = PreCancel
    ///     Submit đơn hàng lên Server : OrderStatusEnum = PreCancel - DeliveryStatus = PreCancel [FINAL]
    /// 
    /// 5c. Đơn hàng hủy sau chế biến: [POS] OrderStatusEnum = PosFinished - DeliveryStatus = Cancel
    ///     Submit đơn hàng lên Server : OrderStatusEnum = Cancel - DeliveryStatus = Cancel [FINAL]
    /// </summary>
    /// 

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
    public enum AccountTypeEnum
    {
        CreditAccount = 1, //Tài khoản thanh toán
        GiftAccount = 2, //Tài khoản sản phẩm
        PointAccount = 3 //Tài khoản tích điểm
    }
    public enum OrderStatusEnum
    {
        //PosNew = 16, // Hóa đươn tạo mới từ POS
        New = 8, //Đơn hàng mới tạo, từ tổng đài,web...//DeliveryStatus: New,Assgigned

        PosProcessing = 17,
        Processing = 10,//DeliveryStatus: POSAccepted, PosUnAccepted, Delivery

        PosFinished = 11,//Ket thuc o POS: POSFinished ->Finish//For POS online
        Finish = 2,//Don hang da gui len Server thanh cong: 

        PosCancel = 13,
        Cancel = 3,// Don hang da bi huy SAU KHI CHẾ BIẾN//DeliveryStatus: Cancel,Fail,Precancel

        PosPreCancel = 12,//Don hang bi huy truoc khi che bien - CHUA SUBMIT LEN SERVER
        PreCancel = 4,//Don hang bi huy truoc khi che bien - DA SUBMIT LEN SERVER
    }

    /// <summary>
    /// Trạng thái của từng sản phẩm cụ thể trong trường hợp nhà hàng
    /// </summary>
    public enum OrderDetailStatusEnum
    {
        New = 8,

        Processing = 10,            // Đang chế biến || Đã in bill cho nhà bếp

        Finish = 2,                 // Cooked
        PosFinished = 11,           // Chef đã HOÀN TẤT việc chế biến || Bill đã được THANH TOÁN

        PosCancel = 13,             //POS HỦY món mặc dù món đã được chế biến
        Cancel = 3,

        PosPreCancel = 12,          //POS HỦY món trước khi món được chế biến
        PreCancel = 4
    }

    public enum DeliveryStatusEnum
    {
        //DeliveryStatus: lưu trạng thái TẠM THỜI , CẬP NHẬT THƯỜNG XUYÊN CỦA ĐƠN HÀNG

        New = 0,//Mới them vao chua tim duoc cua hang
        Assigned = 1,//Da gan cho cua hang
        PosAccepted = 2,//May POS da nhan duoc

        Delivery = 3,//Dang di giao
        Finish = 4,//Da hoan thanh

        PreCancel = 5,//Huy truoc khi che bien
        Cancel = 6,//Huy sao khi che bien

        Fail = 7,//Khong tim thay khach hang
        PosRejected = 8,//May POS da nhan duoc nhung kg dap ung

        //ApiOrder = 9 // Order from ApiOrder
    }


    /// <summary>
    /// Number Of Guest in Order
    /// </summary>
    public enum CustomerGroupEnum
    {
        Single = 1,
        Couple = 2,
        Group = 3,
        Family = 4
    }

    public enum CustomerNationalityEnum
    {
        VietNam = 1,
        Asian = 2,
        European = 3,
        Other = 4
    }


    /// <summary>
    /// Loại hóa đơn cho loại hình Cafe, Giao hàng --Database: OrderType 
    /// </summary>
    public enum OrderTypeEnum
    {
        [Display(Name = "TQ")]
        AtStore = 4,
        [Display(Name = "MV")]
        TakeAway = 5,
        [Display(Name = "GH")]
        Delivery = 6,
        [Display(Name = "CA")]
        DropProduct = 8,
        [Display(Name = "OL")]
        OnlineProduct = 1, // sản phẩm được đặt online
        [Display(Name = "OC")]
        OrderCard = 7
    }

    public enum ProductTypeEnum
    {
        Single = 0,                     //Sản phẩm đơn
        Combo = 1,                      //Combo
        Room = 2,                       //Phòng
        AdditionFee = 3,                //Sản phẩm khuyến mãi
        Extra = 5,                      //Sản phẩm kèm
        General = 6,                    //Sản phẩm Master
        Detail = 7,                     //Sản phẩm con
        CardPayment = 8,                //Card
        Sample = 9                      //Mẫu thẻ
    }

    public enum PaymentTypeEnum
    {
                                    ///Hình thức, loại thanh toán:
        Cash = 1,                   //  1. Tiền mặt
        Card = 2,                   //  2. Thẻ ngân hàng
        MemberPayment = 3,          //  3. Thanh toán bằng thẻ thành viên   (point > sản phẩm)
        Voucher = 4,                //  4. Voucher 
        AccountReceivable = 5,      //  5. Nợ
        Other = 6,                  //  6. Hình thức khác
        MasterCard = 7,             //  7. Thẻ Master
        VisaCard = 8,               //  8. Thẻ Visa
        ExchangeCash = 9,           //  9. Tiền thừa cửa hàng trả lại khách
        PaymentMember = 10,         //  10. Thanh toán cho thẻ thành viên   (tiền > point)

        MoMo = 21,                  //  21. Thanh toán qua MoMo
        GiftTalk = 22,               //  22. Thanh toán bằng GifTalk
        [Display(Name ="Zalo Pay")]
        ZaloPay = 23,                  //  21. Thanh toán qua Zalo
        GrabPay=24,
        Goviet=25,
        VNPay=26,
        GrabFood=35

    }

    /// <summary>
    /// Status cua the membership
    /// 0: tam ngung hoat dong
    /// 1: Dang hoat dong
    /// 2: The bi loi
    /// </summary>
    public enum CustomerTypeEnum
    {
        Inactive = 0,
        Active = 1,
        Suspensed = 2,
        GiftTalk = 3,
    }
    #endregion


    public enum CardAccountTypeEnum
    {
        CreditAccount = 1,      //Tài khoản thanh toán  0-1
        GiftAccount = 2,        //Tài khoản sản phẩm    0-n
        PointAccount = 3        //Tài khoản tích điểm   0-1
    }


    #region Promotion
    /// <summary>
    /// ApplyLevel
    /// --------------------------------------
    /// 0. Order
    /// 1. Order Detail
    /// </summary>
    public enum PromotionApplyLevelEnum
    {
        Order = 0,
        OrderDetail = 1
    }


    /// <summary>
    /// PromotionType
    /// --------------------------------------
    /// 0. Internal: Khuyến mãi trực tiếp của cửa hàng quy định
    /// 1. Separate: Khuyến mãi theo event, chỉ áp dụng 1 lần 1 loại
    /// 2. Common: Khuyến mãi thông thường
    /// --------------------------------------
    /// Có thể áp dụng nhiều Common chung với nhau
    /// Chỉ áp dụng được 1 loại Separate, không áp dụng chung với Common
    /// Có thể áp dụng Internal với tất cả
    /// </summary>
    public enum PromotionTypeEnum
    {
        Internal = 0,
        Separate = 1,
        Common = 2
    }


    /// <summary>
    /// GiftType 
    /// --------------------------------------
    /// 0. DiscountRate:        RATE > 0    AMOUNT > 0
    /// 1. Gift:                RATE = 0    AMOUNT = 0      
    /// 2. DiscountAmount:      RATE = 0    AMOUNT > 0      
    /// </summary>
    public enum PromotionGiftTypeEnum
    {
        DiscountRate = 0,
        Gift = 1,
        DiscountAmount = 2
    }
    #endregion




    public enum OrderChangeModeEnum
    {
        PaymentChange,
        OrderDetailChange
    }

    public enum OrderDetailChangeModeEnum
    {
        AddOrderDetail,
        ModifiedOrderDetail,
        RemoveOrderDetail,
        UpdateOrderDetailInfo
    }

    /// <summary>
    /// OrderDetailViewModel status: 
    /// New = 0     - wait to draw
    /// Drawed = 1  - drawed
    /// Moved = 2   - wait to move
    /// </summary>
    public enum SplitOrderDetailStateEnum
    {
        New = 0,
        Moved = 1
    }

    public enum BillTypeEnum
    {
        Customer,
        Cook,
        Cooking,
        Extra,
        Detail
    }

    //Chi dung cho Passio- Thay doi sau
    public enum ProductGroupEnum
    {
        Hot = 0,
        Ice = 1,
        Other = 2,
    }

    public enum TableStatusEnum
    {
        Ready,
        InUse,
        Delivery, // delivery from store
        NotUse,
    }

    public enum TableTypeEnum
    {
        Circle,
        Rectangle,
        All
    }

    public enum TableOrderTypeEnum
    {
        RectangleAtStore = 4,
        CircleTakeAway = 5,
        CircleDelivery = 6,
        All = 0
    }

    public enum PropertyTypeEnum
    {
        PrepareFor = 0,
        IngredientAdjustment = 1,
        Discount = 2,
        Quantity = 3,
        Promotion = 4,
        Size = 5,
        Extra = 6,
        Att1 = 7,
        Att2 = 8,
        Att3 = 9
    }

    public enum CallOutPositionEnum
    {
        MiddleLeft,
        BottomRight,
        TopCenter
    }




    public enum OpenSessionResult
    {
        Success,
        ExistingSession,
        OutOfBound,
        Other
    }

    public enum Flags
    {
        ScreenState,
        ErrorExit,
        User,
        OrderDetail,
        OrderSummary,
        OnlineOrder,
        Product,
        ErrorRestart,
        OnGoingSession,
        NoSession
    }

    public enum ScreenState
    {
        Login,
        Table,
        Order,
        Dashboard,
        OnlineOrder,
        Delivery,
        Config,
        ReviewOrder,
        DropProduct
    }

    public enum ItemPropertyTypeEnum
    {
        Discount = 1,
        ConponentQuantity = 2,
        DeleteItem = 3,
        SplitItem = 4,
        Escape = 5
    }

    public enum ComponentEnum
    {
        Sugar = 1,
        Cream = 2,
        Milk = 3,
        Coffee = 4,
        Ice = 5
    }

    public enum ScreenModeEnum
    {
        Login,
        Table,
        Sale,
        OnlineOrder,
        Report
    }

    public enum OrderDetailPropertyCommandCode
    {
        IncreaseQuantity,
        DecreaseQuantity,
        DeleteOrderDetail,
        NewOrderDetail // Sử dụng khi muốn tách OrderEditViewModel

    }
    public enum PrintGroupEnum
    {
        Printer1=0,
        Printer2=1,
        Printer3=2
    }
    public enum OrderItemClickEventCommandCode
    {
        OrderPanel,
        ChangeTableForm,
    }
    public enum ResponseStatusEnum
    {
        OK = 200,
        CREATED = 201,
        NOCONTENT = 204,
        BADREQUEST = 400,
        UNAUTHORIZE = 401,
        NOTFOUND = 404,
        ERROR = 500
    }
}
