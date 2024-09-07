using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.DTOModels.DTO.FuzzyLogic;
using ITProjectPriceCalculationManager.Router.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.Router.API.Core.Services;

internal class EvaluatorFuzzyCalculatorService : IEvaluatorFuzzyCalculatorService
{
    private readonly HttpClient _calculatorClient;
    private readonly HttpClient _informationClient;
    private readonly HttpClient _evaluatorClient;
    private readonly IRouteService _routeService;

    public EvaluatorFuzzyCalculatorService(IHttpClientFactory httpClientFactory, IRouteService routeService)
    {
        _informationClient = httpClientFactory.CreateClient("ITProjectsManager");
        _evaluatorClient = httpClientFactory.CreateClient("ITProjectsEvaluatorManager");
        _calculatorClient = httpClientFactory.CreateClient("ITProjectsCalculator");
        _routeService = routeService;
    }

    public async Task<ApplicationToEstimatorsDTO> Calculate(CalculateConfidenceAreaDTO evaluatorFuzzyQuery)
    {
        return await _routeService.PutAsJsonAsync<ApplicationToEstimatorsDTO, ApplicationToEstimatorsDTO>(_informationClient,
            "applicationtoestimatorsapi", new ApplicationToEstimatorsDTO()
        {
            ApplicationId = evaluatorFuzzyQuery.ApplicationId,
            EvaluatorId = evaluatorFuzzyQuery.EvaluatorId,
            ConfidenceArea = await _routeService.PostAsJsonAsync<EvaluatorFuzzyQueryDTO, double>(_calculatorClient, "evaluatorfuzzycalculatorapi", new EvaluatorFuzzyQueryDTO()
            {
                EvaluationCompetentValues = evaluatorFuzzyQuery.EvaluationCompetentValues,
                EvaluateParameters = (await _routeService.GetListByIdAsync<List<ParametersDTO>, Guid>(_evaluatorClient, "parametersapi",
                    evaluatorFuzzyQuery.ApplicationId)).SelectMany(parameter => parameter.EvaluateParameters ?? Enumerable.Empty<EvaluateParameterDTO>()).ToList()
            })
        });
    }
}