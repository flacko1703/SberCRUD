namespace SberCrudOps.Domain.SeedWork;


public interface IStronglyTypedId<TId>
{
    TId Value { get; init; }
}