using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SberCrudOps.Infrastructure.EF.Contexts;
using SberCrudOps.Infrastructure.EF.Options;

namespace SberCrudOps.Infrastructure.Extensions;

public static class PostgreSqlServiceExtension
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var options = configuration.GetOptions<PostgresOptions>("Postgres");
        
        services.AddDbContext<SberOperationDbContext>(ctx 
            => ctx.UseNpgsql(options.ConnectionString));

        services.AddScoped<ISberOperationDbContext>(s 
            => s.GetRequiredService<SberOperationDbContext>());
        
        
        return services;
    }
}