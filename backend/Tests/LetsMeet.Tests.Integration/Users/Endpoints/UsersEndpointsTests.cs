using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using LetsMeet.Modules.Users.Application.Features.CreateUser;
using Microsoft.EntityFrameworkCore;

namespace LetsMeet.Tests.Integration.Users.Endpoints;

public class UsersEndpointsTests : BaseTests, IDisposable
{
    private readonly UsersDatabase _usersDatabase;

    public UsersEndpointsTests()
    {
        _usersDatabase = new UsersDatabase();
    }

    [Fact]
    public async Task CreateUser_endpoint_should_create_new_user()
    {
        var command = new CreateUserCommand("tomasz@mail.com", "TOmek", "Testowy", "SomePassword");

        var response = await Client.PostAsJsonAsync("api/user", command);
        var dbAccount = await _usersDatabase.Context.Users.FirstOrDefaultAsync(x => x.Email.Value == command.Email);

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        dbAccount.Should().NotBeNull();
    }
    
    public void Dispose()
    {
        _usersDatabase.Dispose();
    }
}