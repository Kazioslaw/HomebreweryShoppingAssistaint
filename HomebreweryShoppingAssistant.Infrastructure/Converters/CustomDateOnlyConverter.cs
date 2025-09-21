using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HomebreweryShoppingAssistant.Converters
{
    public class CustomDateOnlyConverter : JsonConverter<DateOnly>
    {
        private const string Format = "yyyy-MM-dd"; // Możesz zmienić na "dd.MM.yyyy" itp.

        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var str = reader.GetString();
            return DateOnly.ParseExact(str!, Format, CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(Format));
        }
    }
}
