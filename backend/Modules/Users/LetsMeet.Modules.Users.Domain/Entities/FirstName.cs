using LetsMeet.Modules.Users.Domain.Exceptions;

namespace LetsMeet.Modules.Users.Domain.Entities;

public record FirstName
{
    public string Value { get;  }

    private FirstName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new FirstNameCaNotBeEmptyException();
        }
        
        Value = value;
    }

    public static FirstName Create(string firstName) => new(firstName);

    public static explicit operator FirstName(string value) => new(value);
    public static implicit operator string(FirstName value) => value.Value;
}