using ITProjectPriceCalculationManager.DTOModels.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.Router.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EvaluatorManagerController : ControllerBase
    {private readonly ILogger<EvaluatorManagerController> _Logger;
        private readonly HttpClient _Client;

        public EvaluatorManagerController(ILogger<EvaluatorManagerController> logger, IHttpClientFactory httpClientFactory)
        {
            _Logger = logger;
            _Client = httpClientFactory.CreateClient("ITProjectsManager");
        }

        [HttpGet]
        [Route("collection")]
        public async Task<IActionResult> GetAllEvaluators()
        {
            return Ok(await _Client.GetAsync<List<EvaluatorDTO>>("api/evaluatorapi/collection"));
        }

        [HttpGet]
        public async Task<IActionResult> GetEvaluatorById(int id)
        {
            return Ok(await _Client.GetAsync<EvaluatorDTO>("api/evaluatorapi"));
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvaluator(EvaluatorDTO evaluator)
        {
            return Ok(await _Client.PostAsJsonAsync<EvaluatorDTO, EvaluatorDTO>("api/evaluatorapi", evaluator));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEvaluator(EvaluatorDTO evaluator)
        {
            return Ok(await _Client.PutAsJsonAsync<EvaluatorDTO, EvaluatorDTO>("api/evaluatorapi", evaluator));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEvaluator(int id)
        {
            return Ok(await _Client.DeleteAsJsonAsync<int, EvaluatorDTO>("api/evaluatorapi", id));
        }
    }
}