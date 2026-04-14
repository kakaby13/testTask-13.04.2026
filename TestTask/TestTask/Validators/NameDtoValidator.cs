using FluentValidation;
using TestTask.BusinessLayer.Dtos;

namespace TestTask.Validators;

public class NameDtoValidator : AbstractValidator<NameDto>
{
    public NameDtoValidator()
    {
        RuleFor(x => x.Family)
            .NotEmpty()
            .WithMessage("Family is required");

        RuleFor(x => x.Given)
            .NotNull()
            .WithMessage("Given must be provided")
            .Must(g => g.Length == 0)
            .WithMessage("Given must contain at least one element")
            .Must(g => g.Length <= 3)
            .WithMessage("Given must contain no more than 3 elements")
            .Must((dto, g) => g.Length == 0 || g[0] == dto.Family)
            .WithMessage("The first element of Given must match Family");
    }
}