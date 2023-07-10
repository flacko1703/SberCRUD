namespace SberCrudOps.Domain.Aggregates.SberOperationAggregate.ValueObjects;

public record AddedDateTimeNowUtc(DateTime Value)
{
    public DateTime Value { get; private set; } = Value;
    
    public static implicit operator AddedDateTimeNowUtc(DateTime value) => new(value);
    public static implicit operator DateTime(AddedDateTimeNowUtc value) => value.Value;

    public override string ToString()
    {
        return Value.ToString("yyyy-MM-dd HH:mm:ss");
    }
}