using Cast.RestClient.Models.ValueObjects;
using Xunit;

namespace Cast.RestClient.Tests.Models.Enums
{
    public class TechnologyTypeTest
    {
        [Fact]
        public void Compare_To_Null()
        {
            var result = Technology.GO.CompareTo(null);
            Assert.Equal(-1, result);
        }
    }
}