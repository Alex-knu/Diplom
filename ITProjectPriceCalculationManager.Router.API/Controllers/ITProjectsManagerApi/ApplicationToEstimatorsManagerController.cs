using ITProjectPriceCalculationManager.DTOModels.DTO.ITProjectsManager;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces.ITProjectsManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.Router.API.Controllers.ITProjectsManagerApi;

//[Authorize]
[ApiController]
[Route("api/itprojectsmanager/[controller]")]
public class ApplicationToEstimatorsManagerController : ControllerBase
{
    private readonly IApplicationToEstimatorsService _applicationToEstimatorsService;
    private readonly ILogger<ApplicationManagerController> _logger;

    public ApplicationToEstimatorsManagerController(ILogger<ApplicationManagerController> logger,
        IApplicationToEstimatorsService applicationToEstimatorsService)
    {
        _logger = logger;
        _applicationToEstimatorsService = applicationToEstimatorsService;
    }
    
    [HttpGet]
    [Route("collection/{applicationId}")]
    public async Task<IActionResult> GetEstimatorGroupByApplicationId([FromRoute] Guid applicationId)
    {
        return Ok(await _applicationToEstimatorsService.GetEstimatorGroupByApplicationId(applicationId));
    }

    [HttpPost]
    public async Task<IActionResult> CreateApplication(ApplicationToEstimatorsDTO query)
    {
        return Ok(await _applicationToEstimatorsService.CreateApplicationToEstimatorsAsync(query));
    }
}