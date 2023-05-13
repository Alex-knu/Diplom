using ITProjectPriceCalculationManager.DTOModels.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ITProjectPriceCalculationManager.Extentions.Extentions;
using ITProjectPriceCalculationManager.Router.API.Core.Services;

namespace ITProjectPriceCalculationManager.Router.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApplicationManagerController : ControllerBase
    {
        private readonly ILogger<ApplicationManagerController> _logger;
        private readonly IConfiguration _config;
        private readonly HttpClient _client;

        public BaseApplicationManagerController(ILogger<ApplicationManagerController> logger, IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            _client = httpClientFactory.CreateClient("ITProjectsManager");
        }

        [HttpGet]
        [Route("collection")]
        public async Task<IActionResult> GetAllApplications()
        {
            return Ok(await RouteService.GetAllAsync<List<ApplicationDTO>>(_client, "baseapplicationapi"));
        }

        [HttpGet]
        public async Task<IActionResult> GetApplicationById(int id)
        {
            return Ok(await RouteService.GetByIdAsync<ApplicationDTO>(_client, "baseapplicationapi", id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateApplication(BaseApplicationDTO query)
        {
            var userInfo = JwtUtils.GetUserInfo(HttpContext);
            return Ok(await RouteService.PostAsJsonAsync<BaseApplicationDTO, ApplicationDTO>(_client, "baseapplicationapi", query));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateApplication(BaseApplicationDTO query)
        {
            return Ok(await RouteService.PutAsJsonAsync<BaseApplicationDTO, ApplicationDTO>(_client, "baseapplicationapi", query));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteApplication(int id)
        {
            return Ok(await RouteService.DeleteAsJsonAsync<ApplicationDTO>(_client, "baseapplicationapi", id));
        }
    }
}