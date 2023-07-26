using LetsMeet.Modules.Users.Domain.Exceptions;

namespace LetsMeet.Modules.Users.Domain.Entities;

public record FirstName
{
    public string Value { get;  }

    private FirstName(string value)
    {
        Value = value;
    }

    public static FirstName Create(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new FirstNameCaNotBeEmpty();
        }

        return new FirstName(firstName);
    }
}