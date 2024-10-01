namespace ITProjectPriceCalculationManager.DTOModels.DTO.ITProjectsManager;

public class DepartmentDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public Guid? ParentId { get; set; }

    public DepartmentDTO? Parent { get; set; }
    public List<DepartmentDTO>? SubDepartments { get; set; }
}