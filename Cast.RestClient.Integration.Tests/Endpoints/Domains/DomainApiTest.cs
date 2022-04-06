using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
