using Cast.RestClient.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cast.RestClient.Tests.Extensions
{
    public class TypeExtensionsTest
    {
        [Theory]
        [InlineData(typeof(DateTimeOffset), true)]
        [InlineData(typeof(DateTimeOffset?), true)]
        [InlineData(typeof(ArgumentNullException), false)]
        public void IsDateTimeOffset(Type type, bool expected)
        {
            // Act
            var result = type.IsDateTimeOffset();

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(typeof(IEnumerable<object>), true)]
        [InlineData(typeof(IList<object>), true)]
        [InlineData(typeof(IList), false)]
        [InlineData(typeof(IEnumerable), false)]
        [InlineData(typeof(ICollection), false)]
        [InlineData(typeof(int[]), false)]
        public void IsGenericEnumerable(Type type, bool expected)
        {
            // Act
            var result = type.IsGenericEnumerable();

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(typeof(DateTimeOffset), true)]
        [InlineData(typeof(DateTimeOffset?), true)]
        [InlineData(typeof(ArgumentNullException), false)]
        public void IsStringConvertible(Type type, bool expected)
        {
            // Act
            var result = type.IsStringConvertible();

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
