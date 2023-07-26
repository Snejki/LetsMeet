using LetsMeet.Modules.Users.Domain.Exceptions;

namespace LetsMeet.Modules.Users.Domain.Entities;

public record Password
{
    public string Value { get;  }

    private Password(string value)
    {
        Value = value;
    }

    public static Password Create(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new PasswordCanNotBeEmpty();
        }

        return new Password(firstName);
    }
}