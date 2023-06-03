namespace ITProjectPriceCalculationManager.DTOModels.DTO
{
    public class EvaluatorDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid? DepartmentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}