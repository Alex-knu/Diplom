using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramsParametr
{
    internal class ProgramsParametr : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid ProgramLanguageId { get; set; }
        public Guid ApplicationId { get; set; }
        public ProgramLanguage.ProgramLanguage ProgramLanguage { get; set; }
        public Application.Application Application { get; set; }
        public ICollection<ProgramsParametrToSubjectAreaElement.ProgramsParametrToSubjectAreaElement> ProgramsParametrToSubjectAreaElements { get; set; }
    }
}