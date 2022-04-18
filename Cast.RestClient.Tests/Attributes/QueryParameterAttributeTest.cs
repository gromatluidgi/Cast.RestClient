using Cast.RestClient.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cast.RestClient.Tests.Attributes
{
    public class QueryParameterAttributeTest
    {
        [Fact]
        public void Ctor()
        {
            // Arrange
            var attribute = new QueryParameterAttribute("Test");

            // Act
            var result = attribute.Name;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test", result);
        }

        [Fact]
        public void Allow_Multiple_Is_False()
        {
            // Arrange
            var attributes = (IList<AttributeUsageAttribute>)typeof(QueryParameterAttribute).GetCustomAttributes(typeof(AttributeUsageAttribute), false);

            // Act
            var attribute = attributes[0];

            // Assert
            Assert.False(attribute.AllowMultiple);
        }

        [Fact]
        public void Valid_On_Property()
        {
            // Arrange
            var attributes = (IList<AttributeUsageAttribute>)typeof(QueryParameterAttribute).GetCustomAttributes(typeof(AttributeUsageAttribute), false);

            // Act
            var attribute = attributes[0];

            // Assert
            Assert.True(attribute.ValidOn.HasFlag(AttributeTargets.Property));
        }
    }
}
