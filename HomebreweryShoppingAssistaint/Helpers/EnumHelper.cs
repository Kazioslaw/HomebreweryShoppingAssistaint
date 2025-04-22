using System.ComponentModel;

namespace HomebreweryShoppingAssistaint.Helpers
{
    public class EnumHelper
    {
        public static string GetEnumDescription(Enum value)
        {
            if (value == null) { return ""; }

            DescriptionAttribute attribute = value.GetType()
                    .GetField(value.ToString())
                    ?.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .SingleOrDefault() as DescriptionAttribute;
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
