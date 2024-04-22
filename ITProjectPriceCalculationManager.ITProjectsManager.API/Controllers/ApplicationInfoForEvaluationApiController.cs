using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApplicationInfoForEvaluationApiController : ControllerBase
{
    private readonly IApplicationInfoForEvaluationService _applicationInfoForEvaluationService;

    public ApplicationInfoForEvaluationApiController(
        IApplicationInfoForEvaluationService applicationInfoForEvaluationService)
    {
        _applicationInfoForEvaluationService = applicationInfoForEvaluationService;
    }


    [HttpGet]
    [Route("{applicationId}")]
    public async Task<IActionResult> GetApplicationById([FromRoute] Guid applicationId)
    {
        return Ok(await _applicationInfoForEvaluationService.GetForEvaluation(applicationId));
    }
}