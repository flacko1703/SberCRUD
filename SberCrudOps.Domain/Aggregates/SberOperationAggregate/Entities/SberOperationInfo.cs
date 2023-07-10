using SberCrudOps.Domain.SeedWork;

namespace SberCrudOps.Domain.Aggregates.SberOperationAggregate.Entities;

public sealed record SberOperationInfo : AuditableEntity
{
    private SberOperationInfo(string? informationText)
    {
        InformationText = informationText;
    }
    
    private SberOperationInfo()
    {
        //For EF
    }
    
    public static SberOperationInfo Create(string? information) => new(information);
   
}