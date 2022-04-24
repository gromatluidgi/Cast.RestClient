using Cast.RestClient.Models.Enumerations;
using System.Text.Json.Serialization;

namespace Cast.RestClient.Models.Aggregates
{
    public class CveCriticityAggrated
    {
        public Criticity Criticity { get; set; }

        [JsonPropertyName("vulnerability")]
        public IEnumerable<VulnerabilityDetailed> Vulnerabilities { get; set; } = Enumerable.Empty<VulnerabilityDetailed>();
    }
}
