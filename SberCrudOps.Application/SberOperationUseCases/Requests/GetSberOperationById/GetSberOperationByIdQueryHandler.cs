using FluentResults;
using SberCrudOps.Application.Common.Mappings;
using SberCrudOps.Application.DTO.Response;
using SberCrudOps.Domain.Repositories;
using SberCrudOps.Shared.Abstractions.Queries;

namespace SberCrudOps.Application.SberOperationUseCases.Requests.GetSberOperationById;

public class GetSberOperationByIdQueryHandler : IQueryHandler<GetSberOperationByIdQuery, SberOperationResponseDto>
{
    private readonly ISberOperationRepository _sberOperationRepository;

    public GetSberOperationByIdQueryHandler(ISberOperationRepository sberOperationRepository)
    {
        _sberOperationRepository = sberOperationRepository;
    }

    public async Task<SberOperationResponseDto?> HandleAsync(GetSberOperationByIdQuery query)
    {
        var operation = await _sberOperationRepository.GetAsync(query.Id) ?? 
                        await _sberOperationRepository.GetByIdSource(query.Id);

        var response = operation?.ToSberOperationResponseDto();
        
        return response;
    }
}