using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.ITProjectsCalculator.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EvaluatorFuzzyCalculatorApiController : ControllerBase
{
    private readonly ICalculateService _calculateService;
    private readonly ILogger<EvaluatorFuzzyCalculatorApiController> _logger;

    public EvaluatorFuzzyCalculatorApiController(ILogger<EvaluatorFuzzyCalculatorApiController> logger, ICalculateService calculatorService)
    {
        _logger = logger;
        _calculateService = calculatorService;
    }

    [HttpPost]
    public async Task<IActionResult> CalulateAsync(EvaluationDTO evaluation)
    {
        return Ok(await _calculateService.Calculate(evaluation));
    }
}