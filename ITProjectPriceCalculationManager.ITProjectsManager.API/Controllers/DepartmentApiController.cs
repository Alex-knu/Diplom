using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentApiController : ControllerBase
    {
        private readonly IDepartmentService _DepartmentService;

        public DepartmentApiController(IDepartmentService departmentService)
        {
            _DepartmentService = departmentService;
        }

        [HttpGet]
        [Route("collection")]
        public async Task<IActionResult> GetAllDepartments()
        {
            return Ok(await _DepartmentService.GetDepartmentsAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetDepartmentById([FromRoute]int id)
        {
            return Ok(await _DepartmentService.GetDepartmentsByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment(DepartmentDTO evaluator)
        {
            return Ok(await _DepartmentService.CreateDepartmentAsync(evaluator));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDepartment(DepartmentDTO evaluation)
        {
            return Ok(await _DepartmentService.UpdateDepartmentAsync(evaluation));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            return Ok(await _DepartmentService.DeleteDepartmentAsync(id));
        }
    }
}