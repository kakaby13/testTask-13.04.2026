namespace TestTask.Extensions;

public static class StartupConfigExtensions
{
    public static IServiceCollection AddCorsConfiguration(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

        return services;
    }
    
    public static WebApplication AddSwagger(this WebApplication app)
    {
        app
            .UseSwagger()
            .UseSwaggerUI();
        
        return app;
    }
}