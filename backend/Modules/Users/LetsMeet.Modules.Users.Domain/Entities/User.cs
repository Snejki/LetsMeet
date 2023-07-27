using LetsMeet.Modules.Users.Domain.Exceptions;

namespace LetsMeet.Modules.Users.Domain.Entities;

public sealed class User
{
    public UserId Id { get; }
    public Email Email { get; }
    public FirstName FirstName { get; }
    public LastName LastName { get; }
    public HashedPassword HashedPassword { get; }

    private User()
    {
    }

    private User(UserId userId, 
        Email email, 
        FirstName firstName, 
        LastName lastName, 
        HashedPassword hashedPassword)
    {
        Id = userId ?? throw new Exception();
        Email = email ?? throw new EmailShouldBeInCorrectFormatException();
        FirstName = firstName ?? throw new FirstNameCaNotBeEmptyException();
        LastName = lastName ?? throw new LastNameCanNotBeEmptyException();
        HashedPassword = hashedPassword ?? throw new PasswordCanNotBeEmptyException();
    }

    public static User Create(UserId userId, 
        Email email, 
        FirstName firstName, 
        LastName lastName, 
        HashedPassword hashedPassword) 
            => new User(userId, email, firstName, lastName, hashedPassword);
}