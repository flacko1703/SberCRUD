using SberCrudOps.Application.DTO.Response;
using SberCrudOps.Shared.Abstractions.Queries;

namespace SberCrudOps.Application.SberOperationUseCases.Requests.GetSberOperationById;

public record GetSberOperationByIdQuery(int Id) 
    : IQuery<SberOperationResponseDto>;