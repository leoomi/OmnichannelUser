namespace OmnichannelUser.Domain.UserAggregate;

public class User
{
    public int? Id { get; private set; }
    public string? Name { get; private set; }
    public string? Email { get; private set; }
    public string? PhoneNumber { get; private set; }
    public Address? Address { get; set; }
    public DateTime? DateOfBirth { get; private set; }

    public User() {}

    public User(
        int? id,
        string? name,
        string? email,
        string? phoneNumber,
        Address? address,
        DateTime? dateOfBirth
    )
    {
        Id = id;
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
        Address = address;
        DateOfBirth = dateOfBirth;
    }
}
