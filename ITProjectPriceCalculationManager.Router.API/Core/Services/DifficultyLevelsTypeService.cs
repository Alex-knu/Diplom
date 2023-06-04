using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.Router.API.Core.Services
{
    internal class DifficultyLevelsTypeService : IDifficultyLevelsTypeService
    {
        private readonly HttpClient _client;
        private readonly IRouteService _routeService;

        public DifficultyLevelsTypeService(IHttpClientFactory httpClientFactory, IRouteService routeService)
        {
            _client = httpClientFactory.CreateClient("ITProjectsManager");
            _routeService = routeService;
        }

        public async Task<IEnumerable<DifficultyLevelsTypeDTO>> GetDifficultyLevelTypesForFactorType(Guid id)
        {
            return await _routeService.GetListByIdAsync<List<DifficultyLevelsTypeDTO>, Guid>(_client, "difficultylevelstypeapi", id);
        }
    }
}