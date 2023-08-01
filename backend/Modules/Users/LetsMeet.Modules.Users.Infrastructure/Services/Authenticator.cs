using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LetsMeet.Modules.Users.Application.Services;
using LetsMeet.Modules.Users.Domain.Entities;
using LetsMeet.Modules.Users.Infrastructure.Options;
using LetsMeet.Shared.Abstractions.DateTimeProvider;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace LetsMeet.Modules.Users.Infrastructure.Services;

internal class Authenticator : IAuthenticator
{

    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly AuthOptions _authOptions;
    private readonly SigningCredentials _signingCredentials;
    private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;

    public Authenticator(
        IDateTimeProvider dateTimeProvider,  
        AuthOptions authOptions)
    {
        _dateTimeProvider = dateTimeProvider;
        _authOptions = authOptions;
        _signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_authOptions.SigningKey!)), 
            SecurityAlgorithms.HmacSha256);
        _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
    }

    public string CreateToken(UserId userId)
    {
        var now = _dateTimeProvider.GetTime();
        
        var claims = new List<Claim>()
        {
            new(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
        };

        var expiry = now.Add(_authOptions.Expiry ?? TimeSpan.FromHours(1));

        var jwt = new JwtSecurityToken(_authOptions.Issuer, _authOptions.Audience, claims, now, expiry,
            _signingCredentials);

        var token = _jwtSecurityTokenHandler.WriteToken(jwt);

        return token;
    }
}