using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.Router.API.Controllers;

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
    public async Task<IActionResult> DeleteParameters(Guid id)
    {
        return Ok(await _ParametersService.DeleteParametersAsync(id));
    }
}