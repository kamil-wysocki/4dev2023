using Developers2023.Application.Interfaces;
using Developers2023.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Developers2023.IoC.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddSingleton<ICustomerService, CustomerService>();

            return services;
        }
    }
}
