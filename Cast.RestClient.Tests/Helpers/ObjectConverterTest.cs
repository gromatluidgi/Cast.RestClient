using Cast.RestClient.Helpers;
using Xunit;

namespace Cast.RestClient.Tests.Helpers
{
    public class ObjectConverterTest
    {
        [Fact]
        public void ArrayObjectToGenericList()
        {
            // Arrange
            var data = new[] { 1, 2, 3 };

            // Act
            var result = ObjectConverter.ArrayObjectToGenericList(data);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(data.Length, result.Count);
            Assert.NotNull(result.GetType().GenericTypeArguments);
            Assert.Single(result.GetType().GenericTypeArguments);
        }
    }
}
