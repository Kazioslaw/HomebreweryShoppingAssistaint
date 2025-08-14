using System.ComponentModel.DataAnnotations;

namespace HomebreweryShoppingAssistant.Models
{
    public class GeneralProduct
    {
        [Key]
        public int GeneralProductID { get; set; }
        public string Name { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
