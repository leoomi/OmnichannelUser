// using OmnichannelUser.Domain.UserAggregate;
// using OmnichannelUser.Infrastructure.ZipCode;

// namespace OmnichannelUser.Tests.Infrastructure.ZipCode;

// public class ZipCodeFinderTests
// {
//     [Fact]
//     public async Task GetAddress_ValidZipCode_ShouldReturnAddress()
//     {
//         var finder = new ZipCodeFinder();
//         var address = await finder.GetAddress("01001000");

//         Assert.NotNull(address);
//         Assert.Equivalent
//         (
//             new Address(
//                 "Praça da Sé",
//                 "lado ímpar",
//                 null,
//                 "01001-000",
//                 "São Paulo",
//                 "SP"),
//             address
//         );
//     }

//     [Theory]
//     [InlineData("010010000")]
//     [InlineData("01001-000")]
//     [InlineData("01001 000")]
//     [InlineData("01001A00")]
//     public async Task GetAddress_InvalidFormatZipCode_ShouldReturnNull(string zipCode)
//     {
//         var finder = new ZipCodeFinder();
//         var address = await finder.GetAddress(zipCode);

//         Assert.Null(address);
//     }

//     [Theory]
//     [InlineData("99999999")]
//     [InlineData("00000000")]
//     public async Task GetAddress_InexistentZipCode_ShouldReturnNull(string zipCode)
//     {
//         var finder = new ZipCodeFinder();
//         var address = await finder.GetAddress(zipCode);

//         Assert.Null(address);
//     }
// }

