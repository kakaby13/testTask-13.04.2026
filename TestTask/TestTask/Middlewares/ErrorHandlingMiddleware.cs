using TestTask.BusinessLayer.Exceptions;

namespace TestTask.Middlewares;

public class ErrorHandlingMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        context.Response.StatusCode = exception is UserFriendlyException
            ? StatusCodes.Status400BadRequest
            : StatusCodes.Status500InternalServerError;
        
        await context.Response.WriteAsJsonAsync(new
        {
            message = exception.Message,
        });
    }
}
