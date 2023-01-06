using NSubstitute;
using RnCore.Logging;
using RnCore.Mailer.Config;
using RnCore.Mailer.Factories;
using RnCore.MailerTests.TestSupport.Builders;

namespace RnCore.MailerTests.RnMailUtilsFactoryTests;

public static class TestHelper
{
  public static RnMailUtilsFactory GetRnMailUtilsFactory(
    ILoggerAdapter<RnMailUtilsFactory>? logger = null,
    RnMailConfig? mailConfig = null) =>
    new(
      logger ?? Substitute.For<ILoggerAdapter<RnMailUtilsFactory>>(),
      mailConfig ?? RnMailConfigBuilder.Default);
}
