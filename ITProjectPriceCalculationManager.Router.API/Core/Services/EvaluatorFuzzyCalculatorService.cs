using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.Router.API.Core.Services;

internal class EvaluatorFuzzyCalculatorService : IEvaluatorFuzzyCalculatorService
{
    private readonly HttpClient _calculatorClient;
    private readonly IRouteService _routeService;

    public EvaluatorFuzzyCalculatorService(IHttpClientFactory httpClientFactory, IRouteService routeService)
    {
        _calculatorClient = httpClientFactory.CreateClient("ITProjectsCalculator");
        _routeService = routeService;
    }

    public async Task<double> Calculate(List<EvaluationCompetentValueDTO> evaluationCompetentValues, List<EvaluateParameterDTO> evaluateParameters)
    {
        return await _routeService.PostAsJsonAsync<List<EvaluationCompetentValueDTO>, double>(_calculatorClient, "evaluatorfuzzycalculatorapi", evaluationCompetentValues);
    }
}