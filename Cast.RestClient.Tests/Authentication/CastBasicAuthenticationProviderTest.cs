using Cast.RestClient.Authentication;
using Xunit;

namespace Cast.RestClient.Tests.Authentication
{
    public class CastBasicAuthenticationProviderTest
    {
        [Fact]
        public void GetAuthorizationHeader_Returns_BasicAuthValue()
        {
            // Arrange
            var login = "Test";
            var password = "Test";

            // Act
            var authProvider = new CastBasicAuthenticationProvider(login, password);

            // Assert
            Assert.Equal(login, authProvider.Login);
            Assert.Equal(password, authProvider.Password);
            Assert.Equal("Basic VGVzdDpUZXN0", authProvider.GetAuthorizationHeader());
        }
    }
}