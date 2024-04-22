namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces;

internal interface IBaseEntity<TKey>
{
    public TKey Id { get; set; }
}