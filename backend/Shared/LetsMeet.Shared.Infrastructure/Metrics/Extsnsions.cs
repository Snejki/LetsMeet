using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Metrics;

namespace LetsMeet.Shared.Infrastructure.Metrics;

internal static class Extsnsions
{
    public static void AddCustomMetrics(this IServiceCollection services)
    {
        services.AddOpenTelemetry()
            .WithMetrics(x =>
            {
                x.AddPrometheusExporter();

                x.AddMeter("Microsoft.AspNetCore.Hosting", "Microsoft.AspNetCore.Server.Kestrel");
            });
    }

    public static void UseCustomMetrics(this WebApplication app)
    {
        app.MapPrometheusScrapingEndpoint();
    }
}