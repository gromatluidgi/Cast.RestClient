using Cast.RestClient.Options;
using System;
using Xunit;

namespace Cast.RestClient.Tests.Options
{
    public class CastRestClientOptionsTest
    {
        [Theory]
        [InlineData(null, typeof(ArgumentNullException))]
        [InlineData("htt://www.google.fr", typeof(ArgumentException))]
        [InlineData("http://www.google.fr", typeof(ArgumentException))]
        [InlineData("ftp://www.google.fr", typeof(ArgumentException))]
        public void Given_InvalidApiUrl_ThrowsException(string url, Type exceptionType)
        {
            // Act
            var action = new Action(() => new CastRestClientOptions(url));

            // Assert
            Assert.Throws(exceptionType, action);
        }

        [Theory]
        [InlineData("https://www.google.fr")]
        [InlineData("https://192.168.0.1:5400")]
        public void Given_ValidApiUrl_Returns(string url)
        {
            // Act
            var options = new CastRestClientOptions(url);

            // Assert
            Assert.NotNull(options);
            Assert.Equal(url, options.HighlightApiUrl);
        }
    }
}