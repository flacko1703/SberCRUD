using SberCrudOps.Domain.Aggregates.SberOperationAggregate;
using SberCrudOps.Domain.Aggregates.SberOperationAggregate.Entities;
using SberCrudOps.Domain.Aggregates.SberOperationAggregate.ValueObjects;

namespace SberCrudOps.Domain.Repositories;

public interface ISberOperationRepository
{
    Task<SberOperation?> GetAsync(SberOperationId id);

    Task<SberOperation?> GetByIdSource(SberOperationInfoId id);
    Task<IEnumerable<SberOperation>?> GetAllAsync();
    Task<SberOperation?> AddAsync(SberOperation? sberOperation);
    Task DeleteAsync(SberOperationId id);
    
    Task<SberOperation?> UpdateAsync(SberOperation? sberOperation);
    Task<SberOperationInfo?> GetInfoAsync(SberOperationId id);
}