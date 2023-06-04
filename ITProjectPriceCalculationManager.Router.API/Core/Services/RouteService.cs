using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.Router.API.Core.Services
{
    public class RouteService : IRouteService
    {
        public async Task<TResult> GetAllAsync<TResult>(HttpClient client, string controller)
        {
            var response = await client.GetAsync<TResult>($"api/{controller}/collection");

            return response;
        }

        public async Task<TResult> GetListByIdAsync<TResult, TKey>(HttpClient client, string controller, TKey id)
        {
            var response = await client.GetByIdAsync<TResult>($"api/{controller}/collection/{id}");

            return response;
        }

        public async Task<TResult> GetByIdAsync<TResult, TKey>(HttpClient client, string controller, TKey id)
        {
            var response = await client.GetByIdAsync<TResult>($"api/{controller}/{id}");

            return response;
        }

        public async Task<TResult> PostAsJsonAsync<T, TResult>(HttpClient client, string controller, T query)
        {
            var response = await client.PostAsJsonAsync<T, TResult>($"api/{controller}", query);

            return response;
        }

        public async Task<TResult> PutAsJsonAsync<T, TResult>(HttpClient client, string controller, T query)
        {
            var response = await client.PutAsJsonAsync<T, TResult>($"api/{controller}", query);

            return response;
        }

        public async Task<TResult> DeleteAsJsonAsync<TResult, TKey>(HttpClient client, string controller, TKey id)
        {
            var response = await client.DeleteAsJsonAsync<TKey, TResult, TKey>($"api/{controller}", id);

            return response;
        }
    }
}