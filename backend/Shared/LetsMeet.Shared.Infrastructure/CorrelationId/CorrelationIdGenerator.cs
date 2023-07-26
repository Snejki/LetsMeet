using LetsMeet.Shared.Abstractions.CorrelationId;

namespace LetsMeet.Shared.Infrastructure.CorrelationId;

public class CorrelationIdGenerator : ICorrelationIdGenerator
{
    private string _correlationId = Guid.NewGuid().ToString();

    public string Get() => _correlationId;
    

    public string Set(string correlationId) => _correlationId = correlationId;
    
    
}