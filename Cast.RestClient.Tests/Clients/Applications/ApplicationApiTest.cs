using Cast.RestClient.Clients.Applications;
using Cast.RestClient.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Cast.RestClient.Tests.Clients.Applications
{
    public class ApplicationApiTest
    {
        [Fact]
        public async Task GetAllApplicationsByDomainId_Returns_Applications()
        {
            // Arrange
            var fakeResponse = TestHelpers.GetFakeResponse<IEnumerable<Application>>();
            var api = new ApplicationApi(TestHelpers.GetFakeApiClientWithResponse(fakeResponse));

            // Act
            var response = await api.GetAllApplicationsByDomainIdAsync(0);

            // Assert
            Assert.NotNull(response);
            Assert.True(response.Success);
            Assert.NotNull(response.Request);
            Assert.Equal(HttpMethod.Get, response.Request!.Method);
            Assert.Equal("domains/0/applications", response.Request!.ResourcePath);
            Assert.Equal(TestHelpers.FakeApiUrl + "/domains/0/applications", response.Request.RequestUri!.ToString());
        }

        [Fact]
        public async Task GetApplicationByIdAsync_Returns_Application()
        {
            // Arrange
            var fakeResponse = TestHelpers.GetFakeResponse<Application>();
            var api = new ApplicationApi(TestHelpers.GetFakeApiClientWithResponse(fakeResponse));

            // Act
            var response = await api.GetApplicationByIdAsync(0, 0, null);

            // Assert
            Assert.NotNull(response);
            Assert.True(response.Success);
            Assert.NotNull(response.Request);
            Assert.Equal(HttpMethod.Get, response.Request!.Method);
            Assert.Equal("domains/0/applications/0", response.Request!.ResourcePath);
            Assert.Equal(TestHelpers.FakeApiUrl + "/domains/0/applications/0", response.Request.RequestUri!.ToString());
        }

        [Fact]
        public async Task DeleteApplicationByIdAsync_Returns_Success()
        {
            // Arrange
            var fakeResponse = TestHelpers.GetFakeResponse();
            var api = new ApplicationApi(TestHelpers.GetFakeApiClientWithResponse(fakeResponse));

            // Act
            var response = await api.DeleteApplicationByIdAsync(0, 0);

            // Assert
            Assert.NotNull(response);
            Assert.True(response.Success);
            Assert.NotNull(response.Request);
            Assert.Equal(HttpMethod.Delete, response.Request!.Method);
            Assert.Equal("domains/0/applications/0", response.Request!.ResourcePath);
            Assert.Equal(TestHelpers.FakeApiUrl + "/domains/0/applications/0", response.Request.RequestUri!.ToString());
        }
    }
}