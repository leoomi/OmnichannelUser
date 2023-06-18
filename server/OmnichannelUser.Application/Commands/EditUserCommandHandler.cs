using AutoMapper;
using MediatR;
using OmnichannelUser.Domain.UserAggregate;

namespace OmnichannelUser.Application.Commands;

public class EditUserCommandHandler: IRequestHandler<EditUserCommand, User?>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public EditUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public Task<User?> Handle(EditUserCommand command, CancellationToken cancellationToken)
    {
        var address = _mapper.Map<Address>(command.Address);
        var user = new User(
            command.Id,
            command.Name,
            command.Email,
            command.PhoneNumber,
            address,
            command.DateOfBirth
        );
        var updateUser = _userRepository.Update(user);

        return Task.FromResult(updateUser);
    }
}
