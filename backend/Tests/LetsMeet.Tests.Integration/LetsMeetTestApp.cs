using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace LetsMeet.Tests.Integration;

internal class LetsMeetTestApp : WebApplicationFactory<Program>
{
    public HttpClient Client { get; }

    public LetsMeetTestApp()
    {
        Client = WithWebHostBuilder(builder =>
        {
            builder.UseEnvironment("test");
        }).CreateClient();
    }
}