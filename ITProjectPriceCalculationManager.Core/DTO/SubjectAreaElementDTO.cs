using ITProjectPriceCalculationManager.Core.Enums;

namespace ITProjectPriceCalculationManager.Core.DTO
{
    public class SubjectAreaElementDTO
    {
        public ConditionalUnitsOfFunctionality ConditionalUnitsOfFunctionality { get; set; }
        public SubjectAreaType SubjectAreaType { get; set; }
        public int DifficultyLevel { get; set; }
        public int Count { get; set; }
    }
}