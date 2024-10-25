using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;

namespace UnitTests.RepositoryTests
{
    public class LyricRepositoryTests
    {
        private readonly IConfiguration _configuration;

        public LyricRepositoryTests()
        {
            var inMemorySettings = new Dictionary<string, string>
            {
                {"LyricsAPI:BaseUrl", "https://api.lyrics.ovh/v1/"},
                {"LyricsAPI:Artist", "Black Sabbath"},
                {"LyricsAPI:Title", "Iron Man"}
            };

            _configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();
        }

        [Fact]
        public async Task GetLyrics_ReturnsLyrics_WhenApiCallSucceeds()
        {
            // Arrange
            var lyrics = new Lyric
            {
                Lyrics = "I am Iron Man"
            };

            var lyricRepository = new LyricRepository(_configuration);

            // Act
            var result = await lyricRepository.GetLyrics();

            // Assert
            Assert.NotNull(result);
            Assert.Contains(lyrics.Lyrics, result.Lyrics);
        }

        [Fact]
        public void LyricRepository_ShouldThrowException_WhenConfigurationIsMissing()
        {
            // Arrange
            var badConfig = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string>())
                .Build();

            // Act and Assert
            Assert.Throws<Exception>(() => new WeatherRepository(badConfig));
        }
    }
}
