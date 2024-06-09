using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.Router.API.Core.Services;

internal class ApplicationToEstimatorsService : IApplicationToEstimatorsService
{
    private readonly HttpClient _client;
    private readonly IRouteService _routeService;

    public ApplicationToEstimatorsService(IHttpClientFactory httpClientFactory, IRouteService routeService)
    {
        _client = httpClientFactory.CreateClient("ITProjectsManager");
        _routeService = routeService;
    }

    public async Task<IEnumerable<EvaluatorDTO>> GetEstimatorGroupByApplicationId(Guid applicationId)
    {
        return await _routeService.GetListByIdAsync<IEnumerable<EvaluatorDTO>, Guid>(_client,
            "applicationtoestimatorsapi", applicationId);
    }

    public async Task<ApplicationToEstimatorsDTO> CreateApplicationToEstimatorsAsync(ApplicationToEstimatorsDTO query)
    {
        var application =
            await _routeService.GetByIdAsync<BaseApplicationDTO, Guid>(_client, "baseapplicationapi",
                query.ApplicationId);
        var result =
            await _routeService.PostAsJsonAsync<ApplicationToEstimatorsDTO, ApplicationToEstimatorsDTO>(_client,
                "applicationtoestimatorsapi", query);

        application.StatusId = new Guid("C4A6971D-A0DE-4D6D-97FE-67DB465E330F");

        await _routeService.PutAsJsonAsync<BaseApplicationDTO, BaseApplicationDTO>(_client, "baseapplicationapi",
            application);

        return result;
    }
}