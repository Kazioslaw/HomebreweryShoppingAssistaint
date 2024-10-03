using System.ComponentModel;

namespace HomebreweryShoppingAssistaint.Enums
{
    public enum EnumFermenterType
    {
        [Description("Wiadro plastikowe")]
        PlasticBucket = 1,
        [Description("Słój szklany")]
        GlassJar = 2,
        [Description("Keg typu Cornelius")]
        CorneliusKeg = 3,
        [Description("Keg typu Petainer")]
        PetainerKeg = 4,
    }
}