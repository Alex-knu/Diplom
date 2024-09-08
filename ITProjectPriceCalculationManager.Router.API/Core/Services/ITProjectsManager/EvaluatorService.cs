using ITProjectPriceCalculationManager.DTOModels.DTO.ITProjectsManager;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces.ITProjectsManager;

namespace ITProjectPriceCalculationManager.Router.API.Core.Services.ITProjectsManager;

internal class EvaluatorService : IEvaluatorService
{
    private readonly HttpClient _authClient;
    private readonly HttpClient _client;
    private readonly IRouteService _routeService;

    public EvaluatorService(IHttpClientFactory httpClientFactory, IRouteService routeService)
    {
        _authClient = httpClientFactory.CreateClient("AuthServer");
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

    public async Task<IEnumerable<EvaluatorDTO>> GetEvaluatorsAsync(HttpContext httpContext)
    {
        _authClient.DefaultRequestHeaders.Add("Authorization", httpContext.Request.Headers["Authorization"].ToString());
        var evaluatorIds = await _routeService.GetByIdAsync<List<Guid>, string>(_authClient, "user", "Evaluator");
        Console.WriteLine(evaluatorIds.Count());
        return await _routeService.GetAsJsonAsync<List<Guid>, List<EvaluatorDTO>>(_client, "evaluatorapi",
            evaluatorIds);
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