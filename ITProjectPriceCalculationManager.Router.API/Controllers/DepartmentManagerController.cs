using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Router.API.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.Router.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DepartmentManagerController : ControllerBase
    {
        private readonly ILogger<DepartmentManagerController> _Logger;
        private readonly HttpClient _client;

        public DepartmentManagerController(ILogger<DepartmentManagerController> logger, IHttpClientFactory httpClientFactory)
        {
            _Logger = logger;
            _client = httpClientFactory.CreateClient("ITProjectsManager");
        }

        [HttpGet]
        [Route("collection")]
        public async Task<IActionResult> GetAllDepartments()
        {
            return Ok(await RouteService.GetAllAsync<List<DepartmentDTO>>(_client, "departmentapi"));
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            return Ok(await RouteService.GetByIdAsync<DepartmentDTO>(_client, "departmentapi", id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment(DepartmentDTO department)
        {
            return Ok(await RouteService.PostAsJsonAsync<DepartmentDTO, DepartmentDTO>(_client, "departmentapi", department));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDepartment(DepartmentDTO department)
        {
            return Ok(await RouteService.PutAsJsonAsync<DepartmentDTO, DepartmentDTO>(_client, "departmentapi", department));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            return Ok(await RouteService.DeleteAsJsonAsync<DepartmentDTO>(_client, "departmentapi", id));
        }
    }
}