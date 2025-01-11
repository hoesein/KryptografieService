using Microsoft.Extensions.DependencyInjection;
using Utilities.KryptografieService.IServices;
using Utilities.KryptografieService.Services;

namespace Utilities.KryptografieService;

public static class DependencyInjection
{
    public static IServiceCollection AddKryptoServices(this IServiceCollection services)
    {
        services.AddScoped<IKryptografie, Kryptografie>();
        return services;
    }
}
