using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SberCrudOps.Application.DTO.Request;

namespace SberCrudOps.Infrastructure.EF.Interceptors;

public class VersionCheckInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        var context = eventData.Context;
        var addedEntries = context?.ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added);

        foreach (var entry in addedEntries)
        {
            if (entry.Entity is SberUpdateOperationRequestDto updateOperationRequestDto)
            {
                var databaseValues = entry.GetDatabaseValues();
                var databaseVersion = (uint)databaseValues[nameof(SberUpdateOperationRequestDto.Version)];
                
                if (updateOperationRequestDto.Version != databaseVersion)
                {
                    throw new DBConcurrencyException("Conflict");
                }
            }
            if (entry.Entity is SberDeleteOperationRequestDto deleteOperationRequestDto)
            {
                var databaseValues = entry.GetDatabaseValues();
                var databaseVersion = (uint)databaseValues[nameof(SberUpdateOperationRequestDto.Version)];
                
                if (deleteOperationRequestDto.Version != databaseVersion)
                {
                    throw new DBConcurrencyException("Conflict");
                }
            }
        }

        return new ValueTask<InterceptionResult<int>>(result);
    }
}