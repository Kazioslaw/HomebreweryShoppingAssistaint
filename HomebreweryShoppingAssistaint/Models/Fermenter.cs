using HomebreweryShoppingAssistaint.Enums;
using System.ComponentModel.DataAnnotations;

namespace HomebreweryShoppingAssistaint.Models
{
    public class Fermenter
    {
        [Key]
        public long Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public EnumFermenterType Type { get; set; }
        public DateOnly StartDate { get; set; }
    }
}
