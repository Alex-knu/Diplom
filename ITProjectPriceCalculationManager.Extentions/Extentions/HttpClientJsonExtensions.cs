using System.Text.Json;

namespace System.Net.Http
{
    public static class HttpClientJsonExtensions
    {
        public static async Task<HttpResponseMessage> DeleteAsJsonAsync<TValue>(this HttpClient client, string requestUri, TValue value, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default)
        {
            var json = JsonSerializer.Serialize(value, options);
            
            using var request = new HttpRequestMessage(HttpMethod.Delete, requestUri)
            {
                Content = new StringContent(json),
            };

            return await client.SendAsync(request, HttpCompletionOption.ResponseContentRead, cancellationToken).ConfigureAwait(false);
        }
    }
}