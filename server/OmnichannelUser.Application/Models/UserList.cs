namespace OmnichannelUser.Application.Models;

public class UserList
{
    public int Length { get; set; }
    public IEnumerable<UserDTO> Users { get; set; } = new List<UserDTO>();
}