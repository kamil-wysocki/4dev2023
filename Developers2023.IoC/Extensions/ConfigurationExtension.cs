using Microsoft.Extensions.Configuration;

namespace Developers2023.IoC.Extensions
{
    public static class ConfigurationExtension
    {
        public static IConfigurationBuilder AddConfiguration(this IConfigurationBuilder builder, string name, 
            bool optional = false, bool reload = true)
        {
            builder.AddJsonFile(name, optional, reloadOnChange: reload);
            return builder;
        }
    }
}
