namespace SberCrudOps.Domain.SeedWork;

/// <summary>
/// Base record for Entities
/// </summary>
/// <typeparam name="TEntityId"></typeparam>
public abstract record Entity : IEntity
{
    public int Id { get; init; }
    

    protected Entity(int id)
    {
        Id = id;
    }

    protected Entity()
    {
        
    }
}