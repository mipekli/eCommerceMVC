namespace eCommerceMVC.Middleware;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;
    
    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Beklenmeyen bir hata oluştu");
    
            context.Response.ContentType = "application/json";
    
            var statusCode = ex switch
            {
                ArgumentException => 400,
                KeyNotFoundException => 404,
                _ => 500
            };
    
            context.Response.StatusCode = statusCode;
    
            await context.Response.WriteAsync($"{{\"message\": \"{ex.Message}\"}}");
        }
    }
    
}