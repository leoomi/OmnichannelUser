using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OmnichannelUser.Application.Commands;
using OmnichannelUser.Application.Models;

namespace OmnichannelUser.API.Controllers;

[ApiController]
[Route("/api/users/")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IValidator<CreateUserCommand> _createUserValidator;

    public UsersController(IMediator mediator, ILogger<WeatherForecastController> logger, IValidator<CreateUserCommand> createUserValidator)
    {
        _mediator = mediator;
        _logger = logger;
        _createUserValidator = createUserValidator;
    }

    [HttpGet("{id}", Name="GetUser")]
    public async Task<ActionResult<UserDTO>> Get(int id)
    {
        var query = new GetUserQuery(id);
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpGet()]
    public async Task<ActionResult<UserDTO[]>> GetList([FromQuery(Name = "page")] int page)
    {
        var query = new GetUserListQuery(page);
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IResult> CreateUser(CreateUserCommand command)
    {
        var validation = await _createUserValidator.ValidateAsync(command);
        if (!validation.IsValid)
        {
            return Results.ValidationProblem(validation.ToDictionary());
        }
        var result = await _mediator.Send(command);

        return Results.CreatedAtRoute("GetUser", new {id = result.Id} ,result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserDTO?>> UpdateUser([FromBody] EditUserCommand command)
    {
        var result = await _mediator.Send(command);

        if (result == null)
        {
            return NotFound(null);
        }

        return Ok(result);
    }
}
