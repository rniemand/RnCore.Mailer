using NSubstitute;
using RnCore.Logging;
using RnCore.Mailer.Builders;
using RnCore.Mailer.Factories;
using RnCore.MailerTests.TestSupport.Builders;

namespace RnCore.MailerTests.Helpers.MailTemplateHelperTests;

[TestFixture]
public class GetTemplateBuilderTests
{
  private const string TemplateName = "TemplateName";
  private const string TemplateWithCss = "{css:hello}";

  [Test]
  public void GetTemplateBuilder_GivenCalled_ShouldLog()
  {
    // arrange
    var logger = Substitute.For<ILoggerAdapter<MailTemplateHelper>>();

    var templateHelper = TestHelper.GetMailTemplateHelper(
      logger: logger);

    // act
    templateHelper.GetTemplateBuilder(TemplateName);

    // assert
    logger.Received(1).LogDebug("Resolving template: {name}", TemplateName);
  }

  [Test]
  public void GetTemplateBuilder_GivenCalled_ShouldCallMailTemplateProvider()
  {
    // arrange
    var mailTemplateProvider = Substitute.For<IMailTemplateProvider>();

    var templateHelper = TestHelper.GetMailTemplateHelper(
      tplProvider: mailTemplateProvider);

    // act
    templateHelper.GetTemplateBuilder(TemplateName);

    // assert
    mailTemplateProvider.Received(1).GetTemplate(TemplateName);
  }

  [Test]
  public void GetTemplateBuilder_GivenTemplateFound_ShouldProcessCssTags()
  {
    // arrange
    var mailTemplateProvider = Substitute.For<IMailTemplateProvider>();

    mailTemplateProvider
      .GetTemplate(TemplateName)
      .Returns(TemplateWithCss);

    var templateHelper = TestHelper.GetMailTemplateHelper(
      tplProvider: mailTemplateProvider);

    // act
    templateHelper.GetTemplateBuilder(TemplateName);

    // assert
    mailTemplateProvider.Received(1).GetCss("hello");
  }

  [Test]
  public void GetTemplateBuilder_GivenHasTemplate_ShouldInjectGlobalPlaceholders()
  {
    // arrange
    var mailTemplateProvider = Substitute.For<IMailTemplateProvider>();

    var rnMailConfig = new RnMailConfigBuilder()
      .WithDefaults()
      .WithGlobalPlaceholder("test", 10)
      .WithGlobalPlaceholder("hello", "world")
      .Build();

    mailTemplateProvider
      .GetTemplate(TemplateName)
      .Returns(TemplateWithCss);

    var templateHelper = TestHelper.GetMailTemplateHelper(
      tplProvider: mailTemplateProvider,
      mailConfig: rnMailConfig);

    // act
    var builder = templateHelper.GetTemplateBuilder(TemplateName);

    // assert
    Assert.That(builder.Placeholders.Count, Is.GreaterThan(0));
    Assert.That(builder.Placeholders.ContainsKey("global.test"));
    Assert.That(builder.Placeholders.ContainsKey("global.hello"));
  }

  [Test]
  public void GetTemplateBuilder_GivenHasTemplate_ShouldReturnValieBuilder()
  {
    // arrange
    var mailTemplateProvider = Substitute.For<IMailTemplateProvider>();

    mailTemplateProvider
      .GetTemplate(TemplateName)
      .Returns(TemplateWithCss);

    var templateHelper = TestHelper.GetMailTemplateHelper(
      tplProvider: mailTemplateProvider);

    // act
    var builder = templateHelper.GetTemplateBuilder(TemplateName);

    // assert
    Assert.That(builder, Is.InstanceOf<MailTemplateBuilder>());
    Assert.That(builder.TemplateName, Is.EqualTo(TemplateName));
    Assert.That(builder.RawTemplate, Is.EqualTo("<style></style>"));
    Assert.That(builder.TemplateFound, Is.True);
  }
}

