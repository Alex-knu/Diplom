using ITProjectPriceCalculationManager.DTOModels.DTO.ITProjectsManager;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces.ITProjectsManager;

namespace ITProjectPriceCalculationManager.Router.API.Core.Services.ITProjectsManager;

internal class ApplicationService : IApplicationService
{
    private readonly HttpClient _client;
    private readonly IRouteService _routeService;

    public ApplicationService(IHttpClientFactory httpClientFactory, IRouteService routeService)
    {
        _client = httpClientFactory.CreateClient("ITProjectsManager");
        _routeService = routeService;
    }

    public async Task<BaseApplicationDTO> CreateApplicationAsync(BaseApplicationDTO query)
    {
        return await _routeService.PostAsJsonAsync<BaseApplicationDTO, BaseApplicationDTO>(_client, "applicationapi", query);
    }

    public async Task<BaseApplicationDTO> DeleteApplicationAsync(Guid id)
    {
        return await _routeService.DeleteAsJsonAsync<BaseApplicationDTO, Guid>(_client, "applicationapi", id);
    }

    public async Task<IEnumerable<BaseApplicationDTO>> GetApplicationsAsync()
    {
        return await _routeService.GetAllAsync<List<BaseApplicationDTO>>(_client, "applicationapi");
    }

    public async Task<BaseApplicationDTO> GetApplicationsByIdAsync(Guid id)
    {
        return await _routeService.GetByIdAsync<BaseApplicationDTO, Guid>(_client, "applicationapi", id);
    }

    public async Task<BaseApplicationDTO> UpdateApplicationAsync(BaseApplicationDTO query)
    {
        return await _routeService.PutAsJsonAsync<BaseApplicationDTO, BaseApplicationDTO>(_client, "applicationapi", query);
    }
}