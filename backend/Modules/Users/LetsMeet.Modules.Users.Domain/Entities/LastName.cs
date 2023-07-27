using LetsMeet.Modules.Users.Domain.Exceptions;

namespace LetsMeet.Modules.Users.Domain.Entities;

public record LastName
{
    public string Value { get;  }

    private LastName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new LastNameCanNotBeEmptyException();
        }
        
        Value = value;
    }

    public static LastName Create(string firstName) => new(firstName);

    public static explicit operator LastName(string value) => new(value);
    public static implicit operator string(LastName value) => value.Value;
}