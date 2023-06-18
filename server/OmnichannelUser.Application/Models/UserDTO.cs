namespace OmnichannelUser.Application.Models;

public class UserDTO
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public AddressDTO? Address { get; set; }
    public DateTime? DateOfBirth { get; set; }
}