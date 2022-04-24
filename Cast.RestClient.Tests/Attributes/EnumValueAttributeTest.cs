using Cast.RestClient.Attributes;
using System;
using System.Collections.Generic;
using Xunit;

namespace Cast.RestClient.Tests.Attributes
{
    public class EnumValueAttributeTest
    {
        [Fact]
        public void Ctor()
        {
            // Arrange
            var attribute = new EnumValueAttribute("Test");

            // Act
            var result = attribute.Value;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test", result);
        }

        [Fact]
        public void Allow_Multiple_Is_False()
        {
            // Arrange
            var attributes = (IList<AttributeUsageAttribute>)typeof(EnumValueAttribute).GetCustomAttributes(typeof(AttributeUsageAttribute), false);

            // Act
            var attribute = attributes[0];

            // Assert
            Assert.False(attribute.AllowMultiple);
        }

        [Fact]
        public void Valid_On_Field()
        {
            // Arrange
            var attributes = (IList<AttributeUsageAttribute>)typeof(EnumValueAttribute).GetCustomAttributes(typeof(AttributeUsageAttribute), false);

            // Act
            var attribute = attributes[0];

            // Assert
            Assert.True(attribute.ValidOn.HasFlag(AttributeTargets.Field));
        }
    }
}
