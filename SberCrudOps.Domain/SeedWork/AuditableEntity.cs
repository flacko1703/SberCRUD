using SberCrudOps.Domain.Aggregates.SberOperationAggregate.ValueObjects;

namespace SberCrudOps.Domain.SeedWork;

public abstract record AuditableEntity : Entity
{
    public AddedDateTimeNowUtc AddedAtUtc { get; init; }
    public DeletedDateTimeNowUtc? DeletedAtUtc { get; init; }
    public CompletedDateTimeNowUtc? CompletedAtUtc { get; protected set; }
    public Information? InformationText { get; protected set; }
    
    public uint Version { get; init; }
}