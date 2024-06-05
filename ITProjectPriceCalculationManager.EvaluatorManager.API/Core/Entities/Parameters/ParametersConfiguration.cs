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
            .HasOne(p => p.ParameterValue)
            .WithOne(pv => pv.Parameter)
            .HasForeignKey<ParameterValue.ParameterValue>(pv => pv.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}