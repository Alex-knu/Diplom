using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.Router.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentTreeManagerController : ControllerBase
    {
        private readonly ILogger<DepartmentTreeManagerController> _logger;
        private readonly HttpClient _client;
        private readonly IRouteService _routeService;

        public DepartmentTreeManagerController(ILogger<DepartmentTreeManagerController> logger, IHttpClientFactory httpClientFactory, IRouteService routeService)
        {
            _logger = logger;
            _client = httpClientFactory.CreateClient("ITProjectsManager");
            _routeService = routeService;
        }

        [HttpGet]
        [Route("collection")]
        public async Task<IActionResult> GetAllDepartments()
        {
            return Ok(await _routeService.GetAllAsync<List<DepartmentDTO>>(_client, "departmenttreeapi"));
        }
    }
}