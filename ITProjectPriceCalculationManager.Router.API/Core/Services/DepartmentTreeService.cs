using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.Router.API.Core.Services;

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