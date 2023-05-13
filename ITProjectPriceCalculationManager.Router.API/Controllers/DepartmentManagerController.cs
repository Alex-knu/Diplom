using ITProjectPriceCalculationManager.DTOModels.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.Router.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentManagerController : ControllerBase
    {
        private readonly ILogger<DepartmentManagerController> _Logger;
        private readonly HttpClient _Client;

        public DepartmentManagerController(ILogger<DepartmentManagerController> logger, IHttpClientFactory httpClientFactory)
        {
            _Logger = logger;
            _Client = httpClientFactory.CreateClient("ITProjectsManager");
        }

        [HttpGet]
        [Route("collection")]
        public async Task<IActionResult> GetAllDepartments()
        {
            return Ok(await _Client.GetAsync<List<DepartmentDTO>>("api/departmentapi/collection"));
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            return Ok(await _Client.GetAsync<DepartmentDTO>("api/departmentapi"));
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment(DepartmentDTO department)
        {
            return Ok(await _Client.PostAsJsonAsync<DepartmentDTO, DepartmentDTO>("api/departmentapi", department));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDepartment(DepartmentDTO department)
        {
            return Ok(await _Client.PutAsJsonAsync<DepartmentDTO, DepartmentDTO>("api/departmentapi", department));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            return Ok(await _Client.DeleteAsJsonAsync<int, DepartmentDTO>("api/departmentapi", id));
        }
    }
}