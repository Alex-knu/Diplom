using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EvaluateParameterValueApiController : ControllerBase
{
    private readonly IEvaluateParameterValueService _EvaluateParameterValueService;

    public EvaluateParameterValueApiController(IEvaluateParameterValueService EvaluateParameterValueService)
    {
        _EvaluateParameterValueService = EvaluateParameterValueService;
    }

    [HttpGet]
    [Route("collection")]
    public async Task<IActionResult> GetAllEvaluateParameterValues()
    {
        return Ok(await _EvaluateParameterValueService.GetEvaluateParameterValueAsync());
    }

    [HttpGet]
    public async Task<IActionResult> GetEvaluateParameterValueById(Guid id)
    {
        return Ok(await _EvaluateParameterValueService.GetEvaluateParameterValueByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateEvaluateParameterValue(EvaluateParameterValueDTO query)
    {
        return Ok(await _EvaluateParameterValueService.CreateEvaluateParameterValueAsync(query));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateEvaluateParameterValue(EvaluateParameterValueDTO query)
    {
        return Ok(await _EvaluateParameterValueService.UpdateEvaluateParameterValueAsync(query));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteEvaluateParameterValue(Guid id)
    {
        return Ok(await _EvaluateParameterValueService.DeleteEvaluateParameterValueAsync(id));
    }
}