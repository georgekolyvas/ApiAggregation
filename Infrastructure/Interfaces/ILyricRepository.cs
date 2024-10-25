using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface ILyricRepository : IGenericRepository<Lyric>
{    
    Task<Lyric?> GetLyrics();
}
