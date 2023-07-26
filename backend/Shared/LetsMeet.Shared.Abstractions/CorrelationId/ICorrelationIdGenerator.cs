namespace LetsMeet.Shared.Abstractions.CorrelationId;

public interface ICorrelationIdGenerator
{
    string Get();

    string Set(string correlationId);
}