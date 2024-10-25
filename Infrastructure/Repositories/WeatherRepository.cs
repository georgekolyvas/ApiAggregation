using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace Infrastructure.Repositories;

public class WeatherRepository : IWeatherRepository
{
    private readonly string? weatherUrl;
    private readonly string? apiKey;    
    private readonly string? fullUrl;   

    public WeatherRepository(IConfiguration configuration)
    {
        apiKey = configuration["WeatherAPI:ApiKey"];
        weatherUrl = configuration["WeatherAPI:BaseUrl"];

        if (string.IsNullOrEmpty(weatherUrl) || string.IsNullOrEmpty(apiKey))        
            throw new Exception("Empty Query Params");        

        fullUrl = $"{weatherUrl}?apikey={apiKey}";
    }
    
    public async Task<Weather?> GetWeather()
    {
        using (HttpClient client = new HttpClient())
        {        
            HttpResponseMessage response = await client.GetAsync(fullUrl);
           
            response.EnsureSuccessStatusCode();           

            var jsonString = await response.Content.ReadAsStringAsync();
            var weather = JsonSerializer.Deserialize<Weather>(jsonString);

            if (weather == null)
                return null;
            else
            {
                weather.ApiCall = DateTime.Now;                
                return weather;
            }
        };
    }
}
