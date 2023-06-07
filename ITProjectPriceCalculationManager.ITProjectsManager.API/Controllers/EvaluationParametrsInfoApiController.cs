using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EvaluationParametrsInfoApiController : ControllerBase
    {
        private readonly IEvaluationParametrsInfoService _EvaluationParametrsInfoService;

        public EvaluationParametrsInfoApiController(IEvaluationParametrsInfoService evaluationParametrsInfoService)
        {
            _EvaluationParametrsInfoService = evaluationParametrsInfoService;
        }

        [HttpGet]
        [Route("collection")]
        public async Task<IActionResult> GetAllEvaluators()
        {
            return Ok(await _EvaluationParametrsInfoService.GetEvaluationAttributes());
        }
    }
}