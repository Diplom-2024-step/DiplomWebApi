namespace AnytourApi.Infrastructure.EmailServer;

public class EmailSettings
{
    public string SenderEmail { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string SMTP { get; set; } = string.Empty;
}