using AutoMapper;
using MediatR;
using OmnichannelUser.Application.Models;
using OmnichannelUser.Application.ZipCode;

namespace OmnichannelUser.Application.Commands;

public class GetAddressByZipCodeQueryHandler: IRequestHandler<GetAddressByZipCodeQuery, AddressDTO?>
{
    private readonly IZipCodeFinder _zipCodeFinder;
    private readonly IMapper _mapper;
    public GetAddressByZipCodeQueryHandler(IZipCodeFinder zipCodeFinder, IMapper mapper)
    {
        _zipCodeFinder = zipCodeFinder;
        _mapper = mapper;
    }

    public async Task<AddressDTO?> Handle(GetAddressByZipCodeQuery query, CancellationToken cancellationToken)
    {
        var address = await _zipCodeFinder.GetAddress(query.ZipCode);
        var mappedAddress = _mapper.Map<AddressDTO>(address);

        return mappedAddress;
    }
}
