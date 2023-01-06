using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RnCore.Logging;
using RnCore.Mailer.Config;
using RnCore.Mailer.Factories;

namespace RnCore.Mailer;

public static class ServiceCollectionExtensions
{
  public static IServiceCollection AddRnMailer(this IServiceCollection services, IConfiguration configuration)
  {
    services.TryAddSingleton(typeof(ILoggerAdapter<>), typeof(LoggerAdapter<>));

    return services
      .AddSingleton(BindConfig(configuration))
      .AddSingleton<IRnMailUtilsFactory, RnMailUtilsFactory>()
      .AddSingleton<IMailTemplateProvider, MailTemplateProvider>()
      .AddSingleton<IMailTemplateHelper, MailTemplateHelper>();
  }

  private static RnMailConfig BindConfig(IConfiguration configuration)
  {
    var boundConfig = new RnMailConfig();
    var configSection = configuration.GetSection("RnCore.Mailer");

    if (!configSection.Exists())
      return boundConfig;

    configSection.Bind(boundConfig);
    return boundConfig;
  }
}
