using System.ComponentModel.DataAnnotations;

namespace HomebreweryShoppingAssistaint.Models
{
    public class ProductLastCheck
    {
        [Key]
        public int ProductCheckHistoryID { get; set; }
        public ICollection<Product> Product { get; set; }
        public int ProductID { get; set; }
        public DateTime CheckDateTime { get; set; }
    }
}
