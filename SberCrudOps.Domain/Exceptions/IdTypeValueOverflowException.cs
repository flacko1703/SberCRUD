using SberCrudOps.Shared.Abstractions.Exceptions;

namespace SberCrudOps.Domain.Exceptions;

public class IdTypeValueOverflowException : SberCrudOpsException
{
    public IdTypeValueOverflowException(int value) 
        : base($"Value {value} is too large for type {value.GetType()}")
    {
    }
}