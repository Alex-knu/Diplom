namespace ITProjectPriceCalculationManager.DTOModels.DTO
{
    public class EvaluationApplicationDTO
    {
        public string UserCreatorId { get; set; }
        public List<ApplicationToFactorsDTO> ApplicationToFactors { get; set; }
    }
}