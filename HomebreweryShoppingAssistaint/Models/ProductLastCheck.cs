using System.ComponentModel.DataAnnotations;

namespace HomebreweryShoppingAssistaint.Models
{
    public class ProductLastCheck
    {
        [Key]
        public int ProductLastCheckID { get; set; }
        public ICollection<Product> Product { get; set; }
        public int ProductID { get; set; }

        //Prawdopodobnie do usunięcia bo Product ma ID Sklepu
        public ICollection<Shop> Shop { get; set; }
        public int ShopID { get; set; }
        
        public DateTime LastCheckDateTime { get; set; }
    }
}
