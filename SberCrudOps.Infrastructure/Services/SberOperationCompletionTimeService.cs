using System.Diagnostics;
using SberCrudOps.Application.Services;
using SberCrudOps.Domain.Repositories;
using SberCrudOps.Infrastructure.EF.Contexts;

namespace SberCrudOps.Infrastructure.Services;

public class SberOperationCompletionTimeService : ICompletionTimeService
{
    private readonly SberOperationDbContext _dbContext;
    private readonly ISberOperationRepository _sberOperationRepository;

    public SberOperationCompletionTimeService(SberOperationDbContext dbContext, 
        ISberOperationRepository sberOperationRepository)
    {
        _dbContext = dbContext;
        _sberOperationRepository = sberOperationRepository;
    }

    public async Task SaveCompletionTime(int id)
    {
        var entity = _dbContext.SberOperations.FirstOrDefault(e => e.Id == id);
        if (entity != null)
        {
            entity.SetCompleted();
            await _sberOperationRepository.UpdateAsync(entity);
        }
    }
}