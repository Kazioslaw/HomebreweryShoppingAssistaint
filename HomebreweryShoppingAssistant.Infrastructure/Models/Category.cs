using System.ComponentModel.DataAnnotations;

namespace HomebreweryShoppingAssistant.Models
{
	public enum ProductCategory
	{
		Słód = 1,
		Drożdże,
		Chmiel,
		Inne
	}
	public class Category
	{
		[Key]
		public int CategoryID { get; set; }
		public ProductCategory CategoryName { get; set; }

		public ICollection<GeneralProduct> GeneralProducts { get; set; }
	}
}
