using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SberCrudOps.Application.Common.Mappings;
using SberCrudOps.Domain.Aggregates.SberOperationAggregate;
using SberCrudOps.Domain.Aggregates.SberOperationAggregate.Entities;
using SberCrudOps.Domain.Aggregates.SberOperationAggregate.ValueObjects;
using SberCrudOps.Domain.Repositories;
using SberCrudOps.Infrastructure.EF.Contexts;

namespace SberCrudOps.Infrastructure.EF.Repositories;

public class PostgresSberOperationRepository : ISberOperationRepository
{
    private readonly SberOperationDbContext _dbContext;

    public PostgresSberOperationRepository(SberOperationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<SberOperation?> GetAsync(SberOperationId id)
    {
        var operation = await _dbContext.SberOperations
            .Include("_sberOperationInfo")
            .AsNoTracking()
            .SingleOrDefaultAsync(_ => _.Id == id.Value);

        return operation;
    }

    public async Task<SberOperation?> GetByIdSource(SberOperationInfoId id)
    {
        var operations = await _dbContext.SberOperations
            .Include("_sberOperationInfo")
            .AsNoTracking()
            .ToListAsync();
        
        var operation = operations.SingleOrDefault(x => x.GetOperationInfo().Id == id.Value);

        return operation;
    }

    public async Task<IEnumerable<SberOperation>?> GetAllAsync()
    {
        var operations = await _dbContext.SberOperations.AsNoTracking().ToListAsync();

        return !operations.Any() ? Enumerable.Empty<SberOperation>() : operations;
    }

    public async Task<SberOperation?> AddAsync(SberOperation? sberOperation)
    { 
        var newOperation = await _dbContext.SberOperations.AddAsync(sberOperation);
        await _dbContext.SaveChangesAsync();
        
        return newOperation.Entity;
    }


    public async Task DeleteAsync(SberOperationId id)
    {
        var operationToDelete = await _dbContext.SberOperations.SingleOrDefaultAsync(_ => _.Id == id.Value);

        _dbContext.SberOperations.Remove(operationToDelete!);
    }

    public async Task<SberOperation?> UpdateAsync(SberOperation? sberOperation)
    {
        var updatedOperation = _dbContext.SberOperations.Update(sberOperation);
        await _dbContext.SaveChangesAsync();
        return updatedOperation.Entity;
    }

    public async Task<SberOperationInfo?> GetInfoAsync(SberOperationId id)
    {




        return null;
    }

}