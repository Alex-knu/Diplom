namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces
{
    public interface IBaseEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}