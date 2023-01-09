using ITProjectPriceCalculationManager.Core.Interfaces;

namespace ITProjectPriceCalculationManager.Core.Entities.ProgramLanguage
{
    public class ProgramLanguage : IBaseEntity<int>
    {
        public int Id { get; set; }
        public int SLOC { get; set; }
        public string Name { get; set; }

        public ICollection<ProgramsParametr.ProgramsParametr> ProgramsParametrs { get; set; }
    }
}