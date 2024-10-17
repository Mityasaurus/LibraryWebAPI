using LibraryWebAPI.BusinessLogic.Contracts;
using LibraryWebAPI.BusinessLogic.Services;
using LibraryWebAPI.BusinessLogic.Services.Proxy;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryWebAPI.BusinessLogic.Installers
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
