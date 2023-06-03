using ITProjectPriceCalculationManager.DTOModels.Enums;
using ITProjectPriceCalculationManager.DTOModels.Interfaces;

namespace ITProjectPriceCalculationManager.DTOModels.DTO
{
    public class SubjectAreaElementDTO : IFactor
    {
        public Guid Id { get; set; }
        public int? Count { get; set; }
        public double Value { get; set; }
        public double SelfEvaluation { get; set; }
        public SubjectAreaType SubjectAreaType { get; set; }
        public ConditionalUnitsOfFunctionality ConditionalUnitsOfFunctionality { get; set; }
    }
}