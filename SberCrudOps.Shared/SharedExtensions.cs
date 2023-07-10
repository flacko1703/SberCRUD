using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SberCrudOps.Shared.Services;

namespace SberCrudOps.Shared
{
    public static class SharedExtensions
    {
        public static IServiceCollection AddShared(this IServiceCollection services)
        {
            services.AddHostedService<AppInitializer>();
            return services;
        }

        public static IApplicationBuilder UseShared(this IApplicationBuilder app)
        {
            return app;
        }
    }
}