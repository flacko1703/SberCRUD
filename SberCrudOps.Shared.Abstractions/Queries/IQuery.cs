namespace SberCrudOps.Shared.Abstractions.Queries
{
    /// <summary>
    /// Interface for queries.
    /// </summary>
    public interface IQuery
    {
    }
    
    /// <summary>
    /// Interface for queries.
    /// </summary>
    /// <typeparam name="TResult">Result type.</typeparam>
    public interface IQuery<TResult> : IQuery
    {
    }
}