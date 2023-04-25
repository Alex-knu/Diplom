using ITProjectPriceCalculationManager.DTOModels.Enums;
using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.SubjectAreaElement
{
    internal class SubjectAreaElement : IBaseEntity<int>
    {
        public int Id { get; set; }
        public int  Count { get; set; }
        public SubjectAreaType SubjectAreaType { get; set; }
        public DifficultyLevelsType DifficultyLevelsType { get; set; }

        public ICollection<ProgramsParametrToSubjectAreaElement.ProgramsParametrToSubjectAreaElement> ProgramsParametrToSubjectAreaElements{ get; set; }
    }
}