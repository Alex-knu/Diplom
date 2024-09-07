using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.ApplicationToEvaluator;

internal class ApplicationToEvaluatorConfiguration : IEntityTypeConfiguration<ApplicationToEvaluator>
{
    public void Configure(EntityTypeBuilder<ApplicationToEvaluator> builder)
    {
        builder
            .HasKey(applicationToEvaluators => applicationToEvaluators.Id);

        builder.Property(applicationToEvaluators => applicationToEvaluators.SelfEvaluation);
        
        builder.Property(applicationToEvaluators => applicationToEvaluators.ConfidenceArea);

        builder
            .HasOne(applicationToEvaluators => applicationToEvaluators.Application)
            .WithMany(application => application.ApplicationToEvaluators)
            .HasForeignKey(applicationToEvaluators => applicationToEvaluators.ApplicationId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasOne(applicationToEvaluators => applicationToEvaluators.Evaluator)
            .WithMany(estimator => estimator.ApplicationToEvaluators)
            .HasForeignKey(applicationToEvaluators => applicationToEvaluators.EvaluatorId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}