using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using SberCrudOps.Shared.Abstractions.Queries;

namespace SberCrudOps.Shared.Queries
{
    public static class QueriesExtensions
    {
        public static IServiceCollection AddQueries(this IServiceCollection services)
        {
            var assembly = Assembly.GetCallingAssembly();
            
            services.AddSingleton<IQueryDispatcher, QueryDispatcher>();
            services.Scan(s => s.FromAssemblies(assembly)
                .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            
            return services;
        }
    }
}