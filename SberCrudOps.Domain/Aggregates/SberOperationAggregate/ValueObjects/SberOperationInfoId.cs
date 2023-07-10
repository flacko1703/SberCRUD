using SberCrudOps.Domain.SeedWork;

namespace SberCrudOps.Domain.Aggregates.SberOperationAggregate.ValueObjects;

public record struct SberOperationInfoId(int Value) : IStronglyTypedId<int>
{
    public int Value { get; init; } = Value;

    public static implicit operator int(SberOperationInfoId id) => id.Value;
    
    public static implicit operator SberOperationInfoId(int id) => new(id);
}