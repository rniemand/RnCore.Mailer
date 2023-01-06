using RnCore.Mailer.Builders;
using RnCore.MailerTests.TestSupport.Builders;

namespace RnCore.MailerTests.RnMailUtilsFactoryTests;

[TestFixture]
public class CreateMessageBuilderTests
{
  private const string FromAddress = "from@address.com";
  private const string FromName = "From Name";

  [Test]
  public void CreateMessageBuilder_GivenCalled_ShouldCreateMailMessageBuilder()
  {
    // arrange
    var mailUtilsFactory = TestHelper.GetRnMailUtilsFactory();

    // act
    var builder = mailUtilsFactory.CreateMessageBuilder();

    // assert
    Assert.That(builder, Is.InstanceOf<MailMessageBuilder>());
  }

  [Test]
  public void CreateMessageBuilder_GivenNoFromName_ShouldSetDefaultFromName()
  {
    // arrange
    var rnMailConfig = new RnMailConfigBuilder()
      .WithDefaults()
      .WithFromAddress(FromAddress)
      .WithFromName("")
      .Build();

    var mailUtilsFactory = TestHelper.GetRnMailUtilsFactory(
      mailConfig: rnMailConfig);

    // act
    var builder = mailUtilsFactory.CreateMessageBuilder();
    var mailMessage = builder.Build();

    // assert
    Assert.That(mailMessage.From!.Address, Is.EqualTo(FromAddress));
    Assert.That(mailMessage.From!.DisplayName, Is.EqualTo(FromAddress));
  }

  [Test]
  public void CreateMessageBuilder_GivenCalled_ShouldSetCorrectFromDetails()
  {
    // arrange
    var rnMailConfig = new RnMailConfigBuilder()
      .WithDefaults()
      .WithFromAddress(FromAddress)
      .WithFromName(FromName)
      .Build();

    var mailUtilsFactory = TestHelper.GetRnMailUtilsFactory(
      mailConfig: rnMailConfig);

    // act
    var builder = mailUtilsFactory.CreateMessageBuilder();
    var mailMessage = builder.Build();

    // assert
    Assert.That(mailMessage.From!.Address, Is.EqualTo(FromAddress));
    Assert.That(mailMessage.From!.DisplayName, Is.EqualTo(FromName));
  }
}

