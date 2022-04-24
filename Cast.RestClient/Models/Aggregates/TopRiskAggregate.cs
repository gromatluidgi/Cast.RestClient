using Cast.RestClient.Converters;
using Cast.RestClient.Models.Abstractions;
using Cast.RestClient.Models.Aggregates;
using System.Text.Json.Serialization;

namespace Cast.RestClient.Models.ValueObjects
{
    [JsonConverter(typeof(AlertAggregateJsonConverterFactory))]
    public class TopRiskAggregate : Aggregate<string, Aggregate<string, Aggregate<string, List<IAlert>>>>
    {
    }
}