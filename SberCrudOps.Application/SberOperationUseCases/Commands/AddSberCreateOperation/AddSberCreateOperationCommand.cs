using FluentResults;
using SberCrudOps.Application.DTO.Request;
using SberCrudOps.Application.DTO.Response;
using SberCrudOps.Shared.Abstractions.Commands;

namespace SberCrudOps.Application.SberOperationUseCases.Commands.AddSberCreateOperation;

public record AddSberCreateOperationCommand(SberCreateOperationRequestDto SberCreateOperationRequest) 
    : ICommand<Result<SberOperationResponseDto>>;