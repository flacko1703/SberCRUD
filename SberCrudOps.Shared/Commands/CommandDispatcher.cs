using Microsoft.Extensions.DependencyInjection;
using SberCrudOps.Shared.Abstractions.Commands;

namespace SberCrudOps.Shared.Commands;

public class CommandDispatcher : ICommandDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public CommandDispatcher(IServiceProvider serviceProvider)
        => _serviceProvider = serviceProvider;

    public async Task<TResult> DispatchAsync<TCommand, TResult>(TCommand command) where TCommand : class, ICommand<TResult>
    {
        using var scope = _serviceProvider.CreateScope();
        var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand, TResult>>();

        var result = await handler.HandleAsync(command);

        return result;
    }
}