namespace LetsMeet.Tests.Integration;

public class BaseTests
{
    protected readonly HttpClient Client;
    
    public BaseTests()
    {
        Client = new LetsMeetTestApp().Client;
    }
}