using FluentValidation;
using SberCrudOps.Domain.Enumerations;

namespace SberCrudOps.Application.SberOperationUseCases.Commands.AddSberCreateOperation;

public class AddSberCreateOperationCommandValidator : AbstractValidator<AddSberCreateOperationCommand>
{
    public AddSberCreateOperationCommandValidator()
    {
        RuleFor(x => x.SberCreateOperationRequest.TypeWorkCode).Equal(TypeWork.Create.Value)
            .WithMessage($"Invalid TypeWork Code for SberCreateOperationCommand. Value must be {TypeWork.Create.Value}");
        
        //TypeWork value must be in the operation enumeration from domain
        RuleFor(x => x.SberCreateOperationRequest.TypeWorkCode)
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