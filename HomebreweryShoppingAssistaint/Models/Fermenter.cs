using HomebreweryShoppingAssistaint.Converters;
using HomebreweryShoppingAssistaint.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HomebreweryShoppingAssistaint.Models
{
    public class Fermenter
    {
        [Key]
        public long Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EnumFermenterType Type { get; set; }
        [JsonConverter(typeof(CustomDateOnlyConverter))]
        public DateOnly StartDate { get; set; }
    }
}
