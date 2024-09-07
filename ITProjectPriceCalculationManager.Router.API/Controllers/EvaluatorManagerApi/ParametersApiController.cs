using ITProjectPriceCalculationManager.DTOModels.DTO.FuzzyLogic;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces.EvaluatorManager;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.Router.API.Controllers.EvaluatorManagerApi;

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
    public async Task<IActionResult> GetParameterByApplicationId([FromRoute] Guid applicationId)
    {
        return Ok(await _ParametersService.GetParameterByApplicationIdAsync(applicationId));
    }

    [HttpGet]
    [Route("collection")]
    public async Task<IActionResult> GetAllParameterss()
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
    [Route("{id}")]
    public async Task<IActionResult> DeleteParameters([FromRoute] Guid id)
    {
        return Ok(await _ParametersService.DeleteParametersAsync(id));
    }
}