using Cast.RestClient.Clients.Applications.Queries;
using Cast.RestClient.Helpers;
using System;
using System.Collections.Generic;
using Xunit;

namespace Cast.RestClient.Tests.Helpers
{
    public class QueryHelperTest
    {
        [Fact]
        public void ParametersFromDynamicEnumerable_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => QueryHelper.ParametersFromDynamicEnumerable(null!, new List<object>()));
            Assert.Throws<ArgumentException>(() => QueryHelper.ParametersFromDynamicEnumerable(string.Empty, new List<object>()));
            Assert.Throws<ArgumentException>(() => QueryHelper.ParametersFromDynamicEnumerable("Param", 0));
        }

        [Fact]
        public void ParametersFromDynamicEnumerable_Returns_QueryString()
        {
            // Arrange
            var list = new HashSet<ApplicationExpand> { ApplicationExpand.Survey };

            // Act
            var result = QueryHelper.ParametersFromDynamicEnumerable("expand", list);

            // Assert
            Assert.Equal("survey", result);
        }

        [Theory]
        [InlineData("expand", new ApplicationExpand[] { ApplicationExpand.Survey }, "survey")]
        [InlineData("expand", new ApplicationExpand[] { ApplicationExpand.Survey, ApplicationExpand.Survey }, "survey&expand=survey")]
        [InlineData("expand", new ApplicationExpand[] { ApplicationExpand.Survey, ApplicationExpand.Survey, ApplicationExpand.Survey }, "survey&expand=survey&expand=survey")]
        public void ParametersFromDynamicArray_Returns_QueryString(string paramName, object value, string expected)
        {
            // Act
            var result = QueryHelper.ParametersFromDynamicArray(paramName, value);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, "1")]
        [InlineData("test", "test")]
        [InlineData(ApplicationExpand.Survey, "survey")]
        public void ParameterFromObject_Returns_QueryStringParam(object input, string expected)
        {
            // Act
            var result = QueryHelper.ParameterFromObject(input);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
