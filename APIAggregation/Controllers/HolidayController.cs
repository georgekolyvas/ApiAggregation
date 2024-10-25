using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIAggregation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HolidayController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public HolidayController(IUnitOfWork unitOfWork)
    {
        // DI on Unit of Work
        _unitOfWork = unitOfWork;
    }

    [HttpGet("GetHoliday")]
    public async Task<IActionResult> GetHoliday()
    {
        try
        {
            var result = await _unitOfWork.Holiday.GetHoliday();            

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest("An error occured: " + ex.Message);
        }
    }
}
