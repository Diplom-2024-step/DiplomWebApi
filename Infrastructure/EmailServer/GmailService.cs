using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using AnytourApi.Infrastructure.EmailServer.Settings;
using Mailjet.Client;
using System.Diagnostics.Tracing;
using Newtonsoft.Json.Linq;
using Mailjet.Client.Resources;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Xml.Linq;

namespace AnytourApi.Infrastructure.EmailServer;

public class GmailService : IEmailService
{
    private readonly MailSettings _emailSettings;
    private readonly MailjetClient _client;

    public GmailService(IOptions<MailSettings> emailSettings)
    {

        _emailSettings = emailSettings.Value;

        _client = new MailjetClient(_emailSettings.ApiKey, _emailSettings.ApiSecret)
        {
            BaseAdress = "https://api.mailjet.com/v3"
        };

    }

    public async Task SendEmailAsync(EmailRequest emailRequest)
    {
        try
        {
            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
             .Property(Send.FromEmail, _emailSettings.FromEmail)
             .Property(Send.FromName, "Expedia")
             .Property(Send.Recipients, new JArray {
                 new JObject {
                     {"Email", emailRequest.To},
                        {"Name", emailRequest.ToName}

                 }
             })
             .Property(Send.Subject, emailRequest.Subject)
             .Property(Send.TextPart, emailRequest.PlainText)
             .Property(Send.HtmlPart, emailRequest.Html);
            MailjetResponse response = await _client.PostAsync(request);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(string.Format("Total: {0}, Count: {1}\n", response.GetTotal(), response.GetCount()));
                Console.WriteLine(response.GetData());
            }
            else
            {
                Console.WriteLine(string.Format("StatusCode: {0}\n", response.StatusCode));
                Console.WriteLine(string.Format("ErrorInfo: {0}\n", response.GetErrorInfo()));
                Console.WriteLine(response.GetData());
                Console.WriteLine(string.Format("ErrorMessage: {0}\n", response.GetErrorMessage()));
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to send email: {ex.Message}", ex);
        }
    }

    public async Task SendConfirmingEmail(string email, string userName, string link)
    {
        var htmlTemplate = @"<!DOCTYPE html>
<html lang=""uk"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Підтвердьте свою електронну адресу</title>
    <style>
        :root {
            --primary-color: #5DB3C1;
            --hover-color: #114fb3;
            --text-color: #141d38;
            --secondary-text: #697488;
        }
        
        body {
            font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif;
            margin: 0;
            padding: 20px;
            background-color: #f5f7fa;
            color: var(--text-color);
            -webkit-font-smoothing: antialiased;
        }
        
        .container {
            max-width: 600px;
            margin: 0 auto;
            padding: 40px;
            background-color: white;
            border-radius: 12px;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.05);
        }
        
        .header {
            text-align: center;
            margin-bottom: 40px;
            padding-bottom: 30px;
            border-bottom: 1px solid #eaedf3;
        }
        
        .logo {
            width: 120px;
            height: auto;
            margin: 0 auto;
        }
        
        .content {
            line-height: 1.8;
            font-size: 16px;
        }
        
        h2 {
            color: var(--text-color);
            font-size: 24px;
            font-weight: 600;
            margin-bottom: 24px;
        }
        
        .button-container {
            text-align: center;
            margin: 35px 0;
        }
        
        .button {
            display: inline-block;
            background-color: #5DB3C1;
            color: white;
            padding: 16px 32px;
            text-decoration: none;
            border-radius: 8px;
            font-weight: 500;
            transition: all 0.2s ease;
            text-align: center;
        }
               
        .notice {
            font-size: 14px;
            color: var(--secondary-text);
            margin-top: 30px;
            padding-top: 20px;
            border-top: 1px solid #eaedf3;
        }
        
        .footer {
            text-align: center;
            margin-top: 40px;
            color: var(--secondary-text);
            font-size: 14px;
        }
        
        @media (max-width: 600px) {
            .container {
                padding: 20px;
            }
            
            .button {
                display: block;
                margin: 0 20px;
            }
        }
    </style>
</head>
<body>
    <div class=""container"">
        <div class=""header"">
            <img src=""https://www.expedia.ie/_dms/header/logo.svg?locale=en_IE&siteid=63&2&6f9ec7db"" alt=""Expedia"" class=""logo"">
        </div>
        <div class=""content"">
            <h2>Привіт, {{UserName}}!</h2>
            <p>Дякуємо, що приєдналися до Expedia. Ми раді бачити вас у нашій спільноті подорожуючих!</p>
            <p>Щоб почати планувати свої подорожі, підтвердьте, будь ласка, вашу електронну адресу:</p>
            <div class=""button-container button"">
                <a href=""{{Link}}"" class=""button"">Підтвердити електронну пошту</a>
            </div>
            <p class=""notice"">Якщо ви не створювали обліковий запис на Expedia, просто проігноруйте це повідомлення.</p>
        </div>
        <div class=""footer"">
            <p>&copy; 2025 Expedia Group. Всі права захищені.</p>
        </div>
    </div>
</body>
</html>";

        await this.SendEmailAsync( new EmailRequest
            {
            FromName = "Expedia",
    To = email,
    Subject = "Підтвердьте свою електронну адресу",
    ToName = userName,
    Html = htmlTemplate.Replace("{{UserName}}", userName).Replace("{{Link}}", link),
    PlainText = $"Привіт {userName},\n\nДля підтвердження вашої електронної адреси, будь ласка, перейдіть за цим посиланням:\n{link}\n\nЯкщо ви не реєструвалися на нашому сайті, просто проігноруйте це повідомлення.\n\nЗ повагою,\nКоманда Expedia"});
    }



   
   }