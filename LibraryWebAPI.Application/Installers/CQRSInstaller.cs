using Microsoft.Extensions.DependencyInjection;
using LibraryWebAPI.Application.CQRS.Mediator;
using LibraryWebAPI.Application.CQRS.Commands.Author;
using LibraryWebAPI.Application.CQRS.Handlers.Author;
using LibraryWebAPI.Application.CQRS.Handlers;
using LibraryWebAPI.Application.CQRS.Queries.Author;
using LibraryWebAPI.Application.Dtos;

namespace LibraryWebAPI.Application.Installers
{
    public static class CQRSInstaller
    {
        public static IServiceCollection AddCQRS(this IServiceCollection services)
        {
            services.AddScoped<IMediator, Mediator>();
            services.AddScoped<ICommandHandler<AddAuthorCommand>, AddAuthorCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateAuthorCommand>, UpdateAuthorCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteAuthorCommand>, DeleteAuthorCommandHandler>();

            services.AddScoped<IQueryHandler<GetAllAuthorsQuery, IReadOnlyList<AuthorDto>>, GetAllAuthorsQueryHandler>();
            services.AddScoped<IQueryHandler<GetAuthorByIdQuery, AuthorDto>, GetAuthorByIdQueryHandler>();

            return services;
        }
    }
}
