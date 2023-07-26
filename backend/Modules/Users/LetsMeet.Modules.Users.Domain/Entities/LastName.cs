using LetsMeet.Modules.Users.Domain.Exceptions;

namespace LetsMeet.Modules.Users.Domain.Entities;

public record LastName
{
    public string Value { get;  }

    private LastName(string value)
    {
        Value = value;
    }

    public static LastName Create(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new LastNameCanNotBeEmpty();
        }

        return new LastName(firstName);
    }
}