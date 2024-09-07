using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces.ITProjectsManager;

namespace ITProjectPriceCalculationManager.Router.API.Core.Services.ITProjectsManager;

internal class EvaluationService : IEvaluationService
{
    private readonly HttpClient _client;
    private readonly IRouteService _routeService;

    public EvaluationService(IHttpClientFactory httpClientFactory, IRouteService routeService)
    {
        _client = httpClientFactory.CreateClient("ITProjectsManager");
        _routeService = routeService;
    }

    public async Task<EvaluationDTO> CreateEvaluationAsync(EvaluationDTO evaluation)
    {
        return await _routeService.PostAsJsonAsync<EvaluationDTO, EvaluationDTO>(_client, "evaluationapi", evaluation);
    }

    public async Task<EvaluationDTO> DeleteEvaluationAsync(Guid id)
    {
        return await _routeService.DeleteAsJsonAsync<EvaluationDTO, Guid>(_client, "evaluationapi", id);
    }

    public async Task<IEnumerable<EvaluationDTO>> GetEvaluationsAsync()
    {
        return await _routeService.GetAllAsync<List<EvaluationDTO>>(_client, "evaluationapi");
    }

    public async Task<EvaluationDTO> GetEvaluationsByIdAsync(Guid id)
    {
        return await _routeService.GetByIdAsync<EvaluationDTO, Guid>(_client, "evaluationapi", id);
    }

    public async Task<EvaluationDTO> UpdateEvaluationAsync(EvaluationDTO evaluation)
    {
        return await _routeService.PutAsJsonAsync<EvaluationDTO, EvaluationDTO>(_client, "evaluationapi", evaluation);
    }
}