using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EvaluationApiController : ControllerBase
    {
        private readonly IEvaluationService _evaluationService;

        public EvaluationApiController(IEvaluationService evaluationService)
        {
            _evaluationService = evaluationService;
        }

        [HttpGet]
        [Route("collection")]
        public async Task<IActionResult> GetAllEvaluations()
        {
            return Ok(await _evaluationService.GetEvaluationsAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetEvaluationById(Guid id)
        {
            return Ok(await _evaluationService.GetEvaluationsByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvaluation(EvaluationDTO evaluator)
        {
            return Ok(await _evaluationService.CreateEvaluationAsync(evaluator));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEvaluation(EvaluationDTO evaluation)
        {
            return Ok(await _evaluationService.UpdateEvaluationAsync(evaluation));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEvaluation(Guid id)
        {
            return Ok(await _evaluationService.DeleteEvaluationAsync(id));
        }
    }
}