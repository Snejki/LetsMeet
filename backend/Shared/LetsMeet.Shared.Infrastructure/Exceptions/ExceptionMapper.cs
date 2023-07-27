using System.Net;
using FluentValidation;
using LetsMeet.Shared.Abstractions.Exceptions;

namespace LetsMeet.Shared.Infrastructure.Exceptions;

internal static class ExceptionMapper
{
    public static ExceptionResponse Map(this Exception exception, string correlationId, DateTime dateTime) => exception switch
    {
        LetsMeetException ex => new ExceptionResponse(new BadRequestResponse(ex.GetType().Name),
            HttpStatusCode.BadRequest),
        ValidationException ex => new ExceptionResponse(new ValidationException(ex.Errors), HttpStatusCode.BadRequest),
        _ => new ExceptionResponse(new InternalServerErrorResponse("Something went wrong", correlationId, dateTime),
            HttpStatusCode.InternalServerError, true)
    };
}