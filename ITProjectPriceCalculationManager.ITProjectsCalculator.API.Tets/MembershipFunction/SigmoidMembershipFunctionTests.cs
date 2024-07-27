using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Helpers.MembershipFunction;

namespace ITProjectPriceCalculationManager.ITProjectsCalculator.API.Tets.MembershipFunction;

[TestFixture]
public class SigmoidMembershipFunctionTests
{
    [Test]
    [TestCase(0.0, 1.0, 0.0, 0.5)]   // x equal to Midpoint
    [TestCase(0.0, 1.0, 1.0, 0.7311)] // x greater than Midpoint
    [TestCase(0.0, 1.0, -1.0, 0.2689)] // x less than Midpoint
    [TestCase(0.0, 0.5, 1.0, 0.6225)] // smaller Slope
    [TestCase(0.0, 2.0, 1.0, 0.8808)] // larger Slope
    public void CalculateMembership_ShouldReturnCorrectResult_WhenParametersAreValid(double midpoint, double slope, double x, double expectedResult)
    {
        var sigmoidMembershipFunction = new SigmoidMembershipFunction(midpoint, slope);

        double result = Math.Round(sigmoidMembershipFunction.CalculateMembership(x), 4);

        Assert.That(result, Is.EqualTo(expectedResult));
    }
}