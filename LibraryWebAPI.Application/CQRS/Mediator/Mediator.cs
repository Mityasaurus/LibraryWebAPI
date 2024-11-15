//using LibraryWebAPI.Application.CQRS.Commands;
//using LibraryWebAPI.Application.CQRS.Handlers;
//using LibraryWebAPI.Application.CQRS.Queries;
//using Microsoft.Extensions.DependencyInjection;

//namespace LibraryWebAPI.Application.CQRS.Mediator
//{
//    public class Mediator : IMediator
//    {
//        private readonly IServiceProvider _serviceProvider;

//        public Mediator(IServiceProvider serviceProvider)
//        {
//            _serviceProvider = serviceProvider;
//        }

//        public async Task<TResult> Send<TResult>(IQuery<TResult> query)
//        {
//            var handler = _serviceProvider.GetRequiredService<IQueryHandler<IQuery<TResult>, TResult>>();
//            return await handler.Handle(query);
//        }

//        public async Task Send(ICommand command)
//        {
//            var handler = _serviceProvider.GetRequiredService<ICommandHandler<ICommand>>();
//            await handler.Handle(command);
//        }
//    }
//}

using LibraryWebAPI.Application.CQRS.Commands;
using LibraryWebAPI.Application.CQRS.Handlers;
using LibraryWebAPI.Application.CQRS.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryWebAPI.Application.CQRS.Mediator
{
    public class Mediator : IMediator
    {
        private readonly IServiceProvider _serviceProvider;

        public Mediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResult> Send<TResult>(IQuery<TResult> query)
        {
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
            dynamic handler = _serviceProvider.GetRequiredService(handlerType);
            return await handler.Handle((dynamic)query);
        }

        public async Task Send(ICommand command)
        {
            var handlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());
            dynamic handler = _serviceProvider.GetRequiredService(handlerType);
            await handler.Handle((dynamic)command);
        }
    }
}
