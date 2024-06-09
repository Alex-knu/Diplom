using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.Router.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EvaluatorFuzzyCalculatorManagerController : ControllerBase
{
    private readonly IEvaluatorFuzzyCalculatorService _calculatorService;
    private readonly ILogger<EvaluatorFuzzyCalculatorManagerController> _logger;

    public EvaluatorFuzzyCalculatorManagerController(ILogger<EvaluatorFuzzyCalculatorManagerController> logger,
        IEvaluatorFuzzyCalculatorService calculatorService, IHttpClientFactory httpClientFactory, IRouteService routeService)
    {
        _logger = logger;
        _calculatorService = calculatorService;
    }

    [HttpPost]
    public async Task<IActionResult> CalculateApplicationPrice(CalculateConfidenceAreaDTO evaluatorFuzzyQuery)
    {
        return Ok(await _calculatorService.Calculate(evaluatorFuzzyQuery));
    }
}