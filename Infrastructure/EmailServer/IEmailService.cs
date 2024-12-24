namespace AnytourApi.Infrastructure.EmailServer;

public interface IEmailService
{

    public Task SendEmailAsync(EmailRequest request);

    public void SendEmail(EmailRequest request);
}
