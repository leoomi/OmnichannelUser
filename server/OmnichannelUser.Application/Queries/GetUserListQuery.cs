using MediatR;
using OmnichannelUser.Application.Models;

namespace OmnichannelUser.Application.Commands;

public class GetUserListQuery: IRequest<UserList>
{
    public int Page;

    public GetUserListQuery(int page)
    {
        Page = page;
    }
}

