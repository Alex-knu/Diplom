using ITProjectPriceCalculationManager.CoreModels.Interfaces;
using ITProjectPriceCalculationManager.CoreModels.Enums;

namespace ITProjectPriceCalculationManager.CoreModels.Entities.SubjectAreaElement
{
    public class SubjectAreaElement : IBaseEntity<int>
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public SubjectAreaType SubjectAreaType { get; set; }
        public DifficultyLevelsType DifficultyLevelsType { get; set; }

        public ICollection<ProgramsParametrToSubjectAreaElement.ProgramsParametrToSubjectAreaElement> ProgramsParametrToSubjectAreaElements{ get; set; }
    }
}