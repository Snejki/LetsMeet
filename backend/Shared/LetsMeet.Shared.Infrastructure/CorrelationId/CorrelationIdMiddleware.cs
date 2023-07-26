using LetsMeet.Shared.Abstractions.CorrelationId;
using Microsoft.AspNetCore.Http;

namespace LetsMeet.Shared.Infrastructure.CorrelationId;

public class CorrelationIdMiddleware : IMiddleware
{
    public const string CorrelationIdHeader = "X-Correlation-ID";

    private readonly ICorrelationIdGenerator _correlationIdGenerator;

    public CorrelationIdMiddleware(ICorrelationIdGenerator correlationIdGenerator)
    {
        _correlationIdGenerator = correlationIdGenerator;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var correlationId = GetCorrelationId(context);
        AddCCorrelationHeaderToResponse(context, correlationId);
        
        await next(context);
    }

    private string GetCorrelationId(HttpContext content)
    {
        if (content.Response.Headers.TryGetValue(CorrelationIdHeader, out var correlationId))
        {
            _correlationIdGenerator.Set(correlationId!);
            return correlationId!;
        }
        else
        {
            return _correlationIdGenerator.Get();
        }
    }

    private void AddCCorrelationHeaderToResponse(HttpContext context, string correlationId)
    {
        context.Response.OnStarting(() =>
        {
            if (!context.Response.Headers.TryGetValue(CorrelationIdHeader, out _))
            {
                context.Response.Headers.Append(CorrelationIdHeader, new[] { correlationId });
            }
            
            return Task.CompletedTask;
        });
    }
}