using LibraryWebAPI.BusinessLogic.Facade;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryWebAPI.BusinessLogic.Installers
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
