using Cast.RestClient.Authentication;
using System;
using Xunit;

namespace Cast.RestClient.Tests.Authentication
{
    public class CastBasicAuthenticationProviderTest
    {
        [Fact]
        public void GetAuthorizationHeader_Returns_BasicAuthValue()
        {
            // Arrange
            string login = "Test";
            string password = "Test";

            // Act
            var authProvider = new CastBasicAuthenticationProvider(login, password);

            // Assert
            Assert.Equal(login, authProvider.Login);
            Assert.Equal(password, authProvider.Password);
            Assert.Equal("Basic VGVzdDpUZXN0", authProvider.GetAuthorizationHeader());
        }
    }
}