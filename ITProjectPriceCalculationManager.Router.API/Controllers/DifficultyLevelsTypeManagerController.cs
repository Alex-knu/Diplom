using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.Router.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class DifficultyLevelsTypeManagerController : ControllerBase
{
    private readonly IDifficultyLevelsTypeService _difficultyLevelsTypeService;
    private readonly ILogger<DifficultyLevelsTypeManagerController> _logger;

    public DifficultyLevelsTypeManagerController(ILogger<DifficultyLevelsTypeManagerController> logger,
        IDifficultyLevelsTypeService difficultyLevelsTypeService)
    {
        _logger = logger;
        _difficultyLevelsTypeService = difficultyLevelsTypeService;
    }

    [HttpGet]
    [Route("collection/{id}")]
    public async Task<IActionResult> GetDifficultyLevelTypesForFactorType([FromRoute] Guid id)
    {
        return Ok(await _difficultyLevelsTypeService.GetDifficultyLevelTypesForFactorType(id));
    }
}