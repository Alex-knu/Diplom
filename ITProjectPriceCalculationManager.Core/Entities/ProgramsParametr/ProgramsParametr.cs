using ITProjectPriceCalculationManager.Core.Interfaces;

namespace ITProjectPriceCalculationManager.Core.Entities.ProgramsParametr
{
    public class ProgramsParametr : IBaseEntity<int>
    {
        public int Id { get; set; }
        public int SLOC { get; set; }
        public int ProgramLanguageId { get; set; }
        public ProgramLanguage.ProgramLanguage ProgramLanguage { get; set; }
        public ICollection<ProgramsParametrToSubjectAreaElement.ProgramsParametrToSubjectAreaElement> ProgramsParametrToSubjectAreaElements{ get; set; }
    }
}