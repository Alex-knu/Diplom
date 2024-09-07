using ITProjectPriceCalculationManager.DTOModels.DTO.FuzzyLogic;
using ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BelongingFunctionApiController : ControllerBase
{
    private readonly IBelongingFunctionService _BelongingFunctionService;

    public BelongingFunctionApiController(IBelongingFunctionService BelongingFunctionService)
    {
        _BelongingFunctionService = BelongingFunctionService;
    }

    [HttpGet]
    [Route("collection")]
    public async Task<IActionResult> GetAllBelongingFunctions()
    {
        return Ok(await _BelongingFunctionService.GetBelongingFunctionAsync());
    }

    [HttpPost]
    public async Task<IActionResult> CreateBelongingFunction(BelongingFunctionDTO query)
    {
        return Ok(await _BelongingFunctionService.CreateBelongingFunctionAsync(query));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBelongingFunction(BelongingFunctionDTO query)
    {
        return Ok(await _BelongingFunctionService.UpdateBelongingFunctionAsync(query));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBelongingFunction(Guid id)
    {
        return Ok(await _BelongingFunctionService.DeleteBelongingFunctionAsync(id));
    }
}