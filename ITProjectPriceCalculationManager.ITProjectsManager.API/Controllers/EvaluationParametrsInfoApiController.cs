using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Services;
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
            _EvaluationParametrsInfoService= evaluationParametrsInfoService;
        }

        [HttpGet]
        [Route("collection")]
        public IActionResult GetAllEvaluators()
        {
            return Ok(_EvaluationParametrsInfoService.GetEvaluationAttributes());
        }
    }
}