using System.ComponentModel.DataAnnotations;

namespace HomebreweryShoppingAssistaint.Models
{
    public enum ShopNameEnum
    {
        [Display(Name = "Ale Piwo")]
        AlePiwo,
        Browamator,
        [Display(Name = "Centrum Piwowarstwa")]
        CentrumPiwowarstwa,
        [Display(Name = "Home Brewing")]
        Homebrewing,
        [Display(Name = "Twój Browar")]
        TwojBrowar
    }
    public class Shop
    {
        [Key]
        public int ShopID { get; set; }
        public ShopNameEnum ShopName { get; set; }
        public string ShopLink { get; set; }       

        public ICollection<Product> Product { get; set; }
    }
}
