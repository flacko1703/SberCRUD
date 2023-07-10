using SberCrudOps.Application.DTO.Response;
using SberCrudOps.Domain.Aggregates.SberOperationAggregate;
using SberCrudOps.Domain.Aggregates.SberOperationAggregate.Entities;
using SberCrudOps.Domain.Enumerations;

namespace SberCrudOps.Application.Common.Mappings;

public static class SberOperationResponseDtoMapping
{
    public static SberOperationResponseDto ToSberOperationResponseDto(this SberOperation info)
    {
        return new SberOperationResponseDto
        { 
            Id = info.Id,
            IdSource = info.GetOperationInfo().Id,
            InformationText = info.InformationText!,
            TypeWorkCode = info.GetTypeWork().Value,
            Added = info.AddedAtUtc.Value.ToString(),
            Deleted = info.DeletedAtUtc?.Value.ToString(),  
            Completed = info.CompletedAtUtc?.Value.ToString()
        };
    }
    

    public static SberOperation? ToModel(this SberOperationResponseDto dto)
    {
        var info = SberOperationInfo.Create(dto.InformationText);
        var typeWork = TypeWork.FromValue(dto.TypeWorkCode);
        var sberOperation = SberOperation.Create(info, typeWork);
        return sberOperation;
    }
}