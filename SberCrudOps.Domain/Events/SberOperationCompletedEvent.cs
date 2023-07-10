using SberCrudOps.Domain.Aggregates.SberOperationAggregate.ValueObjects;
using SberCrudOps.Domain.SeedWork;

namespace SberCrudOps.Domain.Events;

/// <summary>
/// (Sample event without handler)
/// Event that is raised when SberOperation is completed
/// </summary>
/// <param name="Id"></param>
public record SberOperationCompletedEvent(SberOperationId Id) : IDomainEvent;