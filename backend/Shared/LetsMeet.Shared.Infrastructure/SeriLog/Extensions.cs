using LetsMeet.Shared.Infrastructure.CorrelationId;
using LetsMeet.Shared.Infrastructure.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace LetsMeet.Shared.Infrastructure.SeriLog;

internal static class Extensions
{
    public static void UseCustomLogging(this IHostBuilder host, IConfiguration configuration)
    {
        var options = configuration.GetOptions<SeriLogOptions>(SeriLogOptions.SectionName);
        
        host.UseSerilog((ctx, loggerConfiguration) =>
        {
            if (options?.File?.Enabled is true)
            {
                loggerConfiguration
                    .WriteTo
                    .File(options.File.FilePath!, rollingInterval: RollingInterval.Day, outputTemplate: options.File.LogTemplate!)
                    .Enrich
                    .WithCorrelationIdHeader(CorrelationIdMiddleware.CorrelationIdHeader);
            }

            if (options?.Seq?.Enabled is true)
            {
                loggerConfiguration
                    .WriteTo
                    .Seq(options.Seq.ServerUrl!)
                    .Enrich
                    .WithCorrelationIdHeader(CorrelationIdMiddleware.CorrelationIdHeader);
            }
        });
    }
}