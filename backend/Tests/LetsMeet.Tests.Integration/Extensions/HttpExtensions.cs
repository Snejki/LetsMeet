using Newtonsoft.Json;

namespace LetsMeet.Tests.Integration.Extensions;

public static class HttpExtensions
{
    public static async Task<T> DeserializeContentAsync<T>(this HttpResponseMessage response)
    {
        var body = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(body);
    }
}