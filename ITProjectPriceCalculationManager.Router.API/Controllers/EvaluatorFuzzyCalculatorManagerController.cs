using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;
using ITProjectPriceCalculationManager.Router.API.Core.Models;
using Microsoft.AspNetCore.Authorization;
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
    public async Task<IActionResult> CalculateApplicationPrice(List<EvaluationCompetentValueDTO> evaluationCompetentValues)
    {
        List<EvaluateParameterDTO> evaluateParameters = new();
        return Ok(await _calculatorService.Calculate(evaluationCompetentValues, evaluateParameters));
    }
}