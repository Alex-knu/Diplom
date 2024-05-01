using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.Router.API.Core.Services;

internal class ProgramLanguageService : IProgramLanguageService
{
    private readonly HttpClient _client;
    private readonly IRouteService _routeService;

    public ProgramLanguageService(IHttpClientFactory httpClientFactory, IRouteService routeService)
    {
        _client = httpClientFactory.CreateClient("ITProjectsManager");
        _routeService = routeService;
    }

    public async Task<IEnumerable<ProgramLanguageDTO>> GetAllProgramLanguagesByApplicationId(Guid applicationId)
    {
        return await _routeService.GetListByIdAsync<List<ProgramLanguageDTO>, Guid>(_client, "programlanguageapi",
            applicationId);
    }

    public async Task<IEnumerable<ProgramLanguageDTO>> GetProgramLanguagesAsync()
    {
        return await _routeService.GetAllAsync<List<ProgramLanguageDTO>>(_client, "programlanguageapi");
    }
}