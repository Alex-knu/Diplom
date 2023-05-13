using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.Router.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EvaluatorManagerController : ControllerBase
    {
        private readonly ILogger<EvaluatorManagerController> _logger;
        private readonly HttpClient _client;
        private readonly IRouteService _routeService;

        public EvaluatorManagerController(ILogger<EvaluatorManagerController> logger, IHttpClientFactory httpClientFactory, IRouteService routeService)
        {
            _logger = logger;
            _client = httpClientFactory.CreateClient("ITProjectsManager");
            _routeService = routeService;
        }

        [HttpGet]
        [Route("collection")]
        public async Task<IActionResult> GetAllEvaluators()
        {
            return Ok(await _routeService.GetAllAsync<List<EvaluatorDTO>>(_client, "evaluatorapi"));
        }

        [HttpGet]
        public async Task<IActionResult> GetEvaluatorById(int id)
        {
            return Ok(await _routeService.GetByIdAsync<EvaluatorDTO>(_client, "evaluatorapi", id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvaluator(EvaluatorDTO evaluator)
        {
            return Ok(await _routeService.PostAsJsonAsync<EvaluatorDTO, EvaluatorDTO>(_client, "evaluatorapi", evaluator));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEvaluator(EvaluatorDTO evaluator)
        {
            return Ok(await _routeService.PutAsJsonAsync<EvaluatorDTO, EvaluatorDTO>(_client, "evaluatorapi", evaluator));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEvaluator(int id)
        {
            return Ok(await _routeService.DeleteAsJsonAsync<EvaluatorDTO>(_client, "evaluatorapi", id));
        }
    }
}