using NSubstitute;
using RnCore.Logging;
using RnCore.Mailer.Config;
using RnCore.Mailer.Factories;
using RnCore.MailerTests.TestSupport.Builders;

namespace RnCore.MailerTests.Helpers.MailTemplateHelperTests;

public static class TestHelper
{
  public static MailTemplateHelper GetMailTemplateHelper(
    ILoggerAdapter<MailTemplateHelper>? logger = null,
    IMailTemplateProvider? tplProvider = null,
    RnMailConfig? mailConfig = null) =>
    new(
      logger ?? Substitute.For<ILoggerAdapter<MailTemplateHelper>>(),
      tplProvider ?? Substitute.For<IMailTemplateProvider>(),
      mailConfig ?? RnMailConfigBuilder.Default);
}
