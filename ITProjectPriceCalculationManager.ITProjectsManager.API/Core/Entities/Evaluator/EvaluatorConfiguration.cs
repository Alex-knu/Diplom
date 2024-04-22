using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.Evaluator;

internal class EvaluatorConfiguration : IEntityTypeConfiguration<Evaluator>
{
    public void Configure(EntityTypeBuilder<Evaluator> builder)
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
            .WithMany(department => department.Evaluators)
            .HasForeignKey(estimator => estimator.DepartmentId);
    }
}