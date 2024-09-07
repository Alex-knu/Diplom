using ITProjectPriceCalculationManager.DTOModels.DTO.FuzzyLogic;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ParameterApiController : ControllerBase
{
    private readonly IParametersService _ParametersService;

    public ParameterApiController(IParametersService ParametersService)
    {
        _ParametersService = ParametersService;
    }

    [HttpGet]
    [Route("collection/{applicationId}")]
    public async Task<IActionResult> GetAllRulessByApplicationId([FromRoute] Guid applicationId)
    {
        return Ok(await _ParametersService.GetParametersByApplicationIdAsync(applicationId));
    }

    [HttpGet]
    [Route("collection")]
    public async Task<IActionResult> GetAllParameters()
    {
        return Ok(await _ParametersService.GetParametersAsync());
    }

    [HttpPost]
    public async Task<IActionResult> CreateParameters(ParametersDTO query)
    {
        return Ok(await _ParametersService.CreateParametersAsync(query));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateParameters(ParametersDTO query)
    {
        return Ok(await _ParametersService.UpdateParametersAsync(query));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteParameters([FromBody] Guid id)
    {
        return Ok(await _ParametersService.DeleteParametersAsync(id));
    }
}