using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Estimator
{
    internal class EstimatorConfiguration : IEntityTypeConfiguration<Estimator>
    {
        public void Configure(EntityTypeBuilder<Estimator> builder)
        {
            builder
                   .HasKey(estimator => estimator.Id);

            builder.Property(estimator => estimator.FirstName)
                   .IsRequired();

            builder.Property(estimator => estimator.LastName)
                    .IsRequired();

            builder.Property(estimator => estimator.Phone)
                    .IsRequired();

            builder.Property(estimator => estimator.Email)
                    .IsRequired();

            builder
              .HasOne(estimator => estimator.Department)
              .WithMany(department => department.Estimators)
              .HasForeignKey(estimator => estimator.DepartmentId);
        }
    }
}