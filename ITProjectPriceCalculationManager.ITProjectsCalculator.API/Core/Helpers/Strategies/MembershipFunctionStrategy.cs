using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Interfaces.MembershipFunction;
using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Models;

namespace ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Helpers.MembershipFunction;

public class MembershipFunctionStrategy
{
    public IMembershipFunction GetMembershipFunction(Guid strategyId, params double[] parameters)
    {
        var strategy = Constants.MembershipFunctionTypes.FirstOrDefault(x => x.Value.Equals(strategyId));

        switch(strategy.Key)
        {
            case "SigmoidMembershipFunction":
                return new SigmoidMembershipFunction(parameters[0], parameters[1]);
            case "GaussianMembershipFunction":
                return new GaussianMembershipFunction(parameters[0], parameters[1]);
            case "ExponentialMembershipFunction":
                return new ExponentialMembershipFunction(parameters[0], parameters[1]);
            case "QuadraticMembershipFunction":
                return new QuadraticMembershipFunction(parameters[0], parameters[1], parameters[2]);
            default:
                throw new NotImplementedException();
        }
    }
}