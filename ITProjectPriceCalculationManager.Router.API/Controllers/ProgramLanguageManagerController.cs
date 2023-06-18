using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.Router.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProgramLanguageManagerController : ControllerBase
    {
        private readonly ILogger<EvaluatorManagerController> _logger;
        private readonly IProgramLanguageService _programLanguageService;

        public ProgramLanguageManagerController(ILogger<EvaluatorManagerController> logger, IProgramLanguageService programLanguageService)
        {
            _logger = logger;
            _programLanguageService = programLanguageService;
        }

        [HttpGet]
        [Route("collection")]
        public async Task<IActionResult> GetAllProgramLanguages()
        {
            return Ok(await _programLanguageService.GetProgramLanguagesAsync());
        }

        [HttpGet]
        [Route("collection/{applicationId}")]
        public async Task<IActionResult> GetAllProgramLanguagesByApplicationId([FromRoute] Guid applicationId)
        {
            return Ok(await _programLanguageService.GetAllProgramLanguagesByApplicationId(applicationId));
        }
    }
}