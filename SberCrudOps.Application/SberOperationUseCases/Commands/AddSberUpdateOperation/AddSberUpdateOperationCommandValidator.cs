using FluentValidation;
using SberCrudOps.Domain.Enumerations;

namespace SberCrudOps.Application.SberOperationUseCases.Commands.AddSberUpdateOperation;

public class AddSberUpdateOperationCommandValidator : AbstractValidator<AddSberUpdateOperationCommand>
{
    public AddSberUpdateOperationCommandValidator()
    {
        RuleFor(x => x.SberUpdateOperationRequest.TypeWorkCode).Equal(TypeWork.Update.Value)
            .WithMessage($"Invalid TypeWork Code for SberUpdateOperationCommand. Value must be {TypeWork.Update.Value}");
        
        //TypeWork value must be in the operation enumeration from domain
        RuleFor(x => x.SberUpdateOperationRequest.TypeWorkCode)
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