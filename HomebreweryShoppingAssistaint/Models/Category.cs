using System.ComponentModel.DataAnnotations;

namespace HomebreweryShoppingAssistaint.Models
{
    public enum ProductCategory
    {
        Słód,
        Drożdże,
        Chmiel,
        Inne
    }
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public ProductCategory CategoryName { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}
