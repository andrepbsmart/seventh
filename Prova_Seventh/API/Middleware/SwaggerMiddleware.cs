using System;
using System.Reflection;

using Microsoft.OpenApi.Models;

namespace Prova.API.Middleware
{
    public static class SwaggerMiddleware
    {
        public static void AddSwaggerMiddleware(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API - Prova",
                    Version = "v1",
                    Description = "prova.",
                    Contact = new OpenApiContact
                    {
                        Name = "André Pimentel",
                        Email = string.Empty,

                        Url = new Uri("https://provaseventh.com.br/")
                    },
                });


            //    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            //    {
            //        Name = "Authorization",
            //        Type = SecuritySchemeType.ApiKey,
            //        Scheme = "Bearer",
            //        BearerFormat = "JWT",
            //        In = ParameterLocation.Header,
            //        Description = "JWT Authorization header using the Bearer scheme",
            //    });

            //    c.AddSecurityRequirement(new OpenApiSecurityRequirement
            //    {
            //            {
            //                  new OpenApiSecurityScheme
            //                  {
            //                      Reference = new OpenApiReference
            //                      {
            //                          Type = ReferenceType.SecurityScheme,
            //                          Id = "Bearer"
            //                      }
            //                  },
            //                 Array.Empty<string>()
            //}
            //    });

                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
            });

        }
    }
}
