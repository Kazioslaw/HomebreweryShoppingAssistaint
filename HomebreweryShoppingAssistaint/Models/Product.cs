using System.ComponentModel.DataAnnotations;

namespace HomebreweryShoppingAssistaint.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        //public string ProductDescription { get; set; }
        public int? ProductHarvestYear { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal Product30DaysPrice { get; set; }
        public string ProductLink { get; set; }
        public bool IsAvailable { get; set; }

        public int GeneralProductID { get; set; }
        //public int CompanyID { get; set; }
        public int ShopID { get; set; }

        //public Company Company { get; set; }
        public GeneralProduct GeneralProduct { get; set; }
        public Shop Shop { get; set; }


    }

}
