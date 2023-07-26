using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace LetsMeet.Shared.Infrastructure.Exceptions;

internal static class Extensions
{
    public static void AddExceptionMiddleware(this IServiceCollection services)
    {
        services.AddTransient<ExceptionMiddleware>();
    }
    
    public static void UseExceptionMiddleware(this WebApplication app)
    {
        app.UseMiddleware(typeof(ExceptionMiddleware));
    }
}