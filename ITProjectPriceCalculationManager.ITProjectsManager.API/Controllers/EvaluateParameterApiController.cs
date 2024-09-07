using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EvaluateParameterApiController : ControllerBase
{
    private readonly IEvaluateParameterService _EvaluateParameterService;

    public EvaluateParameterApiController(IEvaluateParameterService EvaluateParameterService)
    {
        _EvaluateParameterService = EvaluateParameterService;
    }
    
    [HttpGet]
    [Route("collection/{parameterId}")]
    public async Task<IActionResult> GetEvaluateParametersByParameterId([FromRoute] Guid parameterId)
    {
        return Ok(await _EvaluateParameterService.GetEvaluateParametersByParameterIdAsync(parameterId));
    }

    [HttpGet]
    [Route("collection")]
    public async Task<IActionResult> GetAllEvaluateParameters()
    {
        return Ok(await _EvaluateParameterService.GetEvaluateParameterAsync());
    }

    [HttpPost]
    public async Task<IActionResult> CreateEvaluateParameter(EvaluateParameterDTO query)
    {
        return Ok(await _EvaluateParameterService.CreateEvaluateParameterAsync(query));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateEvaluateParameter(EvaluateParameterDTO query)
    {
        return Ok(await _EvaluateParameterService.UpdateEvaluateParameterAsync(query));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteEvaluateParameter([FromBody] Guid id)
    {
        return Ok(await _EvaluateParameterService.DeleteEvaluateParameterAsync(id));
    }
}