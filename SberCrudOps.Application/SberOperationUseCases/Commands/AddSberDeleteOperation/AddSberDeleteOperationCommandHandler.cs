using FluentResults;
using FluentValidation;
using SberCrudOps.Application.Common.Mappings;
using SberCrudOps.Application.DTO.Response;
using SberCrudOps.Domain.Aggregates.SberOperationAggregate;
using SberCrudOps.Domain.Aggregates.SberOperationAggregate.Entities;
using SberCrudOps.Domain.Enumerations;
using SberCrudOps.Domain.Repositories;
using SberCrudOps.Shared.Abstractions.Commands;

namespace SberCrudOps.Application.SberOperationUseCases.Commands.AddSberDeleteOperation;

public class AddSberUpdateOperationCommandHandler 
    : ICommandHandler<AddSberDeleteOperationCommand, Result<SberOperationResponseDto>>
{
    public readonly ISberOperationRepository _sberOperationRepository;
    private readonly IValidator<AddSberDeleteOperationCommand> _validator;

    public AddSberUpdateOperationCommandHandler(ISberOperationRepository sberOperationRepository, 
        IValidator<AddSberDeleteOperationCommand> validator)
    {
        _sberOperationRepository = sberOperationRepository;
        _validator = validator;
    }

    public async Task<Result<SberOperationResponseDto>> HandleAsync(AddSberDeleteOperationCommand command)
    {
        var validationResult = await _validator.ValidateAsync(command);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        
        var operation = command.SberDeleteOperationRequest;

        var existingOperation = await _sberOperationRepository
            .GetByIdSource(command.SberDeleteOperationRequest.IdSource);

        if (operation.Version == existingOperation?.Version)
        {
            return Result.Fail(new Error("Conflict"));
        }

        var typeWork = TypeWork.FromValue(command.SberDeleteOperationRequest.TypeWorkCode);
        var sberOperationInfo = SberOperationInfo.Create(command.SberDeleteOperationRequest.InformationText);
        var sberOperation = SberOperation.Create(sberOperationInfo, typeWork);
        var result = await _sberOperationRepository.AddAsync(sberOperation);
        
        return Result.Ok(result.ToSberOperationResponseDto());
    }
}