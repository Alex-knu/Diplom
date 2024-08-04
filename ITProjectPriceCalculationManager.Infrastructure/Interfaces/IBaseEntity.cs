namespace ITProjectPriceCalculationManager.Infrastructure.Interfaces;

public interface IBaseEntity<TKey>
{
    public TKey Id { get; set; }
}