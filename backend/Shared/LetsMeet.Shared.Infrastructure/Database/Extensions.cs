using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LetsMeet.Shared.Infrastructure.Database;

public static class Extensions
{
    public static void AddCustomDbContext<T>(this IServiceCollection services, string name) where T : DbContext
    {
        services.AddDbContext<T>(opts => opts.UseInMemoryDatabase(name));
    }
}