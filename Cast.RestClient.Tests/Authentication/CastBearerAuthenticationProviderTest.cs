using Cast.RestClient.Authentication;
using System;
using Xunit;

namespace Cast.RestClient.Tests.Authentication
{
    public class CastBearerAuthenticationProviderTest
    {
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void Given_Invalid_Token_ThrowsException(string value)
        {
            Assert.Throws<ArgumentException>(() => new CastBearerAuthenticationProvider(value));
        }

        [Fact]
        public void GetAuthorizationHeader_Returns_BearerAuthValue()
        {
            // Arrange
            string token = "test";

            // Act
            var authProvider = new CastBearerAuthenticationProvider(token);

            // Assert
            Assert.Equal(token, authProvider.Token);
            Assert.Equal("Bearer " + token, authProvider.GetAuthorizationHeader());
        }
    }
}