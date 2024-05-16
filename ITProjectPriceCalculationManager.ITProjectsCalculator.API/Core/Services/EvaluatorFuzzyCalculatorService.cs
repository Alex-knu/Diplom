using ITProjectPriceCalculationManager.DTOModels.DTO;
using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Helpers.MembershipFunction;
using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Interfaces.MembershipFunction;
using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Interfaces.Services;

namespace ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Services;

internal class EvaluatorFuzzyCalculatorService : IEvaluatorFuzzyCalculatorService
{
    public Task<double> Calculate(EvaluatorFuzzyQueryDTO evaluatorFuzzyQuery)
    {
        var fuzzyInputs = new List<double>();

        foreach(var evaluationCompetentValue in evaluatorFuzzyQuery.EvaluationCompetentValues)
        {
            foreach(var evaluateParameter in evaluatorFuzzyQuery.EvaluateParameters.Where(parameter => parameter.ParameterId == evaluationCompetentValue.EvaluationParameterId))
            {
                fuzzyInputs.Add(SetMembershipFunctionStrategy(evaluateParameter.BelongingFunctionId, evaluateParameter.EvaluateParameterValue.A, evaluateParameter.EvaluateParameterValue.B, evaluateParameter.EvaluateParameterValue.C, evaluateParameter.EvaluateParameterValue.D).CalculateMembership(evaluationCompetentValue.Value));
            }
        }

        return Task.FromResult(Defuzzify(ApplyRulesAndAggregation(fuzzyInputs)));
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