using FluentResults;
using SberCrudOps.Application.Common.Mappings;
using SberCrudOps.Application.DTO.Response;
using SberCrudOps.Domain.Repositories;
using SberCrudOps.Shared.Abstractions.Commands;

namespace SberCrudOps.Application.SberOperationUseCases.Commands.DeleteSberOperation;

public class DeleteSberOperationCommandHandler : ICommandHandler<DeleteSberOperationCommand, Result<SberOperationResponseDto>>
{
    private readonly ISberOperationRepository _sberOperationRepository;

    public DeleteSberOperationCommandHandler(ISberOperationRepository sberOperationRepository)
    {
        _sberOperationRepository = sberOperationRepository;
    }

    public async Task<Result<SberOperationResponseDto>> HandleAsync(DeleteSberOperationCommand command)
    {
        var operation = await _sberOperationRepository.GetAsync(command.Id);
        if (operation == null)
        {
            return Result.Fail(new[] { "Conflict" });
        }

        await _sberOperationRepository.DeleteAsync(command.Id);

        return operation.ToSberOperationResponseDto();
    }
}