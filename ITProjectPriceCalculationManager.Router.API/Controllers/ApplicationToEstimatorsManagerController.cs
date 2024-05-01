using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.Router.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ApplicationToEstimatorsManagerController : ControllerBase
{
    private readonly IApplicationToEstimatorsService _applicationToEstimatorsService;
    private readonly ILogger<ApplicationManagerController> _logger;

    public ApplicationToEstimatorsManagerController(ILogger<ApplicationManagerController> logger,
        IApplicationToEstimatorsService applicationToEstimatorsService)
    {
        _logger = logger;
        _applicationToEstimatorsService = applicationToEstimatorsService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateApplication(ApplicationToEstimatorsDTO query)
    {
        return Ok(await _applicationToEstimatorsService.CreateApplicationToEstimatorsAsync(query));
    }
}