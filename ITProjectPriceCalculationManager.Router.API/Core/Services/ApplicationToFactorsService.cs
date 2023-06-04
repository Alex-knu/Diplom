using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.Router.API.Core.Services
{
    internal class ApplicationToFactorsService : IApplicationToFactorsService
    {
        private readonly HttpClient _client;
        private readonly IRouteService _routeService;

        public ApplicationToFactorsService(IHttpClientFactory httpClientFactory, IRouteService routeService)
        {
            _client = httpClientFactory.CreateClient("ITProjectsManager");
            _routeService = routeService;
        }

        public async Task<EvaluationApplicationDTO> CreateApplicationToFactorsAsync(EvaluationApplicationDTO query)
        {
            return await _routeService.PostAsJsonAsync<EvaluationApplicationDTO, EvaluationApplicationDTO>(_client, "applicationtofactorsapi", query);
        }
    }
}