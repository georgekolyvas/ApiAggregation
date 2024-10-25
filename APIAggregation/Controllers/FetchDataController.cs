using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace APIAggregation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FetchDataController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;    
    private readonly FetchData fetchData = new();

    public FetchDataController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;        
    }

    [HttpGet("FetchData")]    
    public async Task<IActionResult> GetFetchData([SwaggerParameter(description: "Please specify one category: holiday, weather, or lyrics to filter the data, " +
        "or leave the category blank to retrieve all data")][FromQuery] string? category,
        [SwaggerParameter("Do you want to sort data by date?")][FromQuery] bool sort 
        )
    {
        try
        {
            // fetch all data if no category is specified
            if (string.IsNullOrEmpty(category))
            {
                fetchData.Holiday = await _unitOfWork.Holiday.GetHoliday();               
                fetchData.Weather = await _unitOfWork.Weather.GetWeather();
                fetchData.Lyric = await _unitOfWork.Lyric.GetLyrics();              

                return Ok(fetchData);
            }
            else if (string.Equals(category, "holiday", StringComparison.OrdinalIgnoreCase))
            {
                var result = await _unitOfWork.Holiday.GetHoliday();

                if (sort)
                {
                    List<Holiday> holidayList = [result];
                    var sortedResult = holidayList.OrderBy(q => q.ApiCall).ToList();
                    return Ok(sortedResult);
                }

                return Ok(result);
            }
            else if (string.Equals(category, "weather", StringComparison.OrdinalIgnoreCase))
            {
                var result = await _unitOfWork.Weather.GetWeather();

                if (sort)
                {
                    List<Weather> holidayList = [result];
                    var sortedResult = holidayList.OrderBy(q => q.ApiCall).ToList();
                    return Ok(sortedResult);
                }

                return Ok(result);
            }
            else if (string.Equals(category, "lyrics", StringComparison.OrdinalIgnoreCase))
            {
                var result = await _unitOfWork.Lyric.GetLyrics();

                if (sort)
                {
                    List<Lyric> holidayList = [result];
                    var sortedResult = holidayList.OrderBy(q => q.ApiCall).ToList();
                    return Ok(sortedResult);
                }

                return Ok(result);                
            }
            else
                return BadRequest("There was a typing mistake");
        }
        catch (Exception ex)
        {
            return BadRequest("An error occured: " + ex.Message);
        }
    }
}
