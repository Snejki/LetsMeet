using LetsMeet.Shared.Abstractions.DateTimeProvider;
using Microsoft.Extensions.DependencyInjection;

namespace LetsMeet.Shared.Infrastructure.DateTimeProvider;

public static class Extensions
{
    public static void AddDateTimeProvider(this IServiceCollection services)
    {
        services.AddTransient<IDateTimeProvider, DateTImeProvider>();
    }
}