# MailTemplateProvider
/ [Providers](./providers/README.md) / MailTemplateProvider

Used to provide instances of the [MailTemplateBuilder](/docs/builders/MailTemplateBuilder.md) builder class.

## Expectations
The `MailTemplateProvider` expects that the following services are registered on the `DI Container`.

- `ILoggerAdapter<>` - from [Rn.NetCore.Common](https://www.nuget.org/packages/Rn.NetCore.Common/).
- [IRnMailConfigProvider](/docs//providers/RnMailConfigProvider.md) - instance of **RnMailConfigProvider**.
- `IEnvironmentAbstraction` - from [Rn.NetCore.Common](https://www.nuget.org/packages/Rn.NetCore.Common/).
- `IPathAbstraction` - from [Rn.NetCore.Common](https://www.nuget.org/packages/Rn.NetCore.Common/).
- `IDirectoryAbstraction` - from [Rn.NetCore.Common](https://www.nuget.org/packages/Rn.NetCore.Common/).
- `IFileAbstraction` - from [Rn.NetCore.Common](https://www.nuget.org/packages/Rn.NetCore.Common/).

## Methods
The following methods are exposed by the `MailTemplateProvider`.

| Method | Since | Returns | Notes |
| --- | --- | --- | --- |
| `GetTemplate()` | 6.0.1.101 | `string` | Returns the contents of the requested template, `String.Empty` otherwise. |
