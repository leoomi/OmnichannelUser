using OmnichannelUser.Domain.UserAggregate;

namespace OmnichannelUser.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserContext _context;

    public UserRepository()
    {
        _context = new UserContext();
    }

    public User? Get(int id)
    {
        return _context.Users.FirstOrDefault(u => u.Id == id);
    }

    public User Create(User user)
    {
        _context.Add(user);
        _context.SaveChanges();
        return user;
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<User> GetUsers(int page)
    {
        return _context.Users
            .OrderBy(u => u.Id)
            .Skip(10*page)
            .Take(10)
            .ToArray();
    }

    public User? Update(User user)
    {
        var entry = _context.Users
            .SingleOrDefault(u => u.Id == user.Id);
        
        if (entry == null)
        {
            return null;
        }

        _context.Entry(entry).CurrentValues.SetValues(user);
        _context.SaveChanges();
        return entry;
    }
}