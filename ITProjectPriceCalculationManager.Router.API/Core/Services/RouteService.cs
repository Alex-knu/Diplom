namespace ITProjectPriceCalculationManager.Router.API.Core.Services
{
    public static class RouteService
    {
        public static async Task<TResult> GetAllAsync<TResult>(HttpClient client, string controller)
        {
            var response = await client.GetAsync<TResult>($"api/{controller}/collection");

            return response;
        }

        public static async Task<TResult> GetByIdAsync<TResult>(HttpClient client, string controller, int id)
        {
            var response = await client.GetAsync<TResult>($"api/{controller}");

            return response;
        }

        public static async Task<TResult> PostAsJsonAsync<T, TResult>(HttpClient client, string controller, T query)
        {
            var response = await client.PostAsJsonAsync<T, TResult>($"api/{controller}", query);

            return response;
        }

        public static async Task<TResult> PutAsJsonAsync<T, TResult>(HttpClient client, string controller, T query)
        {
            var response = await client.PutAsJsonAsync<T, TResult>($"api/{controller}", query);

            return response;
        }

        public static async Task<TResult> DeleteAsJsonAsync<TResult>(HttpClient client, string controller, int id)
        {
            var response = await client.DeleteAsJsonAsync<int, TResult>($"api/{controller}", id);

            return response;
        }
    }
}