using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationToFactorsApiController : ControllerBase
    {
        private readonly IApplicationToFactorsService _ApplicationToFactorsService;

        public ApplicationToFactorsApiController(IApplicationToFactorsService applicationToFactorsService)
        {
            _ApplicationToFactorsService = applicationToFactorsService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateApplicationToFactors(EvaluationApplicationDTO query)
        {
            return Ok(await _ApplicationToFactorsService.CreateApplicationToFactorsAsync(query));
        }
    }
}