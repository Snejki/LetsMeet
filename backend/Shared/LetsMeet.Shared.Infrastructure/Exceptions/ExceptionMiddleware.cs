using LetsMeet.Shared.Abstractions.CorrelationId;
using LetsMeet.Shared.Abstractions.DateTimeProvider;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace LetsMeet.Shared.Infrastructure.Exceptions;

internal class ExceptionMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly ICorrelationIdGenerator _correlationIdGenerator;
    private readonly IDateTimeProvider _dateTimeProvider;

    public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger, 
        ICorrelationIdGenerator correlationIdGenerator, 
        IDateTimeProvider dateTimeProvider)
    {
        _logger = logger;
        _correlationIdGenerator = correlationIdGenerator;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            var exceptionResponse = e.Map(_correlationIdGenerator.Get(), _dateTimeProvider.GetTime());
            if (exceptionResponse.ShouldLog)
            {
                _logger.LogError(e, "");
            }

            context.Response.StatusCode = (int) exceptionResponse.StatusCode;
            await context.Response.WriteAsJsonAsync(exceptionResponse.Response);
        }
    }
}