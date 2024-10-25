namespace Domain.Entities;

public class Weather
{    
    public List<DailyForecast>? DailyForecasts { get; set; }
    
    public DateTime? ApiCall { get; set; }

    public class DailyForecast
    {
        public DateTime Date { get; set; }
        public int EpochDate { get; set; }
        public Temperature? Temperature { get; set; }
        public Day? Day { get; set; }
        public Night? Night { get; set; }
    }

    public record Day
    {
        public int Icon { get; set; }
        public string? IconPhrase { get; set; }
        public bool HasPrecipitation { get; set; }
    }

    public record Maximum
    {
        public double Value { get; set; }
        public string? Unit { get; set; }
        public int UnitType { get; set; }
    }

    public record Minimum
    {
        public double Value { get; set; }
        public string? Unit { get; set; }
        public int UnitType { get; set; }
    }

    public record Night
    {
        public int Icon { get; set; }
        public string? IconPhrase { get; set; }
        public bool HasPrecipitation { get; set; }
    }

    public record Temperature
    {
        public Minimum? Minimum { get; set; }
        public Maximum? Maximum { get; set; }
    }   
}
