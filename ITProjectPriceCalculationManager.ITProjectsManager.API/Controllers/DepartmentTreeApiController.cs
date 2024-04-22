using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentTreeApiController : ControllerBase
{
    private readonly IDepartmentTreeService _DepartmentTreeService;

    public DepartmentTreeApiController(IDepartmentTreeService departmentTreeService)
    {
        _DepartmentTreeService = departmentTreeService;
    }

    [HttpGet]
    [Route("collection")]
    public async Task<IActionResult> GetAllDepartments()
    {
        return Ok(await _DepartmentTreeService.GetDepartmentsTreeAsync());
    }
}