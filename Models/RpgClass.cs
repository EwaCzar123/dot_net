using System.Text.Json.Serialization;

namespace dot_net.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
         Knight,
         Mage,
         Cleric
    }
}