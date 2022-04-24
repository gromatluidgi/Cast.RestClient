using Cast.RestClient.Converters;
using Cast.RestClient.Models.ValueObjects;
using System.Text.Json.Serialization;

namespace Cast.RestClient.Models.Aggregates
{
    [JsonConverter(typeof(AggregateJsonConverterFactory))]
    public class BenchmarkAlertsAggregate : Aggregate<string, Aggregate<string, List<BenchmarkAlert>>>
    {
    }
}