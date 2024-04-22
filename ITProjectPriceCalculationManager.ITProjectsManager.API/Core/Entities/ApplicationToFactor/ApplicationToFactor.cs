using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationToFactor;

internal class ApplicationToFactor : IBaseEntity<Guid>
{
    public Guid ApplicationId { get; set; }
    public Guid DifficultyLevelsTypeToFactorTypeId { get; set; }
    public double? Value { get; set; }

    public Application.Application Application { get; set; }

    public DifficultyLevelsTypeToFactorType.DifficultyLevelsTypeToFactorType DifficultyLevelsTypeToFactorType
    {
        get;
        set;
    }

    public virtual ICollection<EvaluatorToEvaluatedFactor.EvaluatorToEvaluatedFactor> EvaluatorToEvaluatedFactor
    {
        get;
        set;
    }

    public virtual ICollection<ProgramsParametrToSubjectAreaElement.ProgramsParametrToSubjectAreaElement>
        ProgramsParametrToSubjectAreaElements { get; set; }

    public Guid Id { get; set; }
}