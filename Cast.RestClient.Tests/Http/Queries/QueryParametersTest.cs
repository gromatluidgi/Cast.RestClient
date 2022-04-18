using Cast.RestClient.Http.Queries;
using Moq;
using Xunit;

namespace Cast.RestClient.Tests.Http.Queries
{
    public class QueryParametersTest
    {
        [Fact]
        public void Mock_GetPropertyParametersForType_Returns_MockProperties()
        {
            // Arrange
            var queryParameters = new Mock<QueryParameters>();

            // Act
            var result = QueryParameters.GetPropertyParametersForType(queryParameters.Object.GetType());

            // Assert
            Assert.Equal(3, result.Count);
        }
    }
}
