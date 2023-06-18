using System.Text.RegularExpressions;
using FluentValidation;
using OmnichannelUser.Application.Models;
using OmnichannelUser.Application.ZipCode;

public class AddressValidator : AbstractValidator<AddressDTO>
{
    public AddressValidator(IZipCodeFinder zipCodeFinder)
    {
        RuleFor(a => a.Line1)
            .NotEmpty().WithMessage("Este campo é obrigatório.");
        RuleFor(a => a.Number)
            .NotNull().WithMessage("Este campo é obrigatório.");
        RuleFor(a => a.District)
            .NotEmpty().WithMessage("Este campo é obrigatório.");
        RuleFor(a => a.ZipCode)
            .NotEmpty().WithMessage("Este campo é obrigatório.")
            .Matches(new Regex(@"[0-9]{5}-[\d]{3}")).WithMessage("O CEP não é valido.");
        RuleFor(a => a.City)
            .NotEmpty().WithMessage("Este campo é obrigatório.");
        RuleFor(a => a.State)
            .NotEmpty().WithMessage("Este campo é obrigatório.");
        RuleFor(a => a)
            .MustAsync(async (a, cancellation) =>
            {
                if (a?.ZipCode == null)
                {
                    return false;
                }
                var validAddress = await zipCodeFinder.GetAddress(a.ZipCode!);
                return validAddress != null &&
                    validAddress.Line1 == a.Line1 &&
                    validAddress.District == a.District &&
                    validAddress.City == a.City &&
                    validAddress.State == a.State;
            }).WithMessage("Endereço é inválido. Reinsira o CEP e cheque as informações.");
    }
}
