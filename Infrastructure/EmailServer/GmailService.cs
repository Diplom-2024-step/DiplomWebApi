using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

namespace AnytourApi.Infrastructure.EmailServer;

public class GmailService : IEmailService, IDisposable
{
    private readonly EmailSettings _emailSettings;
    private readonly SmtpClient _smtpClient;

    public GmailService(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value ?? throw new ArgumentNullException(nameof(emailSettings));

        if (string.IsNullOrEmpty(_emailSettings.SMTP))
            throw new InvalidOperationException("SMTP server address is not configured");
        if (string.IsNullOrEmpty(_emailSettings.SenderEmail))
            throw new InvalidOperationException("Sender email is not configured");
        if (string.IsNullOrEmpty(_emailSettings.Password))
            throw new InvalidOperationException("Email password is not configured");
        _smtpClient = new SmtpClient(_emailSettings.SMTP)
        {
            Host = _emailSettings.SMTP,
            Port = 587,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(_emailSettings.SenderEmail, _emailSettings.Password),
            Timeout = 20000 // 20 seconds
        };
    }

    public async Task SendEmailAsync(EmailRequest request)
    {
        try
        {
            var mailMessage = CreateMailMessage(request);
            await _smtpClient.SendMailAsync(mailMessage);
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to send email: {ex.Message}", ex);
        }
    }

    public void SendEmail(EmailRequest request)
    {
        try
        {
            var mailMessage = CreateMailMessage(request);
            _smtpClient.Send(mailMessage);
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to send email: {ex.Message}", ex);
        }
    }

    private MailMessage CreateMailMessage(EmailRequest request)
    {
        var mailMessage = new MailMessage
        {
            From = new MailAddress(_emailSettings.SenderEmail, request.FromName),
            Subject = request.Subject,
            IsBodyHtml = true,
        };

        foreach (var recipient in request.To)
        {
            mailMessage.To.Add(recipient);
        }

        var plainView = AlternateView.CreateAlternateViewFromString(
            request.PlainText,
            null,
            "text/plain"
        );
        var htmlView = AlternateView.CreateAlternateViewFromString(
            request.Html,
            null,
            "text/html"
        );

        mailMessage.AlternateViews.Add(plainView);
        mailMessage.AlternateViews.Add(htmlView);

        return mailMessage;
    }

    public void Dispose()
    {
        _smtpClient?.Dispose();
    }
}