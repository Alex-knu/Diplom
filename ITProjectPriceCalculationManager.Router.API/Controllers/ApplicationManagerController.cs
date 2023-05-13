using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Router.API.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.Router.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ApplicationManagerController : ControllerBase
    {
        private readonly ILogger<ApplicationManagerController> _Logger;
        private readonly HttpClient _client;

        public ApplicationManagerController(ILogger<ApplicationManagerController> logger, IHttpClientFactory httpClientFactory)
        {
            _Logger = logger;
            _client = httpClientFactory.CreateClient("ITProjectsManager");
        }

        [HttpGet]
        [Route("collection")]
        public async Task<IActionResult> GetAllApplications()
        {
            return Ok(await RouteService.GetAllAsync<List<ApplicationDTO>>(_client, "applicationapi"));
        }

        [HttpGet]
        public async Task<IActionResult> GetApplicationById(int id)
        {
            return Ok(await RouteService.GetByIdAsync<ApplicationDTO>(_client, "applicationapi", id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateApplication(ApplicationDTO query)
        {
            return Ok(await RouteService.PostAsJsonAsync<ApplicationDTO, ApplicationDTO>(_client, "applicationapi", query));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateApplication(ApplicationDTO query)
        {
            return Ok(await RouteService.PutAsJsonAsync<ApplicationDTO, ApplicationDTO>(_client, "applicationapi", query));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteApplication(int id)
        {
            return Ok(await RouteService.DeleteAsJsonAsync<ApplicationDTO>(_client, "applicationapi", id));
        }
    }
}