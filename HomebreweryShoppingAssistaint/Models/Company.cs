namespace HomebreweryShoppingAssistaint.Models
{
    public class Company
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
