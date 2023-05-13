using ITProjectPriceCalculationManager.DTOModels.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ITProjectPriceCalculationManager.Extentions.Extentions;

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
            return Ok(await _client.GetAsync<List<ApplicationDTO>>("api/baseapplicationapi/collection"));
        }

        [HttpGet]
        public async Task<IActionResult> GetApplicationById(int id)
        {
            return Ok(await _client.GetAsync<ApplicationDTO>("api/baseapplicationapi"));
        }

        [HttpPost]
        public async Task<IActionResult> CreateApplication(BaseApplicationDTO query)
        {
            var userInfo = JwtUtils.GetUserInfo(HttpContext);
            return Ok(await _client.PostAsJsonAsync<BaseApplicationDTO, ApplicationDTO>("api/baseapplicationapi", query));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateApplication(BaseApplicationDTO query)
        {
            return Ok(await _client.PutAsJsonAsync<BaseApplicationDTO, ApplicationDTO>("api/baseapplicationapi", query));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteApplication(int id)
        {
            return Ok(await _client.DeleteAsJsonAsync<int, ApplicationDTO>("api/baseapplicationapi", id));
        }

    }
}