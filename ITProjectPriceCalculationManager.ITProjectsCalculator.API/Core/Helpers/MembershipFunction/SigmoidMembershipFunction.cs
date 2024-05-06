using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Interfaces.MembershipFunction;

namespace ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Helpers.MembershipFunction;

internal class SigmoidMembershipFunction : IMembershipFunction
{
    private double Midpoint { get; set; }
    private double Slope{ get; set; }

    public SigmoidMembershipFunction(double midpoint, double slope)
    {
        Midpoint = midpoint;
        Slope = slope;
    }

    // Calculate membership value for a given input x
    public double CalculateMembership(double x)
    {
        return 1 / (1 + Math.Exp(-Slope * (x - Midpoint)));
    }
}