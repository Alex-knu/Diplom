using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.Router.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationManagerController : ControllerBase
    {
        private readonly ILogger<ApplicationManagerController> _logger;
        private readonly HttpClient _client;
        private readonly IRouteService _routeService;

        public ApplicationManagerController(ILogger<ApplicationManagerController> logger, IHttpClientFactory httpClientFactory, IRouteService routeService)
        {
            _logger = logger;
            _client = httpClientFactory.CreateClient("ITProjectsManager");
            _routeService = routeService;
        }

        [HttpGet]
        [Route("collection")]
        public async Task<IActionResult> GetAllApplications()
        {
            return Ok(await _routeService.GetAllAsync<List<ApplicationDTO>>(_client, "applicationapi"));
        }

        [HttpGet]
        public async Task<IActionResult> GetApplicationById(int id)
        {
            return Ok(await _routeService.GetByIdAsync<ApplicationDTO>(_client, "applicationapi", id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateApplication(ApplicationDTO query)
        {
            return Ok(await _routeService.PostAsJsonAsync<ApplicationDTO, ApplicationDTO>(_client, "applicationapi", query));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateApplication(ApplicationDTO query)
        {
            return Ok(await _routeService.PutAsJsonAsync<ApplicationDTO, ApplicationDTO>(_client, "applicationapi", query));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteApplication(int id)
        {
            return Ok(await _routeService.DeleteAsJsonAsync<ApplicationDTO>(_client, "applicationapi", id));
        }
    }
}