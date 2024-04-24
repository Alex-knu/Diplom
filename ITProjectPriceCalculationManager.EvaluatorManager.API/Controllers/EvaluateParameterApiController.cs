using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Controllers;

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
    [Route("collection")]
    public async Task<IActionResult> GetAllEvaluateParameters()
    {
        return Ok(await _EvaluateParameterService.GetEvaluateParameterAsync());
    }

    [HttpGet]
    public async Task<IActionResult> GetEvaluateParameterById(Guid id)
    {
        return Ok(await _EvaluateParameterService.GetEvaluateParameterByIdAsync(id));
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
    public async Task<IActionResult> DeleteEvaluateParameter(Guid id)
    {
        return Ok(await _EvaluateParameterService.DeleteEvaluateParameterAsync(id));
    }
}