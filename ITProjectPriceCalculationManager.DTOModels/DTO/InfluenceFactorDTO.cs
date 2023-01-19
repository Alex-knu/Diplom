using ITProjectPriceCalculationManager.CoreModels.Enums;

namespace ITProjectPriceCalculationManager.DTOModels.DTO
{
    public class InfluenceFactorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }   
        public double Count { get; set; }
        public DifficultyLevelsType DifficultyLevelsType { get; set; }
    }
}