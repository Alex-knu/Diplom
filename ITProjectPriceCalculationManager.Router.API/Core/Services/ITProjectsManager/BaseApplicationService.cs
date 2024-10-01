using ITProjectPriceCalculationManager.DTOModels.DTO.ITProjectsManager;
using ITProjectPriceCalculationManager.Extentions.Extentions;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces.ITProjectsManager;

namespace ITProjectPriceCalculationManager.Router.API.Core.Services.ITProjectsManager;

internal class BaseApplicationService : IBaseApplicationService
{
    private readonly HttpClient _client;
    private readonly IRouteService _routeService;

    public BaseApplicationService(IHttpClientFactory httpClientFactory, IRouteService routeService)
    {
        _client = httpClientFactory.CreateClient("ITProjectsManager");
        _routeService = routeService;
    }

    public async Task<BaseApplicationDTO> CreateBaseApplicationAsync(HttpContext httpContext, BaseApplicationDTO query)
    {
        query.UserCreatorId = JwtUtils.GetUserInfo(httpContext).UserId;
        return await _routeService.PostAsJsonAsync<BaseApplicationDTO, BaseApplicationDTO>(_client,
            "baseapplicationapi", query);
    }

    public async Task<BaseApplicationDTO> DeleteBaseApplicationAsync(Guid id)
    {
        return await _routeService.DeleteAsJsonAsync<BaseApplicationDTO, Guid>(_client, "baseapplicationapi", id);
    }

    public async Task<IEnumerable<BaseApplicationDTO>> GetBaseApplicationsAsync(HttpContext httpContext)
    {
        _client.DefaultRequestHeaders.Add("Authorization", httpContext.Request.Headers["Authorization"].ToString());

        return await _routeService.GetAllAsync<IEnumerable<BaseApplicationDTO>>(_client, "baseapplicationapi");
    }

    public async Task<BaseApplicationDTO> GetBaseApplicationsByIdAsync(Guid id)
    {
        return await _routeService.GetByIdAsync<BaseApplicationDTO, Guid>(_client, "baseapplicationapi", id);
    }

    public async Task<BaseApplicationDTO> UpdateBaseApplicationAsync(BaseApplicationDTO query)
    {
        return await _routeService.PutAsJsonAsync<BaseApplicationDTO, BaseApplicationDTO>(_client, "baseapplicationapi",
            query);
    }
}