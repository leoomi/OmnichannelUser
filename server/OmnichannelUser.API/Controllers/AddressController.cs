using MediatR;
using Microsoft.AspNetCore.Mvc;
using OmnichannelUser.Application.Commands;
using OmnichannelUser.Application.Models;

namespace OmnichannelUser.API.Controllers;

[ApiController]
[Route("/api/addresses/")]
public class AddressController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<WeatherForecastController> _logger;

    public AddressController(IMediator mediator, ILogger<WeatherForecastController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet(Name = "GetAddressByZipCode")]
    [Route("zipCode/{zipCode}")]
    public async Task<ActionResult<AddressDTO?>> Get(string zipCode)
    {
        var query = new GetAddressByZipCodeQuery(zipCode);
        var result = await _mediator.Send(query);

        if (result == null)
        {
            return NotFound(null);
        }

        return Ok(result);
    }

}
