namespace ITProjectPriceCalculationManager.DTOModels.DTO
{
    public class ApplicationToFactorsDTO
    {
        public Guid Id { get; set; }
        public Guid ApplicationId { get; set; }
        public Guid DifficultyLevelsTypeToFactorTypeId { get; set; }
        public double? Value { get; set; }
    }
}