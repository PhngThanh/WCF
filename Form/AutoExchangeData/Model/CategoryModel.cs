using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoExchangeData
{
   public class CategoryModel
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsDisplayed { get; set; }
        public bool IsUsed { get; set; }
    }
}
