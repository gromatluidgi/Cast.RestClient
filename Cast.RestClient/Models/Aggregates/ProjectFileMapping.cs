using Cast.RestClient.Models.ValueObjects;

namespace Cast.RestClient.Models.Aggregates
{
    public class ProjectFileMapping
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ClientRef { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Url { get; set; } = string.Empty;

        public string Version { get; set; } = string.Empty;

        public long ReleaseDate { get; set; }

        public IEnumerable<Weakness> Cwes { get; set; } = Enumerable.Empty<Weakness>();

        public IEnumerable<License> Licenses { get; set; } = Enumerable.Empty<License>();

        public bool LicenseFuturChange { get; set; }

        public bool LicensePastChange { get; set; }

        public string Origin { get; set; } = string.Empty;

        public string[] Copyrights { get; set; } = Array.Empty<string>();

        public IEnumerable<FingerprintFile> Files { get; set; } = Enumerable.Empty<FingerprintFile>();
    }
}
