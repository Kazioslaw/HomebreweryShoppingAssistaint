using System.ComponentModel.DataAnnotations;

namespace HomebreweryShoppingAssistaint.Models
{
    public class ShopLastCheck
    {
        [Key]
        public int ShopLastCheckID { get; set; }
        public int ShopID { get; set; }
        public DateTime LastCheckDateTime { get; set; }
    }
}
