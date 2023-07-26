using LetsMeet.Shared.Abstractions.CorrelationId;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace LetsMeet.Shared.Infrastructure.CorrelationId;

public static class Extensions
{
    public static void AddCorrelationIdGenerator(this IServiceCollection services)
    {
        services.AddScoped<ICorrelationIdGenerator, CorrelationIdGenerator>();
    }

    public static void AddCorrelationIdMiddleware(this IServiceCollection services)
    {
        services.AddTransient<CorrelationIdMiddleware>();
    }

    public static void UseCorrelationIdMiddleware(this WebApplication app)
    {
        app.UseMiddleware(typeof(CorrelationIdMiddleware));
    }
}