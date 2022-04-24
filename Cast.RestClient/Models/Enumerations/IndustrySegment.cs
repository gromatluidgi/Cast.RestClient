using Cast.RestClient.Converters;
using Cast.RestClient.Objects;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Cast.RestClient.Models.Enumerations
{
    [ExcludeFromCodeCoverage]
    [JsonConverter(typeof(EnumerationJsonConverterFactory))]
    public sealed class IndustrySegment : Enumeration
    {
        public static readonly IndustrySegment Automotive = new("Automotive");
        public static readonly IndustrySegment ConsumerAndPackagedGoods = new("ConsumerAndPackagedGoods");
        public static readonly IndustrySegment Energy = new("Energy");
        public static readonly IndustrySegment FinancialServices = new("FinancialServices");
        public static readonly IndustrySegment Government = new("Government");
        public static readonly IndustrySegment Healthcare = new("Healthcare");
        public static readonly IndustrySegment Insurance = new("Insurance");
        public static readonly IndustrySegment ITAndBusinessConsulting = new("ITAndBusinessConsulting");
        public static readonly IndustrySegment Manufacturing = new("Manufacturing");
        public static readonly IndustrySegment Media = new("Media");
        public static readonly IndustrySegment Other = new("Other");
        public static readonly IndustrySegment Pharmaceuticals = new("Pharmaceuticals");
        public static readonly IndustrySegment Retail = new("Retail");
        public static readonly IndustrySegment SoftwareISV = new("SoftwareISV");
        public static readonly IndustrySegment TechnologyHardware = new("TechnologyHardware");
        public static readonly IndustrySegment Telecommunications = new("Telecommunications");
        public static readonly IndustrySegment Transportation = new("Transportation");
        public static readonly IndustrySegment Travel = new("Travel");
        public static readonly IndustrySegment Utilities = new("Utilities");

        private IndustrySegment(string name)
            : base(name)
        {
        }
    }
}