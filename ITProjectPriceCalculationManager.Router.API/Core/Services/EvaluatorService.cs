using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.Router.API.Core.Services
{
    internal class EvaluatorService : IEvaluatorService
    {
        private readonly HttpClient _client;
        private readonly IRouteService _routeService;

        public EvaluatorService(IHttpClientFactory httpClientFactory, IRouteService routeService)
        {
            _client = httpClientFactory.CreateClient("ITProjectsManager");
            _routeService = routeService;
        }

        public async Task<EvaluatorDTO> CreateEvaluatorAsync(EvaluatorDTO evaluator)
        {
            return await _routeService.PostAsJsonAsync<EvaluatorDTO, EvaluatorDTO>(_client, "evaluatorapi", evaluator);
        }

        public async Task<EvaluatorDTO> DeleteEvaluatorAsync(Guid id)
        {
            return await _routeService.DeleteAsJsonAsync<EvaluatorDTO, Guid>(_client, "evaluatorapi", id);
        }

        public async Task<IEnumerable<EvaluatorDTO>> GetEvaluatorsAsync()
        {
            return await _routeService.GetAllAsync<List<EvaluatorDTO>>(_client, "evaluatorapi");
        }

        public async Task<EvaluatorDTO> GetEvaluatorsByIdAsync(Guid id)
        {
            return await _routeService.GetByIdAsync<EvaluatorDTO, Guid>(_client, "evaluatorapi", id);
        }

        public async Task<EvaluatorDTO> UpdateEvaluatorAsync(EvaluatorDTO evaluator)
        {
            return await _routeService.PutAsJsonAsync<EvaluatorDTO, EvaluatorDTO>(_client, "evaluatorapi", evaluator);
        }
    }
}