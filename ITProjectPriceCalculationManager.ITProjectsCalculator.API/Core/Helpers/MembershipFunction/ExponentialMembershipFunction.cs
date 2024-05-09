using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Interfaces.MembershipFunction;

namespace ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Helpers.MembershipFunction;

internal class ExponentialMembershipFunction : IMembershipFunction
{
    // Parameters
    private readonly double A; // Коефіцієнт зростання (a)
    private readonly double B; // Зміщення (b)

    // Конструктор
    public ExponentialMembershipFunction(double a, double b)
    {
        A = a;
        B = b;
    }

    // Метод для обчислення ступеня належності
    public double CalculateMembership(double x)
    {
        return Math.Exp(-A * (x - B));
    }
}