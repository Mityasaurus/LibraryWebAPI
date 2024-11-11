using LibraryWebAPI.Application.Facade;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryWebAPI.Application.Installers
{
    public static class LibraryFacadeInstaller
    {
        public static IServiceCollection AddLibraryFacade(this IServiceCollection services)
        {
            services.AddScoped<ILibraryFacade, LibraryFacade>();
            return services;
        }
    }
}
