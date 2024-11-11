using Microsoft.Extensions.DependencyInjection;

namespace LibraryWebAPI.Infrastructure.Persistence.Installers
{
    public static class DataInstaller
    {
        public static IServiceCollection AddDataContext(this IServiceCollection services)
        {
            services
                .AddSingleton<LibraryContext>();
            //.AddTransient<IAuthorRepository, AuthorRepository>()
            //.AddTransient<IBookRepository, BookRepository>();

            return services;
        }
    }
}
