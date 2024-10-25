using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IWeatherRepository, WeatherRepository>();
        services.AddTransient<IHolidayRepository, HolidayRepository>();
        services.AddTransient<ILyricRepository, LyricRepository>();        
    }
}
