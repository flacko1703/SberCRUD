using SberCrudOps.Domain.SeedWork;

namespace SberCrudOps.Domain.Aggregates.SberOperationAggregate.ValueObjects;

public record struct SberOperationId(int Value) : IStronglyTypedId<int>
{
    public int Value { get; init; } = Value;

    public static implicit operator int(SberOperationId id) => id.Value;
    
    public static implicit operator SberOperationId(int id) => new(id);

}