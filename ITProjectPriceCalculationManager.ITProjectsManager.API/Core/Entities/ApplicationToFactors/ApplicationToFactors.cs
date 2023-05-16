using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationToFactors
{
    internal class ApplicationToFactors : IBaseEntity<int>
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public int DifficultyLevelsTypeToFactorTypeId { get; set; }
        public double Value { get; set; }

        public Application.Application Application { get; set; }
        public DifficultyLevelsTypeToFactorType.DifficultyLevelsTypeToFactorType DifficultyLevelsTypeToFactorType { get; set; }
        public virtual ICollection<EvaluatorToEvaluatedFactor.EvaluatorToEvaluatedFactor> EvaluatorToEvaluatedFactor { get; set; }
        public virtual ICollection<ProgramsParametrToSubjectAreaElement.ProgramsParametrToSubjectAreaElement> ProgramsParametrToSubjectAreaElements { get; set; }
    }
}