using LibraryWebAPI.BusinessLogic.Contracts;
using LibraryWebAPI.BusinessLogic.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryWebAPI.BusinessLogic.Installers
{
    public static class AuthorInstaller
    {
        public static IServiceCollection AddAuthors(this IServiceCollection services)
        {
            services.AddScoped<IAuthorService, AuthorService>();
            return services;
        }
    }
}
