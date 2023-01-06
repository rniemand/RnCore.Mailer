# Mail Templates
/ [Misc.](./misc/README.md) / Mail Templates

Mail templates can be used to reduce the amount of embedded `HTML` and `CSS` in your applications, the [MailTemplateHelper](/docs/helpers/MailTemplateHelper.md) class uses the [MailTemplateProvider](/docs/providers/MailTemplateProvider.md) to generate instances of the [MailTemplateBuilder](/docs/builders/MailTemplateBuilder.md) bound to a specific template file which can be compiled and sent via the [SmtpClientWrapper](/docs/wrappers/SmtpClientWrapper.md).

## Folder Structure
You can configure the mail template directory via [RnMailConfig](/docs/configuration/RnMailConfig.md), the following structure is expected when resolving and working with mail templates.

    <templateDir>
    |- css
    |  |- my_css.css
    |  |- another.css
    |- template1.html
    |- template2.html

### Template Directory
This is the value defined at `Rn.MailUtils:templateDir` and is the folder used to resolve template files.

Template files are expected to have an `.html` file extension and are referred to by their name (excluding the extension), so in the example above `template1` would resolve to the `<templateDir>/template1.html` file.

### CSS Directory
The `css` directory is used to store any common `.css` files used by your templates to save on repetition.

When a new instance of [MailTemplateBuilder](/docs/builders/MailTemplateBuilder.md) is created any references to css files (noted using `{css:<file>}`) are resolved and embedded into the final template HTML.

Using the example above a CSS tag `{css:my_css}` will be replaced with the contents of the `<templateDir>/css/my_css.css` in the generated HTML.

## Sample Template
Below is an example of a mail template:

```html
<html lang="en">
<head>
  <meta charset="UTF-8">
  {css:main}
</head>
<body class="mail-body">
  <div class="wrapper">
    <div class="content">
      <h1>{{mail.subject}}</h1>
      <p>Hello {{name}}</p>
      <div>The current date is: {{currentDate:'yyyy-MM-dd'}}</div>
    </div>
  </div>
</body>
</html>
```

In the above example `{css:main}` is replaced with the contents of the main mail template css file.

Additionally all mail placeholder tags will be discovered and replaced with the appropriate values, you can find out more about mail template placeholders [here](/docs/misc/MailTemplatePlaceholders.md).
