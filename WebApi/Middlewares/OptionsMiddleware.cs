namespace AnytourApi.WebApi.Middlewares;

public class CorsMiddleware
{
    private readonly RequestDelegate _next;
    private const string AllowedOrigins = "*"; // Or specify allowed origins

    public CorsMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        await HandleCors(context);

        await _next(context);
    }

    private async Task HandleCors(HttpContext context)
    {
        var origin = context.Request.Headers["Origin"].FirstOrDefault();

        if (!string.IsNullOrEmpty(origin))
        {
            context.Response.Headers.Append("Access-Control-Allow-Origin", new[] { AllowedOrigins });
            context.Response.Headers.Append("Access-Control-Allow-Credentials", new[] { "true" });

            if (context.Request.Method == "OPTIONS")
            {
                context.Response.Headers.Append("Access-Control-Allow-Methods", new[] { "GET, POST, PUT, DELETE, PATCH, HEAD, OPTIONS" });
                context.Response.Headers.Append("Access-Control-Allow-Headers", new[] { "Origin, X-Requested-With, Content-Type, Accept, Authorization" });
                context.Response.StatusCode = 204; // No content
                return;
            }
        }
    }
}