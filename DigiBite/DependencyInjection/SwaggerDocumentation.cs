using DigiBite_Core.Filter;
using DigiBite_Core.Helpers;
using DigiBite_Core.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace DigiBite_Api.DependencyInjection
{
    public static class SwaggerDocumentation
    {
        public static void AddSwaggerDocumentation(this IServiceCollection services)
        {

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new OpenApiInfo
                {
                    Title = "DigiBite API",
                    Version = "v1.0",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Akram Injaileh",
                        Email = "akraminjaileh@gmail.com",
                        Url = new Uri("https://wa.me/+962787454867"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "DigiBite API LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                

            });
        }
    }
}
