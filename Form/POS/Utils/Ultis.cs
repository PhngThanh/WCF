using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

using POS.Repository;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using POS.Repository.ExchangeDataModel;
using SkyConnect.POSLib.ResponseModels;
using System.Collections.Generic;

namespace POS.Utils
{
    public class UtcDateTime
    {
        //private static readonly ILog log =
        //    LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static DateTime Now()
        {
            //Get time UTC 
            DateTime utcNow = DateTime.UtcNow;
            //Parse UTC to time SE Asia
            DateTime datetimeNow = TimeZoneInfo.ConvertTime(utcNow, TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time"));

            //try
            //{
            //    //TODO:Get online time
            //    //datetimeNow = instant.InZone(timeZone).ToDateTimeUnspecified();
            //}
            //catch (Exception)
            //{
            //    log.Error("Can't get UtcDateTime Now !!! --- "
            //        + DateTime.Now.ToString("HH:mm:ss"));
            //}

            return datetimeNow;
        }
    }

    public class Ultis
    {
        public static string EscapeName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                name = NormalizeString(name);

                // Replaces all non-alphanumeric character by a space
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < name.Length; i++)
                {
                    builder.Append(char.IsLetterOrDigit(name[i]) ? name[i] : ' ');
                }

                name = builder.ToString();

                // Replace multiple spaces into a single dash
                name = Regex.Replace(name, @"[ ]{1,}", @" ", RegexOptions.None);
                name = name.Replace("đ", "d");
                name = name.Replace("Đ", "D");
            }

            return name;
        }

        public static string DisplayName(Enum value)
        {
            try
            {
                Type enumType = value.GetType();
                var enumValue = Enum.GetName(enumType, value);
                MemberInfo member = enumType.GetMember(enumValue)[0];

                var attrs = member.GetCustomAttributes(typeof(DisplayAttribute), false);
                var outString = ((DisplayAttribute)attrs[0]).Name;

                if (((DisplayAttribute)attrs[0]).ResourceType != null)
                {
                    outString = ((DisplayAttribute)attrs[0]).GetName();
                }

                return outString;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }


        private static string NormalizeString(string value)
        {
            string normalizedFormD = value.Normalize(NormalizationForm.FormD);
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < normalizedFormD.Length; i++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(normalizedFormD[i]);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    builder.Append(normalizedFormD[i]);
                }
            }

            return builder.ToString().Normalize(NormalizationForm.FormC);
        }

        /// <summary>
        /// Check for POS offline mode
        /// </summary>
        public static bool EnableConnection()
        {
            var storeId = MainForm.StoreInfo.StoreId.ToLower();
            var serverUri = MainForm.StoreInfo.ServerUri.ToLower();
            var serverToken = MainForm.StoreInfo.ServerToken.ToLower();
            var autoExchange = MainForm.PosConfig.EnableRunningAutoData.Trim().ToLower() == "true";
            var autoGetOrder = MainForm.PosConfig.EnableGetAndProcessOrderFromServer.Trim().ToLower() == "true";

            // cái này không phải offline mode, nhưng máy bếp chỉ cần connect vào db POS là đc 
            var isOnlyUseKitchen = MainForm.PosConfig.IsOnlyUseKitchen.Trim().ToLower() == "true";

            if (isOnlyUseKitchen) { return false; }
            if (!autoExchange && !autoGetOrder) { return false; }
            if (string.IsNullOrEmpty(storeId)
                || string.IsNullOrEmpty(serverUri)
                || string.IsNullOrEmpty(serverToken)) { return false; }

            return true;
        }

        public static string GetOrderStatusNameByEnum(OrderStatusEnum statusEnum)
        {
            switch (statusEnum)
            {
                case OrderStatusEnum.New:
                    return "Mới tạo";
                case OrderStatusEnum.Cancel:
                    return "Hủy.";
                case OrderStatusEnum.Finish:
                    return "Hoàn tất.";
                case OrderStatusEnum.PreCancel:
                    return "Hủy sớm.";
                case OrderStatusEnum.PosCancel:
                    return "Hủy";
                case OrderStatusEnum.PosFinished:
                    return "Hoàn tất";
                case OrderStatusEnum.PosPreCancel:
                    return "Hủy sớm";
                case OrderStatusEnum.PosProcessing:
                    return "Đang chế biến";
                default:
                    return "";
            }
        }

        public static string GetDeliveryStatusNameByEnum(DeliveryStatusEnum statusEnum)
        {
            switch (statusEnum)
            {
                case DeliveryStatusEnum.New:
                    return "Mới tạo";
                case DeliveryStatusEnum.Assigned:
                    return "Đang chờ";
                case DeliveryStatusEnum.PreCancel:
                    return "Hủy sớm";
                case DeliveryStatusEnum.Cancel:
                    return "Hủy";
                case DeliveryStatusEnum.PosAccepted:
                    return "Đã chấp nhận";
                case DeliveryStatusEnum.PosRejected:
                    return "Đã từ chối";
                case DeliveryStatusEnum.Finish:
                    return "Hoàn tất";
                case DeliveryStatusEnum.Delivery:
                    return "Đang giao hàng";
                default:
                    return "";
            }
        }
    }

    public class Converter
        {
            public static List<CardAccountModel> convertAccounts(IEnumerable<AccountVM> accounts)
            {
                List<CardAccountModel> listAccount = new List<CardAccountModel>();
                foreach (var account in accounts)
                {
                    CardAccountModel cardAccount = new CardAccountModel()
                    {
                        AccountCode = account.AccountCode,
                        Balance = account.Balance,
                        BrandId = account.BrandId,
                        Level = account.Level_,
                        Type = account.Type,
                    };
                    listAccount.Add(cardAccount);
                }

                return listAccount;
            }
        }


}
