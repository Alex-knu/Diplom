using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RulesApiController : ControllerBase
{
    private readonly IRulesService _RulesService;

    public RulesApiController(IRulesService RulesService)
    {
        _RulesService = RulesService;
    }

    [HttpGet]
    [Route("collection")]
    public async Task<IActionResult> GetAllRuless()
    {
        return Ok(await _RulesService.GetRulesAsync());
    }

    [HttpGet]
    public async Task<IActionResult> GetRulesById(Guid id)
    {
        return Ok(await _RulesService.GetRulesByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateRules(RulesDTO query)
    {
        return Ok(await _RulesService.CreateRulesAsync(query));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateRules(RulesDTO query)
    {
        return Ok(await _RulesService.UpdateRulesAsync(query));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteRules(Guid id)
    {
        return Ok(await _RulesService.DeleteRulesAsync(id));
    }
}