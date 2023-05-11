namespace ITProjectPriceCalculationManager.DTOModels.DTO
{
    public class BaseApplicationDTO
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }
        public string Status { get; set; } 
        public double? Price { get; set; }
        public double Profit { get; set; }
    }
}