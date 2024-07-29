using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Helpers.MembershipFunction;

namespace ITProjectPriceCalculationManager.ITProjectsCalculator.API.Test.MembershipFunction;

[TestFixture]
public class ExponentialMembershipFunctionTheoryTests   
{
    [Theory]
    [TestCase(0.5, 2.0, 3.0, 0.6065)]
    [TestCase(1.0, 1.0, 2.0, 0.3679)]
    [TestCase(0.2, 0.0, 5.0, 0.3679)]
    public void CalculateMembership_ShouldReturnCorrectResult_WhenParametersAreValid(double a, double b, double x, double testResult)
    {
        var function = new ExponentialMembershipFunction(a, b);

        double result = Math.Round(function.CalculateMembership(x), 4);

        Assert.That(result, Is.EqualTo(testResult));
    }
}