using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Developers2023.IoC.Extensions
{
    public static class OpenApiExtension
    {
        public static IServiceCollection AddOpenApi(this IServiceCollection services)
        {
            services.AddSwaggerGen(setup =>
            {
                setup.DescribeAllParametersInCamelCase();

                setup.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "4Developers 2023 API",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Kamil Wysocki",
                        Email = "kamwys93@gmail.com"
                    },
                    Description = "Usługi REST Api pozwalające na zarządzanie klientami"
                });


                //Authorization in Swagger
                //setup.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //{
                //    Description = "Token JWT używany do autoryzacji REST API. \r\n\r\n" +
                //                  "Wpisz 'Bearer' [spacja] token",
                //    Name = "Authorization",
                //    In = ParameterLocation.Header,
                //    Type = SecuritySchemeType.ApiKey,
                //    Scheme = "Bearer"
                //});

                //setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                //{
                //    {
                //      new OpenApiSecurityScheme
                //      {
                //        Reference = new OpenApiReference
                //          {
                //            Type = ReferenceType.SecurityScheme,
                //            Id = "Bearer"
                //          },
                //          Scheme = "Bearer",
                //          Name = "Bearer",
                //          In = ParameterLocation.Header,

                //      },
                //        new List<string>()
                //    }
                //});


                //Swagger auto documentation
                //Assembly[] assemblies = AppDomain.CurrentDomain.GetUserAssemblies();

                //foreach (Assembly assembly in assemblies)
                //{
                //    string documentPath = assembly.GetAssemblyPath();
                //    setup.IncludeXmlComments(documentPath);
                //}
            });
            return services;
        }

        public static void UseOpenApi(this WebApplication app)
        {
            if(app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
        }
    }
}
