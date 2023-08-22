namespace HomebreweryShoppingAssistaint.Models
{
    public class Shop
    {
        public int ShopID { get; set; }
        public string ShopName { get; set; }
        public string ShopLink { get; set; }       

        public Shop(int shopID, string shopName, string shopLink)
        {
            ShopID = shopID;
            ShopName = shopName;
            ShopLink = shopLink;
        }
        public ICollection<Product> Products { get; set; }
    }
}
