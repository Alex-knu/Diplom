using ITProjectPriceCalculationManager.DTOModels.Enums;
using ITProjectPriceCalculationManager.DTOModels.Interfaces;

namespace ITProjectPriceCalculationManager.DTOModels.DTO;

public class EvaluationFactorDTO : IFactor
{
    public Guid Id { get; set; }
    public Guid EvaluatorId { get; set; }
    public Guid FactorId { get; set; }
    public FactorType FactorType { get; set; }
    public DifficultyLevelsType DifficultyLevelsType { get; set; }
    public int? Count { get; set; }
    public double Value { get; set; }
    public double SelfEvaluation { get; set; }
}