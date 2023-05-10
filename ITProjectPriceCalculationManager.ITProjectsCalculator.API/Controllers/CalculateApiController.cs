using Microsoft.AspNetCore.Mvc;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Interfaces.Services;

namespace ITProjectPriceCalculationManager.ITProjectsCalculator.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculateApiController : ControllerBase
    {
        private readonly ILogger<CalculateApiController> _logger;
        private readonly ICalculateService _calculateService;

        public CalculateApiController(ILogger<CalculateApiController> logger, ICalculateService calculatorService)
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
}