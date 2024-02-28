using System.ComponentModel.DataAnnotations;

namespace HomebreweryShoppingAssistaint.Models
{
    public class Delivery
    {
        [Key]
        public int DeliveryID { get; set; }
        public DeliverySupplier DeliveryName { get; set; }
        public decimal DeliveryWeight { get; set; }
        public decimal DeliveryPrice {  get; set; }
        public int ShopID { get; set; }

        public Shop Shop { get; set; }

    }

    public enum DeliverySupplier
    {
        Inpost = 1,
        [Display(Name = "Inpost Paczkomat")]
        Inpost_Paczkomat,
        GLS,
        [Display(Name = "GLS Pobraniowa")]
        GLS_Pobraniowa,
        DPD,
        [Display(Name = "DPD Pobraniowa")]
        DPD_Pobraniowa
    }
}
