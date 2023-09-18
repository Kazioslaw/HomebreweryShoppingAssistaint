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
        public int CategoryId { get; set; }
        public ProductCategory CategoryName { get; set; }

        public Category(int categoryId, ProductCategory categoryName)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
        }

        public ICollection<Product> Product { get; set; }
    }
}
