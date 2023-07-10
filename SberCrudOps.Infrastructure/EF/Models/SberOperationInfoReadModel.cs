namespace SberCrudOps.Infrastructure.EF.Models;

public class SberOperationInfoReadModel
{
    public int Id { get; set; }
    public string? Information { get; set; }
    public DateTime AddedAtUtc { get; set; }
    public DateTime? DeletedAtUtc { get; set; }
}