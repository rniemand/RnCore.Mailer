# Mail Template Placeholders
/ [Misc.](./misc/README.md) / Mail Template Placeholders

When working with the [MailTemplateBuilder](/docs/builders/MailTemplateBuilder.md) and [Mail Templates](/docs/misc/MailTemplates.md) you can use placeholders that will be replaced with values at the time of the template compilation.

These placeholders follow the `{{<key>[:'formatting']}}` syntax where the following is true:

- `<key>` is required and refers to the associated `placeholder` set on the [MailTemplateBuilder](/docs/builders/MailTemplateBuilder.md) using the `AddPlaceHolder()` method.
- `:'formatting'` is optional and provides additional formatting options to be applied to the resolved `placeholder` if it supports it.

Any discovered placeholders that do not have an accompaying `placeholder` value on the [MailTemplateBuilder](/docs/builders/MailTemplateBuilder.md) will be replaced with an empty string to preserve the formatting of the mail.

## Supported Placeholders Types
The following `types` are supported currently:

- `string` - outputted as-is
- `int` - outoutted using `.ToString("D")` by default
- `long` - outoutted using `.ToString("D")` by default
- `bool` - outoutted as `true` or `false`
- `DateTime` - outoutted using `.ToString("s")` by default
- `float` - outoutted using `.ToString("G")` by default
- `double` - outoutted using `.ToString("G")` by default

Unsupported values will be output as `(UNSUPPORTED:{valueType})`.

## Placeholder Arguments
As mentioned above, some `placeholder` value types support an additional formatting argument to give some more control when outputting values, the table below documents these value types.

| Type | Required | Default | Notes |
| --- | --- | --- | --- |
| `DateTime` | optional | `s` | Date formatting string to use, e.g. `yyyy-MM-dd` |
| `int` | optional | `D` | Format to use when calling `.ToString()` |
| `long` | optional | `D` | Format to use when calling `.ToString()` |
| `float` | optional | `G` | Format to use when calling `.ToString()` |
| `double` | optional | `G` | Format to use when calling `.ToString()` |

## Global Placeholders
You can specify `global` placeholder via [RnMailConfig](/docs/configuration/RnMailConfig.md) which will be added to all instances of [MailTemplateBuilder](/docs/builders/MailTemplateBuilder.md) created by the [MailTemplateHelper](/docs/helpers/MailTemplateHelper.md) helper class.

Any values defined under `Rn.MailUtils:templatePlaceholders` will be made availabel to your mail template.

```json
{
  "Rn.MailUtils": {
    "templatePlaceholders": {
      "test": "You found me" 
    } 
  } 
}
```
The above value can be resolved using `{{global.test}}`, this allows you to provide some additional values to your mail templates.
