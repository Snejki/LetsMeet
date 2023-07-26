using Microsoft.AspNetCore.Routing;

namespace LetsMeet.Shared.Abstractions.Endpoints;

public interface IEndpoints
{
    public void MapEndpoints(IEndpointRouteBuilder app);
}