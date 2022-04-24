using Cast.RestClient.Clients.Applications.Queries;
using System;
using System.Collections.Generic;
using Xunit;

namespace Cast.RestClient.Tests.Clients.Applications.Queries
{
    public class ApplicationQueryTest
    {
        /// <summary>
        /// Test the instantiation of query and ensure expand values are unique.
        /// </summary>
        /// <param name="maxEntryPerPage">Max entry per page.</param>
        /// <param name="pageOffset">Page offset.</param>
        /// <param name="expands">Expanded values.</param>
        [Theory]
        [InlineData(0, 0, new ApplicationExpand[] { ApplicationExpand.Survey })]
        [InlineData(10, 50, new ApplicationExpand[] { ApplicationExpand.Survey, ApplicationExpand.Survey })]
        public void Ctor(int maxEntryPerPage, int pageOffset, ApplicationExpand[] expands)
        {
            // Act
            var queryParameters = new ApplicationQuery(maxEntryPerPage, pageOffset, expands);

            // Assert
            Assert.Equal(maxEntryPerPage, queryParameters.MaxEntryPerPage);
            Assert.Equal(pageOffset, queryParameters.PageOffset);
            Assert.NotNull(queryParameters.Expands);
            Assert.Single(queryParameters.Expands!);
        }

        [Fact]
        public void Given_EmptyEnumerable_LoadExpands_DoNothing()
        {
            // Arrange
            var queryParameters = new ApplicationQuery();

            // Act
            queryParameters.LoadExpands(new HashSet<ApplicationExpand>());

            // Asert
            Assert.Null(queryParameters.Expands);
        }

        [Fact]
        public void Given_Enumerable_LoadExpands_Initiliaze()
        {
            // Arrange
            var queryParameters = new ApplicationQuery();

            // Act
            queryParameters.LoadExpands(new HashSet<ApplicationExpand> { ApplicationExpand.Survey });

            // Asert
            Assert.NotNull(queryParameters.Expands);
            Assert.Single(queryParameters.Expands);
        }

        [Fact]
        public void GetPropertyParametersForType_Returns_QueryDictionary()
        {
            // Arrange
            var queryParameters = new ApplicationQuery();
            queryParameters.LoadExpands(new HashSet<ApplicationExpand> { ApplicationExpand.Survey });

            // Act
            var result = queryParameters.ToParametersDictionary();

            // Assert
            Assert.Equal(3, result.Count);
            Assert.Equal(0, Convert.ToInt32(result["maxEntryPerPage"]));
            Assert.Equal(0, Convert.ToInt32(result["pageOffset"]));
            Assert.Equal("survey", result["expand"]);
        }
    }
}
