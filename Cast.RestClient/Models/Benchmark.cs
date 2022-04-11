using Cast.RestClient.Models.ValueObjects;
using System.Text.Json.Serialization;

namespace Cast.RestClient.Models
{
    public class Benchmark
    {
        [JsonPropertyName("benchDate")]
        public BusinessDate Date { get; protected set; } = BusinessDate.Null;

        [JsonPropertyName("min")]
        public EfficiencyIndicator Minimum { get; protected set; } = EfficiencyIndicator.Null;

        [JsonPropertyName("max")]
        public EfficiencyIndicator Maximum { get; protected set; } = EfficiencyIndicator.Null;

        [JsonPropertyName("avg")]
        public EfficiencyIndicator Average { get; protected set; } = EfficiencyIndicator.Null;

        public int SampleSize { get; protected set; }

        public int YourSize { get; protected set; }
    }
}