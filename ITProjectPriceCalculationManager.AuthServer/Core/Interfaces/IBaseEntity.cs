namespace ITProjectPriceCalculationManager.AuthServer.Core.Interfaces
{
    internal interface IBaseEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}