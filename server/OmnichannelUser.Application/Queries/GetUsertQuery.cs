using MediatR;
using OmnichannelUser.Application.Models;

namespace OmnichannelUser.Application.Commands;

public class GetUserQuery: IRequest<UserDTO>
{
    public int Id;

    public GetUserQuery(int id)
    {
        Id = id;
    }
}

