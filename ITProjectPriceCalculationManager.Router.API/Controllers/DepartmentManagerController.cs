using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.Router.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentManagerController : ControllerBase
    {
        private readonly ILogger<DepartmentManagerController> _logger;
        private readonly HttpClient _client;
        private readonly IRouteService _routeService;

        public DepartmentManagerController(ILogger<DepartmentManagerController> logger, IHttpClientFactory httpClientFactory, IRouteService routeService)
        {
            _logger = logger;
            _client = httpClientFactory.CreateClient("ITProjectsManager");
            _routeService = routeService;
        }

        [HttpGet]
        [Route("collection")]
        public async Task<IActionResult> GetAllDepartments()
        {
            return Ok(await _routeService.GetAllAsync<List<DepartmentDTO>>(_client, "departmentapi"));
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            return Ok(await _routeService.GetByIdAsync<DepartmentDTO>(_client, "departmentapi", id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment(DepartmentDTO department)
        {
            return Ok(await _routeService.PostAsJsonAsync<DepartmentDTO, DepartmentDTO>(_client, "departmentapi", department));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDepartment(DepartmentDTO department)
        {
            return Ok(await _routeService.PutAsJsonAsync<DepartmentDTO, DepartmentDTO>(_client, "departmentapi", department));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            return Ok(await _routeService.DeleteAsJsonAsync<DepartmentDTO>(_client, "departmentapi", id));
        }
    }
}