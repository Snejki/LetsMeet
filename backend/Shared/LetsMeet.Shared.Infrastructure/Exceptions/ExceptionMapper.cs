using System.Net;
using LetsMeet.Shared.Abstractions.Exceptions;

namespace LetsMeet.Shared.Infrastructure.Exceptions;

internal static class ExceptionMapper
{
    public static ExceptionResponse Map(this Exception exception, string correlationId, DateTime dateTime) => exception switch
    {
        LetsMeetException ex => new ExceptionResponse(new BadRequestResponse(nameof(ex), nameof(ex)),
            HttpStatusCode.BadRequest),
        _ => new ExceptionResponse(new InternalServerErrorResponse("Something went wrong", correlationId, dateTime),
            HttpStatusCode.InternalServerError, true)
    };
}