using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace LetsMeet.Shared.Infrastructure.HealthChecks;

internal static class Extensions
{
    public static void AddCustomHealthChecks(this IServiceCollection services) => services.AddHealthChecks();

    public static void UseCustomHealthChecks(this WebApplication app) => app.UseHealthChecks(
        "/_health",
        new HealthCheckOptions()
        {
            Predicate = _ => true
        });
}