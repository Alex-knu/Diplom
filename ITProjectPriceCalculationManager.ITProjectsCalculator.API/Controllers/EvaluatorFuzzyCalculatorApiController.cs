using ITProjectPriceCalculationManager.DTOModels.DTO.FuzzyLogic;
using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.ITProjectsCalculator.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EvaluatorFuzzyCalculatorApiController : ControllerBase
{
    private readonly IEvaluatorFuzzyCalculatorService _evaluatorFuzzyCalculatorService;
    private readonly ILogger<EvaluatorFuzzyCalculatorApiController> _logger;

    public EvaluatorFuzzyCalculatorApiController(ILogger<EvaluatorFuzzyCalculatorApiController> logger, IEvaluatorFuzzyCalculatorService evaluatorFuzzyCalculatorService)
    {
        _logger = logger;
        _evaluatorFuzzyCalculatorService = evaluatorFuzzyCalculatorService;
    }

    [HttpPost]
    public async Task<IActionResult> CalulateAsync(EvaluatorFuzzyQueryDTO evaluatorFuzzyQuery)
    {
        return Ok(await _evaluatorFuzzyCalculatorService.Calculate(evaluatorFuzzyQuery));
    }
}