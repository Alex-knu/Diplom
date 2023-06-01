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

        public DepartmentApiController(IDepartmentService evaluatorService)
        {
            _DepartmentService = evaluatorService;
        }

        [HttpGet]
        [Route("collection")]
        public async Task<IActionResult> GetAllDepartments()
        {
            return Ok(await _DepartmentService.GetDepartmentsTreeAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartmentById(int id)
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