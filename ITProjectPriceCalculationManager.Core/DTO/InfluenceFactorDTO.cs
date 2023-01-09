using ITProjectPriceCalculationManager.Core.Enums;

namespace ITProjectPriceCalculationManager.Core.DTO
{
    public class InfluenceFactorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }   
        public double Count { get; set; }
        public DifficultyLevelsType DifficultyLevelsType { get; set; }
    }
}