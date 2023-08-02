using LetsMeet.Modules.Users.Application.Features.ChangeUserPassword;
using LetsMeet.Shared.Abstractions.Endpoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Wolverine;

namespace LetsMeet.Modules.Users.Api.Endpoints;

public class UserChangePasswordEndpoints : IEndpoints
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPut("api/user/change-password",
                (ChangeUserPasswordCommand command, IMessageBus messageBus) => messageBus.InvokeAsync(command))
            .RequireAuthorization();
    }
}