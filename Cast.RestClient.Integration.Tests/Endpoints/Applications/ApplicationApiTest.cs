using Cast.RestClient.Clients.Applications.Commands;
using Cast.RestClient.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Cast.RestClient.Integration.Tests.Endpoints.Applications
{
    /// <summary>
    /// 34 Endpoints to test.
    /// </summary>
    public class ApplicationApiTest : IntegrationTest
    {
        #region GET

        /// <summary>
        /// Test remote api endpoint <b>domains/{domainId}/applications</b>.
        /// </summary>
        /// <remarks>
        /// https://rpa.casthighlight.com/api-doc/index.html#/Applications/getApplications
        /// </remarks>
        /// <returns></returns>
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

        [Fact(Skip = "Not working or can't be tested with demonstration account")]
        public async Task GetApplicationByClientRef_Returns_Application()
        {
            // Arrange
            var client = GetBasicAuthClient();

            // Act
            var response = await client.Application.GetApplicationByClientRefAsync(Options.DomainId, string.Empty);

            // Assert
            Assert.NotNull(response);
        }


        [Fact(Skip = "Not working or can't be tested with demonstration account")]
        public async Task AddMod_Returns_NoContent()
        {
            // Arrange
            var client = GetBasicAuthClient();

            // Act
            var response = await client.Application.AddModAsync(Options.DomainId);

            // Assert
            Assert.NotNull(response);
        }

        [Fact]
        public async Task GetCloudItemsByApplicationId_Returns_NoContent()
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

        [Fact]
        public async Task GetFingerpintFilesAsync_Returns_ProjectFileMapping()
        {
            // Arrange
            var client = GetBasicAuthClient();

            // Act
            var response = await client.Application.GetFingerpintFilesAsync(Options.DomainId, DemoApplicationId);

            // Assert
            Assert.NotNull(response);
            Assert.True(response.Success);
        }

        [Fact]
        public async Task GetProjectFingerpintFilesAsync_Returns_ProjectFileMapping()
        {
            // Arrange
            var client = GetBasicAuthClient();

            // Act
            var response = await client.Application.GetProjectFingerpintFilesAsync(Options.DomainId, DemoApplicationId, DemoProjectId);

            // Assert
            Assert.NotNull(response);
            Assert.True(response.Success);
        }

        #endregion GET

        #region POST

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
        public async Task GetApplicationAggregatedCves_Returns_ListOf_ApplicationAggregatedCve()
        {
            // Arrange
            var client = GetBasicAuthClient();

            // Act
            var response = await client.Application.GetApplicationAggregatedCvesAsync(Options.DomainId);

            // Assert
            Assert.NotNull(response);
            Assert.True(response.Success);
        }

        [Fact(Skip = "Can't be tested with demonstration account")]
        public async Task UpdateApplicationById_Returns_StatusResult()
        {
            // Arrange
            var client = GetBasicAuthClient();
            var command = new ApplicationUpdateCommand("Test");

            // Act
            var response = await client.Application.UpdateApplicationByIdAsync(Options.DomainId, DemoApplicationId, command);

            // Assert
            Assert.NotNull(response);
            Assert.True(response.Success);
        }

        #endregion POST

        #region DELETE

        [Fact(Skip = "Can't be tested with demonstration account")]
        public async Task DeleteApplicationById_Returns_StatusResult()
        {
            // Arrange
            var client = GetBasicAuthClient();

            // Act
            var response = await client.Application.DeleteApplicationByIdAsync(Options.DomainId, DemoApplicationId);

            // Assert
            Assert.NotNull(response);
            Assert.True(response.Success);
        }

        #endregion DELETE
    }
}