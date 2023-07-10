using FluentResults;
using SberCrudOps.Application.DTO.Request;
using SberCrudOps.Application.DTO.Response;
using SberCrudOps.Shared.Abstractions.Commands;

namespace SberCrudOps.Application.SberOperationUseCases.Commands.AddSberUpdateOperation;

public record AddSberUpdateOperationCommand(SberUpdateOperationRequestDto SberUpdateOperationRequest) 
    : ICommand<Result<SberOperationResponseDto>>;