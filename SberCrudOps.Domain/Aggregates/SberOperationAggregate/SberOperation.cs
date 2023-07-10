using SberCrudOps.Domain.Aggregates.SberOperationAggregate.Entities;
using SberCrudOps.Domain.Aggregates.SberOperationAggregate.ValueObjects;
using SberCrudOps.Domain.Enumerations;
using SberCrudOps.Domain.SeedWork;

namespace SberCrudOps.Domain.Aggregates.SberOperationAggregate;

/// <summary>
/// Aggregate root for SberRequest
/// </summary>
public sealed record SberOperation : AggregateRoot<SberOperationId>
{
    private SberOperationInfo _sberOperationInfo;
    private TypeWork _typeWork;
    private SberOperation(SberOperationInfo sberOperationInfo, TypeWork typeWork)
    {
        _sberOperationInfo = sberOperationInfo;
        _typeWork = typeWork;
        InformationText = sberOperationInfo.InformationText;
    }

    private SberOperation()
    {
        //For EF
    }

    /// <summary>
    /// Factory method for SberRequest
    /// </summary>
    /// <param name="sberOperationInfo"></param>
    /// <param name="typeWork"></param>
    /// <returns></returns>
    public static SberOperation? Create(SberOperationInfo sberOperationInfo, TypeWork typeWork)
    {
        return new SberOperation(sberOperationInfo, typeWork);
    }

    
    /// <summary>
    /// Get operation info 
    /// </summary>
    /// <returns>Operation info</returns>
    public SberOperationInfo GetOperationInfo() => _sberOperationInfo;
    
    
    /// <summary>
    /// Sets info for SberOperation
    /// </summary>
    /// <param name="sberOperationInfo"></param>
    /// <returns></returns>
    public SberOperation SetSberOperationInfo(SberOperationInfo sberOperationInfo)
    {
        _sberOperationInfo = sberOperationInfo;
        return this;
    }
    
    /// <summary>
    /// Get TypeWork
    /// </summary>
    /// <returns>TypeWork</returns>
    public TypeWork GetTypeWork() => _typeWork;

    /// <summary>
    /// Sets completion time
    /// </summary>
    public void SetCompleted()
    {
        CompletedAtUtc = DateTime.UtcNow;
    }
    
}