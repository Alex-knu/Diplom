namespace System.Net.Http
{
    public static class CustomHttpClientExtention
    {
        public static async Task<TResult> GetAsync<TResult>(this HttpClient client, string route)
        {
            return await ReadFromJson<TResult>(await client.GetAsync(route));
        }

        public static async Task<TResult> PostAsJsonAsync<T, TResult>(this HttpClient client, string route, T query)
        {
            return await ReadFromJson<TResult>(await client.PostAsJsonAsync<T>(route, query));
        }

        public static async Task<TResult> PutAsJsonAsync<T, TResult>(this HttpClient client, string route, T query)
        {
            return await ReadFromJson<TResult>(await client.PutAsJsonAsync<T>(route, query));
        }

        public static async Task<TResult> DeleteAsJsonAsync<T, TResult>(this HttpClient client, string route, int id)
        {
            return await ReadFromJson<TResult>(await client.DeleteAsJsonAsync<int>(route, id));
        }

        private static async Task<TResult> ReadFromJson<TResult>(HttpResponseMessage responseMessage)
        {
            return await responseMessage.Content.ReadAsAsync<TResult>();
        }
    }
}