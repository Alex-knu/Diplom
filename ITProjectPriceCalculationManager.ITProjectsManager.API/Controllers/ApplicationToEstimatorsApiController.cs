using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApplicationToEstimatorsApiController : ControllerBase
{
    private readonly IApplicationToEstimatorsService _ApplicationToEstimatorsService;

    public ApplicationToEstimatorsApiController(IApplicationToEstimatorsService applicationToEstimatorsService)
    {
        _ApplicationToEstimatorsService = applicationToEstimatorsService;
    }
    
    [HttpGet]
    [Route("collection/{applicationId}")]
    public async Task<IActionResult> GetEstimatorGroupByApplicationId([FromRoute] Guid applicationId)
    {
        return Ok(await _ApplicationToEstimatorsService.GetEstimatorGroupByApplicationId(applicationId));
    }

    [HttpPost]
    public async Task<IActionResult> CreateApplicationToEstimators(ApplicationToEstimatorsDTO query)
    {
        return Ok(await _ApplicationToEstimatorsService.CreateApplicationToEstimatorsAsync(query));
    }
}