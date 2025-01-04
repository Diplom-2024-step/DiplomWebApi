namespace AnytourApi.Infrastructure.EmailServer;

public interface IEmailService
{

    public Task SendEmailAsync(EmailRequest request);

    public Task SendConfirmingEmail(string email, string userName, string link);

}
