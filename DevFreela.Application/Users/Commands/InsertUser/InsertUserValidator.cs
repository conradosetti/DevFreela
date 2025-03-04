using FluentValidation;

namespace DevFreela.Application.Users.Commands.InsertUser;

public class InsertUserValidator : AbstractValidator<InsertUserCommand>
{
    public InsertUserValidator()
    {
        RuleFor(u=> u.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("Formato de email inválido ");
        RuleFor(u => u.BirthDate)
            .Must(b => b <= DateTime.Now.AddYears(-18))
            .WithMessage("Deve ter mais de 18 anos");
    }
}