using Cast.RestClient.Authentication;
using Cast.RestClient.Options;
using System;
using Xunit;

namespace Cast.RestClient.Tests
{
    public class CastRestClientTest
    {
        private const string BaseUrl = "https://demo.casthighlight.com/WS2/";

        [Fact]
        public void Given_Valid_BasicAuthenticationProvider_And_Options_ReturnsClient()
        {
            // Arrange
            var authenticationProvider = new CastBasicAuthenticationProvider("Test", "Test");
            var options = new CastRestClientOptions(BaseUrl);

            // Act
            var client = new CastRestClient(authenticationProvider, options);

            // Assert
            Assert.NotNull(client);
        }

        [Fact]
        public void Given_Valid_BearerAuthenticationProvider_And_Options_ReturnsClient()
        {
            // Arrange
            var authenticationProvider = new CastBearerAuthenticationProvider("Test");
            var options = new CastRestClientOptions(BaseUrl);

            // Act
            var client = new CastRestClient(authenticationProvider, options);

            // Assert
            Assert.NotNull(client);
        }

        [Fact]
        public void Given_Null_AuthenticationProvider_ThrowsException()
        {
            var options = new CastRestClientOptions(BaseUrl);

            Assert.ThrowsAny<Exception>(() => new CastRestClient(null!, options));
        }

        [Fact]
        public void Shoud_Add_AuthorizationHeader_From_Credentials()
        {
            // Arrange
            var authenticationProvider = new CastBasicAuthenticationProvider("Test", "Test");
            var options = new CastRestClientOptions(BaseUrl);

            // Act
            var client = new CastRestClient(authenticationProvider, options);

            // Assert
            Assert.NotNull(client.CastApiClient.HttpClient.DefaultRequestHeaders.Authorization);

            var authorizationHeader = client.CastApiClient.HttpClient.DefaultRequestHeaders.Authorization;
            var header = string.Format("{0} {1}", authorizationHeader!.Scheme, authorizationHeader.Parameter);

            Assert.Equal("Basic VGVzdDpUZXN0", header);
        }
    }
}