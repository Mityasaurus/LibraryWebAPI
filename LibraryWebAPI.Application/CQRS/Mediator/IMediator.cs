using LibraryWebAPI.Application.CQRS.Commands;
using LibraryWebAPI.Application.CQRS.Queries;

namespace LibraryWebAPI.Application.CQRS.Mediator
{
    public interface IMediator
    {
        Task<TResult> Send<TResult>(IQuery<TResult> query);
        Task Send(ICommand command);
    }
}
