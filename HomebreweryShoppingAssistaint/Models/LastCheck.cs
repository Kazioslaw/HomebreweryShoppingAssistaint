namespace HomebreweryShoppingAssistaint.Models
{
    public class LastCheck
    {
        public int LastCheckID { get; set; }
        public int ProductID { get; set; }
        public ICollection<Product> Products { get; set; }
        public int CategoryID { get; set; }
        public ICollection<Category> Categories { get; set; }
        public int ShopID { get; set; }
        public ICollection<Shop> Shops { get; set; }
        public DateTime LastCheckDateTime { get; set; }
        public LastCheck()
        {

        }
    }
}
