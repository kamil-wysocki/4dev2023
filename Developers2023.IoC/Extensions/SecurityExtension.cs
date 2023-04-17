using Developers2023.Common.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Developers2023.IoC.Extensions
{
    public static class SecurityExtension
    {
        public static IServiceCollection AddSecurity(this IServiceCollection services, TokenOption tokenOption)
        {
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                { 
                    ValidIssuer = tokenOption.Issuer,
                    ValidAudience = tokenOption.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes($"{tokenOption.LeftKeySecret}{tokenOption.RightKeySecret}")),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                };
            });

            services.AddAuthorization();

            return services;
        }

        public static void UseSecurity(this WebApplication app)
        {
            app.UseAuthorization();
        }
    }
}
