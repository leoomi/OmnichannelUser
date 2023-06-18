using Microsoft.EntityFrameworkCore;
using OmnichannelUser.Domain.UserAggregate;

public class UserContext : DbContext
{
    public DbSet<User> Users { get ;set; }
    // public DbSet<Address> Addresses;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Database=omnichannel;Username=root;Password=password");
}