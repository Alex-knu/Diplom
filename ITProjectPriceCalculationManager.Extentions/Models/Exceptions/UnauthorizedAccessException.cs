namespace ITProjectPriceCalculationManager.Extentions.Models.Exceptions;

public class UnauthorizedAccessException : Exception
{
    public UnauthorizedAccessException(string message) : base(message)
    {
    }
}