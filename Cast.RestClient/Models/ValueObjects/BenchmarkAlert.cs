using System.Text.Json.Serialization;

namespace Cast.RestClient.Models.ValueObjects
{
    public class BenchmarkAlert
    {
        public BenchmarkAlert()
        { }

        [JsonPropertyName("min")]
        public double Minimum { get; set; }

        [JsonPropertyName("max")]
        public double Maximum { get; set; }

        [JsonPropertyName("avg")]
        public double Average { get; set; }
    }
}