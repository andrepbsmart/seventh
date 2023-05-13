using System;

using MediatR;

using Prova.Application.Handlers.Servers;
using Prova.Application.Handlers.Videos;

namespace Prova.API.Middleware
{
    public static class ApplicationDependency
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServerCreateHandler));
            services.AddMediatR(typeof(ServerUpdateHandler));
            services.AddMediatR(typeof(ServerDeleteHandler));

            services.AddMediatR(typeof(VideoCreateHandler));
            services.AddMediatR(typeof(VideoDeleteHandler));
        }
    }
}
