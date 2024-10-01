using ITProjectPriceCalculationManager.Infrastructure.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Application;

internal class ApplicationView : IBaseEntity<Guid>
{
    public Guid Id { get; set; }
    public Guid CreatorId { get; set; }
    public Guid CreatorUserId { get; set; }
    public Guid StatusId { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string StatusName { get; set; }
    public Guid? EvaluatorUserId { get; set; }
}