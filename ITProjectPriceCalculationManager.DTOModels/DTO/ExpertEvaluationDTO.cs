namespace ITProjectPriceCalculationManager.DTOModels.DTO
{
    public class ExpertEvaluationDTO
    {
        public Guid Id { get; set; }
        public double SelfEvaluation { get; set; }
        public EvaluatorDTO Evaluator { get; set; }
        public List<FactorDTO> ScaleFactors{ get; set; }
        public List<FactorDTO> InfluenceFactors{ get; set; }
    }
}