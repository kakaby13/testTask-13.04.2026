using FluentValidation;
using FluentValidation.AspNetCore;
using TestTask.Validators;

namespace TestTask.Extensions;

public static class ConfigureFluentValidationExtensions
{
    public static IServiceCollection ConfigureFluentValidation(this IServiceCollection services)
    {
        services
            .AddFluentValidationAutoValidation()
            .AddValidatorsFromAssemblyContaining<PatientDtoValidator>()
            .AddValidatorsFromAssemblyContaining<NameDtoValidator >();
        
        return services;
    }
}