namespace ITProjectPriceCalculationManager.DTOModels.DTO
{
    public class EvaluationParametrsInfoDTO
    {
        public string Name { get; set; }
        public int FactorTypeId { get; set; }
        public List<DifficultyLevelsTypeDTO> DifficultyLevels { get; set; }
    }
}