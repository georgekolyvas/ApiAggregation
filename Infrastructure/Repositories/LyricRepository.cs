using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repositories;

public class LyricRepository : ILyricRepository
{
    private readonly string? lyricsUrl;
    private readonly string? artist;
    private readonly string? title;
    private readonly string? fullUrl;

    public LyricRepository(IConfiguration configuration)
    {
        lyricsUrl = configuration["LyricsAPI:BaseUrl"];
        artist = configuration["LyricsAPI:Artist"];
        title = configuration["LyricsAPI:Title"];

        if (string.IsNullOrWhiteSpace(lyricsUrl) || string.IsNullOrWhiteSpace(artist) 
            || (string.IsNullOrEmpty(title)))
            throw new Exception("Empty Query Params");

        fullUrl = $"{lyricsUrl}{artist}/{title}";
    }
    public async Task<Lyric?> GetLyrics()
    {
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(fullUrl);

            response.EnsureSuccessStatusCode();

            Lyric lyric = new()
            {                            
                Lyrics = await response.Content.ReadAsStringAsync()
            };                       

            if (lyric == null)
                return null;
            else
            { 
                lyric.ApiCall = DateTime.Now;                        
                return lyric;
            }
        };
    }
}
