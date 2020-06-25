using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyConnect.POSSimulator.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string Code { get; set; }
        public string ProductName { get; set; }
        public string ShortName { get; set; }
        public double Price { get; set; }
        public string PicURL { get; set; }
        public int CatID { get; set; }
        public Nullable<bool> IsAvailable { get; set; }
        public double DiscountPercent { get; set; }
        public double DiscountPrice { get; set; }
        public int ProductType { get; set; }
        public int DisplayOrder { get; set; }
        public Nullable<bool> HasExtra { get; set; }
        public bool IsFixedPrice { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public Nullable<int> ColorGroup { get; set; }
        public int Group { get; set; }
        public Nullable<bool> IsMenuDisplay { get; set; }
        public Nullable<int> GeneralProductId { get; set; }
        public string Att1 { get; set; }
        public string Att2 { get; set; }
        public string Att3 { get; set; }
        public Nullable<int> MaxExtra { get; set; }
        public Nullable<bool> IsMostOrder { get; set; }
        public bool IsUsed { get; set; }
        public bool IsDefaultChildProduct { get; set; }
    }
}
