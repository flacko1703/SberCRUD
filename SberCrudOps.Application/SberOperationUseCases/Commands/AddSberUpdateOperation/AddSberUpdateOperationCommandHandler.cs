using FluentResults;
using FluentValidation;
using SberCrudOps.Application.Common.Mappings;
using SberCrudOps.Application.DTO.Response;
using SberCrudOps.Domain.Aggregates.SberOperationAggregate;
using SberCrudOps.Domain.Aggregates.SberOperationAggregate.Entities;
using SberCrudOps.Domain.Enumerations;
using SberCrudOps.Domain.Repositories;
using SberCrudOps.Shared.Abstractions.Commands;

namespace SberCrudOps.Application.SberOperationUseCases.Commands.AddSberUpdateOperation;

public class AddSberUpdateOperationCommandHandler 
    : ICommandHandler<AddSberUpdateOperationCommand, Result<SberOperationResponseDto>>
{
    public readonly ISberOperationRepository _sberOperationRepository;
    private readonly IValidator<AddSberUpdateOperationCommand> _validator;

    public AddSberUpdateOperationCommandHandler(ISberOperationRepository sberOperationRepository, 
        IValidator<AddSberUpdateOperationCommand> validator)
    {
        _sberOperationRepository = sberOperationRepository;
        _validator = validator;
    }

    public async Task<Result<SberOperationResponseDto>> HandleAsync(AddSberUpdateOperationCommand command)
    {
        var validationResult = await _validator.ValidateAsync(command);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        
        var operationToUpdate = await _sberOperationRepository
            .GetByIdSource(command.SberUpdateOperationRequest.IdSource);
        
        if (operationToUpdate?.Version == command.SberUpdateOperationRequest.Version)
        {
            return Result.Fail(new[] { "Conflict" });
        }
        
        var typeWork = TypeWork.FromValue(command.SberUpdateOperationRequest.TypeWorkCode);
        var sberOperationInfo = SberOperationInfo.Create(command.SberUpdateOperationRequest.InformationText);
        
        var sberOperation = SberOperation.Create(sberOperationInfo, typeWork);
        var result = await _sberOperationRepository.AddAsync(sberOperation);
        
        return Result.Ok(result.ToSberOperationResponseDto());
    }
}