using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Interfaces.MembershipFunction;

namespace ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Helpers.MembershipFunction;

internal class MembershipFunctionStrategy
{
    public IMembershipFunction GetMembershipFunction(Guid strategyId, params double[] parameters)
    {
        if(strategyId == Guid.Empty)
        {
            return new SigmoidMembershipFunction(0.5, 1.5);
        }
        else if(strategyId == Guid.Empty)
        {
            return new QuadraticMembershipFunction(0.5, 1.5, 0.5);
        }
        else if(strategyId == Guid.Empty)
        {
            return new GaussianMembershipFunction(0.5, 1.5);
        }
        else if(strategyId == Guid.Empty)
        {
            return new ExponentialMembershipFunction(0.5, 1.5);
        }

        throw new NotImplementedException();
    }
}