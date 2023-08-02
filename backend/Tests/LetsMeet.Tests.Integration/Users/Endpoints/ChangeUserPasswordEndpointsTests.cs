using FluentAssertions;
using LetsMeet.Modules.Users.Application.Features.ChangeUserPassword;
using LetsMeet.Tests.Integration.Shared;
using Microsoft.EntityFrameworkCore;

namespace LetsMeet.Tests.Integration.Users.Endpoints;

public class ChangeUserPasswordEndpointsTests : BaseTests, IDisposable
{
    private readonly UsersDatabase _usersDatabase;

    public ChangeUserPasswordEndpointsTests()
    {
        _usersDatabase = new UsersDatabase();
    }

    [Fact]
    public async Task ChangePassword_should_change_password()
    {
        var email = $"{nameof(ChangePassword_should_change_password)}@mail.com";
        var oldPassword = "OLD_PASSWORD";
        var newPassword = "NEW_PASSWORD";
        
        var token = await UsersHelpers.CreateUserAndLogin(email, oldPassword, Client);

        var changePasswordCommand = new ChangeUserPasswordCommand(oldPassword, newPassword);
        var changePasswordResponse = await Client.PutAsJsonWithAuth("api/user/change-password", changePasswordCommand, token);
        changePasswordResponse?.EnsureSuccessStatusCode();
        
        var loggedUserAfterChangePassword = await UsersHelpers.LoginUser(email, newPassword, Client);
        loggedUserAfterChangePassword.Should().NotBeNullOrEmpty();
    }
    
    
    public void Dispose()
    {
        _usersDatabase.Dispose();
    }
}