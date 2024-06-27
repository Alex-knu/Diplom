namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Application;

internal class Application : BaseApplication
{
    public virtual ICollection<ApplicationToEvaluator.ApplicationToEvaluator>? ApplicationToEvaluators { get; set; }
    public virtual ICollection<ApplicationToFactor.ApplicationToFactor>? Factors { get; set; }
    public virtual ICollection<ProgramsParametr.ProgramsParametr>? ProgramsParametrs { get; set; }
}