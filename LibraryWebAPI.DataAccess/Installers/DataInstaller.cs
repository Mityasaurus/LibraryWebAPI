using LibraryWebAPI.DataAccess.Repositories.Author;
using LibraryWebAPI.DataAccess.Repositories.Book;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryWebAPI.DataAccess.Installers
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
