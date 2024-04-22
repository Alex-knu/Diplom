using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.Router.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class DepartmentManagerController : ControllerBase
{
    private readonly IDepartmentService _departmentService;
    private readonly ILogger<DepartmentManagerController> _logger;

    public DepartmentManagerController(ILogger<DepartmentManagerController> logger,
        IDepartmentService departmentService)
    {
        _logger = logger;
        _departmentService = departmentService;
    }

    [HttpGet]
    [Route("collection")]
    public async Task<IActionResult> GetAllDepartments()
    {
        return Ok(await _departmentService.GetDepartmentsAsync());
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetDepartmentById([FromRoute] Guid id)
    {
        return Ok(await _departmentService.GetDepartmentsByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateDepartment(DepartmentDTO department)
    {
        return Ok(await _departmentService.CreateDepartmentAsync(department));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateDepartment(DepartmentDTO department)
    {
        return Ok(await _departmentService.UpdateDepartmentAsync(department));
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteDepartment([FromRoute] Guid id)
    {
        return Ok(await _departmentService.DeleteDepartmentAsync(id));
    }
}