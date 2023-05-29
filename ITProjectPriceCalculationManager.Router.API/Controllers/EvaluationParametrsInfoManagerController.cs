using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.Router.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EvaluationParametrsInfoManagerController : ControllerBase
    {
        private readonly ILogger<EvaluationParametrsInfoManagerController> _logger;
        private readonly HttpClient _client;
        private readonly IRouteService _routeService;

        public EvaluationParametrsInfoManagerController(ILogger<EvaluationParametrsInfoManagerController> logger, IHttpClientFactory httpClientFactory, IRouteService routeService)
        {
            _logger = logger;
            _client = httpClientFactory.CreateClient("ITProjectsManager");
            _routeService = routeService;
        }

        [HttpGet]
        [Route("collection")]
        public async Task<IActionResult> GetAllEvaluationParametrsInfo()
        {
            return Ok(await _routeService.GetAllAsync<List<EvaluationParametrsInfoDTO>>(_client, "evaluationparametrsinfoapi"));
        }
    }
}