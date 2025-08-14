using System.ComponentModel.DataAnnotations;

namespace HomebreweryShoppingAssistant.Models
{
	public enum ShopName
	{
		[Display(Name = "Ale Piwo")]
		AlePiwo = 1,
		Browamator,
		[Display(Name = "Centrum Piwowarstwa")]
		CentrumPiwowarstwa,
		[Display(Name = "Home Brewing")]
		Homebrewing,
		[Display(Name = "Twój Browar")]
		TwojBrowar
	}
	public class Shop
	{
		[Key]
		public int ShopID { get; set; }
		public ShopName ShopName { get; set; }
		public string ShopLink { get; set; }

		public ICollection<Product> Product { get; set; }
	}
}
