using ITProjectPriceCalculationManager.DTOModels.DTO.FuzzyLogic;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces.EvaluatorManager;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.Router.API.Controllers.EvaluatorManagerApi;

[ApiController]
[Route("api/evaluatormanager/[controller]")]
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
    [Route("{id}")]
    public async Task<IActionResult> DeleteEvaluateParameter([FromRoute] Guid id)
    {
        return Ok(await _EvaluateParameterService.DeleteEvaluateParameterAsync(id));
    }
}