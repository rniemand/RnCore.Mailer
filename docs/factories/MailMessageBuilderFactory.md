# MailMessageBuilderFactory
/ [Factories](./factories/README.md) / MailMessageBuilderFactory

## Expectations
The `MailMessageBuilderFactory` expects that the following services are registered on the `DI Container`.

- [ILoggerAdapter<>](https://github.com/rniemand/Rn.NetCore.Common/blob/master/src/Rn.NetCore.Common/Logging/ILoggerAdapter.cs) - from [Rn.NetCore.Common](https://www.nuget.org/packages/Rn.NetCore.Common/).
- [IRnMailConfigProvider](/docs//providers/RnMailConfigProvider.md) - instance of **RnMailConfigProvider**.

## Methods
The following methods are exposed by the `MailMessageBuilderFactory`.

| Method | Since | Returns | Notes |
| --- | --- | --- | --- |
| `Create()` | 6.0.1.101 | [MailMessageBuilder](/docs/builders/MailMessageBuilder.md) | Creates a new instance of the `MailMessageBuilder` class using the global [RnMailConfig](/docs/configuration/RnMailConfig.md) object to set the **from** information. |
