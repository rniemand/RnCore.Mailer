using RnCore.Mailer.Config;
using System.Net.Mail;

namespace RnCore.MailerTests.Config;

[TestFixture]
class RnMailConfigTests
{
  [Test]
  public void RnMailConfig_GivenDefaultConstructor_ShouldSet_Host() =>
    Assert.That(new RnMailConfig().Host, Is.EqualTo("smtp.gmail.com"));

  [Test]
  public void RnMailConfig_GivenDefaultConstructor_ShouldSet_Port() =>
    Assert.That(new RnMailConfig().Port, Is.EqualTo(587));

  [Test]
  public void RnMailConfig_GivenDefaultConstructor_ShouldSet_Username() =>
    Assert.That(new RnMailConfig().Username, Is.EqualTo(string.Empty));

  [Test]
  public void RnMailConfig_GivenDefaultConstructor_ShouldSet_Password() =>
    Assert.That(new RnMailConfig().Password, Is.EqualTo(string.Empty));

  [Test]
  public void RnMailConfig_GivenDefaultConstructor_ShouldSet_FromAddress() =>
    Assert.That(new RnMailConfig().FromAddress, Is.EqualTo(string.Empty));

  [Test]
  public void RnMailConfig_GivenDefaultConstructor_ShouldSet_FromName() =>
    Assert.That(new RnMailConfig().FromName, Is.EqualTo(string.Empty));

  [Test]
  public void RnMailConfig_GivenDefaultConstructor_ShouldSet_DeliveryFormat() =>
    Assert.That(new RnMailConfig().DeliveryFormat, Is.EqualTo(SmtpDeliveryFormat.SevenBit));

  [Test]
  public void RnMailConfig_GivenDefaultConstructor_ShouldSet_DeliveryMethod() =>
    Assert.That(new RnMailConfig().DeliveryMethod, Is.EqualTo(SmtpDeliveryMethod.Network));

  [Test]
  public void RnMailConfig_GivenDefaultConstructor_ShouldSet_EnableSsl() =>
    Assert.That(new RnMailConfig().EnableSsl, Is.True);

  [Test]
  public void RnMailConfig_GivenDefaultConstructor_ShouldSet_Timeout() =>
    Assert.That(new RnMailConfig().Timeout, Is.EqualTo(30000));

  [TestCase("", "", false)]
  [TestCase("user", "", false)]
  [TestCase("", "pass", false)]
  [TestCase("user", "pass", true)]
  public void HasCredentials_GivenSpecificUserAndPassValues_ShouldReturnExpectedResult(string user, string pass, bool expected)
  {
    // arrange
    var config = new RnMailConfig
    {
      Username = user,
      Password = pass
    };

    // assert
    Assert.That(config.HasCredentials(), Is.EqualTo(expected));
  }
}
