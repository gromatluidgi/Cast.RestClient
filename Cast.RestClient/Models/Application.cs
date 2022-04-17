using Cast.RestClient.Models.ValueObjects;

namespace Cast.RestClient.Models
{
    public class Application
    {
        public Application()
        {
        }

        public Application(string name)
        {
            Name = name;
        }

        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ClientRef { get; set; } = string.Empty;

        public IEnumerable<User> Contributors { get; set; } = Enumerable.Empty<User>();

        public IEnumerable<Domain> Domains { get; set; } = Enumerable.Empty<Domain>();

        public IEnumerable<ApplicationMetrics> Metrics { get; set; } = Enumerable.Empty<ApplicationMetrics>();

        public IEnumerable<Tag> Tags { get; set; } = Enumerable.Empty<Tag>();

        public IEnumerable<Survey> Surveys { get; set; } = Enumerable.Empty<Survey>();
    }
}