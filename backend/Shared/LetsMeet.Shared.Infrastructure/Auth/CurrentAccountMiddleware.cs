using LetsMeet.Shared.Abstractions.Auth;
using LetsMeet.Shared.Abstractions.Kernel;
using Microsoft.AspNetCore.Http;
using Wolverine;

namespace LetsMeet.Shared.Infrastructure.Auth;

// ReSharper disable once UnusedType.Global
public class CurrentAccountMiddleware
{
    // ReSharper disable once UnusedMember.Global
    public static async Task<(HandlerContinuation, CurrentUser?)> LoadAsync(
        IHttpContextAccessor httpContextAccessor,
        CancellationToken ct)
    {
        var identity = httpContextAccessor?.HttpContext?.User?.Identity;
        if (identity == null)
        {
            throw new UnauthorizedAccessException();
        }

        var isAuthenticated = identity.IsAuthenticated;
        if (!isAuthenticated || string.IsNullOrEmpty(identity.Name))
        {
            throw new UnauthorizedAccessException();
        }

        var guid = new Guid(identity.Name);
        var currentAccount = new CurrentUser((UserId) guid);
        
        return (HandlerContinuation.Continue, currentAccount);
    }
}

public static class CurrentAccountMiddlewareExtensions
{
    public static void AddCurrentAccountMiddleware(this IPolicies policies) =>
        policies.AddMiddleware<CurrentAccountMiddleware>(x => x.MessageType.IsAssignableTo(typeof(IWithCurrentUser)));
}