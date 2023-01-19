using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramsParametr
{
    public class ProgramsParametr : IBaseEntity<int>
    {
        public int Id { get; set; }
        public int SLOC { get; set; }
        public int ProgramLanguageId { get; set; }
        public int ApplicationId { get; set; }
        public ProgramLanguage.ProgramLanguage ProgramLanguage { get; set; }
        public Application.Application Application { get; set; }
        public ICollection<ProgramsParametrToSubjectAreaElement.ProgramsParametrToSubjectAreaElement> ProgramsParametrToSubjectAreaElements{ get; set; }
    }
}