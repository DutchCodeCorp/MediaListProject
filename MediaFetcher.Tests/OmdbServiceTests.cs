using MediaFetcher.DataServices;
using MediaFetcher.Models;
using Xunit;

namespace MediaFetcher.Tests
{
    public class OmdbServiceTests
    {
        [Fact]
        public async void CanRetrieveMovieById()
        {
            // Arrange - Create an instance of the OmdbService
            OmdbService target = new OmdbService();

            // Act - Request movies
            Movie validMovie = await target.GetById("tt0107290");
            Movie invalidMovie = await target.GetById("NotAnId");

            // Assert - Valid Movie
            Assert.Equal("tt0107290", validMovie.imdbID);
            Assert.Equal("Jurassic Park", validMovie.Title);
            Assert.Equal("1993", validMovie.Year);
            Assert.Equal("Universal Pictures", validMovie.Production);

            // Assert - Invalid Movie
            Assert.Null(invalidMovie);
        }

        [Fact]
        public async void CanRetrieveMoviesByName()
        {
            // Arrange - Create an instance of the OmdbService
            OmdbService target = new OmdbService();

            // Act - Request different results
            var resultPage1 = await target.GetByName("Jurassic");
            var resultPage2 = await target.GetByName("Jurassic", 2);
            var resultEmpty = await target.GetByName("a1z0b2y9c3x8d4w7e5v6");

            // Assert - Pages
            Assert.NotEmpty(resultPage1.Search);
            Assert.Equal(1, resultPage1.CurrentPage);

            Assert.NotEmpty(resultPage2.Search);
            Assert.Equal(2, resultPage2.CurrentPage);

            Assert.InRange(int.Parse(resultPage1.totalResults), 1, int.MaxValue);
            Assert.NotEqual(resultPage1.Search[0], resultPage2.Search[0]);
            Assert.Equal(resultPage1.totalResults, resultPage2.totalResults);

            // Assert - Empty
            Assert.Null(resultEmpty);
        }
    }
}