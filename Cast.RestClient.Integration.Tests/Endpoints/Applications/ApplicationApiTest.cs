using Cast.RestClient.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Cast.RestClient.Integration.Tests.Endpoints.Applications
{
    public class ApplicationApiTest : IntegrationTest
    {
        [Fact]
        public async Task GetAllApplicationsByDomainId_Returns_Applications()
        {
            // Arrange
            var client = GetBasicAuthClient();

            // Act
            var response = await client.Application.GetAllApplicationsByDomainIdAsync(Options.DomainId);

            // Assert
            Assert.NotNull(response);
            Assert.True(response.Success);
        }

        [Fact(Skip = "Can't be tested with demonstration account")]
        public async Task CreateOrUpdateApplications_Returns_StatusResult()
        {
            // Arrange
            var client = GetBasicAuthClient();
            var applications = new List<Application>
            {
                new Application()
                {
                    Name = "Test",
                    Domains = new List<Domain>(),
                },
            };

            // Act
            var response = await client.Application.CreateOrUpdateApplications(Options.DomainId, applications);

            // Assert
            Assert.NotNull(response);
            Assert.True(response.Success);
        }

        [Fact]
        public async Task GetApplicationCloud_Returns_NoContent()
        {
            // Arrange
            var client = GetBasicAuthClient();

            // Act
            var response = await client.Application.GetCloudItemsByApplicationIdAsync(Options.DomainId, DemoApplicationId);

            // Assert
            Assert.NotNull(response);
            Assert.True(response.Success);
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task GetAggregateCloudItemsByApplicationId_Returns_NoContent()
        {
            // Arrange
            var client = GetBasicAuthClient();

            // Act
            var response = await client.Application.GetAggregateCloudItemsByApplicationIdAsync(Options.DomainId, DemoApplicationId);

            // Assert
            Assert.NotNull(response);
            Assert.True(response.Success);
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task GetAlertsByApplicationId_Returns_Alerts()
        {
            // Arrange
            var client = GetBasicAuthClient();

            // Act
            var response = await client.Application.GetAlertsByApplicationIdAsync(Options.DomainId, DemoApplicationId);

            // Assert
            Assert.NotNull(response);
            Assert.True(response.Success);
        }
    }
}