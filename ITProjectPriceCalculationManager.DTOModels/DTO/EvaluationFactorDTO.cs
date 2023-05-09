using ITProjectPriceCalculationManager.DTOModels.Enums;
using ITProjectPriceCalculationManager.DTOModels.Interfaces;

namespace ITProjectPriceCalculationManager.DTOModels.DTO
{
    public class EvaluationFactorDTO : IFactor
    {
        public int Id { get; set; }
        public int EvaluatorId { get; set; }
        public int? Count { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public double SelfEvaluation { get; set; }
        public FactorType FactorType { get; set; }
    }
}