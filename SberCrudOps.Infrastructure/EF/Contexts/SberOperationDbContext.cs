using Microsoft.EntityFrameworkCore;
using SberCrudOps.Domain.Aggregates.SberOperationAggregate;
using SberCrudOps.Infrastructure.EF.Interceptors;

namespace SberCrudOps.Infrastructure.EF.Contexts;

public class SberOperationDbContext : DbContext, ISberOperationDbContext
{
    public SberOperationDbContext(DbContextOptions<SberOperationDbContext> options)
        : base(options)
    {
        
    }
    
    public DbSet<SberOperation?> SberOperations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SberOperationDbContext).Assembly);
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new AuditableEntitiesInterceptor());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        var result = await base.SaveChangesAsync(cancellationToken);
        return result;
    }
}