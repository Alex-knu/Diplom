using ITProjectPriceCalculationManager.DTOModels.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.Router.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApplicationManagerController : ControllerBase
    {
        private readonly ILogger<ApplicationManagerController> _Logger;
        private readonly HttpClient _Client;

        public BaseApplicationManagerController(ILogger<ApplicationManagerController> logger, IHttpClientFactory httpClientFactory)
        {
            _Logger = logger;
            _Client = httpClientFactory.CreateClient("ITProjectsManager");
        }

        [HttpGet]
        [Route("collection")]
        public async Task<IActionResult> GetAllApplications()
        {
            return Ok(await _Client.GetAsync<List<ApplicationDTO>>("api/baseapplicationapi/collection"));
        }

        [HttpGet]
        public async Task<IActionResult> GetApplicationById(int id)
        {
            return Ok(await _Client.GetAsync<ApplicationDTO>("api/baseapplicationapi"));
        }

        [HttpPost]
        public async Task<IActionResult> CreateApplication(BaseApplicationDTO query)
        {
            return Ok(await _Client.PostAsJsonAsync<BaseApplicationDTO, ApplicationDTO>("api/baseapplicationapi", query));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateApplication(BaseApplicationDTO query)
        {
            return Ok(await _Client.PutAsJsonAsync<BaseApplicationDTO, ApplicationDTO>("api/baseapplicationapi", query));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteApplication(int id)
        {
            return Ok(await _Client.DeleteAsJsonAsync<int, ApplicationDTO>("api/baseapplicationapi", id));
        }
        
    }
}