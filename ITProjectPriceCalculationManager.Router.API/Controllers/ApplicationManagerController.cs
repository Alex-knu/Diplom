using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces.ITProjectsManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.Router.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ApplicationManagerController : ControllerBase
{
    private readonly IApplicationService _applicationService;
    private readonly ILogger<ApplicationManagerController> _logger;

    public ApplicationManagerController(ILogger<ApplicationManagerController> logger,
        IApplicationService applicationService)
    {
        _logger = logger;
        _applicationService = applicationService;
    }

    [HttpGet]
    [Route("collection")]
    public async Task<IActionResult> GetAllApplications()
    {
        return Ok(await _applicationService.GetApplicationsAsync());
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetApplicationById([FromRoute] Guid id)
    {
        return Ok(await _applicationService.GetApplicationsByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateApplication(ApplicationDTO query)
    {
        return Ok(await _applicationService.CreateApplicationAsync(query));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateApplication(ApplicationDTO query)
    {
        return Ok(await _applicationService.UpdateApplicationAsync(query));
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteApplication([FromRoute] Guid id)
    {
        return Ok(await _applicationService.DeleteApplicationAsync(id));
    }
}