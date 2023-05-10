using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApplicationApiController : ControllerBase
    {
        private readonly IApplicationService _ApplicationService;

        public BaseApplicationApiController(IApplicationService applicationService)
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
        public async Task<IActionResult> CreateApplication(BaseApplicationDTO query)
        {
            return Ok(await _ApplicationService.CreateBaseApplicationAsync(query));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateApplication(BaseApplicationDTO query)
        {
            return Ok(await _ApplicationService.UpdateApplicationAsync((ApplicationDTO)query));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteApplication(int id)
        {
            return Ok(await _ApplicationService.DeleteApplicationAsync(id));
        }
    }
}