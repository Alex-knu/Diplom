using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.ITProjects.API.Controllers
{
    [Route("api/[controller]")]
    public class CalculateController : Controller
    {
        private readonly ILogger<CalculateController> _logger;

        public CalculateController(ILogger<CalculateController> logger)
        {
            _logger = logger;
        }
    }
}