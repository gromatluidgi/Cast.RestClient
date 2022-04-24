namespace Cast.RestClient.Models.ValueObjects
{
    public class FingerprintFile
    {
        public string LocalStringPath { get; set; } = string.Empty;

        public string ComponentFilePath { get; set; } = string.Empty;

        public string Sha256 { get; set; } = string.Empty;
    }
}
