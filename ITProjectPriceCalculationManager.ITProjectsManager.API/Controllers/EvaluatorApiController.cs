using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EvaluatorApiController : ControllerBase
    {
        private readonly IEvaluatorService _EvaluatorService;

        public EvaluatorApiController(IEvaluatorService evaluatorService)
        {
            _EvaluatorService = evaluatorService;
        }

        [HttpGet]
        [Route("collection")]
        public async Task<IActionResult> GetAllEvaluators(List<Guid> userIds)
        {
            return Ok(await _EvaluatorService.GetEvaluatorsAsync(userIds));
        }

        [HttpGet]
        public async Task<IActionResult> GetEvaluatorById(Guid id)
        {
            return Ok(await _EvaluatorService.GetEvaluatorsByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvaluator(EvaluatorDTO evaluator)
        {
            return Ok(await _EvaluatorService.CreateEvaluatorAsync(evaluator));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEvaluator(EvaluatorDTO evaluation)
        {
            return Ok(await _EvaluatorService.UpdateEvaluatorAsync(evaluation));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEvaluator(Guid id)
        {
            return Ok(await _EvaluatorService.DeleteEvaluatorAsync(id));
        }
    }
}