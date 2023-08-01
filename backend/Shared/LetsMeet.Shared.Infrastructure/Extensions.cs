using System.Reflection;
using LetsMeet.Shared.Infrastructure.CorrelationId;
using LetsMeet.Shared.Infrastructure.DateTimeProvider;
using LetsMeet.Shared.Infrastructure.Exceptions;
using LetsMeet.Shared.Infrastructure.HealthChecks;
using LetsMeet.Shared.Infrastructure.Metrics;
using LetsMeet.Shared.Infrastructure.SeriLog;
using LetsMeet.Shared.Infrastructure.Swagger;
using LetsMeet.Shared.Infrastructure.Wolverine;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LetsMeet.Shared.Infrastructure;

public static class Extensions
{
    public static void AddInfrastructure(this WebApplicationBuilder builder, IList<Assembly> assemblies)
    {
        builder.Services.AddServices();
        builder.Host.UseCustomWolverine(typeof(Extensions).Assembly, assemblies);
        builder.Host.UseCustomLogging(builder.Configuration);
    }
    
    public static void UseInfrastructure(this WebApplication app)
    {
        app.UseCustomSwagger();        
        app.UseCustomMetrics();

        app.UseCorrelationIdMiddleware();
        
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionMiddleware();
        }

        app.UseCustomHealthChecks();
        app.UseHttpsRedirection();
        app.UseAuthorization();
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddCorrelationIdGenerator();
        services.AddCorrelationIdMiddleware();
        services.AddDateTimeProvider();
        services.AddHttpContextAccessor();
        services.AddControllers();
        services.AddCustomSwagger();
        services.AddCustomHealthChecks();
        services.AddExceptionMiddleware();
        services.AddCustomMetrics();
    }
}