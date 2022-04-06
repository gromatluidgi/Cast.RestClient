using Cast.RestClient.Objects;

namespace Cast.RestClient.Models.Enums
{
    public class IndustrySegment : StringEnumeration
    {
        public static readonly IndustrySegment Automotive = new IndustrySegment("Automotive");

        private IndustrySegment(string name) : base(name)
        {
        }
    }
}
