using MediatR;
using OmnichannelUser.Application.Models;

namespace OmnichannelUser.Application.Commands;

public class GetAddressByZipCodeQuery: IRequest<AddressDTO?>
{
    public string ZipCode;

    public GetAddressByZipCodeQuery(string zipCode)
    {
        ZipCode = zipCode;
    }
}

