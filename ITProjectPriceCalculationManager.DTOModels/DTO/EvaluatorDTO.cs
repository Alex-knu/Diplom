namespace ITProjectPriceCalculationManager.DTOModels.DTO;

public class EvaluatorDTO
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid? DepartmentId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Phone { get; set; }
    public required string Email { get; set; }
    public double? CompetencyLevel { get; set; }

    public DepartmentDTO? Department { get; set; }
}