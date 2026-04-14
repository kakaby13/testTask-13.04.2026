using FluentValidation;
using TestTask.BusinessLayer.Dtos;
using TestTask.DataLayer.Enums;

namespace TestTask.Validators;

public class PatientDtoValidator : AbstractValidator<PatientDto>
{
    public PatientDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .SetValidator(new NameDtoValidator());

        RuleFor(x => x.Active)
            .Must(g => string.IsNullOrEmpty(g) || Enum.TryParse<Active>(g, out _))
            .WithMessage("Active must be one of: True, False");
        
        RuleFor(x => x.Gender)
            .Must(g => string.IsNullOrEmpty(g) || Enum.TryParse<Gender>(g, out _))
            .WithMessage("Gender must be one of: Male, Female, Other, Unknown");
        
        RuleFor(x => x.BirthDate)
            .NotEmpty().WithMessage("BirthDate is required")
            .LessThan(DateTime.Now).WithMessage("BirthDate must be in the past");

    }
}