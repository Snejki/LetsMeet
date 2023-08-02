using System.Net.Http.Json;
using LetsMeet.Modules.Users.Application.Features.CreateUser;
using LetsMeet.Modules.Users.Application.Features.LoginUser;
using LetsMeet.Tests.Integration.Extensions;

namespace LetsMeet.Tests.Integration.Shared;

public static class UsersHelpers
{
    public static async Task<string> CreateUserAndLogin(string email, string password, HttpClient client)
    {
        var firstName = "Thomas";
        var lastName = "Golonka";
        
        var createUserCommand = new CreateUserCommand(email, firstName, lastName, password);
        await client.PostAsJsonAsync("api/user", createUserCommand);

        return await LoginUser(email, password, client);
    }
    
    public static async Task<string> LoginUser(string email, string password, HttpClient client)
    {
        var loginUserQuery = new LoginUserQuery(email, password);
        var loginResponse = await client.PostAsJsonAsync("api/auth/login", loginUserQuery);
        loginResponse.EnsureSuccessStatusCode();
        
        var loginResponseModel = await loginResponse.DeserializeContentAsync<LoginUserResponseDto>();
        return loginResponseModel.Token;
    }
}