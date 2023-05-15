using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Prova.Domain.Interfaces;

using Prova.Data.Context;
using Prova.Data.Repositorys;

namespace Prova.API.Middleware
{
    public static class PersistenceDependency
    {
        private static string _database = "";
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<PostgreContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("DataBase")
                    , o => o.MigrationsAssembly("Data")));

            services.AddScoped<PostgreContext>();

            //Repositorys
            services.AddScoped<IServer, ServerRepository>();
            services.AddScoped<IVideo, VideoRepository>();

            //Patterns
            services.AddScoped<IUnityofWork, UnityofWork>();
        }
    }
}
