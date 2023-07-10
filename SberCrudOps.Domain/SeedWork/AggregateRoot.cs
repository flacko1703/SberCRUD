namespace SberCrudOps.Domain.SeedWork;

/// <summary>
/// Base record for Entities which are aggregates
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract record AggregateRoot<T> : AuditableEntity, IDomainEvent
{
    private readonly List<IDomainEvent> _domainEvents = new();

    public IEnumerable<IDomainEvent> DomainEvents => _domainEvents;

    public void AddEvent(IDomainEvent @event)
    {
        if (!_domainEvents.Any())
        {
            _domainEvents.Add(@event);
        }
    }

    public IEnumerable<IDomainEvent> GetDomainEvents()
    {
        return _domainEvents;
    }

    public void ClearEvents()
    {
        _domainEvents.Clear();
    }
}