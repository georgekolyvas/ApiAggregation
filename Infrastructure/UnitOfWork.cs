using Infrastructure.Interfaces;

namespace Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    public IWeatherRepository Weather { get; }

    public IHolidayRepository Holiday { get; }

    public ILyricRepository Lyric { get; }       

    public UnitOfWork(
        IWeatherRepository weather, 
        IHolidayRepository holiday,
        ILyricRepository lyric)
    {
        Weather = weather;
        Holiday = holiday;
        Lyric = lyric;        
    }
}
