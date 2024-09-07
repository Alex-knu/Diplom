using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces.EvaluatorManager;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.Router.API.Controllers.EvaluatorManagerApi;

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

    [HttpGet]
    public async Task<IActionResult> GetBelongingFunctionById(Guid id)
    {
        return Ok(await _BelongingFunctionService.GetBelongingFunctionByIdAsync(id));
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