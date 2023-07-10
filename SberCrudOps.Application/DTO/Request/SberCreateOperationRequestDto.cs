namespace SberCrudOps.Application.DTO.Request;

public record SberCreateOperationRequestDto
{
    public string? InformationText { get; set; }
    public int TypeWorkCode { get; init; } = 1;
}