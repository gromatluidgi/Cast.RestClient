namespace Cast.RestClient.Models
{
    public class Project
    {
        public long Id { get; set; }

        public string ClientRef { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Url { get; set; } = string.Empty;

        public string Version { get; set; } = string.Empty;

        public long ReleaseDate { get; set; }

        public IEnumerable<License> Licenses { get; set; } = Enumerable.Empty<License>();
    }
}
