namespace ITProjectPriceCalculationManager.DTOModels.DTO
{
    public class EvaluationParametrsInfoDTO
    {
        public string Name { get; set; }
        public Guid FactorTypeId { get; set; }
        public List<DifficultyLevelsTypeDTO> DifficultyLevels { get; set; }
    }
}