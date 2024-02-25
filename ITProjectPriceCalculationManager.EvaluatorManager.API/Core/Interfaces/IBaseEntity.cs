namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Interfaces
{
    internal interface IBaseEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}