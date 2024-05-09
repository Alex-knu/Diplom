using ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Interfaces.MembershipFunction;

namespace ITProjectPriceCalculationManager.ITProjectsCalculator.API.Core.Helpers.MembershipFunction;

internal class QuadraticMembershipFunction : IMembershipFunction
{
    // Parameters
    private readonly double A; // Коефіцієнт a
    private readonly double B; // Коефіцієнт b
    private readonly double C; // Коефіцієнт c

    // Конструктор
    public QuadraticMembershipFunction(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;
    }

    // Метод для обчислення ступеня належності
    public double CalculateMembership(double x)
    {
        if (x < A || x > C)
        {
            return 0.0; // Якщо значення x знаходиться за межами діапазону, ступінь належності дорівнює 0
        }
        else if (x >= A && x <= B)
        {
            return 2 * Math.Pow((x - A) / (C - A), 2);
        }
        else if (x > B && x <= C)
        {
            return 1 - 2 * Math.Pow((x - C) / (C - A), 2);
        }
        else
        {
            return 0.0;
        }
    }
}