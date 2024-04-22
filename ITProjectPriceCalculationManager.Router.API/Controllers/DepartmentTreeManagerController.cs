using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.Router.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class DepartmentTreeManagerController : ControllerBase
{
    private readonly IDepartmentTreeService _departmentTreeService;
    private readonly ILogger<DepartmentTreeManagerController> _logger;

    public DepartmentTreeManagerController(ILogger<DepartmentTreeManagerController> logger,
        IDepartmentTreeService departmentTreeService)
    {
        _logger = logger;
        _departmentTreeService = departmentTreeService;
    }

    [HttpGet]
    [Route("collection")]
    public async Task<IActionResult> GetDepartmentsTreeAsync()
    {
        return Ok(await _departmentTreeService.GetDepartmentsTreeAsync());
    }
}