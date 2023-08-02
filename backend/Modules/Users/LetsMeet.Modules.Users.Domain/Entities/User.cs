using LetsMeet.Modules.Users.Domain.Exceptions;
using LetsMeet.Shared.Abstractions.Kernel;

namespace LetsMeet.Modules.Users.Domain.Entities;

public sealed class User
{
    public UserId Id { get; private set; }
    public Email Email { get; private set; }
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public HashedPassword HashedPassword { get; private set; }

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
            => new (userId, email, firstName, lastName, hashedPassword);

    public void ChangePassword(HashedPassword hashedPassword)
    {
        HashedPassword = hashedPassword ?? throw new PasswordCanNotBeEmptyException();
    }
    
    // ReSharper disable once UnusedMember.Local
#pragma warning disable CS8618
    internal User()
    {
    }
#pragma warning restore CS8618
}