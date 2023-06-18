using MediatR;
using OmnichannelUser.Application.Models;

namespace OmnichannelUser.Application.Commands;

public class CreateUserCommand: IRequest<UserDTO>
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public AddressDTO Address { get; set; } = new();
    public DateTime? DateOfBirth { get; set; }
}
