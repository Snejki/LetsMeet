using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace LetsMeet.Tests.Integration.Shared;

public static class HttpClientExtensions
{
    public static async Task<HttpResponseMessage?> PostAsJsonWithAuth<T>(this HttpClient client, string url, T request,
        string token)
    {
        if (client is null)
        {
            throw new ArgumentNullException(nameof(client));
        }

        var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
        requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        requestMessage.Content = JsonContent.Create(request, mediaType: null);
        
        return await client.SendAsync(requestMessage);
    }
    
    public static async Task<HttpResponseMessage?> PutAsJsonWithAuth<T>(this HttpClient client, string url, T request,
        string token)
    {
        if (client is null)
        {
            throw new ArgumentNullException(nameof(client));
        }

        var requestMessage = new HttpRequestMessage(HttpMethod.Put, url);
        requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        requestMessage.Content = JsonContent.Create(request, mediaType: null);
        
        return await client.SendAsync(requestMessage);
    }
}