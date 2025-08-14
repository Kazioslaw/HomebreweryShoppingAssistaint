using System.ComponentModel.DataAnnotations;

namespace HomebreweryShoppingAssistant.Models
{
	public class ProductCheckHistory
	{
		[Key]
		public int ProductCheckHistoryID { get; set; }
		public int ProductID { get; set; }
		public Product Product { get; set; }
		public DateTime CheckDateTime { get; set; }
	}
}
