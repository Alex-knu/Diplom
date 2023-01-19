using ITProjectPriceCalculationManager.CoreModels.Enums;

namespace ITProjectPriceCalculationManager.DTOModels.DTO
{
    public class SubjectAreaElementDTO
    {
        public int Id { get; set; }
        public double Count { get; set; }
        public int DifficultyLevel { get; set; }
        public SubjectAreaType SubjectAreaType { get; set; }
        public ConditionalUnitsOfFunctionality ConditionalUnitsOfFunctionality { get; set; }
    }
}