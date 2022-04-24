using Cast.RestClient.Models.Enumerations;
using System.Diagnostics.CodeAnalysis;

namespace Cast.RestClient.Models.ValueObjects
{
    /// <summary>
    /// The Common Vulnerability Scoring System (CVSS) provides a way to capture the principal
    /// characteristics of a vulnerability and produce a numerical score reflecting its severity.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Cvss
    {
        public float Score { get; set; }

        public string? AccessVector { get; set; }

        public string? AccessComplexity { get; set; }

        public string? Authentication { get; set; }

        public string? ConfidentidentialityImpact { get; set; }

        public string? IntegrityImpact { get; set; }

        public string? AvailabilityImpact { get; set; }

        public VulnerabilitySource? Source { get; set; }
    }
}
