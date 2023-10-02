using System.ComponentModel.DataAnnotations;

namespace HomebreweryShoppingAssistaint.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductPrice { get; set; }
        public string Product30DaysPrice { get; set; }
        public string ProductLink { get; set; }
        public bool IsAvailable { get; set; }
        public int CategoryID { get; set; }
        public int CompanyID { get; set; }
        public int ShopID { get; set; }
      
        public Category Category { get; set; }
        public Company Company { get; set; }
        public Shop Shop { get; set; }

    }

}
