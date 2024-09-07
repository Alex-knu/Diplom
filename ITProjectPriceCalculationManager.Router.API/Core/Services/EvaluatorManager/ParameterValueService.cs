using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces.EvaluatorManager;

namespace ITProjectPriceCalculationManager.Router.API.Core.Services.EvaluatorManager;

internal class ParameterValueService : IParameterValueService
{
    private readonly HttpClient _evaluatorClient;
    private readonly IRouteService _routeService;

    public ParameterValueService(IHttpClientFactory httpClientFactory, IRouteService routeService)
    {
        _evaluatorClient = httpClientFactory.CreateClient("ITProjectsEvaluatorManager");
        _routeService = routeService;
    }

    public async Task<ParameterValueDTO> CreateParameterValueAsync(ParameterValueDTO parameterValue)
    {
        return await _routeService.PostAsJsonAsync<ParameterValueDTO, ParameterValueDTO>(_evaluatorClient, "parametervalueapi", parameterValue);
    }

    public async Task<ParameterValueDTO> DeleteParameterValueAsync(Guid id)
    {
        return await _routeService.DeleteAsJsonAsync<ParameterValueDTO, Guid>(_evaluatorClient, "parametervalueapi", id);
    }

    public async Task<ParameterValueDTO> GetParameterValueByIdAsync(Guid id)
    {
        return await _routeService.GetByIdAsync<ParameterValueDTO, Guid>(_evaluatorClient, "parametervalueapi", id);
    }

    public async Task<IEnumerable<ParameterValueDTO>> GetParameterValueAsync()
    {
        return await _routeService.GetAllAsync<List<ParameterValueDTO>>(_evaluatorClient, "parametervalueapi");
    }

    public async Task<ParameterValueDTO> GetParameterValuesByIdAsync(Guid id)
    {
        return await _routeService.GetByIdAsync<ParameterValueDTO, Guid>(_evaluatorClient, "parametervalueapi", id);
    }

    public async Task<ParameterValueDTO> UpdateParameterValueAsync(ParameterValueDTO parameterValue)
    {
        return await _routeService.PutAsJsonAsync<ParameterValueDTO, ParameterValueDTO>(_evaluatorClient, "parametervalueapi", parameterValue);
    }
}