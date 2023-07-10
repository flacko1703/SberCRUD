using System.Text.Json.Serialization;

namespace SberCrudOps.Application.DTO.Request;

public record SberDeleteOperationRequestDto
{
    public int IdSource { get; set; }
    public int TypeWorkCode { get; init; } = 3;
    
    [JsonIgnore]
    public string? InformationText { get; set; }
    
    [JsonIgnore]
    public uint Version { get; init; }
}