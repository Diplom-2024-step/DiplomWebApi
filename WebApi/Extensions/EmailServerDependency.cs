using AnytourApi.Infrastructure.EmailServer;
using AnytourApi.Infrastructure.EmailServer.Settings;

namespace AnytourApi.WebApi.Extensions;

public static class EmailServerDependency
{
    public static IServiceCollection AddEmailService(
        this IServiceCollection services,
        IConfiguration configuration)
    {

        var emailSettings = configuration.GetSection("EmailSettings").Get<MailSettings>();

        if (emailSettings == null)
        {
            throw new InvalidOperationException("EmailSettings section is missing in configuration");
        }

        services.Configure<MailSettings>(configuration.GetSection("EmailSettings"));
        services.AddScoped<IEmailService, GmailService>();

        return services;
    }
}
