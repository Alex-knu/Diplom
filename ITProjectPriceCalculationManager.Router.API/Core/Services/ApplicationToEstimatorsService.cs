using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.Router.API.Core.Services
{
    internal class ApplicationToEstimatorsService : IApplicationToEstimatorsService
    {
        private readonly HttpClient _client;
        private readonly IRouteService _routeService;

        public ApplicationToEstimatorsService(IHttpClientFactory httpClientFactory, IRouteService routeService)
        {
            _client = httpClientFactory.CreateClient("ITProjectsManager");
            _routeService = routeService;
        }

        public async Task<ApplicationToEstimatorsDTO> CreateApplicationToEstimatorsAsync(ApplicationToEstimatorsDTO query)
        {
            return await _routeService.PostAsJsonAsync<ApplicationToEstimatorsDTO, ApplicationToEstimatorsDTO>(_client, "applicationtoestimatorsapi", query);
        }
    }
}