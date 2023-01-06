using NSubstitute;
using RnCore.Logging;
using RnCore.Mailer.Factories;
using RnCore.Mailer.Wrappers;
using RnCore.MailerTests.TestSupport.Builders;
using System.Net.Mail;

namespace RnCore.MailerTests.RnMailUtilsFactoryTests;

[TestFixture]
public class CreateSmtpClientTests
{
  private const string Host = "smtp.gmail.com";
  private const int Port = 955;

  [Test]
  public void CreateSmtpClient_GivenCalled_ShouldReturnSmtpClientWrapper()
  {
    // arrange
    var mailUtilsFactory = TestHelper.GetRnMailUtilsFactory();

    // act
    var smtpClient = mailUtilsFactory.CreateSmtpClient();

    // assert
    Assert.That(smtpClient, Is.Not.Null);
    Assert.That(smtpClient, Is.InstanceOf<ISmtpClient>());
  }

  [Test]
  public void CreateSmtpClient_GivenCalled_ShouldSetCorrectHost()
  {
    // arrange
    var mailConfig = new RnMailConfigBuilder()
      .WithDefaults()
      .WithHost(Host)
      .WithPort(Port)
      .Build();

    var mailUtilsFactory = TestHelper.GetRnMailUtilsFactory(
      mailConfig: mailConfig);

    // act
    var smtpClient = mailUtilsFactory.CreateSmtpClient();

    // assert
    Assert.That(smtpClient.Host, Is.EqualTo(Host));
    Assert.That(smtpClient.Port, Is.EqualTo(Port));
  }

  [Test]
  public void CreateSmtpClient_GivenCalled_ShouldSetDeliveryFormat()
  {
    // arrange
    var mailConfig = new RnMailConfigBuilder()
      .WithDefaults()
      .WithDeliveryFormat(SmtpDeliveryFormat.International)
      .Build();

    var mailUtilsFactory = TestHelper.GetRnMailUtilsFactory(
      mailConfig: mailConfig);

    // act
    var smtpClient = mailUtilsFactory.CreateSmtpClient();

    // assert
    Assert.That(smtpClient.DeliveryFormat, Is.EqualTo(SmtpDeliveryFormat.International));
  }

  [Test]
  public void CreateSmtpClient_GivenCalled_ShouldSetDeliveryMethod()
  {
    // arrange
    var mailConfig = new RnMailConfigBuilder()
      .WithDefaults()
      .WithDeliveryMethod(SmtpDeliveryMethod.Network)
      .Build();

    var mailUtilsFactory = TestHelper.GetRnMailUtilsFactory(
      mailConfig: mailConfig);

    // act
    var smtpClient = mailUtilsFactory.CreateSmtpClient();

    // assert
    Assert.That(smtpClient.DeliveryMethod, Is.EqualTo(SmtpDeliveryMethod.Network));
  }

  [Test]
  public void CreateSmtpClient_GivenCalled_ShouldSetEnableSsl()
  {
    // arrange
    var mailConfig = new RnMailConfigBuilder()
      .WithDefaults()
      .WithEnableSsl(true)
      .Build();

    var mailUtilsFactory = TestHelper.GetRnMailUtilsFactory(
      mailConfig: mailConfig);

    // act
    var smtpClient = mailUtilsFactory.CreateSmtpClient();

    // assert
    Assert.That(smtpClient.EnableSsl, Is.EqualTo(true));
  }

  [Test]
  public void CreateSmtpClient_GivenCalled_ShouldSetTimeout()
  {
    // arrange
    var mailConfig = new RnMailConfigBuilder()
      .WithDefaults()
      .WithTimeout(120)
      .Build();

    var mailUtilsFactory = TestHelper.GetRnMailUtilsFactory(
      mailConfig: mailConfig);

    // act
    var smtpClient = mailUtilsFactory.CreateSmtpClient();

    // assert
    Assert.That(smtpClient.Timeout, Is.EqualTo(120));
  }

  [Test]
  public void CreateSmtpClient_GivenCalled_ShouldSetUseDefaultCredentials()
  {
    // arrange
    var mailConfig = new RnMailConfigBuilder()
      .WithDefaults()
      .Build();

    var mailUtilsFactory = TestHelper.GetRnMailUtilsFactory(
      mailConfig: mailConfig);

    // act
    var smtpClient = mailUtilsFactory.CreateSmtpClient();

    // assert
    Assert.That(smtpClient.UseDefaultCredentials, Is.EqualTo(false));
  }

  [Test]
  public void CreateSmtpClient_GivenNoConfiguredCredentials_ShouldNotSetCredentials()
  {
    // arrange
    var mailConfig = new RnMailConfigBuilder()
      .WithDefaults()
      .WithUsername("")
      .WithPassword("")
      .Build();

    var mailUtilsFactory = TestHelper.GetRnMailUtilsFactory(
      mailConfig: mailConfig);

    // act
    var smtpClient = mailUtilsFactory.CreateSmtpClient();

    // assert
    Assert.That(smtpClient.Credentials, Is.Null);
  }

  [Test]
  public void CreateSmtpClient_GivenHasConfiguredCredentials_ShouldSetCredentials()
  {
    // arrange
    var mailConfig = new RnMailConfigBuilder()
      .WithDefaults()
      .WithUsername("username")
      .WithPassword("password")
      .Build();

    var mailUtilsFactory = TestHelper.GetRnMailUtilsFactory(
      mailConfig: mailConfig);

    // act
    var smtpClient = mailUtilsFactory.CreateSmtpClient();

    // assert
    Assert.That(smtpClient.Credentials, Is.Not.Null);
    var networkCredential = smtpClient.Credentials.GetCredential(mailConfig.Host, mailConfig.Port, string.Empty);

    Assert.That(networkCredential!.UserName, Is.EqualTo(mailConfig.Username));
    Assert.That(networkCredential!.Password, Is.EqualTo(mailConfig.Password));
  }

  [Test]
  public void CreateSmtpClient_GivenCalled_ShouldLog()
  {
    // arrange
    var logger = Substitute.For<ILoggerAdapter<RnMailUtilsFactory>>();

    var mailConfig = new RnMailConfigBuilder()
      .WithDefaults()
      .WithTimeout(120)
      .Build();

    var mailUtilsFactory = TestHelper.GetRnMailUtilsFactory(
      mailConfig: mailConfig,
      logger: logger);

    // act
    mailUtilsFactory.CreateSmtpClient();

    // assert
    logger.Received(1).LogDebug("Created new instance for: {host}", mailConfig.Host);
  }
}

