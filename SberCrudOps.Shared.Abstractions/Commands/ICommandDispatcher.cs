namespace SberCrudOps.Shared.Abstractions.Commands
{
    public interface ICommandDispatcher
    {
        Task<TResult> DispatchAsync<TCommand, TResult>(TCommand command) where TCommand : class, ICommand<TResult>;
    }
}