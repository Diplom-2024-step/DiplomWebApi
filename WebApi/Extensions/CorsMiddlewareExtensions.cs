using AnytourApi.WebApi.Middlewares;

namespace AnytourApi.WebApi.Extensions;

public static class CorsMiddlewareExtensions
{
    public static IApplicationBuilder UseOptions(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CorsMiddleware>();
    }
}
