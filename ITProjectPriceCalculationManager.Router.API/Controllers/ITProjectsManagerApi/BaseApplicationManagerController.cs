using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces.ITProjectsManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.Router.API.Controllers.ITProjectsManager;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class BaseApplicationManagerController : ControllerBase
{
    private readonly IBaseApplicationService _baseApplicationService;
    private readonly ILogger<ApplicationManagerController> _logger;

    public BaseApplicationManagerController(ILogger<ApplicationManagerController> logger,
        IBaseApplicationService baseApplicationService)
    {
        _logger = logger;
        _baseApplicationService = baseApplicationService;
    }

    [HttpGet]
    [Route("collection")]
    public async Task<IActionResult> GetBaseApplicationsAsync()
    {
        return Ok(await _baseApplicationService.GetBaseApplicationsAsync(HttpContext));
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetBaseApplicationsByIdAsync([FromRoute] Guid id)
    {
        return Ok(await _baseApplicationService.GetBaseApplicationsByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateBaseApplicationAsync(BaseApplicationDTO query)
    {
        return Ok(await _baseApplicationService.CreateBaseApplicationAsync(HttpContext, query));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBaseApplicationAsync(BaseApplicationDTO query)
    {
        return Ok(await _baseApplicationService.UpdateBaseApplicationAsync(query));
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteBaseApplicationAsync([FromRoute] Guid id)
    {
        return Ok(await _baseApplicationService.DeleteBaseApplicationAsync(id));
    }
}