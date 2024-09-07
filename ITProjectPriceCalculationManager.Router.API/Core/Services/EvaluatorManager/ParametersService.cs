using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces.EvaluatorManager;

namespace ITProjectPriceCalculationManager.Router.API.Core.Services.EvaluatorManager;

internal class ParametersService : IParametersService
{
    private readonly HttpClient _evaluatorClient;
    private readonly IRouteService _routeService;

    public ParametersService(IHttpClientFactory httpClientFactory, IRouteService routeService)
    {
        _evaluatorClient = httpClientFactory.CreateClient("ITProjectsEvaluatorManager");
        _routeService = routeService;
    }

    public async Task<ParametersDTO> CreateParametersAsync(ParametersDTO parameter)
    {
        return await _routeService.PostAsJsonAsync<ParametersDTO, ParametersDTO>(_evaluatorClient, "parametersapi", parameter);
    }

    public async Task<ParametersDTO> DeleteParametersAsync(Guid id)
    {
        return await _routeService.DeleteAsJsonAsync<ParametersDTO, Guid>(_evaluatorClient, "parametersapi", id);
    }

    public async Task<ParametersDTO> GetParametersByIdAsync(Guid id)
    {
        return await _routeService.GetByIdAsync<ParametersDTO, Guid>(_evaluatorClient, "parametersapi", id);
    }

    public async Task<IEnumerable<ParametersDTO>> GetParametersAsync()
    {
        return await _routeService.GetAllAsync<List<ParametersDTO>>(_evaluatorClient, "parametersapi");
    }

    public async Task<IEnumerable<ParametersDTO>> GetParameterByApplicationIdAsync(Guid applicationId)
    {
        return await _routeService.GetListByIdAsync<List<ParametersDTO>, Guid>(_evaluatorClient, "parametersapi", applicationId);
    }

    public async Task<ParametersDTO> UpdateParametersAsync(ParametersDTO parameter)
    {
        return await _routeService.PutAsJsonAsync<ParametersDTO, ParametersDTO>(_evaluatorClient, "parametersapi", parameter);
    }
}