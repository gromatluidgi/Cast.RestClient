using Cast.RestClient.Helpers;
using System;
using System.Collections.Generic;
using Xunit;

namespace Cast.RestClient.Tests.Helpers
{
    public class EnsureTest
    {
        [Fact]
        public void ArgumentNotNull_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => Ensure.ArgumentNotNull(null!, string.Empty));
        }

        [Fact]
        public void ArgumentNotNullOrEmptyString_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => Ensure.ArgumentNotNullOrEmptyString(null!, string.Empty));
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

        [Fact]
        public void IsEnumerable_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => Ensure.IsEnumerable(null!, string.Empty));
            Assert.Throws<ArgumentException>(() => Ensure.IsEnumerable(string.Empty, string.Empty));
        }

        [Fact]
        public void IsEnumerable_Returns()
        {
            try
            {
                Ensure.IsEnumerable(new List<object>(), string.Empty);
                Assert.True(true);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void IsArray_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => Ensure.IsArray(null!, string.Empty));
            Assert.Throws<ArgumentException>(() => Ensure.IsArray(string.Empty, string.Empty));
        }

        [Fact]
        public void IsArray_Returns()
        {
            try
            {
                Ensure.IsArray(new object[] { }, string.Empty);
                Assert.True(true);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void IsConvertibleToString_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => Ensure.IsConvertibleToString(null!, string.Empty));
            Assert.Throws<ArgumentException>(() => Ensure.IsConvertibleToString(new object(), string.Empty));
        }

        [Fact]
        public void IsConvertibleToString_Returns()
        {
            try
            {
                Ensure.IsConvertibleToString(0, string.Empty);
                Assert.True(true);
            }
            catch (Exception)
            {
                Assert.True(false);
            }
        }
    }
}