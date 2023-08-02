using LetsMeet.Modules.Users.Application.Services;
using LetsMeet.Modules.Users.Domain.Repositories;
using LetsMeet.Modules.Users.Infrastructure.DAL;
using LetsMeet.Modules.Users.Infrastructure.Repositories;
using LetsMeet.Modules.Users.Infrastructure.Services;
using LetsMeet.Shared.Infrastructure.Database;
using LetsMeet.Shared.Infrastructure.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LetsMeet.Modules.Users.Infrastructure;

public static class Extensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IUserRepository, UserRepository>();   
        services.AddTransient<IPasswordEncrypter, PasswordEncrypter>();
        services.AddScoped<IPasswordHasher<string>, PasswordHasher<string>>();
        services.AddScoped<IAuthenticator, Authenticator>();
        
        services.AddCustomDbContext<UsersDbContext>("Users");
    }

    public static void UseInfrastructure(this WebApplication app)
    {
        
    }
}