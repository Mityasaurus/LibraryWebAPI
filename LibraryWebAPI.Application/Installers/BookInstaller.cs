using LibraryWebAPI.Application.Builder;
using LibraryWebAPI.Application.Contracts;
using LibraryWebAPI.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryWebAPI.Application.Installers
{
    public static class BookInstaller
    {
        public static IServiceCollection AddBooks(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>()
                .AddScoped<IBookBuilder, BookBuilder>();
            return services;
        }
    }
}
