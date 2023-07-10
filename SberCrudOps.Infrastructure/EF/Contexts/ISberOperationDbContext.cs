using Microsoft.EntityFrameworkCore;
using SberCrudOps.Domain.Aggregates.SberOperationAggregate;

namespace SberCrudOps.Infrastructure.EF.Contexts;

public interface ISberOperationDbContext
{
    DbSet<SberOperation?> SberOperations { get; set; }
}