using Cast.RestClient.Clients.Applications;
using Cast.RestClient.Clients.Applications.Queries;
using Cast.RestClient.Models;
using Cast.RestClient.Models.Aggregates;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Cast.RestClient.Tests.Clients.Applications
{
    public class ApplicationApiTest
    {
        [Fact]
        public void Ctor()
        {
            // Arrange
            var client = TestHelpers.GetFakeApiClient();
            
            // Act
            var api = new ApplicationApi(client);

            // Assert
            Assert.NotNull(api.ApiClient);
        }

        #region GET

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
            var parameters = new ApplicationQuery(0, 0, new[] { ApplicationExpand.Survey });

            // Act
            var response = await api.GetApplicationByIdAsync(0, 0, parameters);

            // Assert
            Assert.NotNull(response);
            Assert.True(response.Success);
            Assert.NotNull(response.Request);
            Assert.Equal(HttpMethod.Get, response.Request!.Method);
            Assert.Equal("domains/0/applications/0", response.Request!.ResourcePath);
            Assert.Equal(TestHelpers.FakeApiUrl + "/domains/0/applications/0?maxEntryPerPage=0&pageOffset=0&expand=survey", response.Request.RequestUri!.ToString());
        }

        #endregion GET

        #region POST

        [Fact]
        public async Task GetApplicationAggregatedCves_Returns_ListOf_ApplicationAggregatedCve()
        {
            // Arrange
            var fakeResponse = TestHelpers.GetFakeResponse<IEnumerable<ApplicationAggregatedCve>>();
            var api = new ApplicationApi(TestHelpers.GetFakeApiClientWithResponse(fakeResponse));

            // Act
            var response = await api.GetApplicationAggregatedCvesAsync(0);

            // Assert
            Assert.NotNull(response);
            Assert.True(response.Success);
            Assert.NotNull(response.Request);
            Assert.Equal(HttpMethod.Post, response.Request!.Method);
            Assert.Equal("domains/0/applications/vulnerabilities/aggregated", response.Request!.ResourcePath);
        }

        #endregion POST

        #region DELETE

        [Fact]
        public async Task DeleteApplicationByIdAsync_Returns_NoContent()
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

        #endregion DELETE
    }
}