using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;

namespace UnitTests.RepositoryTests
{
    public class HolidayRepositoryTests
    {
        private readonly IConfiguration _configuration;

        public HolidayRepositoryTests()
        {
            var inMemorySettings = new Dictionary<string, string>
            {
                {"HolidayAPI:ApiKey", "cb5582cc1c8f49daaa016db88f964247"},
                {"HolidayAPI:BaseUrl", "https://holidays.abstractapi.com/v1/"},
                {"HolidayAPI:Month", "10"},
                {"HolidayAPI:Country", "GR"},
                {"HolidayAPI:Year", "2024"},
                {"HolidayAPI:Day", "28"}
            };

            _configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();
        }

        [Fact]
        public async Task GetHoliday_ReturnsHoliday_WhenApiCallSucceeds()
        {
            // Arrange
            var holidays = new Holiday
            {
                name = "The Ochi day",
                name_local = "",
                language = "",
                description = "",
                country = "GR",
                location = "Greece",
                type = "National",
                date = "10/28/2024",
                date_year = "2024",
                date_month = "10",
                date_day = "28",
                week_day = "Monday"
            };

            var holidayRepository = new HolidayRepository(_configuration);

            // Act
            var result = await holidayRepository.GetHoliday();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(holidays.name, result.name);
            Assert.Equal(holidays.date, result.date);
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