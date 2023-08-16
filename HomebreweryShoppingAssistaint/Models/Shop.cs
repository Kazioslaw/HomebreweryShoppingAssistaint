namespace HomebreweryShoppingAssistaint.Models
{
    public class Shop
    {
        public int ShopID { get; set; }
        public string ShopName { get; set; }
        public string ShopLink { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
