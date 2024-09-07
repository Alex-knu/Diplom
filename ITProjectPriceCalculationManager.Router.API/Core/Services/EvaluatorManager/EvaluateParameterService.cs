using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces.EvaluatorManager;

namespace ITProjectPriceCalculationManager.Router.API.Core.Services.EvaluatorManager;

internal class EvaluateParameterService : IEvaluateParameterService
{
    private readonly HttpClient _evaluatorClient;
    private readonly IRouteService _routeService;

    public EvaluateParameterService(IHttpClientFactory httpClientFactory, IRouteService routeService)
    {
        _evaluatorClient = httpClientFactory.CreateClient("ITProjectsEvaluatorManager");
        _routeService = routeService;
    }

    public async Task<EvaluateParameterDTO> CreateEvaluateParameterAsync(EvaluateParameterDTO evaluateParameter)
    {
        return await _routeService.PostAsJsonAsync<EvaluateParameterDTO, EvaluateParameterDTO>(_evaluatorClient, "evaluateparameterapi", evaluateParameter);
    }

    public async Task<EvaluateParameterDTO> DeleteEvaluateParameterAsync(Guid id)
    {
        return await _routeService.DeleteAsJsonAsync<EvaluateParameterDTO, Guid>(_evaluatorClient, "evaluateparameterapi", id);
    }

    public async Task<IEnumerable<EvaluateParameterDTO>> GetEvaluateParametersByParameterIdAsync(Guid parameterId)
    {
        return await _routeService.GetListByIdAsync<List<EvaluateParameterDTO>, Guid>(_evaluatorClient, "evaluateparameterapi", parameterId);
    }

    public async Task<IEnumerable<EvaluateParameterDTO>> GetEvaluateParameterAsync()
    {
        return await _routeService.GetAllAsync<List<EvaluateParameterDTO>>(_evaluatorClient, "evaluateparameterapi");
    }

    public async Task<EvaluateParameterDTO> GetEvaluateParameterByIdAsync(Guid id)
    {
        return await _routeService.GetByIdAsync<EvaluateParameterDTO, Guid>(_evaluatorClient, "evaluateparameterapi", id);
    }

    public async Task<EvaluateParameterDTO> UpdateEvaluateParameterAsync(EvaluateParameterDTO evaluateParameter)
    {
        return await _routeService.PutAsJsonAsync<EvaluateParameterDTO, EvaluateParameterDTO>(_evaluatorClient, "evaluateparameterapi", evaluateParameter);
    }
}