using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationToFactors
{
    internal class ApplicationToFactors : IBaseEntity<int>
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public int FactorId { get; set; }
        public int FactorTypeId { get; set; }
        public int? DifficultyLevelId { get; set; }
        public double Value { get; set; }

        public Attribute.Attribute Factor { get; set; }
        public Application.Application Application { get; set; }
        public DifficultyLevelsType.DifficultyLevelsType DifficultyLevel { get; set; }
        public FactorType.FactorType FactorType { get; set; }
        public virtual ICollection<EvaluatorToEvaluatedFactor.EvaluatorToEvaluatedFactor> EvaluatorToEvaluatedFactor { get; set; }
        public virtual ICollection<ProgramsParametrToSubjectAreaElement.ProgramsParametrToSubjectAreaElement> ProgramsParametrToSubjectAreaElements { get; set; }
    }
}