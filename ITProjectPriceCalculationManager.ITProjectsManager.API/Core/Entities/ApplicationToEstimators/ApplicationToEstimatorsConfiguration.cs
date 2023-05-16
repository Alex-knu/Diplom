using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationToEstimators
{
    internal class ApplicationToEstimatorsConfiguration : IEntityTypeConfiguration<ApplicationToEstimators>
    {
        public void Configure(EntityTypeBuilder<ApplicationToEstimators> builder)
        {
            builder
                   .HasKey(applicationToEstimators => applicationToEstimators.Id);

            builder.Property(applicationToEstimators => applicationToEstimators.SelfEvaluation);

            builder
                .HasOne(applicationToEstimators => applicationToEstimators.Application)
                .WithMany(application => application.ApplicationToEstimators)
                .HasForeignKey(applicationToEstimators => applicationToEstimators.ApplicationId);

            builder
                .HasOne(applicationToEstimators => applicationToEstimators.Estimator)
                .WithMany(estimator => estimator.ApplicationToEstimators)
                .HasForeignKey(applicationToEstimators => applicationToEstimators.EstimatorId);
        }
    }
}