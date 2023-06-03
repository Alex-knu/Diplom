using ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Interfaces;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.DifficultyLevels
{
    internal class DifficultyLevel : IBaseEntity<int>
    {
        public int Id { get; set; }
        public int RelationId { get; set; }
        public string Name { get; set; }
    }
}