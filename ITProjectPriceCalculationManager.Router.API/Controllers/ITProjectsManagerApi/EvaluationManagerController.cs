using ITProjectPriceCalculationManager.DTOModels.DTO.ITProjectsManager;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces.ITProjectsManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.Router.API.Controllers.ITProjectsManager;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class EvaluationManagerController : ControllerBase
{
    private readonly IEvaluationService _evaluationService;
    private readonly ILogger<EvaluationManagerController> _logger;

    public EvaluationManagerController(ILogger<EvaluationManagerController> logger,
        IEvaluationService evaluationService)
    {
        _logger = logger;
        _evaluationService = evaluationService;
    }

    [HttpGet]
    [Route("collection")]
    public async Task<IActionResult> GetAllEvaluations()
    {
        return Ok(await _evaluationService.GetEvaluationsAsync());
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetEvaluationById([FromRoute] Guid id)
    {
        return Ok(await _evaluationService.GetEvaluationsByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateEvaluation(EvaluationDTO evaluation)
    {
        return Ok(await _evaluationService.CreateEvaluationAsync(evaluation));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateEvaluation(EvaluationDTO evaluation)
    {
        return Ok(await _evaluationService.CreateEvaluationAsync(evaluation));
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteEvaluation([FromRoute] Guid id)
    {
        return Ok(await _evaluationService.DeleteEvaluationAsync(id));
    }
}