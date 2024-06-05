using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ParametersApiController : ControllerBase
{
    private readonly IParametersService _ParametersService;

    public ParametersApiController(IParametersService ParametersService)
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

    [HttpGet]
    public async Task<IActionResult> GetParametersById(Guid id)
    {
        return Ok(await _ParametersService.GetParametersByIdAsync(id));
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