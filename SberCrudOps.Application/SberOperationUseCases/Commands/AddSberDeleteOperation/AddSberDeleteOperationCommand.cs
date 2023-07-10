using FluentResults;
using SberCrudOps.Application.DTO.Request;
using SberCrudOps.Application.DTO.Response;
using SberCrudOps.Shared.Abstractions.Commands;

namespace SberCrudOps.Application.SberOperationUseCases.Commands.AddSberDeleteOperation;

public record AddSberDeleteOperationCommand(SberDeleteOperationRequestDto SberDeleteOperationRequest) 
    : ICommand<Result<SberOperationResponseDto>>;