using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITProjectPriceCalculationManager.ITProjectsManager.API.Core.Entities.EvaluatorToEvaluatedFactor;

internal class EvaluatorToEvaluatedFactorConfiguration : IEntityTypeConfiguration<EvaluatorToEvaluatedFactor>
{
    public void Configure(EntityTypeBuilder<EvaluatorToEvaluatedFactor> builder)
    {
        builder
            .HasKey(programsParametr => programsParametr.Id);

        builder
            .HasOne(programsParametr => programsParametr.Evaluator)
            .WithMany(programLanguage => programLanguage.EvaluatorToEvaluatedFactor)
            .HasForeignKey(programsParametr => programsParametr.EvaluatorId);

        builder
            .HasOne(programsParametr => programsParametr.EvaluatedFactor)
            .WithMany(programLanguage => programLanguage.EvaluatorToEvaluatedFactor)
            .HasForeignKey(programsParametr => programsParametr.EvaluatedFactorId);
    }
}