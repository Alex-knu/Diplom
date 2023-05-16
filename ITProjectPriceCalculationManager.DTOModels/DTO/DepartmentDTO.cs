namespace ITProjectPriceCalculationManager.DTOModels.DTO
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }

        public List<DepartmentDTO> SubDepartments { get; set; }
    }
}