using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;

namespace UnitTests.RepositoryTests
{
    public class WeatherRepositoryTests
    {
        private readonly IConfiguration _configuration;

        public WeatherRepositoryTests()
        {
            var inMemorySettings = new Dictionary<string, string>
            {
                {"WeatherAPI:ApiKey", "pIGFqJYetR8rRAGLATc3KuDw8D3zN7Pd"},
                {"WeatherAPI:BaseUrl", "http://dataservice.accuweather.com/forecasts/v1/daily/1day/182536"}
            };

            _configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();
        }

        [Fact]
        public async Task GetWeather_ReturnsWeather_WhenApiCallSucceeds()
        {
            // Arrange
            var weathers = new Weather
            {
                DailyForecasts = new List<Weather.DailyForecast>
                {
                    new Weather.DailyForecast { EpochDate = 1729828800 }
                }
            };

            var weatherRepository = new WeatherRepository(_configuration);

            // Act
            var result = await weatherRepository.GetWeather();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(weathers.DailyForecasts.Count, result?.DailyForecasts?.Count);

        }

        [Fact]
        public void WeatherRepository_ShouldThrowException_WhenConfigurationIsMissing()
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