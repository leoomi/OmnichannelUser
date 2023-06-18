namespace OmnichannelUser.Application.Models;

public class AddressDTO
{
    public int? Id { get; set; }
    public string? Line1 { get; set; }
    public string? Line2 { get; set; }
    public string? District { get; set; }
    public int? Number { get; set; }
    public string? ZipCode { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
}