namespace ITProjectPriceCalculationManager.DTOModels.DTO
{
    public class ApplicationToFactorsDTO
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public int DifficultyLevelsTypeToFactorTypeId { get; set; }
        public double Value { get; set; }
    }
}