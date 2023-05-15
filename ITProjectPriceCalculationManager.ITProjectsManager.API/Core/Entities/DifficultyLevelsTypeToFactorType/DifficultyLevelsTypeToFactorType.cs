namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.DifficultyLevelsTypeToFactorType
{
    internal class DifficultyLevelsTypeToFactorType
    {
        public int Id { get; set; }
        public int DifficultyLevelId { get; set; }
        public int FactorId { get; set; }
        public int FactorTypeId { get; set; }
        public double Value { get; set; }

        public DifficultyLevelsType.DifficultyLevelsType DifficultyLevel { get; set; }
        public Attribute.Attribute Factor { get; set; }
        public FactorType.FactorType FactorType { get; set; }
        public virtual ICollection<ApplicationToFactors.ApplicationToFactors> ApplicationToFactors { get; set; }
    }
}