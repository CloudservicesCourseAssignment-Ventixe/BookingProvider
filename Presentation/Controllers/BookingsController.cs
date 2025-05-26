using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingsController(IBookingService bookingService) : ControllerBase
{
    private readonly IBookingService _bookingService = bookingService;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBookingRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }


        var response = await _bookingService.CreateBookingAsync(request);
        if (response.Succeeded)
        {
            return Ok(response);
        }
        return StatusCode(StatusCodes.Status500InternalServerError, "Unable to create booking");
    }
}
