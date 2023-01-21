using Microsoft.AspNetCore.Mvc;
using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Interfaces.Services;

namespace ITProjectPriceCalculationManager.ITProjectsCalculator.API.Controllers
{
    [Route("api/[controller]")]
    public class CalculateController : Controller
    {
        private readonly ILogger<CalculateController> _logger;
        private readonly ICalculateService _calculateService;

        public CalculateController(ILogger<CalculateController> logger, ICalculateService calculatorService)
        {
            _logger = logger;
            _calculateService = calculatorService;
        }

        [HttpPost]
        public ApplicationDTO CalulateAsync(ApplicationDTO applicationDTO)
        {
            return _calculateService.AlbrehtMethodCalculate(applicationDTO);
        }
    }
}