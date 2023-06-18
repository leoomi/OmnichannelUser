namespace OmnichannelUser.Infrastructure.ZipCode;

public class ViacepAddress
{
    public bool Erro { get; set; } = false;
    public string Cep { get; set; } = "";
    public string Logradouro { get; set; } = "";
    public string Complemento { get; set; } = "";
    public string Bairro { get; set; } = "";
    public string Localidade { get; set; } = "";
    public string Uf { get; set; } = "";
}
