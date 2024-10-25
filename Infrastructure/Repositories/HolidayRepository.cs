using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace Infrastructure.Repositories;

public class HolidayRepository : IHolidayRepository
{
    private readonly string? holidayUrl;
    private readonly string? apiKey;
    private readonly string? fullUrl;
    public readonly string? month;
    public readonly string? country;
    public readonly string? year;
    public readonly string? day;

    public HolidayRepository(IConfiguration configuration)
    {
        // get the values from user's secret
        apiKey = configuration["HolidayAPI:ApiKey"];
        holidayUrl = configuration["HolidayAPI:BaseUrl"];
        month = configuration["HolidayAPI:Month"];
        country = configuration["HolidayAPI:Country"];
        year = configuration["HolidayAPI:Year"];
        day = configuration["HolidayAPI:Day"];

        // check for null or empty
        if (string.IsNullOrEmpty(holidayUrl) || string.IsNullOrEmpty(apiKey) ||
            string.IsNullOrEmpty(month) || string.IsNullOrEmpty(country) ||
            string.IsNullOrEmpty(year) || string.IsNullOrEmpty(day))
            throw new Exception("Empty Query Params");

        fullUrl = $"{holidayUrl}?api_key={apiKey}&country={country}&year={year}&month={month}&day={day}";
    }

    public async Task<Holiday?> GetHoliday()
    {
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(fullUrl);

            response.EnsureSuccessStatusCode();

            // response as a string
            var jsonString = await response.Content.ReadAsStringAsync();

            // parse json string to an object
            var holiday = JsonSerializer.Deserialize<List<Holiday>>(jsonString);

            if (holiday == null)
                return null;
            else
            {
                holiday.ForEach(q => q.ApiCall = DateTime.Now);
                return holiday.First();                
            }
        };
    }
}
