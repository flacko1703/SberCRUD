namespace SberCrudOps.Domain.Aggregates.SberOperationAggregate.ValueObjects;

public record DeletedDateTimeNowUtc(DateTime? Value)
{
    public DateTime? Value { get; private set; } = Value;
    
    public static implicit operator DeletedDateTimeNowUtc(DateTime? value) => new(value);
    public static implicit operator DateTime?(DeletedDateTimeNowUtc value) => value.Value;
    
    public override string? ToString()
    {
        return Value?.ToString("yyyy-MM-dd HH:mm:ss");
    }
}