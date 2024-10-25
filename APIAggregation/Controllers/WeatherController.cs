using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIAggregation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WeatherController : ControllerBase
{    
    private readonly IUnitOfWork _unitOfWork;

    public WeatherController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet("GetWeather")]
    public async Task<IActionResult> GetWeather() 
    {
        try
        {
            var result = await _unitOfWork.Weather.GetWeather();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest("An error occured: " + ex.Message);   
        }       
    }
}
