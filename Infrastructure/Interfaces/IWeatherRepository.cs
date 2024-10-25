using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IWeatherRepository : IGenericRepository<Weather>
{    
    Task<Weather?> GetWeather();
}
