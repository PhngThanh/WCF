using POS.Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository.ExchangeDataModel
{
    public class ResultModel
    {
        public string Message { get; set; }
        public bool Success { get; set; }
    }

    public class ResultModelWithContent
    {
        public Object Content { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
