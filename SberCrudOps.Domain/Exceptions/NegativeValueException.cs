using SberCrudOps.Domain.Aggregates.SberOperationAggregate.ValueObjects;
using SberCrudOps.Shared.Abstractions.Exceptions;

namespace SberCrudOps.Domain.Exceptions;

public class NegativeValueException : SberCrudOpsException
{
    public NegativeValueException(int id) 
        : base($"Value of {nameof(SberOperationId)} must be greater than 0. Value: {id}")
    {
    }
}