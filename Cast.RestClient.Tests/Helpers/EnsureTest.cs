using Cast.RestClient.Helpers;
using System;
using Xunit;

namespace Cast.RestClient.Tests.Helpers
{
    public class EnsureTest
    {
        [Fact]
        public void ArgumentNotNull()
        {
            var action = new Action(() => Ensure.ArgumentNotNull(null!, string.Empty));

            Assert.Throws<ArgumentNullException>(action);
        }

        [Theory]
        [InlineData(null, false, typeof(ArgumentNullException))]
        [InlineData("htt://www.google.fr", true, typeof(ArgumentException))]
        [InlineData("http://www.google.fr", true, typeof(ArgumentException))]
        [InlineData("ftp://www.google.fr", true, typeof(ArgumentException))]
        public void ValidateApiUrl(string apiUrl, bool secureOnly, Type exceptionType)
        {
            var action = new Action(() => Ensure.ValidApiUrl(apiUrl, secureOnly));

            Assert.Throws(exceptionType, action);
        }
    }
}
