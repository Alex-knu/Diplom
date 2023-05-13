using ITProjectPriceCalculationManager.DTOModels.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ITProjectPriceCalculationManager.Extentions.Extentions;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.Router.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApplicationManagerController : ControllerBase
    {
        private readonly ILogger<ApplicationManagerController> _logger;
        private readonly HttpClient _client;
        private readonly IRouteService _routeService;

        public BaseApplicationManagerController(ILogger<ApplicationManagerController> logger, IHttpClientFactory httpClientFactory, IRouteService routeService)
        {
            _logger = logger;
            _client = httpClientFactory.CreateClient("ITProjectsManager");
            _routeService = routeService;
        }

        [HttpGet]
        [Route("collection")]
        public async Task<IActionResult> GetAllApplications()
        {
            return Ok(await _routeService.GetAllAsync<List<ApplicationDTO>>(_client, "baseapplicationapi"));
        }

        [HttpGet]
        public async Task<IActionResult> GetApplicationById(int id)
        {
            return Ok(await _routeService.GetByIdAsync<ApplicationDTO>(_client, "baseapplicationapi", id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateApplication(BaseApplicationDTO query)
        {
            var userInfo = JwtUtils.GetUserInfo(HttpContext);
            return Ok(await _routeService.PostAsJsonAsync<BaseApplicationDTO, ApplicationDTO>(_client, "baseapplicationapi", query));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateApplication(BaseApplicationDTO query)
        {
            return Ok(await _routeService.PutAsJsonAsync<BaseApplicationDTO, ApplicationDTO>(_client, "baseapplicationapi", query));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteApplication(int id)
        {
            return Ok(await _routeService.DeleteAsJsonAsync<ApplicationDTO>(_client, "baseapplicationapi", id));
        }
    }
}