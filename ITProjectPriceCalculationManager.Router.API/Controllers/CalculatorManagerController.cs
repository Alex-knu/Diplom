using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;
using ITProjectPriceCalculationManager.Router.API.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.Router.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorManagerController : ControllerBase
    {
        private readonly ILogger<CalculatorManagerController> _logger;
        private readonly ICalculatorService _calculatorService;

        public CalculatorManagerController(ILogger<CalculatorManagerController> logger, ICalculatorService calculatorService, IHttpClientFactory httpClientFactory, IRouteService routeService)
        {
            _logger = logger;
            _calculatorService = calculatorService;
        }

        [HttpPost]
        public async Task<IActionResult> CalculateApplicationPrice(CaculateRequestModel application)
        {
            return Ok(await _calculatorService.CalculateApplicationPriceAsync(application.ApplicationId));
        }
    }
}