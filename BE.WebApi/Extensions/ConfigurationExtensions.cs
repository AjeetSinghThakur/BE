using BE.Service.ConfigurationOptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BE.WebApi.Extensions
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<SmtpOptions>(config.GetSection(SmtpOptions.Section));
            services.Configure<JsonWebTokenOptions>(config.GetSection(JsonWebTokenOptions.Section));

            return services;
        }
    }
}
