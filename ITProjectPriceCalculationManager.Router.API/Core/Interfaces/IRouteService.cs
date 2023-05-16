namespace ITProjectPriceCalculationManager.Router.API.Core.Interfaces
{
    public interface IRouteService
    {
        Task<TResult> DeleteAsJsonAsync<TResult>(HttpClient client, string controller, int id);
        Task<TResult> GetAllAsync<TResult>(HttpClient client, string controller);
        Task<TResult> GetByIdAsync<TResult>(HttpClient client, string controller, int id);
        Task<TResult> PostAsJsonAsync<T, TResult>(HttpClient client, string controller, T query);
        Task<TResult> PutAsJsonAsync<T, TResult>(HttpClient client, string controller, T query);
    }

}