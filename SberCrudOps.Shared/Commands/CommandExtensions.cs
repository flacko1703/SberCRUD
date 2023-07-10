using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SberCrudOps.Shared.Abstractions.Commands;

namespace SberCrudOps.Shared.Commands;

public static class CommandExtensions
{
    public static IServiceCollection AddCommands(this IServiceCollection services)
    {
        var assembly = Assembly.GetCallingAssembly();
    
        services.AddSingleton<ICommandDispatcher, CommandDispatcher>();
        services.Scan(s => s.FromAssemblies(assembly)
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        return services;
    }
}