using ITProjectPriceCalculationManager.Core.Enums;
using ITProjectPriceCalculationManager.Core.Interfaces;

namespace ITProjectPriceCalculationManager.Core.Entities.SubjectAreaElement
{
    public class SubjectAreaElement : IBaseEntity<int>
    {
        public int Id { get; set; }
        public SubjectAreaType SubjectAreaType { get; set; }
        public DifficultyLevelsType DifficultyLevelsType { get; set; }
        public int Count { get; set; }
    }
}