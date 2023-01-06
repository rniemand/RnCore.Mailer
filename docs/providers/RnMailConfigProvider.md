# RnMailConfigProvider
/ [Providers](./providers/README.md) / RnMailConfigProvider

Used to provide instances of the [RnMailConfig](/docs/configuration/RnMailConfig.md) configuration class.

The default implementation of `RnMailConfigProvider` caches configuration at construction time and will require an application restart to load new configuration values.

## Expectations
The `RnMailConfigProvider` expects that the following services are registered on the `DI Container`.

- `ILoggerAdapter<>` - from [Rn.NetCore.Common](https://www.nuget.org/packages/Rn.NetCore.Common/).
- `IConfiguration` - from [Microsoft.Extensions.Configuration](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.configuration?view=dotnet-plat-ext-6.0).
