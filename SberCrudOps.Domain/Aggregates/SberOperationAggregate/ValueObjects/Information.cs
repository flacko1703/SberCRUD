namespace SberCrudOps.Domain.Aggregates.SberOperationAggregate.ValueObjects;

public record Information(string? Value)
{
    public static implicit operator string?(Information info) => info.Value;
    
    public static implicit operator Information(string? value) => new(value);
}