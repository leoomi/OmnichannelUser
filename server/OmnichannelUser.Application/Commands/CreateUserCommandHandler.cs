using AutoMapper;
using MediatR;
using OmnichannelUser.Application.Models;
using OmnichannelUser.Domain.UserAggregate;

namespace OmnichannelUser.Application.Commands;

public class CreateUserCommandHandler: IRequestHandler<CreateUserCommand, UserDTO>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public Task<UserDTO> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var address = _mapper.Map<Address>(command.Address);
        var user = new User(
            null,
            command.Name,
            command.Email,
            command.PhoneNumber,
            address,
            command.DateOfBirth
        );
        var createdUser = _userRepository.Create(user);
        var mappedUser = _mapper.Map<UserDTO>(createdUser);

        return Task.FromResult(mappedUser);
    }
}
