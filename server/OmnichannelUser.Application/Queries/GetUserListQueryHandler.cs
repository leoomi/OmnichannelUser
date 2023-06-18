using AutoMapper;
using MediatR;
using OmnichannelUser.Application.Models;
using OmnichannelUser.Domain.UserAggregate;

namespace OmnichannelUser.Application.Commands;

public class GetUserListQueryHandler: IRequestHandler<GetUserListQuery, List<UserDTO>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public GetUserListQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public Task<List<UserDTO>> Handle(GetUserListQuery query, CancellationToken cancellationToken)
    {
        var users = _userRepository.GetUsers(query.Page);
        var mappedUsers = _mapper.Map<List<UserDTO>>(users.ToList());

        return Task.FromResult(mappedUsers);
    }
}
