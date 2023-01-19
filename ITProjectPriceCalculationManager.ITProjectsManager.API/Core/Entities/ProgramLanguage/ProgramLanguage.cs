using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ProgramLanguage
{
    public class ProgramLanguage : IBaseEntity<int>
    {
        public int Id { get; set; }
        public int SLOC { get; set; }
        public string Name { get; set; }

        public ICollection<ProgramsParametr.ProgramsParametr> ProgramsParametrs { get; set; }
    }
}