namespace Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        IWeatherRepository Weather { get; }  
        IHolidayRepository Holiday { get; }
        ILyricRepository Lyric { get; }        
    }
}
