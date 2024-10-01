namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Application;

internal class Application : BaseApplication
{
    public virtual ICollection<Parameter.Parameter>? ApplicationToParameters { get; set; }
    public virtual ICollection<ApplicationToEvaluator.ApplicationToEvaluator>? ApplicationToEvaluators { get; set; }
}