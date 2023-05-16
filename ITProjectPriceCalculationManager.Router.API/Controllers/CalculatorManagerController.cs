using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;
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
        private readonly HttpClient _client;
        private readonly IRouteService _routeService;

        public CalculatorManagerController(ILogger<CalculatorManagerController> logger, IHttpClientFactory httpClientFactory, IRouteService routeService)
        {
            _logger = logger;
            _client = httpClientFactory.CreateClient("ITProjectsCalculator");
            _routeService = routeService;
        }

        [HttpPost]
        public async Task<IActionResult> CalculateApplicationPrice(EvaluationDTO query)
        {
            return Ok(await _routeService.PostAsJsonAsync<EvaluationDTO, EvaluationResultDTO>(_client, "calculateapi", query));
        }
    }
}