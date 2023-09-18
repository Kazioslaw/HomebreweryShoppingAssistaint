using System.ComponentModel.DataAnnotations.Schema;

namespace HomebreweryShoppingAssistaint.Models
{
    public class LastCheck
    {
        public int LastCheckID { get; set; }
        public int ProductID { get; set; }
        public ICollection<Product> Product { get; set; }
        public int CategoryID { get; set; }
        public ICollection<Category> Category { get; set; }     
        public int ShopID { get; set; }
        public ICollection<Shop> Shop { get; set; }
        public DateTime LastCheckDateTime { get; set; }
        public LastCheck()
        {

        }
    }
}
