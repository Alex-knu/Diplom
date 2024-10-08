using ITProjectPriceCalculationManager.DTOModels.DTO.FuzzyLogic;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces.EvaluatorManager;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.Router.API.Controllers.EvaluatorManagerApi;

[ApiController]
[Route("api/evaluatormanager/[controller]")]
public class ParameterValueApiController : ControllerBase
{
    private readonly IParameterValueService _ParameterValueService;

    public ParameterValueApiController(IParameterValueService ParameterValueService)
    {
        _ParameterValueService = ParameterValueService;
    }

    [HttpGet]
    [Route("collection")]
    public async Task<IActionResult> GetAllParameterValues()
    {
        return Ok(await _ParameterValueService.GetParameterValueAsync());
    }

    [HttpGet]
    public async Task<IActionResult> GetParameterValueById(Guid id)
    {
        return Ok(await _ParameterValueService.GetParameterValueByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateParameterValue(ParameterValueDTO query)
    {
        return Ok(await _ParameterValueService.CreateParameterValueAsync(query));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateParameterValue(ParameterValueDTO query)
    {
        return Ok(await _ParameterValueService.UpdateParameterValueAsync(query));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteParameterValue(Guid id)
    {
        return Ok(await _ParameterValueService.DeleteParameterValueAsync(id));
    }
}