using ITProjectPriceCalculationManager.DTOModels.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.Router.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationManagerController : ControllerBase
    {
        private readonly ILogger<ApplicationManagerController> _Logger;
        private readonly HttpClient _Client;

        public ApplicationManagerController(ILogger<ApplicationManagerController> logger, IHttpClientFactory httpClientFactory)
        {
            _Logger = logger;
            _Client = httpClientFactory.CreateClient("ITProjectsManager");
        }

        [HttpGet]
        [Route("collection")]
        public async Task<IActionResult> GetAllApplications()
        {
            return Ok(await _Client.GetAsync<List<ApplicationDTO>>("api/applicationapi/collection"));
        }

        [HttpGet]
        public async Task<IActionResult> GetApplicationById(int id)
        {
            return Ok(await _Client.GetAsync<ApplicationDTO>("api/applicationapi"));
        }

        [HttpPost]
        public async Task<IActionResult> CreateApplication(ApplicationDTO query)
        {
            return Ok(await _Client.PostAsJsonAsync<ApplicationDTO, ApplicationDTO>("api/applicationapi", query));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateApplication(ApplicationDTO query)
        {
            return Ok(await _Client.PutAsJsonAsync<ApplicationDTO, ApplicationDTO>("api/applicationapi", query));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteApplication(int id)
        {
            return Ok(await _Client.DeleteAsJsonAsync<int, ApplicationDTO>("api/applicationapi", id));
        }
    }
}