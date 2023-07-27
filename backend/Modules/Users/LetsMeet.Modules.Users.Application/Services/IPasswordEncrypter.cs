namespace LetsMeet.Modules.Users.Application.Services;

public interface IPasswordEncrypter
{
    string HashPassword(string password);

    bool IsValidPassword(string password, string hash);
}