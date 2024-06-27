using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationToFactor;

internal class ApplicationToFactor : IBaseEntity<Guid>
{
    public Guid Id { get; set; }
    public Guid ApplicationId { get; set; }
    public Guid DifficultyLevelsTypeToFactorTypeId { get; set; }
    public double? Value { get; set; }

    public required Application.Application Application { get; set; }
    public required DifficultyLevelsTypeToFactorType.DifficultyLevelsTypeToFactorType DifficultyLevelsTypeToFactorType { get; set; }

    public virtual ICollection<EvaluatorToEvaluatedFactor.EvaluatorToEvaluatedFactor>? EvaluatorToEvaluatedFactor { get; set; }
    public virtual ICollection<ProgramsParametrToSubjectAreaElement.ProgramsParametrToSubjectAreaElement>? ProgramsParametrToSubjectAreaElements { get; set; }
}