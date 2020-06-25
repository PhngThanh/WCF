using POS.Repository;
using POS.Repository.ExchangeDataModel;
using POS.Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterManager
{
    public class CurrentOrderManager
    {
        public OrderEditViewModel OrderEditViewModel { get; set; }
        public OrderEditViewModel TmpOrderEditViewModel { get; set; }
        public int? CardType { get; set; }
        public PaymentTypeEnum paymentType { get; set; }

        public CardCustomerModel CurrentCustomerModel { get; set; }
        public VoucherResultModel CurrentVoucherModel { get; set; }

        public event Action<OrderDetailEditViewModel, OrderDetailChangeModeEnum> NotifyChangeOrderDetail;

        //public static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public int _currentOrderDetailId = 0;
        public int _currentMappingId = 0;
        public bool isChange = false;

        /// <summary>
        /// True: khi order được edit
        /// False: khi order được lưu vào database
        /// </summary>
        public bool isDirty = false;

        #region getter and setter
        //Contructor for orderEditViewModel
        public OrderEditViewModel getOrderEditViewModel()
        {
            return OrderEditViewModel;
        }

        public List<PaymentEditViewModel> getPaymentEditViewModels()
        {
            return OrderEditViewModel.getPaymentEditViewModels();
        }

        public void setOrderEditViewModel(OrderEditViewModel order)
        {
            OrderEditViewModel = order;
        }

        public bool hasOrder()
        {
            if (OrderEditViewModel == null)
            {
                return false;
            }
            return true;
        }

        //Contructor for CurrentCustomerModel
        public CardCustomerModel getCurrentCustomerModel()
        {
            return CurrentCustomerModel;
        }

        public void setCurrentCustomerModel(CardCustomerModel currentCustomer)
        {
            CurrentCustomerModel = currentCustomer;
        }

        public Boolean isCurrentCustomerModelEmpty()
        {
            if (CurrentCustomerModel != null)
            {
                return false;
            }
            return true;
        }

        //contructor for cardType 
        public int? getCardType()
        {
            return CardType;
        }

        public void setCardType(int? cardType)
        {
            CardType = cardType;
        }

        //contructor for CurrentVoucherModel
        public VoucherResultModel getCurrentVoucherModel()
        {
            return CurrentVoucherModel;
        }

        public void setCurrentVoucherModel(VoucherResultModel model)
        {
            CurrentVoucherModel = model;
        }

        //contrutor for TmpOrderEditViewModel
        public OrderEditViewModel getTmpOrderEditViewModel()
        {
            return TmpOrderEditViewModel;
        }

        public void setTmpOrderEditViewModel(OrderEditViewModel tmpOrderView)
        {
            TmpOrderEditViewModel = tmpOrderView;
        }

        //contructor for _currentOrderDetailId
        public int getCurrentOrderDetailId()
        {
            return _currentOrderDetailId;
        }
        #endregion












        /// <summary>
        /// Get OrderDetailViewModel of current OrderEditViewModel
        /// </summary>
        /// <param name="isRemoveCancel">True: remove items with CANCEL status- False: Get all</param>
        public List<OrderDetailEditViewModel> GetOrderDetails(bool isRemoveCancel)
        {
            if (isRemoveCancel)
            {

                return OrderEditViewModel.getOrderDetailEditViewModels().Where(od => od.Status == (int)OrderDetailStatusEnum.New ||
                                                       od.Status == (int)OrderDetailStatusEnum.Processing ||
                                                       od.Status == (int)OrderDetailStatusEnum.PosFinished ||
                                                       od.Status == (int)OrderDetailStatusEnum.Finish).ToList();
            }
            else
            {
                return OrderEditViewModel.getOrderDetailEditViewModelsList();
            }
        }

        //public List<OrderDetailEditViewModel> GetTempOrderDetails(bool isRemoveCancel)
        //{
        //    if (TmpOrderEditViewModel == null)
        //    {
        //        TmpOrderEditViewModel = new OrderEditViewModel();
        //    }
        //    if (isRemoveCancel)
        //    {
        //        return TmpOrderEditViewModel.OrderDetailEditViewModels.Where(od => od.Status == (int)OrderDetailStatusEnum.New ||
        //                                               od.Status == (int)OrderDetailStatusEnum.Processing ||
        //                                               od.Status == (int)OrderDetailStatusEnum.PosFinished ||
        //                                               od.Status == (int)OrderDetailStatusEnum.Finish).ToList();
        //    }
        //    else
        //    {
        //        return TmpOrderEditViewModel.getOrderDetailEditViewModelsList()();
        //    }
        //}

        public List<OrderDetailEditViewModel> GetExtraAndMainOrderDetails(int mainItemId)
        {
            //Dam bao Main Item luon duong truoc trong danh sach
            return OrderEditViewModel.OrderDetailEditViewModels.Where(od => od.OrderDetailID == mainItemId || od.ParentId == mainItemId
                 && (od.Status == (int)OrderDetailStatusEnum.New
                    || od.Status == (int)OrderDetailStatusEnum.Processing
                    || od.Status == (int)OrderDetailStatusEnum.PosFinished
                    || od.Status == (int)OrderDetailStatusEnum.Finish
                    || od.Status == (int)OrderDetailStatusEnum.PosCancel
                    || od.Status == (int)OrderDetailStatusEnum.Cancel)).
                OrderBy(od => od.ParentId).ToList();
        }

        public List<OrderDetailEditViewModel> GetExtraOrderDetails(int mainOrderDetailId)
        {
            return OrderEditViewModel.OrderDetailEditViewModels.Where(od => (od.ParentId == mainOrderDetailId)
                 && (od.Status == (int)OrderDetailStatusEnum.New
                    || od.Status == (int)OrderDetailStatusEnum.Processing
                    || od.Status == (int)OrderDetailStatusEnum.PosFinished
                    || od.Status == (int)OrderDetailStatusEnum.Finish
                    || od.Status == (int)OrderDetailStatusEnum.PosCancel
                    || od.Status == (int)OrderDetailStatusEnum.PosCancel
                    || od.Status == (int)OrderDetailStatusEnum.Cancel)).ToList();
        }


        public OrderDetailEditViewModel GetOrderDetailById(int orderDetailId)
        {
            return OrderEditViewModel.OrderDetailEditViewModels.FirstOrDefault(od => od.OrderDetailID == orderDetailId);
        }
    }
}
