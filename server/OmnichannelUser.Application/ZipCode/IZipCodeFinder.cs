using OmnichannelUser.Application.Models;

namespace OmnichannelUser.Application.ZipCode;

public interface IZipCodeFinder
{
    Task<AddressDTO?> GetAddress(string zipCode);
}

