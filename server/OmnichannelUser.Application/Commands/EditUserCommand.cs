using MediatR;
using OmnichannelUser.Application.Models;
using OmnichannelUser.Domain.UserAggregate;

namespace OmnichannelUser.Application.Commands;

public class EditUserCommand: IRequest<User?>
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public AddressDTO Address { get; set; } = new();
    public DateTime DateOfBirth { get; set; }
}

