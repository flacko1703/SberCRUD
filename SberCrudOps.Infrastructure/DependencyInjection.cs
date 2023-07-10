using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SberCrudOps.Application.Services;
using SberCrudOps.Domain.Repositories;
using SberCrudOps.Infrastructure.EF.Interceptors;
using SberCrudOps.Infrastructure.EF.Repositories;
using SberCrudOps.Infrastructure.Extensions;
using SberCrudOps.Infrastructure.Services;

namespace SberCrudOps.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ISberOperationRepository, PostgresSberOperationRepository>();
        services.AddSingleton<AuditableEntitiesInterceptor>();
        services.AddSingleton<VersionCheckInterceptor>();
        services.AddScoped<ICompletionTimeService, SberOperationCompletionTimeService>();
        services.AddPersistence(configuration);
        return services;
    }
}