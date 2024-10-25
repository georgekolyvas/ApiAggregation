using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIAggregation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LyricController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public LyricController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet("GetLyrics")]
    public async Task<IActionResult> GetLyrics()
    {
        try
        {
            var result = await _unitOfWork.Lyric.GetLyrics();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest("An error occured: " + ex.Message);
        }
    }
}
