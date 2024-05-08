using ITProjectPriceCalculationManager.DTOModels.DTO;
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
    public async Task<IActionResult> CalulateAsync(List<EvaluationCompetentValueDTO> evaluationCompetentValues)//, List<EvaluateParameterDTO> evaluateParameters)
    {
        List<EvaluateParameterDTO> evaluateParameters = new();
        return Ok(await _evaluatorFuzzyCalculatorService.Calculate(evaluationCompetentValues, evaluateParameters));
    }
}