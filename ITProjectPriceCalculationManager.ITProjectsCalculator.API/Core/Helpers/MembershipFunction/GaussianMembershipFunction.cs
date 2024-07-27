using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Interfaces.MembershipFunction;

namespace ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Helpers.MembershipFunction;

public class GaussianMembershipFunction : IMembershipFunction
{
    private readonly double Mean;
    private readonly double Stddev;

    public GaussianMembershipFunction(double mean, double stddev)
    {
        Mean = mean;
        Stddev = stddev;
    }

    // Calculate membership value for a given input x
    public double CalculateMembership(double x)
    {
        return Math.Exp(-0.5 * Math.Pow((x - Mean) / Stddev, 2));
    }
}