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
    public AddressController(IMediator mediator)
    {
        _mediator = mediator;
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
