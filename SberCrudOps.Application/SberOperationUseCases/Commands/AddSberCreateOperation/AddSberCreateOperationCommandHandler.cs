using FluentResults;
using FluentValidation;
using SberCrudOps.Application.Common.Mappings;
using SberCrudOps.Domain.Aggregates.SberOperationAggregate;
using SberCrudOps.Domain.Aggregates.SberOperationAggregate.Entities;
using SberCrudOps.Domain.Enumerations;
using SberCrudOps.Domain.Repositories;
using SberCrudOps.Shared.Abstractions.Commands;
using SberOperationResponseDto = SberCrudOps.Application.DTO.Response.SberOperationResponseDto;

namespace SberCrudOps.Application.SberOperationUseCases.Commands.AddSberCreateOperation;

public class AddSberCreateOperationCommandHandler 
    : ICommandHandler<AddSberCreateOperationCommand, Result<SberOperationResponseDto>>
{
    private readonly ISberOperationRepository _sberOperationRepository;
    private readonly IValidator<AddSberCreateOperationCommand> _validator;

    public AddSberCreateOperationCommandHandler(ISberOperationRepository sberOperationRepository, 
        IValidator<AddSberCreateOperationCommand> validator)
    {
        _sberOperationRepository = sberOperationRepository;
        _validator = validator;
    }

    public async Task<Result<SberOperationResponseDto>> HandleAsync(AddSberCreateOperationCommand command)
    {
        var validationResult = await _validator.ValidateAsync(command);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        
        var operation = command.SberCreateOperationRequest;
        
        var typeWork = TypeWork.FromValue(operation.TypeWorkCode);
        var sberOperationInfo = SberOperationInfo.Create(operation.InformationText);
        var sberOperation = SberOperation.Create(sberOperationInfo, typeWork);
        var result = await _sberOperationRepository.AddAsync(sberOperation);
        
        return Result.Ok(result.ToSberOperationResponseDto());
    }
}