using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using LetsMeet.Modules.Users.Application.Features.CreateUser;
using LetsMeet.Modules.Users.Application.Features.LoginUser;

namespace LetsMeet.Tests.Integration.Users.Endpoints;

public class AuthEndpointsTests : BaseTests, IDisposable
{
    private readonly UsersDatabase _usersDatabase;

    public AuthEndpointsTests()
    {
        _usersDatabase = new UsersDatabase();
    }

    [Fact]
    public async Task Login_should_response_with_correct_token()
    {
        await CreateAccount();
        
        var query = new LoginUserQuery("tomasaz@mail.com", "SomePassword");
        var response = await Client.PostAsJsonAsync("api/auth/login", query);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    private async Task CreateAccount()
    {
        var command = new CreateUserCommand("tomasaz@mail.com", "TOmek", "Testowy", "SomePassword");
        await Client.PostAsJsonAsync("api/user", command);
    }

    public void Dispose()
    {
        _usersDatabase.Dispose();
    }
}