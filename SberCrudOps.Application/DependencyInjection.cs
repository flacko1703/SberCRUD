using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SberCrudOps.Application.SberOperationUseCases.Commands.AddSberCreateOperation;
using SberCrudOps.Shared.Commands;
using SberCrudOps.Shared.Queries;

namespace SberCrudOps.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddCommands();
        services.AddQueries();
        services.AddValidatorsFromAssemblyContaining(typeof(AddSberCreateOperationCommandValidator));
        return services;
    }
}