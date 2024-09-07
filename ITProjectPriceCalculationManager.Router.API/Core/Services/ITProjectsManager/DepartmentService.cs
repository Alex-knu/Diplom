using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces.ITProjectsManager;

namespace ITProjectPriceCalculationManager.Router.API.Core.Services.ITProjectsManager;

internal class DepartmentService : IDepartmentService
{
    private readonly HttpClient _client;
    private readonly IRouteService _routeService;

    public DepartmentService(IHttpClientFactory httpClientFactory, IRouteService routeService)
    {
        _client = httpClientFactory.CreateClient("ITProjectsManager");
        _routeService = routeService;
    }

    public async Task<DepartmentDTO> CreateDepartmentAsync(DepartmentDTO department)
    {
        return await _routeService.PostAsJsonAsync<DepartmentDTO, DepartmentDTO>(_client, "departmentapi", department);
    }

    public async Task<DepartmentDTO> DeleteDepartmentAsync(Guid id)
    {
        return await _routeService.DeleteAsJsonAsync<DepartmentDTO, Guid>(_client, "departmentapi", id);
    }

    public async Task<IEnumerable<DepartmentDTO>> GetDepartmentsAsync()
    {
        return await _routeService.GetAllAsync<List<DepartmentDTO>>(_client, "departmentapi");
    }

    public async Task<DepartmentDTO> GetDepartmentsByIdAsync(Guid id)
    {
        return await _routeService.GetByIdAsync<DepartmentDTO, Guid>(_client, "departmentapi", id);
    }

    public async Task<DepartmentDTO> UpdateDepartmentAsync(DepartmentDTO department)
    {
        return await _routeService.PutAsJsonAsync<DepartmentDTO, DepartmentDTO>(_client, "departmentapi", department);
    }
}