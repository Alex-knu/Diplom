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
        private readonly HttpClient _client;
        private readonly IRouteService _routeService;

        public ProgramLanguageManagerController(ILogger<EvaluatorManagerController> logger, IHttpClientFactory httpClientFactory, IRouteService routeService)
        {
            _logger = logger;
            _client = httpClientFactory.CreateClient("ITProjectsManager");
            _routeService = routeService;
        }

        [HttpGet]
        [Route("collection")]
        public async Task<IActionResult> GetAllProgramLanguages()
        {
            return Ok(await _routeService.GetAllAsync<List<ProgramLanguageDTO>>(_client, "programlanguageapi"));
        }
    }
}