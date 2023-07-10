using SberCrudOps.Domain.Aggregates.SberOperationAggregate.ValueObjects;

namespace SberCrudOps.Application.DTO.Response;

public record SberOperationResponseDto
{
    public int Id { get; set; }
    public int IdSource { get; set; }
    public string? InformationText { get; set; }
    public int TypeWorkCode { get; set; } 
    public string Added { get; set; }
    public string? Deleted { get; set; }
    public string? Completed { get; set; }
}