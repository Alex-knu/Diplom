using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Helpers.MembershipFunction;

namespace ITProjectPriceCalculationManager.ITProjectsCalculator.API.Test.MembershipFunction;

[TestFixture]
public class QuadraticMembershipFunctionTests
{
    [Test]
    [TestCase(0.0, 5.0, 10.0, -1.0, 0.0)] // x is less than A
    [TestCase(0.0, 5.0, 10.0, 11.0, 0.0)] // x is greater than C
    [TestCase(0.0, 5.0, 10.0, 0.0, 0.0)]  // x is exactly A
    [TestCase(0.0, 5.0, 10.0, 5.0, 0.5)]  // x is exactly B
    [TestCase(0.0, 5.0, 10.0, 10.0, 1.0)] // x is exactly C
    [TestCase(0.0, 5.0, 10.0, 2.5, 0.125)]// x is between A and B
    [TestCase(0.0, 5.0, 10.0, 7.5, 0.875)]  // x is between B and C
    public void CalculateMembership_ShouldReturnCorrectResult_WhenParametersAreValid(double a, double b, double c, double x, double expectedResult)
    {
        var quadraticMembershipFunction = new QuadraticMembershipFunction(a, b, c);

        double result = Math.Round(quadraticMembershipFunction.CalculateMembership(x), 4);

        Assert.That(result, Is.EqualTo(expectedResult));
    }
}