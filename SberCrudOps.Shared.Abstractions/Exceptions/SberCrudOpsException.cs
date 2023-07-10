namespace SberCrudOps.Shared.Abstractions.Exceptions;

public abstract class SberCrudOpsException : Exception
{
    protected SberCrudOpsException(string message) : base(message)
    {
        
    }
}