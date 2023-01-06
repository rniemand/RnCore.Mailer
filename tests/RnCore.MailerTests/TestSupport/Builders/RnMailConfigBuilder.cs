using RnCore.Mailer.Config;
using System.Net.Mail;

namespace RnCore.MailerTests.TestSupport.Builders;

public class RnMailConfigBuilder
{
  public static RnMailConfig Default = new RnMailConfigBuilder().WithDefaults().Build();

  private readonly RnMailConfig _mailConfig = new();
  private readonly Dictionary<string, object> _globalPlaceholders = new();

  public RnMailConfigBuilder WithDefaults() =>
    WithFromName("From Name")
      .WithFromAddress("from@address.com")
      .WithUsername("username")
      .WithPassword("password");

  public RnMailConfigBuilder WithFromAddress(string fromAddress)
  {
    _mailConfig.FromAddress = fromAddress;
    return this;
  }

  public RnMailConfigBuilder WithFromName(string fromName)
  {
    _mailConfig.FromName = fromName;
    return this;
  }

  public RnMailConfigBuilder WithHost(string host)
  {
    _mailConfig.Host = host;
    return this;
  }

  public RnMailConfigBuilder WithPort(int port)
  {
    _mailConfig.Port = port;
    return this;
  }

  public RnMailConfigBuilder WithDeliveryFormat(SmtpDeliveryFormat deliveryFormat)
  {
    _mailConfig.DeliveryFormat = deliveryFormat;
    return this;
  }

  public RnMailConfigBuilder WithDeliveryMethod(SmtpDeliveryMethod deliveryMethod)
  {
    _mailConfig.DeliveryMethod = deliveryMethod;
    return this;
  }

  public RnMailConfigBuilder WithEnableSsl(bool enabled)
  {
    _mailConfig.EnableSsl = enabled;
    return this;
  }

  public RnMailConfigBuilder WithTimeout(int timeout)
  {
    _mailConfig.Timeout = timeout;
    return this;
  }

  public RnMailConfigBuilder WithUsername(string username)
  {
    _mailConfig.Username = username;
    return this;
  }

  public RnMailConfigBuilder WithPassword(string password)
  {
    _mailConfig.Password = password;
    return this;
  }

  public RnMailConfigBuilder WithGlobalPlaceholder(string placeholder, object value)
  {
    _mailConfig.TemplatePlaceholders[placeholder] = value;
    return this;
  }

  public RnMailConfig Build() => _mailConfig;
}

