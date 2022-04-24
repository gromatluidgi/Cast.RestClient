using Cast.RestClient.Converters;
using Cast.RestClient.Objects;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Cast.RestClient.Models.Enumerations
{
    [ExcludeFromCodeCoverage]
    [JsonConverter(typeof(EnumerationJsonConverterFactory))]
    public sealed class Technology : Enumeration
    {
        public static readonly Technology KSH = new("KSH");
        public static readonly Technology GO = new("GO");

        private Technology(string name)
            : base(name)
        {
        }
    }
}