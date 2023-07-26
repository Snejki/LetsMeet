using LetsMeet.Modules.Users.Domain.Repositories;
using LetsMeet.Modules.Users.Infrastructure.DAL;
using LetsMeet.Modules.Users.Infrastructure.Repositories;
using LetsMeet.Shared.Infrastructure.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace LetsMeet.Modules.Users.Infrastructure;

public static class Extensions
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddCustomDbContext<UsersDbContext>("Users");
    }

    public static void UseInfrastructure(this WebApplication app)
    {
        
    }
}