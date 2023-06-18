namespace OmnichannelUser.Domain.UserAggregate;

public class Address
{
    public int? Id { get; private set; }
    public string? Line1 { get; private set; }
    public string? Line2 { get; private set; }
    public string? District { get; private set; }
    public int? Number { get; private set; }
    public string? ZipCode { get; private set; }
    public string? City { get; private set; }
    public string? State { get; private set; }

    public Address() {}

    public Address(
        string? line1,
        string? line2,
        string? district,
        int? number,
        string? zipCode,
        string? city,
        string? state
    )
    {
        Line1 = line1;
        Line2 = line2;
        District = district;
        Number = number;
        ZipCode = zipCode;
        City = city;
        State = state;
    }
}

