using RnCore.Logging;
using RnCore.Mailer.Config;

namespace RnCore.Mailer.Factories;

public interface IMailTemplateProvider
{
  string GetTemplate(string name);
  string GetCss(string name);
}

public class MailTemplateProvider : IMailTemplateProvider
{
  private readonly ILoggerAdapter<MailTemplateProvider> _logger;
  private readonly RnMailConfig _mailConfig;
  private readonly string _templateDir;
  private readonly string _cssDir;

  public MailTemplateProvider(
    ILoggerAdapter<MailTemplateProvider> logger,
    RnMailConfig mailConfig)
  {
    _logger = logger;
    _mailConfig = mailConfig;

    _templateDir = GenerateTemplateDirPath();
    _cssDir = GenerateCssDirPath();

    EnsureDirectoryExists(_cssDir);
  }

  public string GetTemplate(string name)
  {
    var tplFilePath = GenerateTemplatePath(name);

    // TODO: [EXTRACT] (MailTemplateProvider.GetTemplate) Create abstraction
    if (File.Exists(tplFilePath))
      return File.ReadAllText(tplFilePath);

    _logger.LogError("Unable to resolve template file path: {path}", tplFilePath);
    return string.Empty;
  }

  public string GetCss(string name)
  {
    var filePath = GenerateCssPath(name);

    // TODO: [EXTRACT] (MailTemplateProvider.GetCss) Create abstraction
    if (File.Exists(filePath))
      return File.ReadAllText(filePath);

    _logger.LogWarning("Unable to find requested CSS file: {path}", filePath);
    return string.Empty;
  }

  private string GenerateTemplateDirPath()
  {
    var templateDir = _mailConfig.TemplateDir;

    // TODO: [EXTRACT] (MailTemplateProvider.GenerateTemplateDirPath) Create abstraction
    if (templateDir.StartsWith("./"))
      templateDir = Path.Join(Environment.CurrentDirectory, templateDir[2..]);

    // ReSharper disable once ConvertIfStatementToReturnStatement
    // TODO: [EXTRACT] (MailTemplateProvider.GenerateTemplateDirPath) Create abstraction
    if (!Path.EndsInDirectorySeparator(templateDir))
      return Path.Join(templateDir, Path.DirectorySeparatorChar.ToString());

    return templateDir;
  }

  private string GenerateCssDirPath()
  {
    // TODO: [EXTRACT] (MailTemplateProvider.GenerateCssDirPath) Create abstraction
    var basePath = Path.Join(_templateDir, "css");

    // ReSharper disable once ConvertIfStatementToReturnStatement
    // TODO: [EXTRACT] (MailTemplateProvider.GenerateCssDirPath) Create abstraction
    if (!Path.EndsInDirectorySeparator(basePath))
      return Path.Join(basePath, Path.DirectorySeparatorChar.ToString());

    return basePath;
  }

  private void EnsureDirectoryExists(string path)
  {
    // TODO: [EXTRACT] (MailTemplateProvider.EnsureDirectoryExists) Create abstraction
    if (Directory.Exists(path))
      return;

    Directory.CreateDirectory(path);
  }

  private string GenerateTemplatePath(string name) =>
    Path.Join(_templateDir, $"{name}.html");

  private string GenerateCssPath(string name) =>
    Path.Join(_cssDir, $"{name}.css");
}
