using TestTask.Middlewares;

namespace TestTask.Extensions;

public static class MiddlewareExtensions
{
    public static WebApplication AddCustomMiddlewares(this WebApplication app)
    {
        app.UseMiddleware<ErrorHandlingMiddleware>();

        return app;
    }
}