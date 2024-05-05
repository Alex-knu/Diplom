namespace ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Models;

internal class Constants
{
    public static Dictionary<string, Guid> MembershipFunctionTypes = new Dictionary<string, Guid>()
    {
        { "SigmoidMembershipFunction", new Guid("f4bf3d51-4f18-42e5-b92f-1e8cf40dca1a") },
        { "GaussianMembershipFunction", new Guid("a13bcaf8-0d49-4df7-ba32-0d6fd5b4c4c0") },
        { "ExponentialMembershipFunction", new Guid("6d8622f5-8e17-49a9-b66e-5e11fd761278") },
        { "QuadraticMembershipFunction", new Guid("9c4b86fc-0f8f-4e26-8de0-29c57b076a54") }
    };
}