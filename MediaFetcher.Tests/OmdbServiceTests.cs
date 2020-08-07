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
    }
}