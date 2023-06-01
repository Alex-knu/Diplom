using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.Router.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DifficultyLevelsTypeManagerController : ControllerBase
    {
        private readonly ILogger<DifficultyLevelsTypeManagerController> _logger;
        private readonly HttpClient _client;
        private readonly IRouteService _routeService;

        public DifficultyLevelsTypeManagerController(ILogger<DifficultyLevelsTypeManagerController> logger, IHttpClientFactory httpClientFactory, IRouteService routeService)
        {
            _logger = logger;
            _client = httpClientFactory.CreateClient("ITProjectsManager");
            _routeService = routeService;
        }

        [HttpGet]
        [Route("collection/{id}")]
        public async Task<IActionResult> GetAllApplications([FromRoute]int id)
        {
            return Ok(await _routeService.GetListByIdAsync<List<DifficultyLevelsTypeDTO>>(_client, "difficultylevelstypeapi", id));
        }
    }
}