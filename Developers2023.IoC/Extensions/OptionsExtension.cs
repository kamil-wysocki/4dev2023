using Developers2023.Common.Options.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Developers2023.IoC.Extensions
{
    public static class OptionsExtension
    {
        public static WebApplicationBuilder AddOption<T>(this WebApplicationBuilder builder) where T : BaseOption
        {
            builder.Services.AddOptions<T>()
                .Bind(builder.Configuration.GetSection(typeof(T).Name));
            //Validation option
                //.ValidateDataAnnotations()
                //.ValidateOnStart();

            return builder;
        }

        public static T GetOption<T>(this IConfiguration configuration) where T : BaseOption
        {
            T? option = configuration.GetSection(typeof(T).Name).Get<T>();

            if (option != null)
            {
                return option;
            }
            else
            {
                throw new ArgumentException($"Option {typeof(T).Name} not found in configuration");
            }
        }
    }
}
