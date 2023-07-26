using LetsMeet.Shared.Abstractions.DateTimeProvider;

namespace LetsMeet.Shared.Infrastructure.DateTimeProvider;

public class DateTImeProvider : IDateTimeProvider
{
    public System.DateTime GetTime() => System.DateTime.UtcNow;
}