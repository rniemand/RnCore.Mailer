# SmtpClientFactory
/ [Factories](./factories/README.md) / SmtpClientFactory

## Expectations
The `SmtpClientFactory` expects that the following services are registered on the `DI Container`.

- [ILoggerAdapter<>](https://github.com/rniemand/Rn.NetCore.Common/blob/master/src/Rn.NetCore.Common/Logging/ILoggerAdapter.cs) - from [Rn.NetCore.Common](https://www.nuget.org/packages/Rn.NetCore.Common/).
- [IRnMailConfigProvider](/docs//providers/RnMailConfigProvider.md) - instance of **RnMailConfigProvider**.