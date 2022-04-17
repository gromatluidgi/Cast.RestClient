using Cast.RestClient.Models.Abstractions;

namespace Cast.RestClient.Models.ValueObjects
{
    public class RiskAlertResult : IAlert
    {
        public string Alert { get; set; } = string.Empty;

        public object? Labels { get; set; }

        public float Usage { get; set; }

        public long Weight { get; set; }

        public int BadAlertCount { get; set; }

        public string[] FilesTriggeredAlert { get; set; } = new string[0];

        public double Score { get; set; }

        public int TotalWeight { get; set; }
    }
}