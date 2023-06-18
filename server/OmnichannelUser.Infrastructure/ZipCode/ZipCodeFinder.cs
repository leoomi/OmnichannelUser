using System.Text.Json;
using System.Net;
using System.Text.Json.Serialization;
using OmnichannelUser.Application.ZipCode;
using OmnichannelUser.Application.Models;

namespace OmnichannelUser.Infrastructure.ZipCode;

public class ZipCodeFinder : IZipCodeFinder
{
    private const string Url = "https://viacep.com.br/ws/{0}/json/";
    private readonly HttpClient _http;
    private readonly JsonSerializerOptions _jsonOptions;

    public ZipCodeFinder()
    {
        _http = new HttpClient();
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        };
    }

    public async Task<AddressDTO?> GetAddress(string zipCode)
    {
        zipCode = zipCode.Replace("-", "");
        var filledUrl = String.Format(Url, zipCode);
        var response = await _http.GetAsync(filledUrl);
        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            return null;
        }

        var body = await response.Content.ReadAsStringAsync();
        var viacepAddress = JsonSerializer.Deserialize<ViacepAddress>(body, _jsonOptions);

        if (viacepAddress is null || viacepAddress.Erro)
        {
            return null;
        }
        return new AddressDTO
        {
            Line1 = viacepAddress.Logradouro,
            Line2 = viacepAddress.Complemento,
            District = viacepAddress.Bairro,
            ZipCode = viacepAddress.Cep,
            City = viacepAddress.Localidade,
            State = viacepAddress.Uf
        };
    }
}
