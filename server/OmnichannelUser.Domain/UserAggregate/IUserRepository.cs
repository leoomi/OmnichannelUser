namespace OmnichannelUser.Domain.UserAggregate;

public interface IUserRepository
{
    User? Get(int id);
    User Create(User user);
    User? Update(User user);
    void Delete(int id);
    IEnumerable<User> GetUsers(int page);
    int GetUserCount();
}
