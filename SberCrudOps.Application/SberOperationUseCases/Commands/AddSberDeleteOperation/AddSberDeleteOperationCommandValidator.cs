using FluentValidation;
using SberCrudOps.Domain.Enumerations;

namespace SberCrudOps.Application.SberOperationUseCases.Commands.AddSberDeleteOperation;

public class AddSberDeleteOperationCommandValidator : AbstractValidator<AddSberDeleteOperationCommand>
{
    public AddSberDeleteOperationCommandValidator()
    {
        RuleFor(x => x.SberDeleteOperationRequest.TypeWorkCode).Equal(TypeWork.Delete.Value)
            .WithMessage($"Invalid TypeWork Code for SberCreateOperationCommand. Value must be {TypeWork.Delete.Value}");
        
        //TypeWork value must be in the operation enumeration from domain
        RuleFor(x => x.SberDeleteOperationRequest.TypeWorkCode)
            .Must(IsTypeWorkValueIsValid)
            .WithMessage("TypeWork enumeration value is invalid");
        
    }


    /// <summary>
    /// Check if typeWork value is exists in TypeWork enumeration
    /// </summary>
    /// <param name="typeWork"></param>
    /// <returns></returns>
    private bool IsTypeWorkValueIsValid(int typeWork)
    {
        var typeWorks = TypeWork.GetAll();
        return typeWorks.Select(x => x.Value).Contains(typeWork);
    }
}