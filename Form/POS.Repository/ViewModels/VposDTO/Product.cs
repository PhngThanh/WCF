using System;

namespace POS.Repository.ViewModels.VposDTO
{
    [Serializable]
    public class Product
    {
        public string Name { get; set; } = "";
        public string Code { get; set; } = "";
        public double Price { get; set; } = 0;
        public double DiscountPercent { get; set; } = -1;
        public bool IsExtra { get; set; } = false;

        public override string ToString()
        {
            return Name + "|" + Code + " |" + Price + "|" + DiscountPercent + "|" + IsExtra + "%";
        }
    }
}
