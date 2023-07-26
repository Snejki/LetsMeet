using System.Net;

namespace LetsMeet.Shared.Infrastructure.Exceptions;

public record ExceptionResponse(object Response, HttpStatusCode StatusCode, bool ShouldLog = false);

public record BadRequestResponse(string Code, string Message);

public record InternalServerErrorResponse(string Message, string CorrelationId, System.DateTime Date);