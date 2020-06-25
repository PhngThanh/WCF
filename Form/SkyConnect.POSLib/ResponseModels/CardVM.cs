using SkyConnect.POSLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyConnect.POSLib.ResponseModels
{
    public class CardVM
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public System.DateTime AppliedTime { get; set; }
        public string Provider { get; set; }
        public bool Active { get; set; }
        public Nullable<int> MembershipId { get; set; }
        public string MembershipCode { get; set; }
        public string MembershipName { get; set; }
        public string MembershipTypeName { get; set; }
        public int MembershipStatus { get; set; }
        public string MembershipTypeAppendCode { get; set; }
        public IEnumerable<AccountVM> Accounts { get; set; }
        public double Balance
        {
            get
            {
                double balance = 0;
                if (this.Accounts == null || Accounts.Count() <= 0)
                {
                    return 0;
                }
                else
                {
                    foreach (var account in Accounts)
                    {
                        if (account.Type == (int)SkyConnectAccountTypeEnum.CreditAccount)
                        {
                            balance += account.Balance ?? 0;
                        }
                    }
                }
                return balance;
            }
        }
        public string FirstAccountCode
        {
            get
            {
                if (Accounts != null && Accounts.Count() > 0)
                {
                    return Accounts.FirstOrDefault().AccountCode;
                }
                else
                {
                    return "";
                }
            }
        }
        public string CustomerName { get; set; }
        public int? CustomerId { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }
        public void PrintData()
        {
            Console.WriteLine("\nMã thẻ: {0}\nSố dư trong thẻ: {1}\nThẻ của khách: {2}", this.Code, this.Balance, this.CustomerName);
        }
    }
}
