using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.Router.API.Core.Services;

internal class ApplicationService : IApplicationService
{
    private readonly HttpClient _client;
    private readonly IRouteService _routeService;

    public ApplicationService(IHttpClientFactory httpClientFactory, IRouteService routeService)
    {
        _client = httpClientFactory.CreateClient("ITProjectsManager");
        _routeService = routeService;
    }

    public async Task<ApplicationDTO> CreateApplicationAsync(ApplicationDTO query)
    {
        return await _routeService.PostAsJsonAsync<ApplicationDTO, ApplicationDTO>(_client, "applicationapi", query);
    }

    public async Task<ApplicationDTO> DeleteApplicationAsync(Guid id)
    {
        return await _routeService.DeleteAsJsonAsync<ApplicationDTO, Guid>(_client, "applicationapi", id);
    }

    public async Task<IEnumerable<ApplicationDTO>> GetApplicationsAsync()
    {
        return await _routeService.GetAllAsync<List<ApplicationDTO>>(_client, "applicationapi");
    }

    public async Task<ApplicationDTO> GetApplicationsByIdAsync(Guid id)
    {
        return await _routeService.GetByIdAsync<ApplicationDTO, Guid>(_client, "applicationapi", id);
    }

    public async Task<ApplicationDTO> UpdateApplicationAsync(ApplicationDTO query)
    {
        return await _routeService.PutAsJsonAsync<ApplicationDTO, ApplicationDTO>(_client, "applicationapi", query);
    }
}