# MailMessageBuilder
/ [Builders](./builders/README.md) / MailMessageBuilder

## Injected Template Placeholders
When passing in an instance of [MailTemplateBuilder](/docs/builders/MailTemplateBuilder.md) into **MailMessageBuilder** the following [template placeholders](/docs/misc/MailTemplatePlaceholders.md) are made available for use in the provided [mail template](/docs/misc/MailTemplates.md).

| Placeholder | Since | Type | Notes |
| --- | --- | --- | --- |
| `{{mail.subject}}` | 6.0.1.103 | string | The provided mail subject. |
| `{{mail.fromAddress}}` | 6.0.1.103 | Address | The mails from address. |
| `{{mail.fromName}}` | 6.0.1.103 | string | The mails from name. |
| `{{mail.toAddress}}` | 6.0.1.103 | Address | The first recipients email address. |
| `{{mail.toName}}` | 6.0.1.103 | string | The first recipients name. |
| `{{mail.date}}` | 6.0.1.103 | DateTime | The local `DateTime` when the template was compiled. |
