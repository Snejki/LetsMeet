using FluentAssertions;
using LetsMeet.Modules.Users.Domain.Entities;
using LetsMeet.Shared.Abstractions.Kernel;
using Xunit;

namespace LestMeet.Modules.Users.Tests.Unit.Domain.Entities;

public sealed class UserTests
{
    [Fact]
    public void User_WhenProvidedAllData_ShouldBeCreated()
    {
        var userId = UserId.Create(Guid.NewGuid());
        var email = Email.Create("mail@mail.com");
        var firstName = FirstName.Create("Thomas");
        var lastName = LastName.Create("Kowalsky");
        var password = HashedPassword.Create("hash");

        var sut = User.Create(userId, email, firstName, lastName, password);

        sut.Id.Should().BeEquivalentTo(userId);
        sut.Email.Should().BeEquivalentTo(email);
        sut.FirstName.Should().BeEquivalentTo(firstName);
        sut.LastName.Should().BeEquivalentTo(lastName);
        sut.HashedPassword.Should().BeEquivalentTo(password);
    }
}