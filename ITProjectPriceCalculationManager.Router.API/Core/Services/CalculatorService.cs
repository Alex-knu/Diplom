using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.Router.API.Core.Services
{
    internal class CalculatorService : ICalculatorService
    {
        private readonly HttpClient _calculatorClient;
        private readonly HttpClient _itManagerClient;
        private readonly IRouteService _routeService;

        public CalculatorService(IHttpClientFactory httpClientFactory, IRouteService routeService)
        {
            _itManagerClient = httpClientFactory.CreateClient("ITProjectsManager");
            _calculatorClient = httpClientFactory.CreateClient("ITProjectsCalculator");
            _routeService = routeService;
        }

        public async Task<BaseApplicationDTO> CalculateApplicationPriceAsync(Guid applicationId)
        {
            var application = await _routeService.GetByIdAsync<BaseApplicationDTO, Guid>(_itManagerClient, "baseapplicationapi", applicationId);
            var applicationInfo = await _routeService.GetByIdAsync<EvaluationDTO, Guid>(_itManagerClient, "applicationinfoforevaluationapi", applicationId);
            var result = await _routeService.PostAsJsonAsync<EvaluationDTO, EvaluationResultDTO>(_calculatorClient, "calculateapi", applicationInfo);

            if (string.IsNullOrEmpty(result.Error))
            {
                application.Price = result.Result;
                application.StatusId = new Guid("56533C08-2C5B-4BBA-8DC2-9EFE0FB3DC66");
            }
            else
            {
                application.StatusId = new Guid("9806F24D-89D7-42F5-80B4-D39AC7798949");
            }

            return await _routeService.PutAsJsonAsync<BaseApplicationDTO, BaseApplicationDTO>(_itManagerClient, "baseapplicationapi", application);
        }
    }
}