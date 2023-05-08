using ITProjectPriceCalculationManager.DTOModels.Enums;
using ITProjectPriceCalculationManager.DTOModels.Interfaces;

namespace ITProjectPriceCalculationManager.DTOModels.DTO
{
    public class FactorDTO : IFactor
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public DifficultyLevelsType DifficultyLevelsType { get; set; }
    }
}