using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.Router.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class EvaluationParametrsInfoManagerController : ControllerBase
{
    private readonly IEvaluationParametrsInfoService _evaluationParametrsInfoService;
    private readonly ILogger<EvaluationParametrsInfoManagerController> _logger;

    public EvaluationParametrsInfoManagerController(ILogger<EvaluationParametrsInfoManagerController> logger,
        IEvaluationParametrsInfoService evaluationParametrsInfoService)
    {
        _logger = logger;
        _evaluationParametrsInfoService = evaluationParametrsInfoService;
    }

    [HttpGet]
    [Route("collection")]
    public async Task<IActionResult> GetAllEvaluationParametrsInfo()
    {
        return Ok(await _evaluationParametrsInfoService.GetEvaluationAttributes());
    }
}