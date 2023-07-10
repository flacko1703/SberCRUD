namespace SberCrudOps.Domain.Aggregates.SberOperationAggregate.ValueObjects;

public record CompletedDateTimeNowUtc(DateTime? Value)
{
    public DateTime? Value { get; private set; } = Value;
    
    public static implicit operator CompletedDateTimeNowUtc(DateTime? value) => new(value);
    public static implicit operator DateTime?(CompletedDateTimeNowUtc value) => value.Value;
    
    public override string? ToString()
    {
        return Value?.ToString("yyyy-MM-dd HH:mm:ss");
    }
}