using HomebreweryShoppingAssistaint.Enums;

namespace HomebreweryShoppingAssistaint.Models
{
    public class Fermenter
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public EnumFermenterType Type { get; set; }
        public DateOnly StartDate { get; set; }
    }
}
