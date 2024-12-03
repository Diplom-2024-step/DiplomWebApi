using AnytourApi.Infrastructure.EmailServer;

namespace AnytourApi.WebApi.Extensions;

public static class EmailServerDependency
{
    public static IServiceCollection AddEmailService(
        this IServiceCollection services,
        IConfiguration configuration)
    {

        var emailSettings = configuration.GetSection("EmailSettings").Get<EmailSettings>();

        if (emailSettings == null)
        {
            throw new InvalidOperationException("EmailSettings section is missing in configuration");
        }

        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
        services.AddScoped<IEmailService, GmailService>();

        return services;
    }
}
