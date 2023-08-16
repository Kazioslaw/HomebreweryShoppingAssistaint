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
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public int ShopID { get; set; }
        public Shop Shop { get; set; }

    }

}
