using BridgingTheGap.Data.Reservation;
using Microsoft.Extensions.DependencyInjection;

namespace BridgingTheGap.Data;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddData(this IServiceCollection services)
    {
        services.AddSingleton<ReservationRepository>();
        return services;
    }
}
