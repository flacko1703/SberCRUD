namespace SberCrudOps.Domain.SeedWork;

public interface IAuditableEntity
{
    DateTime AddedAtUtc { get; init; }
    DateTime? DeletedAtUtc { get; init; }
    string? Information { get; init; }
}