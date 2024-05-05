using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Helpers.CalculateMethods;
using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Helpers.MembershipFunction;
using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Interfaces.MembershipFunction;
using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Interfaces.Services;

namespace ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Services;

internal class EvaluatorFuzzyCalculatorService : IEvaluatorFuzzyCalculatorService
{
    public Task<double> Calculate(List<EvaluateParameterDTO> evaluateParameters)
    {
        var fuzzyInputs = new List<double>();

        evaluateParameters.ForEach(param => fuzzyInputs.Add(SetMembershipFunctionStrategy(param.BelongingFunctionId, param.EvaluateParameterValue.A, param.EvaluateParameterValue.B, param.EvaluateParameterValue.C, param.EvaluateParameterValue.D).CalculateMembership(0)));

        return Task.FromResult(Defuzzify(ApplyRulesAndAggregation(fuzzyInputs)));
    }

    public Task<EvaluationResultDTO> Calculate(EvaluationDTO evaluation, double? price = null)
    {
        return SetStrategy().Calculate(evaluation, price);
    }

    private CalculateMethod SetStrategy()
    {
        return new AlbrehtMethod();
    }

    private IMembershipFunction SetMembershipFunctionStrategy(Guid strategyId, params double[] parameters)
    {
        return new MembershipFunctionStrategy().GetMembershipFunction(strategyId, parameters);
    }

    private double ApplyRulesAndAggregation(List<double> fuzzyInputs)
    {
        double output = 0.0;

        fuzzyInputs.ForEach(input => output = Math.Max(output, input));

        return output;
    }

    // Fuzzy Logic Defuzzification using Centroid Method
    public static double Defuzzify(double aggregatedValue)
    {
        // Define fuzzy sets and their respective ranges
        double lowComfortRangeStart = 0.0;
        double lowComfortRangeEnd = 30.0;
        double highComfortRangeStart = 70.0;
        double highComfortRangeEnd = 100.0;

        // Calculate centroids
        double lowCentroid = (lowComfortRangeEnd + lowComfortRangeStart) / 2.0;
        double highCentroid = (highComfortRangeEnd + highComfortRangeStart) / 2.0;

        // Weighted average
        double defuzzifiedValue = (aggregatedValue * highCentroid + (1 - aggregatedValue) * lowCentroid) / 2.0;

        return defuzzifiedValue;
    }
}