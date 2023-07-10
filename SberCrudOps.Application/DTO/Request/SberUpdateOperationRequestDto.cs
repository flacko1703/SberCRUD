using System.Text.Json.Serialization;

namespace SberCrudOps.Application.DTO.Request;

public record SberUpdateOperationRequestDto
{
    public int IdSource { get; set; }
    public string? InformationText { get; set; }
    public int TypeWorkCode { get; init; } = 2;
    
    [JsonIgnore]
    public uint Version { get; init; }
}