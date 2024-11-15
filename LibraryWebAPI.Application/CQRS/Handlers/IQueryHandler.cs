using LibraryWebAPI.Application.CQRS.Queries;

namespace LibraryWebAPI.Application.CQRS.Handlers
{
    public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> Handle(TQuery query);
    }
}
