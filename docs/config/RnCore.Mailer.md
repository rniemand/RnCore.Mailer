# RnCore.Mailer
/ [Config](./config/README.md) / RnCore.Mailer

Holder

```json
{
  "RnCore.Mailer": {
    "host": "smtp.gmail.com",
    "port": 587,
    "username": "myuser",
    "password": "mypass",
    "fromAddress": "1@2.com",
    "fromName": "Me",
    "deliveryFormat": "SevenBit",
    "deliveryMethod": "Network",
    "enableSsl": true,
    "timeout": 30000,
    "encoding": "UTF8",
    "templateDir": "./mail-templates",
    "templatePlaceholders": {
      "key": "value"
    }
  }
}
```

## Configuration Properties
Below is a brekdown of each configuration value.

| Path | Type | Required | Default | Notes |
| --- | --- | --- | --- | --- |
| `host` | `string` | optional | smtp.gmail.com | Host to use when connecting to your mail service. |
| `port` | `int` | optional | `587` | Port to use when connecting to your mail service. |
| `username` | `string` | optional | - | Username to use when connecting to your mail service. |
| `password` | `string` | optional | - | Password to use when connecting to your mail service. |
| `fromAddress` | `EMail` | required | - | The from address to use when sending emails. |
| `fromName` | `string` | optional | - | The from name to use when sending emails, defaults to `fromAddress`. |
| `deliveryFormat` | [SmtpDeliveryFormat](https://docs.microsoft.com/en-us/dotnet/api/system.net.mail.smtpdeliveryformat?view=net-6.0) | optional | `SevenBit` | Delivery format to use. |
| `deliveryMethod` | [SmtpDeliveryMethod](https://docs.microsoft.com/en-us/dotnet/api/system.net.mail.smtpdeliverymethod?view=net-6.0) | optional | `Network` | Delivery method to use when sending emails. |
| `enableSsl` | `bool` | optional | `true` | Enabled the usage of SSL. |
| `timeout` | `int` | optional | `30000` | Timeout to use when sending emails. |
| `encoding` | [Encoding](https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=net-6.0) | optional | `UTF8` | The encoding to use when sending emails. |
| `templateDir` | `Directory` | optional | `./mail-templates` | Path to mail template directory. |
| `templatePlaceholders` | `Dictionary<>` | optional | `{}` | Global placeholder values that can be used when using the [MailTemplateBuilder](/docs/builders/MailTemplateBuilder.md) helper. |
