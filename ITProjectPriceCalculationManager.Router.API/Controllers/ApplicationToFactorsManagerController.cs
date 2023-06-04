using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.Router.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationToFactorsManagerController : ControllerBase
    {
        private readonly ILogger<ApplicationManagerController> _logger;
        private readonly IApplicationToFactorsService _applicationToFactorsService;

        public ApplicationToFactorsManagerController(ILogger<ApplicationManagerController> logger, IApplicationToFactorsService applicationToFactorsService)
        {
            _logger = logger;
            _applicationToFactorsService = applicationToFactorsService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateApplication(EvaluationApplicationDTO query)
        {
            return Ok(await _applicationToFactorsService.CreateApplicationToFactorsAsync(query));
        }
    }
}