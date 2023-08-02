using System.Text;
using LetsMeet.Shared.Infrastructure.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace LetsMeet.Shared.Infrastructure.Auth;

internal static class Extensions
{
    public static void AddCustomAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var authOptions = configuration.GetOptions<AuthOptions>(AuthOptions.SectionName);

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.Audience = authOptions.Audience;
            options.IncludeErrorDetails = true;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateAudience = true,
                ValidateIssuer = false,
                //ValidIssuer = options.ClaimsIssuer,
                ClockSkew = TimeSpan.Zero,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authOptions.SigningKey!))
            };
        });

        services.AddAuthorization();
    }

    public static void AddAuthOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCustomOptions<AuthOptions>(configuration, AuthOptions.SectionName);
    }
}