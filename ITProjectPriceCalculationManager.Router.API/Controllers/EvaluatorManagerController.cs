using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.Router.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EvaluatorManagerController : ControllerBase
    {
        private readonly ILogger<EvaluatorManagerController> _logger;
        private readonly IEvaluatorService _evaluatorService;

        public EvaluatorManagerController(ILogger<EvaluatorManagerController> logger, IEvaluatorService evaluatorService)
        {
            _logger = logger;
            _evaluatorService = evaluatorService;
        }

        [HttpGet]
        [Route("collection")]
        public async Task<IActionResult> GetAllEvaluators()
        {
            return Ok(await _evaluatorService.GetEvaluatorsAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetEvaluatorById([FromRoute]Guid id)
        {
            return Ok(await _evaluatorService.GetEvaluatorsByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvaluator(EvaluatorDTO evaluator)
        {
            return Ok(await _evaluatorService.CreateEvaluatorAsync(evaluator));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEvaluator(EvaluatorDTO evaluator)
        {
            return Ok(await _evaluatorService.UpdateEvaluatorAsync(evaluator));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteEvaluator([FromRoute]Guid id)
        {
            return Ok(await _evaluatorService.DeleteEvaluatorAsync(id));
        }
    }
}