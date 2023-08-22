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
        public int ShopID { get; set; }


        public Product(int productID, string productName, string productDescription, string productPrice, string product30DaysPrice, int categoryID, int shopID)
        {
            ProductID = productID;
            ProductName = productName;
            ProductDescription = productDescription;
            ProductPrice = productPrice;
            Product30DaysPrice = product30DaysPrice;
            CategoryID = categoryID;
            ShopID = shopID;
        }
        public Category Category { get; set; }
        public Shop Shop { get; set; }

    }

}
