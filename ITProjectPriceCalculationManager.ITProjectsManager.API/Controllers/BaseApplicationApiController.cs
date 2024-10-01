using ITProjectPriceCalculationManager.DTOModels.DTO.ITProjectsManager;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseApplicationApiController : ControllerBase
{
    private readonly IBaseApplicationService _baseApplicationService;

    public BaseApplicationApiController(IBaseApplicationService baseApplicationService)
    {
        _baseApplicationService = baseApplicationService;
    }

    [HttpGet]
    [Route("collection")]
    public async Task<IActionResult> GetAllApplications()
    {
        return Ok(await _baseApplicationService.GetBaseApplicationsAsync(HttpContext));
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetApplicationById([FromRoute] Guid id)
    {
        return Ok(await _baseApplicationService.GetBaseApplicationsByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateApplication(BaseApplicationDTO query)
    {
        return Ok(await _baseApplicationService.CreateBaseApplicationAsync(query));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateApplication(BaseApplicationDTO query)
    {
        return Ok(await _baseApplicationService.UpdateBaseApplicationAsync(query));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteApplication([FromBody] Guid id)
    {
        return Ok(await _baseApplicationService.DeleteBaseApplicationAsync(id));
    }
}