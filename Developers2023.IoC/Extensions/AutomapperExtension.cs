using Microsoft.Extensions.DependencyInjection;

namespace Developers2023.IoC.Extensions
{
    public static class AutomapperExtension
    {
        public static IServiceCollection AddAutomapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
