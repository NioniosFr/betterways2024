using Microsoft.Extensions.DependencyInjection;

namespace BridgingTheGap.Core;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddMediatR(sc => { sc.RegisterServicesFromAssembly(typeof(DependencyInjectionExtensions).Assembly); });

        return services;
    }
}
