using AutoMapper;
using OmnichannelUser.Application.Models;
using OmnichannelUser.Domain.UserAggregate;

namespace OmnichannelUser.Application.AutoMapper;

public class ConfigurationMapping : Profile
{
    public ConfigurationMapping()
    {
        CreateMap<Address, AddressDTO>().ReverseMap();
        CreateMap<User, UserDTO>().ReverseMap();
    }
}