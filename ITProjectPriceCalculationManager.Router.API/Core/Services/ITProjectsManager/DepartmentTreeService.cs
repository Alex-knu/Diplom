using ITProjectPriceCalculationManager.DTOModels.DTO.ITProjectsManager;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces.ITProjectsManager;

namespace ITProjectPriceCalculationManager.Router.API.Core.Services.ITProjectsManager;

internal class DepartmentTreeService : IDepartmentTreeService
{
    private readonly HttpClient _client;
    private readonly IRouteService _routeService;

    public DepartmentTreeService(IHttpClientFactory httpClientFactory, IRouteService routeService)
    {
        _client = httpClientFactory.CreateClient("ITProjectsManager");
        _routeService = routeService;
    }

    public async Task<IEnumerable<DepartmentDTO>> GetDepartmentsTreeAsync()
    {
        return await _routeService.GetAllAsync<List<DepartmentDTO>>(_client, "departmenttreeapi");
    }
}