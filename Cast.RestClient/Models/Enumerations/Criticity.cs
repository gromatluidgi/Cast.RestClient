using System.Text.Json.Serialization;

namespace Cast.RestClient.Models.Enumerations
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Criticity
    {
        CRITICAL,
        HIGH,
        MEDIUM,
        LOW,
        UNKNOWN,
        ADVISORY,
    }
}
