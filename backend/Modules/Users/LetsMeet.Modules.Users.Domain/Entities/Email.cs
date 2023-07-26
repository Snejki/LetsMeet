using System.Net.Mail;
using LetsMeet.Modules.Users.Domain.Exceptions;

namespace LetsMeet.Modules.Users.Domain.Entities;

public record  Email
{
    public string Value { get; }

    private Email(string value)
    {
        Value = value;
    }

    public static Email Create(string value)
    {
        if (!IsValid(value))
        {
            throw new EmailShouldBeInCorrectFormat();
        }

        return new Email(value);
    }
    
    private static bool IsValid(string email)
    {
        try
        {
            new MailAddress(email);
            return true;
        }
        catch
        {
            return false;
        }
    }
}