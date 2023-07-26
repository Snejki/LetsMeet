using LetsMeet.Modules.Users.Domain.Exceptions;

namespace LetsMeet.Modules.Users.Domain.Entities;

public sealed class User
{
    public UserId Id { get; }
    public Email Email { get; }
    public FirstName FirstName { get; }
    public LastName LastName { get; }
    public Password Password { get; }

    private User()
    {
    }

    private User(UserId userId, 
        Email email, 
        FirstName firstName, 
        LastName lastName, 
        Password password)
    {
        Id = userId ?? throw new Exception();
        Email = email ?? throw new EmailShouldBeInCorrectFormat();
        FirstName = firstName ?? throw new FirstNameCaNotBeEmpty();
        LastName = lastName ?? throw new LastNameCanNotBeEmpty();
        Password = password ?? throw new PasswordCanNotBeEmpty();
    }

    public static User Create(UserId userId, 
        Email email, 
        FirstName firstName, 
        LastName lastName, 
        Password password) 
            => new User(userId, email, firstName, lastName, password);
}