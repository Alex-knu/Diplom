using ITProjectPriceCalculationManager.DTOModels.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.Router.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorManagerController : ControllerBase
    {
        private readonly ILogger<CalculatorManagerController> _Logger;
        private readonly HttpClient _Client;

        public CalculatorManagerController(ILogger<CalculatorManagerController> logger, IHttpClientFactory httpClientFactory)
        {
            _Logger = logger;
            _Client = httpClientFactory.CreateClient("ITProjectsCalculator");
        }

        [HttpPost]
        public async Task<IActionResult> CalculateApplicationPrice(ApplicationDTO query)
        {
            return Ok(await _Client.PostAsJsonAsync<ApplicationDTO, ApplicationDTO>("api/calculateapi", query));
        }
    }
}