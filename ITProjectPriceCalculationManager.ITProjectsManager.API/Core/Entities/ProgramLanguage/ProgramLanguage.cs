using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramLanguage
{
    internal class ProgramLanguage : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public int SLOC { get; set; }
        public string Name { get; set; }

        public ICollection<ProgramsParametr.ProgramsParametr> ProgramsParametrs { get; set; }
    }
}