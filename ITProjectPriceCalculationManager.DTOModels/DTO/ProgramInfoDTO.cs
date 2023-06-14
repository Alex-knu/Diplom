namespace ITProjectPriceCalculationManager.DTOModels.DTO
{
    public class ProgramInfoDTO
    {
        public Guid Id { get; set; }
        public List<ApplicationToFactorsDTO> ApplicationToFactors { get; set; }
    }
}