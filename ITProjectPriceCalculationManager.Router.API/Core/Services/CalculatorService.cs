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
                application.Status = "Оцінено";
            }
            else
            {
                application.Status = "На доопрацюванні";
            }

            return await _routeService.PutAsJsonAsync<BaseApplicationDTO, BaseApplicationDTO>(_itManagerClient, "baseapplicationapi", application);
        }
    }
}