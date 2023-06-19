using OmnichannelUser.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;

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
        var user = _context.Users
            .Include(u => u.Address)
            .FirstOrDefault(u => u.Id == id);
        return user;
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

    public int GetUserCount()
    {
        return _context.Users.Count();
    }

    public User? Update(User user)
    {
        var entry = _context.Users
            .Include(u => u.Address)
            .SingleOrDefault(u => u.Id == user.Id);
        
        if (entry == null)
        {
            return null;
        }

        _context.Entry(entry).CurrentValues.SetValues(user);

        var addressEntry = _context.Addresses
            .SingleOrDefault(a => a.Id == user.Address!.Id);
        _context.Entry(addressEntry!).CurrentValues.SetValues(user.Address!);

        _context.SaveChanges();
        return entry;
    }
}