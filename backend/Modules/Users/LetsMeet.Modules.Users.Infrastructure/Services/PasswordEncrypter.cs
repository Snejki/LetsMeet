using LetsMeet.Modules.Users.Application.Services;
using Microsoft.AspNetCore.Identity;

namespace LetsMeet.Modules.Users.Infrastructure.Services;

public class PasswordEncrypter : IPasswordEncrypter
{
    private readonly IPasswordHasher<string> _passwordHasher;

    public PasswordEncrypter(IPasswordHasher<string> passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }

    public string HashPassword(string password) => _passwordHasher.HashPassword(default!, password);

    public bool IsValidPassword(string password, string hash) =>
        _passwordHasher.VerifyHashedPassword(default!, hash, password) == PasswordVerificationResult.Success;
}