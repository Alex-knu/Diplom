namespace ITProjectPriceCalculationManager.DTOModels.Interfaces
{
    public interface IFactor
    {
        public int? Count { get; set; }
        public double Value { get; set; }
        public double SelfEvaluation { get; set; }
    }
}