using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProgramLanguageApiController : ControllerBase
{
    private readonly IProgramLanguageService _ProgramLanguageService;

    public ProgramLanguageApiController(IProgramLanguageService programLanguageService)
    {
        _ProgramLanguageService = programLanguageService;
    }

    [HttpGet]
    [Route("collection")]
    public async Task<IActionResult> GetAllProgramLanguages()
    {
        return Ok(await _ProgramLanguageService.GetProgramLanguagesAsync());
    }

    [HttpGet]
    [Route("collection/{applicationId}")]
    public async Task<IActionResult> GetAllProgramLanguagesByApplicationId([FromRoute] Guid applicationId)
    {
        return Ok(await _ProgramLanguageService.GetAllProgramLanguagesByApplicationId(applicationId));
    }
}