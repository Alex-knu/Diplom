using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ITProjectPriceCalculationManager.EvaluatorManager.API.Core.Entities.Parameters;

internal class ParametersConfiguration : IEntityTypeConfiguration<Parameters>
{
    public void Configure(EntityTypeBuilder<Parameters> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired();

        builder.Property(ep => ep.ApplicationId)
            .IsRequired();
        
        builder
            .HasMany(parameter => parameter.EvaluateParameters)
            .WithOne(evaluateParameter => evaluateParameter.Parameter)
            .HasForeignKey(evaluateParameter => evaluateParameter.ParameterId);
    }
}