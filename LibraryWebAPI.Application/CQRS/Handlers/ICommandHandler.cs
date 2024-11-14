using LibraryWebAPI.Application.CQRS.Commands;

namespace LibraryWebAPI.Application.CQRS.Handlers
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task Handle(TCommand command);
    }
}
