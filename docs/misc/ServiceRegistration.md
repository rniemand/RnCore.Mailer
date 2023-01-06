# Service Registration
/ [Misc.](./misc/README.md) / Service Registration

This page covers what services are registered when you call the `.AddRnMailUtils()` method.

## Registers
The `.AddRnMailUtils()` extension method will register the following obhects on the provided `IServiceCollection` instance.

| Interface | Reg. Method | Notes |
| --- | --- | --- |
| `IEnvironmentAbstraction` | `TryAddSingleton()` | Used to calculate paths. |
| `IPathAbstraction` | `TryAddSingleton()` | Used to build and resolve template paths. |
| `IDirectoryAbstraction` | `TryAddSingleton()` | Used to query directories. |
| `IFileAbstraction` | `TryAddSingleton()` | Used to work with files and templates. |
| `ILoggerAdapter<>` | `TryAddSingleton()` | Used for logging |
| `ISmtpClientFactory` | `AddSingleton()` | Used to create instances of the [SmtpClientWrapper](/docs/wrappers/SmtpClientWrapper.md) class. |
| `IMailMessageBuilderFactory` | `AddSingleton()` | Used to create instances of the [MailMessageBuilder](/docs/builders/MailMessageBuilder.md) builder. |
| `IRnMailConfigProvider` | `AddSingleton()` | Used to provide instances of the [RnMailConfig](/docs/configuration/RnMailConfig.md) object. |
| `IMailTemplateProvider` | `AddSingleton()` | Used to create instances of the [MailTemplateBuilder](/docs/builders/MailTemplateBuilder.md) builder. |
| `IMailTemplateHelper` | `AddSingleton()` | Utility class used within `Rn.NetCore.MailUtils`. |

## Depends On
The following objects are not registered on the `IServiceCollection` instance, but are expected to be present.

- `IConfiguration` - used to resolve configuration for the mailer
