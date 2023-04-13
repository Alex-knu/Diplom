using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationApiController : ControllerBase
    {
        private readonly IApplicationService _ApplicationService;

        public ApplicationApiController(IApplicationService applicationService)
        {
            _ApplicationService = applicationService;
        }

        [HttpGet]
        [Route("collection")]
        public async Task<IActionResult> GetAllApplications()
        {
            return Ok(await _ApplicationService.GetApplicationsAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetApplicationById(int id)
        {
            return Ok(await _ApplicationService.GetApplicationsByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateApplication(ApplicationDTO query)
        {
            return Ok(await _ApplicationService.CreateApplicationAsync(query));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateApplication(ApplicationDTO query)
        {
            return Ok(await _ApplicationService.UpdateApplicationAsync(query));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteApplication(int id)
        {
            return Ok(await _ApplicationService.DeleteApplicationAsync(id));
        }
    }
}