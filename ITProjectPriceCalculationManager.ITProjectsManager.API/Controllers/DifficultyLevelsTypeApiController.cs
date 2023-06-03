using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DifficultyLevelsTypeApiController : ControllerBase
    {
        private readonly IDifficultyLevelsTypeService _DifficultyLevelsTypeService;

        public DifficultyLevelsTypeApiController(IDifficultyLevelsTypeService difficultyLevelsTypeService)
        {
            _DifficultyLevelsTypeService = difficultyLevelsTypeService;
        }

        [HttpGet]
        [Route("collection/{id}")]
        public IActionResult GetDifficultyLevelsById([FromRoute]Guid id)
        {
            return Ok(_DifficultyLevelsTypeService.GetDifficultyLevelTypesForFactorType(id));
        }
    }
}