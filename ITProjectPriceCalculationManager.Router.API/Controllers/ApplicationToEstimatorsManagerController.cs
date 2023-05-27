using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.Router.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationToEstimatorsManagerController : ControllerBase
    {
        private readonly ILogger<ApplicationManagerController> _logger;
        private readonly HttpClient _client;
        private readonly IRouteService _routeService;

        public ApplicationToEstimatorsManagerController(ILogger<ApplicationManagerController> logger, IHttpClientFactory httpClientFactory, IRouteService routeService)
        {
            _logger = logger;
            _client = httpClientFactory.CreateClient("ITProjectsManager");
            _routeService = routeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateApplication(ApplicationToEstimatorsDTO query)
        {
            return Ok(await _routeService.PostAsJsonAsync<ApplicationToEstimatorsDTO, ApplicationToEstimatorsDTO>(_client, "applicationtoestimatorsapi", query));
        }
    }
}