
using System.Text.RegularExpressions;
using FluentValidation;
using OmnichannelUser.Application.Commands;
using OmnichannelUser.Application.ZipCode;

public class EditUserCommandValidator : AbstractValidator<EditUserCommand>
{
    public EditUserCommandValidator(IZipCodeFinder zipCodeFinder)
    {
        RuleFor(c => c.Id)
            .NotNull().WithMessage("Este campo é obrigatório.");
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Este campo é obrigatório.");
        RuleFor(c => c.Email)
            .NotEmpty().WithMessage("Este campo é obrigatório.")
            .EmailAddress().WithMessage("O e-mail utilizado não é válido.");
        RuleFor(c => c.PhoneNumber)
            .NotEmpty().WithMessage("Este campo é obrigatório.")
            .Matches(new Regex(@"^\([1-9]{2}\) (?:[2-8]|9[1-9])[0-9]{3}\-[0-9]{4}$")).WithMessage("O número não é válido.");
        RuleFor(c => c.DateOfBirth)
            .NotEmpty().WithMessage("Este campo é obrigatório.")
            .Must(d => d <= DateTime.Now.AddYears(-18)).WithMessage("O usuário precisar ter pelo menos 18 anos.");
        RuleFor(c => c.Address)
            .NotNull()
            .SetValidator(new AddressValidator(zipCodeFinder));
    }
}