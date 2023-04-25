using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Department
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder
                   .HasKey(department => department.Id);

            builder.Property(department => department.Name)
                   .IsRequired();

            builder
              .HasMany(department => department.SubDepartment)
              .WithOne(department => department.Parent)
              .HasForeignKey(department => department.ParentId);
        }
    }
}