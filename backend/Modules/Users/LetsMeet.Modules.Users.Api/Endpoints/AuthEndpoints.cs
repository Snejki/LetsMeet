using LetsMeet.Modules.Users.Application.Features.LoginUser;
using LetsMeet.Shared.Abstractions.Endpoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Wolverine;

namespace LetsMeet.Modules.Users.Api.Endpoints;

public class AuthEndpoints : IEndpoints
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPost("api/auth/login",
                (IMessageBus messageBus, LoginUserQuery query) => messageBus
                    .InvokeAsync<LoginUserResponseDto>(query))
            .Produces<LoginUserResponseDto>()
            .Produces(StatusCodes.Status500InternalServerError)
            .WithDescription("Login user")
            .WithOpenApi();
    }
}