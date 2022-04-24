namespace Cast.RestClient.Models.ValueObjects
{
    public class VulnerableSoftware
    {
        public string Vendor { get; set; } = string.Empty;

        public string Product { get; set; } = string.Empty;

        public float SearchScore { get; set; }

        public string PreviousVersion { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Version { get; set; } = string.Empty;

        public string Update { get; set; } = string.Empty;

        public string Edition { get; set; } = string.Empty;
    }
}
