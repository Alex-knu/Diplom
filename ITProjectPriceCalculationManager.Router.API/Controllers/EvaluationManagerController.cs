using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.Router.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EvaluationManagerController : ControllerBase
    {
        private readonly ILogger<EvaluationManagerController> _logger;
        private readonly HttpClient _client;
        private readonly IRouteService _routeService;

        public EvaluationManagerController(ILogger<EvaluationManagerController> logger, IHttpClientFactory httpClientFactory, IRouteService routeService)
        {
            _logger = logger;
            _client = httpClientFactory.CreateClient("ITProjectsManager");
            _routeService = routeService;
        }

        [HttpGet]
        [Route("collection")]
        public async Task<IActionResult> GetAllEvaluations()
        {
            return Ok(await _routeService.GetAllAsync<List<EvaluationDTO>>(_client, "evaluationapi"));
        }

        [HttpGet]
        public async Task<IActionResult> GetEvaluationById(int id)
        {
            return Ok(await _routeService.GetByIdAsync<EvaluationDTO>(_client, "evaluationapi", id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvaluation(EvaluationDTO evaluator)
        {
            return Ok(await _routeService.PostAsJsonAsync<EvaluationDTO, EvaluationDTO>(_client, "evaluationapi", evaluator));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEvaluation(EvaluationDTO evaluator)
        {
            return Ok(await _routeService.PutAsJsonAsync<EvaluationDTO, EvaluationDTO>(_client, "evaluationapi", evaluator));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEvaluation(int id)
        {
            return Ok(await _routeService.DeleteAsJsonAsync<EvaluationDTO>(_client, "evaluationapi", id));
        }
    }
}