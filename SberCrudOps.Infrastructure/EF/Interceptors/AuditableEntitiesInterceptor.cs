using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SberCrudOps.Domain.Aggregates.SberOperationAggregate.ValueObjects;
using SberCrudOps.Domain.SeedWork;

namespace SberCrudOps.Infrastructure.EF.Interceptors;

public class AuditableEntitiesInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        if (eventData.Context is null)
        {
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        var entries = eventData.Context.ChangeTracker.Entries<AuditableEntity>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property(x => x.AddedAtUtc).CurrentValue = new AddedDateTimeNowUtc(DateTime.UtcNow);
            }

            if (entry.State == EntityState.Deleted)
            {
                entry.Property(x => x.DeletedAtUtc).CurrentValue = new DeletedDateTimeNowUtc(DateTime.UtcNow);
            }
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}