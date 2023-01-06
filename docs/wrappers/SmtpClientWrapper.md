# SmtpClientWrapper
/ [Wrappers](./wrappers/README.md) / SmtpClientWrapper

Wrapper for the **SmtpClient** `.net` class, exposed as `ISmtpClient`.

```csharp
public interface ISmtpClient
{
  SmtpDeliveryFormat DeliveryFormat { get; set; }
  SmtpDeliveryMethod DeliveryMethod { get; set; }
  bool EnableSsl { get; set; }
  string? PickupDirectoryLocation { get; set; }
  string? TargetName { get; set; }
  int Timeout { get; set; }
  bool UseDefaultCredentials { get; set; }
  ICredentialsByHost? Credentials { get; set; }

  Task SendMailAsync(MailMessage message);
  Task SendMailAsync(MailMessage message, CancellationToken cancellationToken);
  Task SendMailAsync(string from, string recipients, string? subject, string? body);
  Task SendMailAsync(string from, string recipients, string? subject, string? body, CancellationToken cancellationToken);
}
```