using System.ComponentModel.DataAnnotations;

namespace HomebreweryShoppingAssistant.Models
{
	public class ShopCheckHistory
	{
		[Key]
		public int ShopCheckHistoryID { get; set; }
		public DateTime CheckDateTime { get; set; }

		public int ShopID { get; set; }
		public Shop Shop { get; set; }
	}
}
