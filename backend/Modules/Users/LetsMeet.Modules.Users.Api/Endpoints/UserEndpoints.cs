using LetsMeet.Modules.Users.Application.Features.CreateUser;
using LetsMeet.Shared.Abstractions.Endpoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Wolverine;

namespace LetsMeet.Modules.Users.Api.Endpoints;

public class UserEndpoints : IEndpoints
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPost("api/user", (CreateUserCommand command, IMessageBus messageBus) => messageBus.InvokeAsync(command));
        
        
    }
}