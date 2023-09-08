namespace HomebreweryShoppingAssistaint.Models
{
    public enum ShopNameEnum
    {
        Browamator,
        TwojBrowar,
        Homebrewing,
        AlePiwo,
        CentrumPiwowarstwa

    }
    public class Shop
    {
        public int ShopID { get; set; }
        public ShopNameEnum ShopName { get; set; }
        public string ShopLink { get; set; }       

        public Shop(int shopID, ShopNameEnum shopName, string shopLink)
        {
            ShopID = shopID;
            ShopName = shopName;
            ShopLink = shopLink;
        }
        public ICollection<Product> Products { get; set; }
    }
}
