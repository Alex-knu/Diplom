using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.Router.API.Core.Services;

internal class BelongingFunctionService : IBelongingFunctionService
{
    private readonly HttpClient _evaluatorClient;
    private readonly IRouteService _routeService;

    public BelongingFunctionService(IHttpClientFactory httpClientFactory, IRouteService routeService)
    {
        _evaluatorClient = httpClientFactory.CreateClient("ITProjectsEvaluatorManager");
        _routeService = routeService;
    }

    public async Task<BelongingFunctionDTO> CreateBelongingFunctionAsync(BelongingFunctionDTO belongingFunction)
    {
        return await _routeService.PostAsJsonAsync<BelongingFunctionDTO, BelongingFunctionDTO>(_evaluatorClient, "belongingfunctionapi", belongingFunction);
    }

    public async Task<BelongingFunctionDTO> DeleteBelongingFunctionAsync(Guid id)
    {
        return await _routeService.DeleteAsJsonAsync<BelongingFunctionDTO, Guid>(_evaluatorClient, "belongingfunctionapi", id);
    }

    public async Task<BelongingFunctionDTO> GetBelongingFunctionByIdAsync(Guid id)
    {
        return await _routeService.GetByIdAsync<BelongingFunctionDTO, Guid>(_evaluatorClient, "belongingfunctionapi", id);
    }

    public async Task<IEnumerable<BelongingFunctionDTO>> GetBelongingFunctionAsync()
    {
        return await _routeService.GetAllAsync<List<BelongingFunctionDTO>>(_evaluatorClient, "belongingfunctionapi");
    }

    public async Task<BelongingFunctionDTO> UpdateBelongingFunctionAsync(BelongingFunctionDTO belongingFunction)
    {
        return await _routeService.PutAsJsonAsync<BelongingFunctionDTO, BelongingFunctionDTO>(_evaluatorClient, "belongingfunctionapi", belongingFunction);
    }
}