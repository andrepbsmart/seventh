using System;
using System.Reflection;

using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

using Prova.Data.Context;

using Prova.API.Middleware;

namespace Prova.API
{
    public class Startup : IStartup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //var root = Directory.GetCurrentDirectory();
            //var dotenv = Path.Combine(root, ".env");
            //DotEnv.Load(dotenv);

            //CORS
            services.AddCors(options =>
            {
                options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });


            services.AddDbContext<PostgreContext>(opt =>
            {
                opt.UseNpgsql("name=ConnectionStrings:DataBase");
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            services.AddDbContext<PostgreContext>(opt => opt.UseNpgsql("name=ConnectionStrings:DataBase"));

            services.AddControllers().AddNewtonsoftJson();
            services.AddApplication();
            services.AddPersistence(Configuration);
            services.AddEndpointsApiExplorer();
            services.AddSwaggerMiddleware();
            services.AddRateLimiting(Configuration);
            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddSession();
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API-Prova v1"));
            app.UseHttpsRedirection();
            app.UseCors("Open");
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.UseRateLimiting();
            app.UseSession();
        }
    }

    public interface IStartup
    {
        IConfiguration Configuration { get; }
        void ConfigureServices(IServiceCollection services);
        void Configure(WebApplication app, IWebHostEnvironment environment);
    }

    public static class StartupExtensions
    {
        public static WebApplicationBuilder UseStartup<TStartup>(this WebApplicationBuilder webAppBuilder) where TStartup : IStartup
        {
            var startup = Activator.CreateInstance(typeof(TStartup), webAppBuilder.Configuration) as Startup;

            if (startup == null) throw new ArgumentException("Classe Startup.cs invalida");

            startup.ConfigureServices(webAppBuilder.Services);
            var app = webAppBuilder.Build();
            startup.Configure(app, app.Environment);

            app.Run();

            return webAppBuilder;
        }
    }
}