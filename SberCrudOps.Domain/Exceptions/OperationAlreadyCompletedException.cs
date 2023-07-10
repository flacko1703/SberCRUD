using SberCrudOps.Shared.Abstractions.Exceptions;

namespace SberCrudOps.Domain.Exceptions;

public class OperationAlreadyCompletedException : SberCrudOpsException
{
    public OperationAlreadyCompletedException() 
        : base("Operation already completed")
    {
    }
}