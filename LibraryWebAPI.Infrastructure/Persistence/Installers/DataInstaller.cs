using Microsoft.Extensions.DependencyInjection;
using LibraryWebAPI.Application.Persistence;
using LibraryWebAPI.Application.Persistence.Repositories.Author;
using LibraryWebAPI.Application.Persistence.Repositories.Book;
using LibraryWebAPI.Infrastructure.Persistence.Repositories.Author;
using LibraryWebAPI.Infrastructure.Persistence.Repositories.Book;

namespace LibraryWebAPI.Infrastructure.Persistence.Installers
{
    public static class DataInstaller
    {
        public static IServiceCollection AddDataContext(this IServiceCollection services)
        {
            services
            .AddSingleton<LibraryContext>()
            .AddTransient<IAuthorRepository, AuthorRepository>()
            .AddTransient<IBookRepository, BookRepository>();

            return services;
        }
    }
}
