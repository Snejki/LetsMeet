using LetsMeet.Modules.Users.Domain.Exceptions;

namespace LetsMeet.Modules.Users.Domain.Entities;

public record HashedPassword 
{
    public string Value { get; }
    
    private HashedPassword(string value) 
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new PasswordCanNotBeEmptyException();
        }
        
        Value = value;
    }

    public static HashedPassword Create(string password) => new(password);
    
    public static explicit operator HashedPassword(string value) => new(value);
    public static implicit operator string(HashedPassword value) => value.Value;
}