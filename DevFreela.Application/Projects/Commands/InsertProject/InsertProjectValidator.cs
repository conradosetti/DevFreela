using FluentValidation;

namespace DevFreela.Application.Projects.Commands.InsertProject;

public class InsertProjectValidator : AbstractValidator<InsertProjectCommand>
{
    public InsertProjectValidator()
    {
        RuleFor(p => p.Title)
            .NotEmpty()
            .WithMessage("Não pode ser vazio")
            .MaximumLength(50)
            .WithMessage("Tamanho máximo de 50 caracteres");
        
        RuleFor(p => p.Cost)
            .GreaterThan(0)
            .WithMessage("O valor deve ser maior que zero");
    }
}