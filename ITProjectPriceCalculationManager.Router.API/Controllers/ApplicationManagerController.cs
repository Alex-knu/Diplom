using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.Router.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicationManagerController : ControllerBase
    {
        private readonly ILogger<ApplicationManagerController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public ApplicationManagerController(ILogger<ApplicationManagerController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("collection")]
        public async Task GetAllApplications()
        {
            var httpClient = _httpClientFactory.CreateClient("ITProjectsManager");
            var httpResponseMessage = await httpClient.GetAsync("repos/dotnet/AspNetCore.Docs/branches");
        }
    }
}