using FluentResults;
using SberCrudOps.Application.DTO.Response;
using SberCrudOps.Domain.Aggregates.SberOperationAggregate;
using SberCrudOps.Domain.Aggregates.SberOperationAggregate.ValueObjects;
using SberCrudOps.Shared.Abstractions.Commands;

namespace SberCrudOps.Application.SberOperationUseCases.Commands.DeleteSberOperation;

public record DeleteSberOperationCommand(SberOperationId Id) : ICommand<Result<SberOperationResponseDto>>;