using Cast.RestClient.Models.ValueObjects;
using System.Text.Json.Serialization;

namespace Cast.RestClient.Models
{
    public class Benchmark
    {

        [JsonPropertyName("benchDate")]
        public BusinessDate? Date { get; protected set; }

        [JsonPropertyName("min")]
        public EfficiencyIndicator? Minimum { get; protected set; }

        [JsonPropertyName("max")]
        public EfficiencyIndicator? Maximum { get; protected set; }

        [JsonPropertyName("avg")]
        public EfficiencyIndicator? Average { get; protected set; }

        public int SampleSize { get; protected set; }

        public int YourSize { get; protected set; }
    }
}