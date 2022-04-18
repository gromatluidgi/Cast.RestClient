using Cast.RestClient.Clients.Applications.Queries;
using Cast.RestClient.Extensions;
using System;
using Xunit;

namespace Cast.RestClient.Tests.Extensions
{
    public class EnumExtensionsTest
    {
        [Theory]
        [InlineData(ApplicationExpand.Survey, "survey")]
        public void GetStringValue(Enum enumValue, string expected)
        {
            // Act
            var result = enumValue.GetStringValue();

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
