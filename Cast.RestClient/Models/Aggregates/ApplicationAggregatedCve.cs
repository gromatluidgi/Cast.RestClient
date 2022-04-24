using Cast.RestClient.Helpers;
using System.Text.Json.Serialization;

namespace Cast.RestClient.Models.Aggregates
{
    public class ApplicationAggregatedCve
    {
        public ApplicationAggregatedCve(long id, string name)
        {
            Ensure.ArgumentNotNull(id, nameof(id));
            Ensure.ArgumentNotNullOrEmptyString(name, nameof(name));

            Id = id;
            Name = name;
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public double? BusinessValue { get; set; }

        [JsonPropertyName("components")]
        public IEnumerable<Project> Projects { get; set; } = Enumerable.Empty<Project>();

        [JsonPropertyName("cveCriticityAggregateds")]
        public IEnumerable<CveCriticityAggrated> CveCriticities { get; set; } = Enumerable.Empty<CveCriticityAggrated>();
    }
}
