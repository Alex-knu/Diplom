using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.Router.API.Core.Services;

internal class EvaluationParametrsInfoService : IEvaluationParametrsInfoService
{
    private readonly HttpClient _client;
    private readonly IRouteService _routeService;

    public EvaluationParametrsInfoService(IHttpClientFactory httpClientFactory, IRouteService routeService)
    {
        _client = httpClientFactory.CreateClient("ITProjectsManager");
        _routeService = routeService;
    }

    public async Task<IEnumerable<EvaluationParametrsInfoDTO>> GetEvaluationAttributes()
    {
        return await _routeService.GetAllAsync<List<EvaluationParametrsInfoDTO>>(_client, "evaluationparametrsinfoapi");
    }
}