using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Helpers.MembershipFunction;

namespace ITProjectPriceCalculationManager.ITProjectsCalculator.API.Tets.MembershipFunction;

[TestFixture]
public class GaussianMembershipFunctionTests
{
    [Test]
    [TestCase(0.5, 2.0, 3.0, 0.4578)]
    [TestCase(1.0, 1.0, 2.0, 0.6065)]
    [TestCase(0.2, 0.0, 5.0, 0)]
    public void CalculateMembership_ShouldReturnCorrectResult_WhenParametersAreValid(double mean, double stddev, double x, double expectedResult)
    {
        var gaussianMembershipFunction = new GaussianMembershipFunction(mean, stddev);

        double result = Math.Round(gaussianMembershipFunction.CalculateMembership(x), 4);

        Assert.That(result, Is.EqualTo(expectedResult));
    }
}
