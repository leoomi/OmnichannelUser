using AutoMapper;
using MediatR;
using OmnichannelUser.Application.Models;
using OmnichannelUser.Domain.UserAggregate;

namespace OmnichannelUser.Application.Commands;

public class GetUserQueryHandler: IRequestHandler<GetUserQuery, UserDTO>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public GetUserQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public Task<UserDTO> Handle(GetUserQuery query, CancellationToken cancellationToken)
    {
        var user = _userRepository.Get(query.Id);
        var mappedUser = _mapper.Map<UserDTO>(user);

        return Task.FromResult(mappedUser);
    }
}
