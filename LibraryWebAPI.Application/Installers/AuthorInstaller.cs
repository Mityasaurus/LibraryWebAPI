using LibraryWebAPI.Application.Contracts;
using LibraryWebAPI.Application.Services;
using LibraryWebAPI.Application.Services.Proxy;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryWebAPI.Application.Installers
{
    public static class AuthorInstaller
    {
        public static IServiceCollection AddAuthors(this IServiceCollection services)
        {
            services.AddSingleton<AuthorService>();
            services.AddSingleton<IAuthorService, AuthorServiceProxy>();
            return services;
        }
    }
}
