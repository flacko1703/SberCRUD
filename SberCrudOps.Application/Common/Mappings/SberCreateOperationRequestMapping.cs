using SberCrudOps.Application.DTO.Request;
using SberCrudOps.Domain.Aggregates.SberOperationAggregate;
using SberCrudOps.Domain.Aggregates.SberOperationAggregate.Entities;
using SberCrudOps.Domain.Enumerations;

namespace SberCrudOps.Application.Common.Mappings;

public static class SberCreateOperationRequestMapping
{
    public static SberCreateOperationRequestDto ToSberOperationCreateRequestDto(this SberOperation info)
    {
        return new SberCreateOperationRequestDto
        {
            InformationText = info.InformationText!,
            TypeWorkCode = info.GetTypeWork().Value
        };
    }

    public static SberOperation? ToModel(this SberCreateOperationRequestDto dto)
    {
        return SberOperation.Create(SberOperationInfo.Create(dto.InformationText!),
            TypeWork.FromValue(dto.TypeWorkCode));
    }
}