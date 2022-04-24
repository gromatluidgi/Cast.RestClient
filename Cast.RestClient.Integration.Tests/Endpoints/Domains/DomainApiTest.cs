using System.Threading.Tasks;
using Xunit;

namespace Cast.RestClient.Integration.Tests.Endpoints.Domains
{
    public class DomainApiTest : IntegrationTest
    {
        [Fact]
        public async Task GetDomainById_Returns_Domain()
        {
            var client = GetBasicAuthClient();

            var response = await client.Domain.GetDomainByIdAsync(Options.DomainId);

            Assert.NotNull(response);
            Assert.True(response.Success);
        }

        [Fact]
        public async Task GetIndustrySegments_Returns_IndustrySegments()
        {
            var client = GetBasicAuthClient();

            var response = await client.Domain.GetIndustrySegmentsAsync();

            Assert.NotNull(response);
            Assert.True(response.Success);
            Assert.NotNull(response.Data);
            // Making an assertion on data length, allow changes detection on server-side.
            Assert.Equal(19, response.Data!.Count);
        }
    }
}
