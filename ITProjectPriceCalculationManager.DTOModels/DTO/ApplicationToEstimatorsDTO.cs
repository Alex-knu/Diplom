namespace ITProjectPriceCalculationManager.DTOModels.DTO
{
    public class ApplicationToEstimatorsDTO
    {
        public int ApplicationId { get; set; }
        public List<EvaluatorDTO> Evaluators { get; set; }
    }
}