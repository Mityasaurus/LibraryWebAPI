using LibraryWebAPI.BusinessLogic.Contracts;
using LibraryWebAPI.BusinessLogic.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryWebAPI.BusinessLogic.Installers
{
    public static class BookInstaller
    {
        public static IServiceCollection AddBooks(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            return services;
        }
    }
}
